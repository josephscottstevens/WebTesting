open canopy
open Main

let UserName = SetupUser()

//elementTimeout <- 30.0
chromeDir <- __SOURCE_DIRECTORY__
start chrome

"User Logins in, and sees the main navigation bar" &&& fun _ ->
    url "https://localhost:44336/"
    "#Email_I" << "jstevens@uscarenet.com"
    "#Password_I" << "History12!"
    click "#SetPasswordSubmitImg"
    displayed "#mainNav"

// It would be nice to test that validation is working as well
// TODO: change Provider and Sex type to have Id's just like Language does
"Verify Patient data" &&& fun _ ->
    click "a[href='/people']"
    "#patientsGridView_DXFREditorcol2_I" << UserName
    press enter
    click "#patientsGridView_tccell0_2 > a"
    click ".btn.btn-sm.btn-success.fa.fa-user"
    "#MiddleId" << "Test"
    "#SSNId" << "000112222"
    "#DateOfBirth" << "10/27/1988"
    click "#MainProviderId"
    click "#ejControl_3_popup > div > ul > li > span"
    click "#SexTypeId"                                         
    click "#ejControl_7_popup > div > ul > li:nth-child(1)"
    click "#LanguageId0_hidden"
    click "#LanguageId0_popup > div.e-content > ul > li:nth-child(2)"
    click "#SubmitId"
    reload()
    "#MiddleId" == "Test"
    "#SexTypeId" == "Male"
    "#LanguageId0_hidden" == "Afar"
    "#MainProviderId" == "Brown, Rush"
run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()