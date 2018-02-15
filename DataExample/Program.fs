open FSharp.Data.Sql
open XPlot.GoogleCharts

let [<Literal>] ConnectionString = "Data Source=localhost;Initial Catalog=NavcareDB_interface2;Integrated Security=True; "
type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>
let ctx = Sql.GetDataContext()

[<EntryPoint>]
let main _ = 

    let beginningOfMonth = new System.DateTime(2018, 1, 1)
    ctx.Tsk.Tasks
    |> Seq.map (fun t -> 
                        match t.IsComplete with 
                        | true ->
                            match t.FinishTime with 
                            | Some finishTime -> 
                                if finishTime.Date >= beginningOfMonth then
                                    "Completed"
                                else
                                    "NotRelevant"
                            | None ->
                                "ErrorData"
                        | false ->
                            if t.DueTime.Date < beginningOfMonth then
                                "PastDue"
                            else
                                "Open"
    )
    |> Seq.where (fun t -> t <> "NotRelevant")
    |> Seq.countBy (fun t -> t)
    |> Seq.toList
    |> Chart.Pie
    |> Chart.Show

    //ctx.Ptn.PatientDemographics
    //|> Seq.where (fun t-> t.Race.IsSome)
    //|> Seq.map(fun t-> t.Race.Value)
    //|> Seq.countBy (fun t -> t)
    //|> Seq.sortByDescending snd
    //|> Seq.take 5 
    //|> Chart.Column
    //|> Chart.WithTitle "Most common Race\Ethnicity"
    //|> Chart.Show

    0 // done