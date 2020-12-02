#region using

using System;
using System.Reflection;
using System.Runtime.InteropServices;

#endregion


// Info comuni a tutti gli assembly
[assembly: AssemblyCompany("SpringSource")]
[assembly: AssemblyProduct("Spring.NET Framework 3.0.0")]
[assembly: AssemblyCopyright("Copyright 2002-2020 Spring.NET Framework Team.")]

// Aggiornati in base a tag e repository Git
[assembly: AssemblyTrademark("Git 3.0.0-11-gebee6ce - 2020/12/02 11:43:25 - Working3 - https://github.com/rpaterlini/spring-net.git - ")]
[assembly: AssemblyFileVersion("3.0.0.11")]
[assembly: AssemblyVersion("3.0.0.0")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: ComVisible(false)]
[assembly: AssemblyCulture("")]
