open canopy
open runner
open FSharp.Data.Sql


chromeDir <- __SOURCE_DIRECTORY__
start chrome

"User Logins in, and sees the main navigation bar" &&& fun _ ->
    url "https://localhost:44336/"
    "#Email_I" << "jstevens@uscarenet.com"
    "#Password_I" << "History12!"
    click "#SetPasswordSubmitImg"
    displayed "#mainNav"

"Verify Patient First Name, Last Name, and Gender exist and are set" &&& fun _ ->
    click "a[href='/people']"
    "#patientsGridView_DXFREditorcol2_I" << "stevens, joseph"
    press enter
    click "#patient_link_1"
    click "#PopupPacient_1_PWC-1 > div > button > span"
    click "#ejControl_3_hidden"                                         
    click "#ejControl_3_popup > div.e-content > ul > li:nth-child(1)"
    click "#ejControl_5_hidden"
    click "#ejControl_5_popup > div > ul > li:nth-child(1)"
    click "#SubmitId"
    "#FirstId" == "Joseph"
    "#LastId" == "Stevens"
    "#ejControl_3_hidden" == "1st Lt"
    "#ejControl_5_hidden" == "Male"

run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()