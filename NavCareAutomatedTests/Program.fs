open canopy
open FSharp.Data.Sql

chromeDir <- __SOURCE_DIRECTORY__
start chrome

pin FullScreen

let email = "jstevens@uscarenet.com"
let password = "History12!"
let [<Literal>] ConnectionString = "Data Source=navsql;Initial Catalog=NavcareDB_Test4;Integrated Security=True; "
type Sql = SqlDataProvider<ConnectionString = ConnectionString, DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER, UseOptionTypes = true>

let ctx = Sql.GetDataContext()
let baseUrl = "https://test.navcare.com/"

let writeSlow str =
    [0..String.length str - 1]
    |> List.iter (fun i ->
    press (str.[i].ToString())
    sleep 0.2
    )


"Login to website" &&& fun _ ->
    url baseUrl
    "#Email_I" << email
    "#Password_I" << password
    click "#SetPasswordSubmitImg"
    displayed "#mainNav"

//-----------------------------------------------------------------
    
    // Tab 1.) Load new CCM Patient (Not from enrollment tab)

"1.) Navigate with search tab" &&& fun _ ->
    click "#mainNav > li:nth-child(2) > a"
    displayed "#PeopleSearchGrid"
    on (baseUrl + "search")

"2.) Select enroll new person" &&& fun _ ->
    click """//*[@id="headerBar"]/div[2]/div/button[9]/span""" // Using Xpath because selector is unreliable

"3.) Input patient facility information" &&& fun _ ->
    js """document.getElementById("mainFooter").remove()""" |> ignore
    click "#FacilityId_dropdown"
    "#FacilityId_inputSearch" << "advanced internal medicine"
    click "#\34 7 > span"
    contains "Advanced Internal Medicine" (read "#FacilityId_hidden")

"4.) Input patient medical records number (MRN)" &&& fun _ ->
    "#MedicalRecordNoId" << "1241240124"
    click "#PatientAccountNoId"
    "#MedicalRecordNoId" != null

"5.) Input Primary Care Provider (PCP)" &&& fun _ ->
    click "#MainProviderId_dropdown"
    "#MainProviderId_inputSearch" << "Abbott"
    press down
    press enter
    contains "Abbott" (read "#MainProviderId_hidden")

"6.) Input care coordinator" &&& fun _ ->
    click "#CareCoordinatorId_dropdown"
    "#CareCoordinatorId_inputSearch" << "abercrombie"
    press down
    press enter
    contains "abercrombie" (read "#CareCoordinatorId_hidden")

"7.) Input DOB" &&& fun _ ->
    click "#DateofBirthId"
    "#DateofBirthId" << "2/6/2018"
    click "#NicknameId"
    "#DateofBirthId" != null

"8.) Input SSN" &&& fun _ ->
    click "#SSNId"
    "#SSNId" << "123456789"
    click "#NicknameId"
    "#SSNId" != null

"9.) Select Gender" &&& fun _ ->
    click "#GenderIdentityId_dropdown"
    press down
    press down
    press down
    press enter
    "#GenderIdentityId_hidden" != null

"10.) Input Race" &&& fun _ ->
    click "#demographicInformationForm > div:nth-child(7) > div:nth-child(7) > div > div > span > span > span"
    click "#raceDropdown-1"
    "#demographicInformationForm > div:nth-child(7) > div:nth-child(7) > div > div > span > span > input" != null

"11.) Input Language" &&& fun _ ->
    
    click "#demographicInformationForm > div.col-xs-12.padding-h-0.padding-top-10 > div > div:nth-child(3) > div > div:nth-child(2) > div > span > span > span"
    click "#languageDropdown-2"
    "#demographicInformationForm > div.col-xs-12.padding-h-0.padding-top-10 > div > div:nth-child(3) > div > div:nth-child(2) > div > span > span > input" != null

