open canopy
open Main

elementTimeout <- 30.0
chromeDir <- __SOURCE_DIRECTORY__
start chrome

SetupUser()

"User Logins in, and sees the main navigation bar" &&& fun _ ->
    url "https://localhost:44336/"
    "#Email_I" << "jstevens@uscarenet.com"
    "#Password_I" << "History12!"
    click "#SetPasswordSubmitImg"
    displayed "#mainNav"

"Verify Patient data" &&& fun _ ->
    click "a[href='/people']"
    "#patientsGridView_DXFREditorcol2_I" << FullName
    press enter
    click "#patientsGridView_tccell0_2 > a"
    click ".btn.btn-sm.btn-success.fa.fa-user"
    "#MiddleId" << "Test"
    click "#SexTypeId"                                         
    click "#ejControl_5_popup > div > ul > li:nth-child(1)"
    click "#LanguageId0_hidden"
    click "#LanguageId0_popup > div.e-content > ul > li:nth-child(2)"
    click "#SubmitId"
    reload()
    "#MiddleId" == "Test"
    "#SexTypeId" == "Male"
    "#LanguageId0_hidden" == "Afar"
    
run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()