module SkillChecking

open canopy

let runSkillChecking =
    let urls = 
        [ "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=c1793f51-1a65-4c09-b2e1-af9753df19e6"
        ; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=fc0dad15-8233-40f1-86d1-ad512eee4778"
        ; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=3d6bb0e8-80c4-41c8-aa47-45618a58b8cf"
        ]
    let mutable i = 0

    many urls.Length (fun _ ->
        url urls.[i]
        displayed "#Skills > div:nth-child(3) > div > div > div > div:nth-child(1) > div.col-xs-14.col-sm-12 > strong"
        let skills = read "#Skills > div:nth-child(3) > div > div > div > div:nth-child(1) > div.col-xs-14.col-sm-12 > strong"
        i <- i + 1
    )