"12.) Input phone numbers" &&& fun _ ->

    click "#demographicInformationForm > div:nth-child(9) > div > div:nth-child(3) > div > div:nth-child(2) > div > span > span > span"
    press down
    press enter
    click "#demographicInformationForm > div:nth-child(9) > div > div:nth-child(3) > div > div:nth-child(3) > input"
    writeSlow "8004003000" 
    //"#demographicInformationForm > div:nth-child(9) > div > div:nth-child(3) > div > div:nth-child(3) > input" << phoneNumber
    press enter
    "#demographicInformationForm > div:nth-child(9) > div > div:nth-child(3) > div > div:nth-child(2) > div > span > span > input" != null
    "#demographicInformationForm > div:nth-child(9) > div > div:nth-child(3) > div > div:nth-child(3) > input" != null

"13.) Input address info" &&& fun _ ->

    //input data
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div > input" << "123 abc rd"
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div > input" << "456 def rd"
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(3) > div > input" << "1234"
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > div > input" << "North Augusta"
    click "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(2) > div.margin-bottom-5 > div > div > span > span > span"
    click "#stateDropdown-40"
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(2) > div:nth-child(3) > div > input" << "29841"

    //chcek for values
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div > input" != null
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div > input" != null
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(3) > div > input" != null
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > div > input" != null
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(2) > div.margin-bottom-5 > div > div > span > span > input" != null
    "#demographicInformationForm > div.col-xs-12.padding-h-0.margin-bottom-5 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(2) > div:nth-child(3) > div > input" != null

"14.) Input availability for contact" &&& fun _ ->
    
    //input data
    click "#TZLabel_dropdown"
    click "#TZLabel_popup > div > ul > li:nth-child(1) > span"
    click "#\23 Day_0_Preferred"
    click "#\23 Day_1_Preferred"
    click "#\23 Day_2_Preferred"
    click "#\23 Day_3_Preferred"
    click "#\23 Day_4_Preferred"
    click "#\23 Day_5_Preferred"
    click "#\23 Day_6_Preferred"

    //timing options
    click "#Day_0_TimingOption_dropdown"
    click "#Day_0_TimingOption_popup > div > ul > li:nth-child(2)"

    click "#Day_1_TimingOption_dropdown"
    click "#Day_1_TimingOption_popup > div > ul > li:nth-child(2)"

    click "#Day_2_TimingOption_dropdown"
    click "#Day_2_TimingOption_popup > div > ul > li:nth-child(3)"

    click "#Day_3_TimingOption_dropdown"
    click "#Day_3_TimingOption_popup > div > ul > li:nth-child(3)"

    click "#Day_4_TimingOption_dropdown"
    click "#Day_4_TimingOption_popup > div > ul > li:nth-child(2)"

    click "#Day_5_TimingOption_dropdown"
    click "#Day_5_TimingOption_popup > div > ul > li:nth-child(1)"


    //begin and end times
    click "#Day_0_BeginTime_dropdown"
    click "#Day_0_BeginTime_popup > div.e-content > ul > li:nth-child(2)"
    click "#Day_0_EndTime_dropdown > span"
    click "#Day_0_EndTime_popup > div.e-content > ul > li:nth-child(4)"

    click "#Day_1_BeginTime_dropdown"
    click "#Day_1_BeginTime_popup > div.e-content > ul > li:nth-child(2)"
    click "#Day_1_EndTime_dropdown"
    click "#Day_1_EndTime_popup > div.e-content > ul > li:nth-child(3)"

    click "#Day_2_BeginTime_dropdown > span"
    click "#Day_2_BeginTime_popup > div.e-content > ul > li:nth-child(1)"

    click "#Day_3_BeginTime_dropdown"
    click "#Day_3_BeginTime_popup > div.e-content > ul > li:nth-child(2)"

    click "#Day_4_BeginTime_dropdown"
    click "#Day_4_BeginTime_popup > div.e-content > ul > li:nth-child(1)"
    click "#Day_4_EndTime_dropdown"
    click "#Day_4_EndTime_popup > div.e-content > ul > li:nth-child(2)"

"15.)  Save new patient" &&& fun _ ->

    "#PatientsFacilityIDNoId" << "12345"
    "#FirstNameId" << "test"
    "#LastNameId" << "patient"
    click "#SexatBirthId_dropdown"
    click "#\31"
    click "#DemographicsForm > div.col-xs-12.padding-h-0.padding-top-10.padding-bottom-10 > div > input.btn.btn-sm.btn-success"

