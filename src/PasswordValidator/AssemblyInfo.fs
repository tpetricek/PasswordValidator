namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("PasswordValidator")>]
[<assembly: AssemblyProductAttribute("PasswordValidator")>]
[<assembly: AssemblyDescriptionAttribute("Simple password validator")>]
[<assembly: AssemblyVersionAttribute("1.2")>]
[<assembly: AssemblyFileVersionAttribute("1.2")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.2"
