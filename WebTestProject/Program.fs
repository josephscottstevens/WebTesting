open canopy
open Main
open OpenQA.Selenium

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
    click (first ".btn.btn-sm.btn-success.fa.fa-user")
    "#MiddleId" << "Test"
    click "#SexTypeId"                                         
    click "#ejControl_5_popup > div > ul > li:nth-child(1)"
    click "#SexualOrientationId"
    click "#ejControl_6_popup > div.e-content > ul > li:nth-child(2)"

    click "#SubmitId"

    notDisplayed "#alertMessage"

    click "#PatientLanguagesMap0_hidden"
    click "#PatientLanguagesMap0_popup > div.e-content > ul > li:nth-child(1)"

    click "#SubmitId"

    press Keys.F5
    
    "#MiddleId" == "Test"
    "#SexTypeId" == "Male"
    "#SexualOrientationId" == "Straight or heterosexual"
    "#PatientLanguagesMap0_hidden" == "English"
    
run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()