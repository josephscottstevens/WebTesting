module Main
open FSharp.Data.Sql

let [<Literal>] ConnectionString = "Data Source=localhost;Initial Catalog=NavcareDB_interface;Integrated Security=True; "
type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>

let newUserId = System.Guid.NewGuid().ToString()

let SetupUser _ =
    let ctx = Sql.GetDataContext()
    let maybeUser = ctx.Dbo.AspNetUsers |> Seq.where (fun t-> t.UserName = "TestUser@uscarenet.com") |> Seq.tryHead
    if maybeUser.IsSome then 
        let usrId = maybeUser.Value.Id
        let maybePatient = ctx.Ptn.Patients |> Seq.where (fun t-> t.UserId = usrId) |> Seq.tryHead
        if maybePatient.IsSome then
            maybePatient.Value.Delete()
        maybeUser.Value.Delete()
    ctx.SubmitUpdates()
    let usr = ctx.Dbo.AspNetUsers.``Create(AccessFailedCount, CanAddManualTime, EmailConfirmed, IsBillable, IsOnCall, LockoutEnabled, PhoneNumberConfirmed, RegistrationDate, TwoFactorEnabled, UserName)``
                (0, true, true, true, true, false, true, System.DateTime.Now, false, "TestUser@uscarenet.com")
    usr.Id <- newUserId
    usr.PasswordHash <- Some "AAgvTSlzShga1HVDEBJf76Whv2QfsihPA9xeM23UZozf975lVLk+ZcDljC5E1MDu6w=="
    usr.SecurityStamp <- Some "31fc6d9c-6a0a-4009-b93a-712218d6c130"
    usr.FirstName <- Some "Test"
    usr.LastName <- Some "User"

    ctx.Ptn.Patients.``Create(AccountNo, AutoSync, HasAccessToDashboard, HcoId, IsActive, IsCCM, IsEligibleForAWV, IsRemoved, OpenTasksCount, OpenTocsCount, PercentEnrollmentCompleted, UserId)``
                (0, false, 0, 2, 0, true, true, false, 0, 0, 0, newUserId) |> ignore
    ctx.SubmitUpdates()
    
    "User, Test"