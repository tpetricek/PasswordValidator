namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("PasswordValidator")>]
[<assembly: AssemblyProductAttribute("PasswordValidator")>]
[<assembly: AssemblyDescriptionAttribute("Simple password validator")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