"16.) Add new contact" &&& fun _ ->

    click "#Person-navitem-17"
    sleep 4
    click "#ContactsGrid_add > a"
    "#ContactEditForm > div:nth-child(2) > div:nth-child(1) > div > span > span > input.e-maskedit.e-js.e-input" << "mark"
    "#ContactEditForm > div:nth-child(2) > div:nth-child(3) > div > span > span > input.e-maskedit.e-js.e-input" << "carroll"
    click "#ejControl_9_dropdown"
    click "#ejControl_9_popup > div > ul > li:nth-child(1)"
    "#PhoneNumberId0" << "1234567891"
    click "#AddEditSubmit"

"17.) Select social history and add data per EHR and save" &&& fun _ ->

    click "#Person-navitem-18"

    click "#ejControl_10_dropdown"
    click "#ejControl_10_popup > div.e-content > ul > li:nth-child(4)"

    click "#ejControl_11_hidden"
    click "#ejControl_11_popup > div > ul > li:nth-child(3)"
    click "#ejControl_12_hidden"
    click "#ejControl_12_popup > div > ul > li:nth-child(6) > span"

    "#socialHistoryContainer > div:nth-child(3) > div:nth-child(4) > div > span > span > input" <<  "abcde"
    click "#socialHistoryContainer > div:nth-child(3) > div:nth-child(5) > div > span > div > span > span"

    "#socialHistoryContainer > div:nth-child(5) > div.col-xs-12.col-sm-12.col-md-6.padding-left-0 > textarea" << "test data test data test data"

    click "#ejControl_13_hidden"
    click "#ejControl_13_popup > div > ul > li:nth-child(5)"
    "#socialHistoryContainer > div:nth-child(4) > div:nth-child(2) > div > span > span > input.e-maskedit.e-js.e-input" << "daily"

    click "#ejControl_14_hidden"
    click "#ejControl_14_popup > div > ul > li:nth-child(3)"
    "#socialHistoryContainer > div:nth-child(4) > div:nth-child(4) > div > span > span > input.e-maskedit.e-js.e-input" << "5"

    click "#SHSubmit"

"18.) Select insurance information, add data and save" &&& fun _ ->

    click "#Person-navitem-69"
    
    click "#ejControl_15_dropdown"
    click "#ejControl_15_popup > div.e-content > ul > li:nth-child(5)"
    click "#ejControl_16_dropdown"
    click "#ejControl_16_popup > div.e-content > ul > li:nth-child(8)"
    click "#ejControl_17_dropdown"
    click "#ejControl_17_popup > div.e-content > ul > li:nth-child(7) > span"

    click "#insuranceContainer > div > div > input.btn.btn-sm.btn-success.pull-left.margin-right-5"

"19.) Select clinical summary and then select problem list" &&& fun _ ->
    sleep 3
    click "#Person-navitem-23"
    sleep 3
    click "#Person-navitem-26"

"20.) Add DX codes for patients" &&& fun _ ->
    click "#problemListGrid_add > a"
    click "#ejControl_19_dropdown"
    click "#ejControl_19_popup > div > ul > li:nth-child(2)"

    "#ejControl_20" << "123"
    sleep 5
    click "#A150"
    click "#ProblemStatus_dropdown"
    click "#ProblemStatus_popup > div > ul > li.e-active"

    click "#problemPriority_dropdown"
    click "#problemPriority_popup > div > ul > li:nth-child(2)"

    "#ProblemOnsetDate" << "5/5/2018"

    click "#ProblemType_dropdown"
    click "#ProblemType_popup > div > ul > li:nth-child(1)"

    "#selectedProblem > div:nth-child(5) > div.padding-left-0.padding-right-0.col-xs-12 > textarea" << "test data test data test data"

    click "#selectedProblem > div:nth-child(6) > div > input.btn.btn-sm.btn-success.pull-right"

