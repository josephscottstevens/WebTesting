﻿open canopy
open FSharp.Data
open FSharp.Data.Sql
open System.Net.WebSockets

//let [<Literal>] ConnectionString = "Data Source=localhost;Initial Catalog=NavcareDB_interface2;Integrated Security=True; "
let [<Literal>] ConnectionString = "Data Source=sql01;Initial Catalog=Hr_Url_Tracking;Integrated Security=True; "
//type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>
type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>

let newUserId = System.Guid.NewGuid().ToString()
let ctx = Sql.GetDataContext()

let opportunities = new CsvProvider<"R:\IT\CognautoFiles\Output\Opportunities", HasHeaders=false>()
let urls = opportunities.Rows |> Seq.toArray
let mutable i = 0
let mutable skills = []

chromeDir <- __SOURCE_DIRECTORY__
start chrome


//urls.Length
many urls.Length (fun _ ->
    let newUrl = urls.[i].Column3
    //let idx = newUrlBefore.IndexOf('?')
    //let newUrl = "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail" + newUrlBefore.[idx..]
         
    url newUrl 
    let skill = someElement "#Skills > div:nth-child(3) > div > div > div > div:nth-child(1) > div.col-xs-14.col-sm-12 > strong"
         
    if skill.IsSome && skill.Value.GetCssValue("Display") = "none" then
        skills <- (urls.[i].Column2, newUrl) :: skills
    else if skill.IsNone then
        skills <- (urls.[i].Column2, newUrl) :: skills
    else if skill.IsSome && skill.Value.GetCssValue("Display") <> "none" && skill.Value.Text <> "Home Health Aide, Personal Care Aide" then 
        skills <- (urls.[i].Column2, newUrl) :: skills
    i <- i + 1
)

lastly (fun _ ->
    let ctx = Sql.GetDataContext()

    // Delete all rows in table
    ctx.Dbo.HrOpportunityUrls
    |> Seq.toList
    |> List.map (fun t -> 
        t.Delete()
        ctx.SubmitUpdates()
    )
    |> ignore
            

    // Insert new rows
    skills
    |> List.map (fun (t,y ) -> 
        let newUrl = ctx.Dbo.HrOpportunityUrls.Create() 
        newUrl.OpportunityNumber <- t
        newUrl.OpportunityUrl <- Some y   //optional field
        ctx.SubmitUpdates()
    )
    |> ignore
    
    //let allRows = 
        //skills
        //|> List.map (fun (t, y) -> t + "," + y)
        //|> List.reduce(fun t y -> t + "\n" + y) 

        

    //System.IO.File.WriteAllText("C:\Cognauto\Automation Output\Ultiprofiles\OpportunitiesOutput.csv", allRows)
)
    
run()
System.Console.WriteLine("Press any key to continue")
System.Console.ReadLine() |> ignore
quit()