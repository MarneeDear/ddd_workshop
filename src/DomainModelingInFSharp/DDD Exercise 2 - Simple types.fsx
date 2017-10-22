// ================================================
// DDD Exercise: Model some simple types
//
// ================================================

(*
REQUIREMENTS


=== SIMPLE TYPES ===

An OrderId is represented by an integer
A CustomerId is represented by an integer
A UsdMoney is a wrapped decimal
A GpbMoney is a wrapped decimal

=== CONSTRAINED TYPES ===

A String50 is represented by an string that is not null or empty and must be <= 50 chars
An EmailAddress is represented by an string that must contain an "@" char
A WidgetCode is represented by a string that must start with a "W"  
A GizmoCode is represented by a string that must start with a "G"
A ProductCode is either a WidgetCode or a GizmoCode

*)

open System

// ----------------------------------------
// Helper module
// ----------------------------------------
module SimpleTypes =

    type OrderId = OrderId of int
    //type CustomerId = ??  // you take it from here!
    //type UsdMoney = ??
    //type GpbMoney = ??


    type String50 = private String50 of string
    
    module String50module =
        let create (s:string) = 
            if String.IsNullOrEmpty(s) then 
                None               
            else if (s.Length <= 50) then
                Some (String50 s)
            else None

        let value (String50 s) = s

    //type EmailAddress = ??
    type EmailAddress = private EmailAddress of string

    module EmailAddressmodule =
        let create (s:string) =
            if String.IsNullOrEmpty(s) then
                None
            else if (s.Contains("@")) then
                Some (EmailAddress)
            else None
        let value (EmailAddress s) = s
                
    
    //module EmailAddress =
    //    let create (s:string) = ??
    //    let value (EmailAddress s) = ??

    //type WidgetCode = ??
    type WidgetCode = private WidgetCode of string
    
    //module WidgetCode =
    //    let create (s:string) = ??
    //    let value (WidgetCode s) = ??

    //type GizmoCode = ??
    
    //type ProductCode = ??
        
// ----------------------------------------
// Example of how constraints are enforced
// ----------------------------------------

open SimpleTypes 

let s50_Opt = String50 "a" // error

let s50_Opt = String50.create "a" // ok
match s50_Opt with
| Some s50 -> "valid:" + (String50.value s50)
| None -> "invalid"