"21.) Select medications and add data" &&& fun _ ->
    sleep 3
    click "#Person-navitem-27"
    click "#medicationsGrid_add > a"

    "#drugSearch" << "tyl"
    click "#selectedMedication > div.col-xs-12.padding-top-10.padding-right-0 > div:nth-child(8)"
    click "#\34 74018"

    "#txtSigText" << "test data test data test data test data"

    click "#ejControl_26_dropdown"
    click "#ejControl_26_popup > div.e-content > ul > li:nth-child(2)"

    "#selectedMedication > div:nth-child(2) > div:nth-child(1) > div:nth-child(4) > div > span > span > input" << "5/5/2018"
    "#selectedMedication > div:nth-child(2) > div:nth-child(1) > div:nth-child(5) > div > span > span > input" << "6/5/2018"
    "#selectedMedication > div:nth-child(2) > div:nth-child(1) > div:nth-child(6) > div > span > span > input" << "5/5/2018"

    click "#selectedMedication > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > span > div > span > span"
    click "#selectedMedication > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > span > div > span > span"

    "#selectedMedication > div:nth-child(2) > div:nth-child(2) > div:nth-child(3) > div > span > span > input" << "2"
    "#selectedMedication > div:nth-child(2) > div:nth-child(2) > div:nth-child(5) > div > span > span > input" << "5"
    "#selectedMedication > div:nth-child(2) > div:nth-child(2) > div:nth-child(6) > div > span > span > input.e-maskedit.e-js.e-input" << "30"
    "#selectedMedication > div:nth-child(2) > div:nth-child(2) > div:nth-child(7) > div > span > span > input" << "5/5/2019"
    "#selectedMedication > div:nth-child(2) > div:nth-child(2) > div:nth-child(8) > div > span > span > input.e-maskedit.e-js.e-input" << "test data test data test data test data "

    click "#selectedMedication > div:nth-child(5) > div > input.btn.btn-sm.btn-success.pull-right"

"22.) Select medical history and add data" &&& fun _ ->
    click "#Person-navitem-28"
    click "#PastMedicalHistoryGridView_DXCBtn0 > span"

    "#Description_I" << "test data test data test data test data"
    "#Year_I" << "2020"

    click "#PastMedicalHistoryTCMProvider_B-1"
    click "#PastMedicalHistoryTCMProvider_DDD_gv_DXDataRow0 > td:nth-child(2)"

    "#Facility_I" << "test data"
    "#Notes_I" << "test data"

    click "#btnUpdate > span"

"23 & 24.) Select allergies, input data and update" &&& fun _ ->
    click "#Person-navitem-31"
    click "#AllergiesGridView_DXCBtn0 > span"
    "#AllergiesGridView_DXEFL_DXEditor2_I" << "test data"
    "#AllergiesGridView_DXEFL_DXEditor3_I" << "test data"
    click "#AllergiesGridView_DXEFL_DXCBtn1 > span"

"25.) Select last known vitals, click new and add data" &&& fun _ ->
    click "#Person-navitem-32"
    click "#VitalsGridView_DXCBtn0 > span"
    "#VitalsGridView_DXEFL_DXEditor2_I" << "50"
    "#VitalsGridView_DXEFL_DXEditor4_I" << "50"
    "#VitalsGridView_DXEFL_DXEditor6_I" << "50"
    "#VitalsGridView_DXEFL_DXEditor8_I" << "50"
    "#VitalsGridView_DXEFL_DXEditor10_I" << "5/5/2018"
    "#VitalsGridView_DXEFL_DXEditor3_I" << "50"
    "#VitalsGridView_DXEFL_DXEditor5_I" << "50"
    "#VitalsGridView_DXEFL_DXEditor7_I" << "50"
    "#VitalsGridView_DXEFL_DXEditor9_I" << "50"
    click "#VitalsGridView_DXEFL_DXCBtn1 > span"

"26.) Select records and upload necessary documents" &&& fun _ ->
    url (baseUrl + "people/?patientId=1#/people/_primarycarerecords")
    click "#main > div > div.e-gridtoolbar.e-toolbar.e-js.e-widget.e-box.e-toolbarspan.e-tooltip > ul > li > a"
    "#TimeVisitId" << "5/5/2018"
    "#RecordTable > tbody > tr > td > div > div:nth-child(2) > div:nth-child(4) > div > input" << "test test test"
    "#Comments" << "test test test"

    "#UploadFile" << """C:\Users\jstevens\Downloads\test document.txt"""
    click "#Save"

