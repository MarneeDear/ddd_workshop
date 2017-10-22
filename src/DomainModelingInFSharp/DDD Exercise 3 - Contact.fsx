// ================================================
// DDD Exercise: Model a Contact management system
//
// ================================================

(*
REQUIREMENTS

The Contact management system stores Contacts

A Contact has 
* a personal name
* an optional email address
* an optional postal address
* Rule: a contact must have an email or a postal address

A Personal Name consists of a first name, middle initial, last name
* Rule: the first name and last name are required
* Rule: the middle initial is optional
* Rule: the first name and last name must not be more than 50 chars
* Rule: the middle initial is exactly 1 char, if present

A postal address consists of a four address fields plus a country

Rule: An Email Address can be verified or unverified

*)



// ----------------------------------------
// Helper module
// ----------------------------------------
open System
module SimpleTypes =

    type String1 = String1 of string // you take it from here!
    module String1mod =
        let create (s:string) =
            if (String.IsNullOrEmpty(s)) then
                None
            else if (s.Length <= 1) then
                Some (String1 s)
            else
                None
        let value (String1 s) = s

    type String50 = String50 of string

    module String50mod = 
        let create (s:string) =
            if (String.IsNullOrEmpty(s)) then
                None
            else if (s.Length <= 50) then
                Some (String1 s)
            else
                None
        let value (String50 s) = s


    type EmailAddress = private EmailAddress of string
    
    module EmailAddressMod =
        let create (s:string) = 
            if String.IsNullOrEmpty(s) then 
                None               
            else if s.Contains("@") then
                Some (EmailAddress s)
            else None

        let value (EmailAddress s) = s

// ----------------------------------------
// Main domain code
// ----------------------------------------

open SimpleTypes 

// this is what we DON'T want to do!
type BadContactDesign = {

  FirstName: string
  MiddleInitial: string
  LastName: string

  EmailAddress: string
  IsEmailVerified: bool 
  }

type PersonalName =     
    {
        FirstName : String50
        MiddleInitial : String1 option
        LastName: String50
    }

type VerifiedEmail =
    VerifiedEmail of EmailAddress

type PostalAddress =
    {
        
    }

type ContactInfo =
    {
        EmailAddress : EmailAddress option
        PostalAddress: PostalAddress option
    }


type Contact =  // you take it from here!
    {
        Name : PersonalName
    }
