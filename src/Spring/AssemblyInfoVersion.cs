#region using

using System;
using System.Reflection;
using System.Runtime.InteropServices;

#endregion


// Info comuni a tutti gli assembly
[assembly: AssemblyCompany("SpringSource")]
[assembly: AssemblyProduct("Spring.NET Framework 3.0.0")]
[assembly: AssemblyCopyright("Copyright 2002-2018 Spring.NET Framework Team.")]

// Aggiornati in base a tag e repository Git
[assembly: AssemblyTrademark("Git 3.0 - 2020/03/25 15:25:11 - 3.0 - https://github.com/rpaterlini/spring-net.git - ")]
[assembly: AssemblyFileVersion("3.0.0")]
[assembly: AssemblyVersion("3.0.0")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: ComVisible(false)]
[assembly: AssemblyCulture("")]
