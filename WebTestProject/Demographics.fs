module Demographics

open canopy

let runDemographics =

    pin FullScreen

    let email = "jstevens@uscarenet.com"
    let password = "History12!"

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

    "Verify Required Fields" &&& fun _ ->
        js """document.getElementById("mainFooter").remove()""" |> ignore
        clear "SSNId"
        click "#SaveId"
