﻿open canopy

let email = "example@uscarenet.com"
let password = "Password123!"

chromeDir <- __SOURCE_DIRECTORY__
start chrome
pin FullScreen

"User Logins in, and sees the main navigation bar" &&& fun _ ->
    url "https://localhost:44336/people/?patientId=6174"
    "#Email_I" << email
    "#Password_I" << password
    click "#SetPasswordSubmitImg"
    displayed "#mainNav"

"Verify Patient data" &&& fun _ ->
    js """document.getElementById("mainFooter").remove()""" |> ignore
    "#MiddleNameId" << "Test"
    "#DateofBirthId" << "10/27/1988"
    click "#SaveId"
    reload()
    "#MiddleNameId" == "Test"
    "#DateofBirthId" == "10/27/1988"
run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()