open canopy
open FSharp.Data.Sql

chromeDir <- __SOURCE_DIRECTORY__
start chrome

pin FullScreen

let email = "jstevens@uscarenet.com"
let password = "History12!"
let [<Literal>] ConnectionString = "Data Source=navsql;Initial Catalog=NavcareDB_Test4;Integrated Security=True; "
type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>

let ctx = Sql.GetDataContext()



"User Logins in, and sees the main navigation bar" &&& fun _ ->
    url "https://test4.navcare.com/people/?patientId=6174"
    "#Email_I" << email
    "#Password_I" << password
    click "#SetPasswordSubmitImg"
    displayed "#mainNav"

"Verify Patient data" &&& fun _ ->
    js """document.getElementById("mainFooter").remove()""" |> ignore
    "#MiddleNameId" << "Test"
    "#DateofBirthId" << "10/27/1988"
    click "input.btn.btn-sm.btn-success"
    reload()
    "#MiddleNameId" == "Test"
    "#DateofBirthId" == "10/27/1988"

run()
System.Console.WriteLine("Press any key to continue")
System.Console.ReadLine() |> ignore
quit()

[<EntryPoint>]
let main argv = 
    0 // done