namespace PasswordValidator

/// Defines a password requirement
type IRequirement = 
  /// Returns true if the password is OK
  abstract IsSatisfied : string -> bool  
  
/// The `Validators` module provides access to the individual
/// password validators. Those can be used to check simple 
/// password conditions, including the following:
///
///  - **Length** - check that password is at least 8 characters
///  - **Digits** - check that password contains a digit
///  - **Upper case** - check that password includes upper case letters
///
module Validators =
  /// Checks length
  let LengthRequirement = 
    { new IRequirement with
        member x.IsSatisfied(password) = 
          password.Length >= 8 }

  /// Checks digits
  let DigitRequirement =
    { new IRequirement with
        member x.IsSatisfied(password) = 
          password 
          |> Seq.exists System.Char.IsDigit }
  
  /// Checks length
  let UpperCaseRequirement =
    { new IRequirement with
        member x.IsSatisfied(password) = 
          password 
          |> Seq.exists System.Char.IsUpper }

/// Checks lots of stuff
type PowerValidator(requirements:seq<IRequirement>) = 
  member x.IsSatisfied(password) =
    requirements 
    |> Seq.forall (fun x -> x.IsSatisfied password)