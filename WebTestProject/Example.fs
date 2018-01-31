module Example

open canopy
open System
open Main

let runExample =
    "Data is set properly" &&& fun _ ->
        url "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=3d6bb0e8-80c4-41c8-aa47-45618a58b8cf"
        displayed "#Skills > div:nth-child(3) > div > div > div > div:nth-child(1) > div.col-xs-14.col-sm-12 > strong"
    
    lastly (fun _ ->
        Console.WriteLine("Done!")
        ()
    )