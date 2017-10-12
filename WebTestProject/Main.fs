module Main
open FSharp.Data.Sql

let [<Literal>] ConnectionString = "Data Source=localhost;Initial Catalog=NavcareDB_interface;Integrated Security=True; "
type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>

let newUserName = "TestUser@uscarenet.com"
let newUserId = System.Guid.NewGuid().ToString()


// TODO: Switch over to hardCoded UserId, so we can more reliably delete test data
let CleanupExistingUser =
    let ctx = Sql.GetDataContext()
    let maybeUser = ctx.Dbo.AspNetUsers |> Seq.where (fun t-> t.UserName = newUserName) |> Seq.tryHead
    if maybeUser.IsSome then 
        let usrId = maybeUser.Value.Id
        let maybePatient = ctx.Ptn.Patients |> Seq.where (fun t-> t.UserId = usrId) |> Seq.tryHead
        if maybePatient.IsSome then
            let maybeTask = ctx.Tsk.Tasks |> Seq.where(fun t -> t.PatientId = maybePatient.Value.Id) |> Seq.tryHead
            if maybeTask.IsSome then
                maybeTask.Value.Delete()
                ctx.SubmitUpdates()
            let maybeProvider = ctx.Ptn.ProvidersPatientsMap |> Seq.where(fun t -> t.PatientId = Some maybePatient.Value.Id) |> Seq.tryHead
            if maybeProvider.IsSome then
                maybeProvider.Value.Delete()
                ctx.SubmitUpdates()
            let autoHistory = ctx.Tsk.AutomatedTasksTriggerHistory |> Seq.where(fun t -> t.PatientId = maybePatient.Value.Id) |> Seq.tryHead
            if autoHistory.IsSome then
                autoHistory.Value.Delete()
                ctx.SubmitUpdates()
            maybePatient.Value.Delete()
            ctx.SubmitUpdates()
        maybeUser.Value.Delete()
        ctx.SubmitUpdates()
    ignore

// Note, need to disable trigger on ptn.Patient
// Note, need to disable trigger on ptn.ProvidersPatientsMap
let SetupUser _ =
    CleanupExistingUser()
    let ctx = Sql.GetDataContext()
    let usr = ctx.Dbo.AspNetUsers.``Create(AccessFailedCount, CanAddManualTime, EmailConfirmed, IsBillable, IsOnCall, LockoutEnabled, PhoneNumberConfirmed, RegistrationDate, TwoFactorEnabled, UserName)``
                (0, true, true, true, true, false, true, System.DateTime.Now, false, newUserName)
    usr.Id <- newUserId
    usr.PasswordHash <- Some "AAgvTSlzShga1HVDEBJf76Whv2QfsihPA9xeM23UZozf975lVLk+ZcDljC5E1MDu6w=="
    usr.SecurityStamp <- Some "31fc6d9c-6a0a-4009-b93a-712218d6c130"
    usr.FirstName <- Some "Test"
    usr.LastName <- Some "User"

    ctx.Ptn.Patients.``Create(AccountNo, AutoSync, HasAccessToDashboard, HcoId, IsActive, IsCCM, IsEligibleForAWV, IsRemoved, OpenTasksCount, OpenTocsCount, PercentEnrollmentCompleted, UserId)``
                (0, false, 0, 2, 0, true, true, false, 0, 0, 0, newUserId) |> ignore
    ctx.SubmitUpdates()
    let newPtn = ctx.Ptn.Patients |> Seq.where (fun t-> t.UserId = newUserId) |> Seq.head

    let provider = ctx.Ptn.ProvidersPatientsMap.``Create(IsMainProvider)``(true)
    provider.PatientId <- Some newPtn.Id
    provider.ProviderId <- Some 2375
    ctx.SubmitUpdates()
    
    "User, Test"