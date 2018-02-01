module SkillChecking

open canopy
open System
open Main
open FSharp.Data
open System.IO

type Opportunities = CsvProvider<"C:\Cognauto\Automation Output\Ultiprofiles\Opportunities.csv">

let runSkillChecking =
    let opportunities = Opportunities.Load("C:\Cognauto\Automation Output\Ultiprofiles\Opportunities.csv")
    let urls = opportunities.Rows |> Seq.toArray

    let mutable i = 0
    let mutable skills = []

    many urls.Length (fun _ ->
        url urls.[i].``Https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=fc0dad15-8233-40f1-86d1-ad512eee4778``
        let skill = someElement "#Skills > div:nth-child(3) > div > div > div > div:nth-child(1) > div.col-xs-14.col-sm-12 > strong"
         
        if skill.IsSome && skill.Value.GetCssValue("Display") = "none" then
            skills <- urls.[i].CHRON01600 :: skills
        else if skill.IsNone then
            skills <- urls.[i].CHRON01600 :: skills
        else if skill.IsSome && skill.Value.GetCssValue("Display") <> "none" && skill.Value.Text = "Home Health Aide, Personal Care Aide" then 
            skills <- urls.[i].CHRON01600 :: skills
        i <- i + 1
    )

    lastly (fun _ ->
        let allRows = List.reduce(fun t y -> t + "\n" + y) skills
        
        File.WriteAllText("C:\Cognauto\Automation Output\Ultiprofiles\OpportunitiesOutput.csv", allRows)
    )
    