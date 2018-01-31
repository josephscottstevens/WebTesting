module SkillChecking

open canopy
open System
open Main

let runSkillChecking =
    
    let urls = 
        [ "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=fc0dad15-8233-40f1-86d1-ad512eee4778"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=c1793f51-1a65-4c09-b2e1-af9753df19e6"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=ff295baf-1caa-40e2-bf98-5d40f2d75688"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=bef83ea9-bddc-4154-9688-09a5f7c17b31"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=8418a361-436d-4eb2-9c95-3df1e948890c"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=fb1876a0-1dfd-403b-9952-2df415c94ff9"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=eac07dd1-b0a7-4784-8eec-c64514e5b4d1"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=449e599d-60ae-4ff8-a39f-fcb612e0585f"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=f8c32c53-4e27-4dad-95ac-0741e875ed05"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=8851263f-25c2-489b-993d-f96b8c95f79e"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=26650c95-821a-4b1e-b05c-d8b7aaa11d3f"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=5da26805-84d8-4800-9d38-0e0fd59d25ec"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=3d6bb0e8-80c4-41c8-aa47-45618a58b8cf"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=5cda0ab1-75ee-4caa-ac25-114ca03ff15c"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=8e41a950-5abc-4fc7-9d06-08d56ef6b18b"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=8b63a014-e0cc-4cea-bbaa-18690348fd7b"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=9f6dff77-f161-4775-a9a0-c4a105d6fef1"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=0076263b-477a-4fdb-892c-800889402072"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=217fa69b-1be5-4b24-8e8d-304ec5c72466"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=75a9cf6d-a47c-4b43-912d-5b72ee3c1bcb"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=cb1ec146-e79c-494a-b537-7af7f91ac626"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=e8aec87b-7494-4ee6-a592-435ad195ead2"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=4746edda-4357-4f30-84d1-3ea972c8620c"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=6d935dac-bce7-4eb5-a9c7-175798798893"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=0911ca08-ba4c-4bf0-b9f1-7a1fd17b5a05"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=086b5515-5ee8-433b-b896-8dd6ab79f0cb"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=1a4f73c3-922c-4b57-9ded-fb83388c03a8"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=54c19bbe-f294-42a6-b342-de14d41896bd"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=ecc28d67-d679-42b7-8594-997e08c328d0"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=8fd506f2-7cf5-4818-b5cc-16385c57d1e0"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=92070fff-3a66-48b8-9ee0-5991941e6f84"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=7ead65ae-8eca-40b1-b8b9-dd19352e6e1e"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=239cd954-ad8f-45ac-9aea-b926243aa687"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=ba142215-ffe5-43ad-98c6-c4e0659fca79"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=2193bd84-323f-4321-b156-f360cb94ba66"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=67187766-e32f-4681-8d86-92b4ba14501e"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=61c915b5-88fd-4c6f-90e4-7951014641a5"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=65ec235b-854c-4cda-af48-495567513950"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=6edf2ef7-53c2-4632-b987-de172e78ef25"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=261e7f09-dcc7-4f0c-834d-787394039bae"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=44be6279-d3af-4d4e-9521-447369b8fcb4"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=777cff36-249d-418c-bdba-deb5a7e1db09"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=5dbe87c5-7899-468e-93ec-a39e279c3932"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=91dfb449-ee54-4d9f-a6bb-863e842f871f"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=c38ebdf0-c4a8-4aef-80b2-035f15dd8e9e"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=02ada184-f200-4620-8742-7a973bdfad92"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=dc8144fc-ebba-4ee6-afda-1e8e578a3694"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=4301685a-de7f-421d-8e69-c0e789485c22"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=47502e35-bf9e-49e0-ae71-798ea2eafd74"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=f1c854ec-4994-4b08-a2d6-2c908bee1193"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=6d64653c-4ea3-436c-b511-6148efe3fce1"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=ff57d10a-5c7a-4e58-9062-7ac0ca13929b"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=584d2d12-ef1c-4652-b133-d061993ba961"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=46268eea-9c78-4269-a941-3d67a6da55a6"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=f99c5fa8-edef-4954-8b76-9ec78e76891a"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=65dfcd34-52a3-414b-b4f3-c9c1c8c4fd9e"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=875a3294-ddcd-41b4-9eaf-4d2a364a2eab"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=842ff2a4-72b2-4d76-bb5e-4a327da5f64f"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=55389c5d-4683-42f1-8015-2eb1aadc4fbb"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=c89713ce-5ded-4a56-8554-fca9463514cd"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=a92c35cb-45f7-4793-8531-4e04b9da74a4"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=45e6a5e6-b2c1-49fd-81dc-f10591f33813"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=ce775894-2d45-4cf8-b1dd-4d28a7a2b5e4"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=dc4e03ca-db3b-4e23-ad94-cec9a7d0d929"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=71ddf6d6-24da-493d-85f9-8965a812dcdf"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=29afc372-924e-41c4-a928-c1a87cb56d69"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=128cbe24-547a-4757-b0d0-52faae9f7a76"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=05b0e397-59eb-4fda-96f4-ccbb613d97dd"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=e84c127e-f830-4d4d-8fe6-3fd35d02649f"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=55dbfbd5-42d5-4d42-b52c-9095e7384c1a"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=0db09118-f1d7-4495-b59a-a53e0442e9ab"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=708ab80e-f30a-474d-9efb-48daf4d8c0c4"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=59f82aed-0101-4b9f-a64b-eb4e4a2be8d6"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=ff35ac09-2941-4596-9988-ec1c8aefa4bb"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=691a35c4-efbc-4121-a18c-252811e23244"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=74818b27-6bec-4ae6-a6e8-2e82545b9a28"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=3e818368-8c40-4fa8-8747-e1d45e1188d1"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=8e5d8a3f-25fd-4d95-9e1f-95ba907d0176"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=053fd445-3781-4773-87c0-c3ff09e252b3"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=1c4ca406-4cd3-45eb-a27f-a0a53642b573"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=fe40429e-7760-455a-95f6-dc8a069ff15c"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=7d6d84c1-ed74-41cb-a374-9a679c344d8f"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=80bda710-4841-4b32-9a6b-25db6ba9c83a"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=cd66065a-5fab-49ce-bb54-4df88cf98877"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=4fe72132-4b64-4e4c-822b-e0b0dcf40d87"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=f1ed564b-f3bc-4bee-b430-624dd0570762"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=0463619e-47df-48dd-afa5-54daafc69ba5"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=c8f86b5b-071e-4f60-a9d4-ad88783e20da"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=0f74b3d6-2a89-479e-864e-f1b7e6482d1c"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=63b81f38-1153-4eb7-88ae-b3a8ae760061"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=005b92c5-47ec-4caf-96fa-5a6d5d0478c0"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=0df8c4a6-ab0f-4a62-a066-f06ff38297b6"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=3281b3c5-9692-4bd4-99e6-ea43d8f7b63b"
; "https://recruiting.ultipro.com/CAR1037/JobBoard/f0c16bb3-7879-3406-ff38-bfdd3e3afea8/OpportunityDetail?opportunityId=054f097c-946d-412e-b136-b7e66e7223e2"

        ]
    let mutable i = 0
    let mutable skills = []
    let mutable skillsAndUrls = []
    // urls.Length
    many 4 (fun _ ->
        url urls.[i]
        let skill = 
            try 
                read "#Skills > div:nth-child(3) > div > div > div > div:nth-child(1) > div.col-xs-14.col-sm-12 > strong"
            with _ ->
                ""
        if skill <> "Home Health Aide, Personal Care Aide" then
            skills <- skill :: skills
        //skillsAndUrls <- (urls.[i], skill) :: skillsAndUrls
        
        i <- i + 1
    )

    lastly (fun _ ->
        let somePatient = ctxTest4.Ptn.Patients.Individuals.``100``
        Console.WriteLine(skills)
        Console.WriteLine(skillsAndUrls)
        ()
    )