"27.) Select Enrollment to upload written consent" &&& fun _ ->
    click "#Person-navitem-64"
    click "#main > div > div.e-gridtoolbar.e-toolbar.e-js.e-widget.e-box.e-toolbarspan.e-tooltip > ul > li > a"
    "#RecordTable > tbody > tr > td > div > div:nth-child(2) > div:nth-child(2) > div > input" << "test test"
    "#Comments" << "test test"
    "#UploadFile" << """C:\Users\jstevens\Downloads\test document.txt"""
    click "#Save"

"28.) select services and select CCM, start ccm services" &&& fun _ ->
    click "#Person-navitem-19"
    click "#Person-navitem-20"
    click "#CreateCCMButtonPatientPanel"

"29.) Fill out CCM data and update" &&& fun _ ->
    click "#VerbalConsent_S_D"
    "#ComprehensiveAssessment_I" << "2/14/2018"
    click "#AddNewCCMButton_CD > span"
    sleep 3

"30.) Select tasks and add tasks" &&& fun _ ->
    click "#Person-navitem-33"
    click "#tasksContainer > div:nth-child(2) > button"

"31.) Select welcome call template" &&& fun _ ->
    click "#TaskTemplatesForSimpleTaskGridLookupPartial_B-1"
    "#TaskTemplatesForSimpleTaskGridLookupPartial_DDD_gv_DXFREditorcol1_I" << "welcome"
    click "#TaskTemplatesForSimpleTaskGridLookupPartial_DDD_gv_DXDataRow0 > td:nth-child(2)"

"32.) Assign task and save" &&& fun _->
    sleep 3
    click "#AddEditTaskSubmit_CD"
    sleep 10
   
//----------------------------------------------------------------------------------------------------------

    // Tab 2.) Load new CCM patient (From enrollment tab)

"1.) Select Patient" &&& fun _ ->
    click "#mainNav > li:nth-child(3) > a"
    click "#Name_filterBarcell"
    "#Name_filterBarcell" << "test"
    sleep 3
    click "#contextMenuButton"
     
"2.) Edit selected patient" &&& fun _ ->
    click "#enrollmentGrid_Context > li:nth-child(1) > a"
    "#ccmEnrollmentGridEditForm > div:nth-child(5) > div:nth-child(3) > div > span > span > input.e-maskedit.e-js.e-input" << "test test test"
    "#ccmEnrollmentGridEditForm > div:nth-child(8) > div > div.col-xs-12.col-sm-12.col-md-6.padding-left-0 > textarea" << "test test test"
    click "#ccmEnrollmentGridEditForm > div.col-xs-12.padding-top-10.padding-bottom-10 > div > input.btn.btn-sm.btn-success.pull-right"
    sleep 3

"3.) Select Accepted under enrollment status" &&& fun _ ->
    click "#Status_filterBarcell_dropdown"
    click "#Status_filterBarcell_popup > div > ul > li:nth-child(4) > span"
    "#Name_filterBarcell" << ""
    click "#Facility_filterBarcell"

"4.) Add DX codes" &&& fun _ ->
    click "#mainNav > li:nth-child(3) > a"
    click "#Name_filterBarcell"
    "#Name_filterBarcell" << "test"
    sleep 3
    click "#contextMenuButton"
    click "#enrollmentGrid_Context > li:nth-child(1) > a"
    "#ejControl_7" << "123"
    sleep 3
    click "#C8123"

"5.) Submit changes to patient" &&& fun _ ->
    click "#ccmEnrollmentGridEditForm > div.col-xs-12.padding-top-10.padding-bottom-10 > div > input.btn.btn-sm.btn-success.pull-right"
    sleep 3    

run()
System.Console.WriteLine("Press any key to continue")
System.Console.ReadLine() |> ignore
quit()

[<EntryPoint>]
let main argv = 
    0 // done