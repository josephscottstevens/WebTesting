module SkillChecking

open Main
open canopy
open System
open System.IO
open FSharp.Data

let runSkillChecking =
    let opportunities = new CsvProvider<"R:\IT\CognautoFiles\Output\Opportunities", HasHeaders=false>()
    let urls = opportunities.Rows |> Seq.toArray

    let mutable i = 0
    let mutable skills = []

    before (fun _ -> 
        let ctx = SqlTest4.GetDataContext()
        let newUrl = ctx.Dbo.HrOpportunityUrls.Create() 
        newUrl.OpportunityNumber <- "Test"
        newUrl.OpportunityUrl <- Some"Test"   //optional field
        ctx.SubmitUpdates()

    )

    many urls.Length (fun _ ->
        url urls.[i].Column2
        let skill = someElement "#Skills > div:nth-child(3) > div > div > div > div:nth-child(1) > div.col-xs-14.col-sm-12 > strong"
         
        if skill.IsSome && skill.Value.GetCssValue("Display") = "none" then
            skills <- (urls.[i].Column1, urls.[i].Column2) :: skills
        else if skill.IsNone then
            skills <- (urls.[i].Column1, urls.[i].Column2) :: skills
        else if skill.IsSome && skill.Value.GetCssValue("Display") <> "none" && skill.Value.Text <> "Home Health Aide, Personal Care Aide" then 
            skills <- (urls.[i].Column1, urls.[i].Column2) :: skills
        i <- i + 1
    )

    lastly (fun _ ->
        let allRows = 
            skills
            |> List.map (fun (t, y) -> t + "," + y)
            |> List.reduce(fun t y -> t + "\n" + y) 
        
        File.WriteAllText("C:\Cognauto\Automation Output\Ultiprofiles\OpportunitiesOutput.csv", allRows)
    )
    