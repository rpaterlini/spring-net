///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument<string>("target", "Default");
var configuration = Argument<string>("configuration", "Debug");

///////////////////////////////////////////////////////////////////////////////
// AddIn
///////////////////////////////////////////////////////////////////////////////

 // #addin nuget:?package=Cake.NPM&version=0.17.0
// #tool "nuget:?package=NUnit.ConsoleRunner&version=3.10.0"

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////


var rootPath = MakeAbsolute(Directory("."));
var buildPath = rootPath.Combine(new DirectoryPath("./build"));


///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup((ctx) =>
{
    // Executed BEFORE the first task.
    Information( "Running tasks:");
    Information( $" From {rootPath.FullPath}" );
    Information( $" To {binPath.FullPath}" );
    Information( $" Configuration {configuration}" );
    Information( $" Deploy {deployPath}" );
});

Teardown((ctx) =>
{
    // Executed AFTER the last task.
    Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Description("Cleans all directories that are used during the build process.")
    .Does(() =>
{
    // Clean solution directories.
	
	var allCsProjPaths = new string[]{"src","test"}
		.Select(dir => $"./{dir}/**/*.csproj")
		.SelectMany(dir => GetFiles(dir))
		.Select(proj => proj.GetDirectory())
		.ToArray();
			

	
    foreach(var path in allCsProjPaths) {
        Information( $"Cleaning {path}" );
        DelDir(path + "/bin");
        DelDir(path + "/obj");
    }
	
    Information( $"Cleaning build" );
	DelDir("build");
});

void DelDir(string path) {
	var ds = new DeleteDirectorySettings {
		Recursive = true,
		Force = true
	};	
	
	if(DirectoryExists(path)){
		DeleteDirectory(path, ds);
	}
}

Task("FullClean")
    .Description("Cleans all directories that are used during the build process.")
	.IsDependentOn("Clean")
    .Does(() =>
{
	var packagesPath = rootPath.Combine(new DirectoryPath("./packages"));
	Information( $"Cleaning {packagesPath}" );
	CleanDirectory(packagesPath);
});


Task("Restore")
    .Description("Restores all the NuGet packages that are used by the specified solution.")
    .Does(() =>
{
    
	Information( $"Restoring nuget for Spring.Net.sln." );

	var setting = new ProcessSettings{ 
		Arguments = $"restore Spring.Net.sln" 
	};
	using(var process = StartAndReturnProcess("Tools/nuget.exe", setting)) {
		process.WaitForExit();
		if(process.GetExitCode()!=0) {
			throw new Exception("nuget failed"); 
		}
	}
    
});


Task("Build")
    .Description("Builds all the different parts of the project.")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("SubGitRev")
    .Does(() =>
{
 	Information( $"Building Spring.Net.sln" );
	MSBuild("Spring.Net.sln", settings => {
		settings
			.SetMaxCpuCount(0)
			.SetPlatformTarget(PlatformTarget.MSIL)
			.SetVerbosity(Verbosity.Minimal)
			.UseToolVersion(MSBuildToolVersion.VS2019)
			.WithTarget("Build")
			.SetConfiguration(configuration);
		}
	);
});


Task("SubGitRev")
    .Description("Esegue SubGitRev.")
    .Does(() =>
{
	if(configuration.ToLower() == "release") {
		var setting = new ProcessSettings{ 
			Arguments = "info -r . -s src/Spring/AssemblyInfoVersion.cs.wcrev -d src/Spring/AssemblyInfoVersion.cs" 
		};
		RunSubGitRev(setting);
	}
});

void RunSubGitRev(ProcessSettings setting) {
	using(var process = StartAndReturnProcess("./build-support/SubGitRev/SubGitRev.exe", setting))
	{
		process.WaitForExit();
		if(process.GetExitCode()!=0) {
			throw new Exception("SubGitRev failed"); 
		}
	}
}



Task("Deploy")
    .Description("Genera tutto in ./build/deploy per il rilascio.")
    .IsDependentOn("Build")
    .Does(() =>
{
	var to = "build/deployDebug";
	if(configuration.ToLower() == "release") {
		to = "build/deployRelease";
	}
	EnsureDirectoryExists(to);
	
	CopyFiles( $"build/{configuration}/Spring.Aop/netstandard2.0/Spring.Aop*.*" ,to);
	CopyFiles( $"build/{configuration}/Spring.Core/netstandard2.0/Spring.Core*.*" ,to);
	CopyFiles( $"build/{configuration}/Spring.Data/netstandard2.0/Spring.Data*.*" ,to);
	CopyFiles( $"build/{configuration}/Spring.Data.NHibernate5/netstandard2.0/Spring.Data.NHibernate5*.*" ,to);
	DeleteFile(to + "/Spring.Data.NHibernate5.dll.config");
	CopyFiles( $"build/{configuration}/Spring.Scheduling.Quartz3/netstandard2.0/Spring.Scheduling.Quartz3*.*" ,to);
	CopyFiles( $"build/{configuration}/Spring.Testing.NUnit/netstandard2.0/Spring.Testing.NUnit*.*" ,to);

	CopyFiles( $"build/{configuration}/Spring.Services/net452/Spring.Services*.*" ,to);
});




///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);