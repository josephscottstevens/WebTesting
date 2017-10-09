module Main
open FSharp.Data.Sql

let [<Literal>] ConnectionString = "Data Source=localhost;Initial Catalog=NavcareDB_interface;Integrated Security=True; "
type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>
let ctx = Sql.GetDataContext()

let patientId = 6666
let usr, ptn = 
    query {
        for usr in ctx.Dbo.AspNetUsers do
        for ptn in usr.``ptn.Patients by Id`` do
        where (ptn.Id = patientId)
        where (usr.NameComputed.IsSome)
        select (usr, ptn)
        exactlyOne
    }

let dem = ctx.Ptn.PatientDemographics |> Seq.where (fun t-> t.PatientId = patientId) |> Seq.tryHead

let FullName = usr.NameComputed.Value

let SetupUser _ =
    ctx.Dbo.PatientLanguagesMap 
    |> Seq.where(fun t-> t.PatientId = patientId) 
    |> Seq.toList 
    |> List.map(fun t-> t.Delete()) 
    |> ignore

    if dem.IsSome then
        dem.Value.Delete()
        ctx.SubmitUpdates()