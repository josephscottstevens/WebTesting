﻿// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
let message = new System.Net.Mail.MailMessage()
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code