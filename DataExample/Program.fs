open FSharp.Data.Sql
open XPlot.GoogleCharts

let [<Literal>] ConnectionString = "Data Source=navsql;Initial Catalog=NavcareDB_Test4;Integrated Security=True; "
type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>

let ctx = Sql.GetDataContext()

[<EntryPoint>]
let main _ = 


    ctx.Ptn.PatientDemographics
    |> Seq.where (fun t-> t.Race.IsSome)
    |> Seq.map(fun t-> t.Race.Value)
    |> Seq.countBy (fun t -> t)
    |> Seq.sortByDescending snd
    |> Seq.take 5
    |> Chart.Column
    |> Chart.WithTitle "Most common Race\Ethnicity"
    |> Chart.Show


    ctx.Ptn.PatientDemographics
    |> Seq.where (fun t-> t.MaritalStatus.IsSome)
    |> Seq.map (fun t-> t.MaritalStatus.Value)
    |> Seq.countBy (fun t-> t)
    |> Seq.sortByDescending snd
    |> Seq.take 5
    |> Chart.Pie
    |> Chart.WithTitle "Most common marital status"
    |> Chart.Show


    0 // done
