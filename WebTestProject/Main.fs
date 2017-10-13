module Main
open FSharp.Data.Sql
open System

let [<Literal>] ConnectionString = "Data Source=localhost;Initial Catalog=NavcareDB_interface;Integrated Security=True; "
type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>

let newUserId = System.Guid.NewGuid().ToString()

// Note, need to disable trigger on ptn.Patient
// Note, need to disable trigger on ptn.ProvidersPatientsMap

let SetupProvider _ =
    let ctx = Sql.GetDataContext()
    let newPtn = ctx.Ptn.Patients |> Seq.where (fun t-> t.UserId = newUserId) |> Seq.head
    let provider = ctx.Ptn.ProvidersPatientsMap.``Create(IsMainProvider)``(true)
    provider.PatientId <- Some newPtn.Id
    provider.ProviderId <- Some 2234
    ctx.SubmitUpdates()
    ()

let SetupPatient _ =
    let ctx = Sql.GetDataContext()
    let ptn = ctx.Ptn.Patients.``Create(AccountNo, AutoSync, HasAccessToDashboard, HcoId, IsActive, IsCCM, IsEligibleForAWV, IsRemoved, OpenTasksCount, OpenTocsCount, PercentEnrollmentCompleted, UserId)``
                (0, false, 0, 2, 0, true, true, false, 0, 0, 0, newUserId)
    ctx.SubmitUpdates()
    ()

let SetupUser _ =
    let ctx = Sql.GetDataContext()
    let usr = ctx.Dbo.AspNetUsers.``Create(AccessFailedCount, CanAddManualTime, EmailConfirmed, IsBillable, IsOnCall, LockoutEnabled, PhoneNumberConfirmed, RegistrationDate, TwoFactorEnabled, UserName)``
                (0, true, true, true, true, false, true, System.DateTime.Now, false, newUserId)
    usr.Id <- newUserId
    usr.PasswordHash <- Some "AAgvTSlzShga1HVDEBJf76Whv2QfsihPA9xeM23UZozf975lVLk+ZcDljC5E1MDu6w=="
    usr.SecurityStamp <- Some "31fc6d9c-6a0a-4009-b93a-712218d6c130"
    usr.FirstName <- Some "Test"
    usr.LastName <- Some "User"
    ctx.SubmitUpdates()
    

let CleanUpUser _ =
    let ctx = Sql.GetDataContext()
    match ctx.Ptn.Patients |> Seq.where(fun t-> t.UserId = newUserId) |> Seq.tryHead with
    | Some ptn ->
        match ctx.Ptn.ProvidersPatientsMap |> Seq.where (fun t-> t.PatientId = Some ptn.Id) |> Seq.tryHead with
        | Some prov -> prov.Delete()
        | None -> ()
    | None -> ()
    match ctx.Dbo.AspNetUsers |> Seq.where (fun t-> t.Id = newUserId) |> Seq.tryHead with
    | Some usr -> usr.Delete()
    | None -> ()

let SetupTestUser _ =
    SetupUser()
    SetupPatient()
    SetupProvider()
    "User, Test"