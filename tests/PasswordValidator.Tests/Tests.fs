#if INTERACTIVE
#r "../../bin/PasswordValidator.dll"
#r "../../packages/NUnit/lib/nunit.framework.dll"
#r "../../packages/FsCheck/lib/net45/FsCheck.dll"
#load "FsUnit.fs"
#else
module PasswordValidator.SimpleTests
#endif

open FsUnit
open NUnit.Framework
open FsCheck
open PasswordValidator

[<Test>]
let ``Length requirement works on sample input`` () =
  let len = Validators.LengthRequirement
  len.IsSatisfied("test") |> should equal false
  len.IsSatisfied("long test") |> should equal true

[<Test>]
let ``Power validator can combine lengt and digit`` () =
  let reqs = 
    [ Validators.LengthRequirement
      Validators.DigitRequirement ]
  let pow = PowerValidator(reqs)

  pow.IsSatisfied("test1") |> should equal false
  pow.IsSatisfied("long test") |> should equal false
  pow.IsSatisfied("long test1") |> should equal true

[<Test>]
let ``Power validator returns false when requirement fails`` () =
  let alwaysFalse = 
    { new IRequirement with
        member x.IsSatisfied(pwd) = false }
  let pow = PowerValidator( [alwaysFalse] )
  pow.IsSatisfied("test1") |> should equal false

[<Test>]
let ``Length requirement requires 8 or more characters`` () = 
  let len = Validators.LengthRequirement
  Check.Quick(fun (s:string) ->
    if s <> null then
      let expected = s.Length >= 8
      let actual = len.IsSatisfied(s) 
      actual |> should equal expected )

[<Test>]
let ``Reversed password is valid when original is valid`` () = 
  let reqs = 
    [ Validators.LengthRequirement
      Validators.DigitRequirement ]
  let pow = PowerValidator(reqs)
  Check.Quick(fun (s:string) ->
    if s <> null then
      let reversed = System.String(Array.rev(s.ToCharArray()))
      pow.IsSatisfied(reversed)
      |> should equal <| pow.IsSatisfied(s) )