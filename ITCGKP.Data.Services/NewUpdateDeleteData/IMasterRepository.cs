using ITCGKP.Data.ViewModels;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public interface IMasterRepository
    {
        //Page Setup Table

        // Multiple Branches
        Task<List<string>> PageSetupTestFormulaApply(int cmpdid);
        Task<bool> AddNewPageSetupValidedMultipleBranch(int cmpdid);
        Task<int> AddNewPageSetupNewUserMultipleBranch(int cmpdid);

        // Multiple Branches end

        Task<int> AddNewPageSetup(PageSetupViewModel models);
        Task<bool> UpdatePageSetup(PageSetupViewModel models);
        Task<bool> UpdatePageSetupByComp(int compid, bool truefalse);
        Task<PageSetupViewModel> GetPageSetupById(int id);
        Task<int> GetPageSetupByCompId(int compId);
        Task<PageSetupViewModel> GetPageSetuppPrintComp(int cmpid);
        Task<List<PageSetupViewModel>> GetAllPageSetup(int cmpid);
        // Agent Table
        Task<bool> TestSubMasterTempNo();
        Task<string> AgentSrNoCreation(int cmpid);
        Task<int> AddNewAgent(AgentFileViewModel models);
        Task<bool> UpdateAgent(AgentFileViewModel models);
        Task<List<AgentFileViewModel>> GetAllAgent(int cmpid);
        Task<List<AgentFileViewModel>> GetAllAgentBranchWise(int cmpid, string name, string mobileno, string cityx);
        Task<AgentFileViewModel> GetAgentById(int id);
        Task<bool> DeleteAgent(int id);
        Task<AgentFileViewModel> GetAgentByCode(string code);

        // Client File
        Task<string> ClientSrNoCreation(int cmpid);
        Task<int> AddNewClient(ClientFileViewModel models);
        Task<bool> UpdateClient(ClientFileViewModel models);
        Task<List<ClientFileViewModel>> GetAllClient(int cmpid);
        Task<List<ClientFileViewModel>> GetAllClient(int cmpid, int clientid);
        Task<List<ClientFileViewModel>> GetAllClientBranchWise(int cmpid, string name);
        Task<ClientFileViewModel> GetClientById(int id);
        Task<ClientFileViewModel> GetClientDefaultValue(int cmpid);        
        Task<bool> DeleteClient(int id);
        Task<ClientFileViewModel> GetClientByCode(string code);

        // Area File
        Task<int> AddNewArea(AreaFileViewModel models);
        Task<bool> UpdateArea(AreaFileViewModel models);
        Task<List<AreaFileViewModel>> GetAllArea(int id);
        Task<List<AreaFileViewModel>> GetAllAreaByDistrict(int id);
        Task<AreaFileViewModel> GetAreaById(int id);
        Task<bool> DeleteArea(int id);
        Task<List<AreaFileViewModel>> GetAllAreaDetails(int id, string name);

        // Test Group Master File
        Task<int> AddNewTestGroupMasterRecord(TestGroupMasterViewModel models);
        Task<bool> UpdateTestGroupMaster(TestGroupMasterViewModel models);
        Task<TestGroupMasterViewModel> GetTestGroupMasterById(int id);
        Task<TestGroupMasterViewModel> GetTestGroupMasterCompany(int cmdid);
        Task<bool> DeleteTestGroupMaster(int id);
        Task<List<TestGroupMasterViewModel>> GetAllTestGroupMaster(int cmpid);
        Task<TestGroupMasterViewModel> GetAllTestGroupMasterName(int cmpid, string shortname);

        // Doctor Master File
        Task<string> DoctorSrNoCreation(int cmpid);
        Task<int> AddNewDoctorMasterRecord(DoctorViewModel models);
        Task<bool> UpdateDoctorMaster(DoctorViewModel models);
        Task<DoctorViewModel> GetDoctorMasterById(int id);
        Task<bool> DeleteDoctorMaster(int id);
        Task<List<int>> GetDetailsDoctorMasterById(int id, int cmdid, int testGroupid);
        Task<DoctorDetailsMasterViewModel> GetDetailsDoctorMasterTestGroup(string doctorid, int cmdid, int testGroupid);
        Task<List<DoctorViewModel>> GetAllDoctorMaster(int cmpid);
        Task<List<DoctorViewModel>> GetAllDoctorMasterName(int cmpid, string name, string mobileno, string addressx);
        Task<int> AddNewDoctorMasterAccountRecord(DoctorViewModel models);
        Task<bool> UpdateDoctorMasterAccount(DoctorViewModel models);
        Task<List<DoctorViewModel>> GetAllDoctorMasterLedger(int cmpid);
        Task<string> GetDoctorMasterLedgerId(int id);

        // Doctor In Labs Details
        Task<int> AddNewDoctorMasterLabRecord(DoctorLabViewModel models);
        Task<bool> UpdateDoctorMasterLab(DoctorLabViewModel models);
        Task<DoctorLabViewModel> GetDoctorMasterLabById(int id);
        Task<bool> DeleteDoctorMasterLab(int id);
        Task<List<DoctorLabViewModel>> GetDoctorMasterLabList(int cmpid);
        // Report Group Table       
        Task<int> AddNewReportGroupMasterRecord(ReportGroupViewModel models);
        Task<bool> UpdateReportGroupMaster(ReportGroupViewModel models);
        Task<ReportGroupViewModel> GetReportGroupMasterById(int id);
        Task<bool> DeleteReportGroupMaster(int id);
        Task<List<ReportGroupViewModel>> GetAllReportGroupMaster(int cmpid);
        Task<int> ReportGroupOrderNo(int cmpid);
        Task<bool> UpdateReportSerialNo(TempReportViewFile models);
        // Test Doc Master File
        Task<int> AddNewTestDocMasterRecord(TestDocMasterViewModel models);
        Task<bool> UpdateTestDocMaster(TestDocMasterViewModel models);
        Task<TestDocMasterViewModel> GetTestDocMasterById(int id);
        Task<bool> DeleteTestDocMaster(int id);
        Task<List<TestDocMasterViewModel>> GetAllTestDocMaster(int cmpid);
        Task<List<TestDocMasterViewModel>> GetAllTestDocMaster(int cmpid, string testcode, int testgid);
        Task<List<TestDocMasterViewModel>> GetAllTestDocMaster(int cmpid, int testgid);

        // Test  Master File       
        Task<int> AddNewTestMasterRecord(TestMasterViewModel models);
        Task<bool> UpdateTestMaster(TestMasterViewModel models);
        Task<bool> UpdateInsertTestMaster(int testid, int insertno, int totalrows, int compid);
        Task<TestMasterViewModel> GetTestMasterById(int id);
        Task<List<TestSubMasterViewModel>> GetTestMasterBySubId(int id);
        Task<List<TestSubMasterViewModel>> GetTestMasterSuId(int id);
        Task<TestSubMasterViewModel> GetTestMasterBySubDocId(int id);
        Task<bool> DeleteTestMaster(int id);
        Task<bool> DeleteTestMasterOne(int id, int tno);
        Task<List<TestMasterViewModel>> GetAllTestMaster(int cmpid, int rptid, int testgid,string testname);
        Task<List<TestMasterViewModel>> GetAllTestMaster(int cmpid, int rptid, int testgid);
        Task<List<TestMasterViewModel>> GetAllTestMaster(int cmpid);
        Task<List<TestMasterViewModel>> GetAllTestMasterGroup(int cmpid);
        Task<List<TestMasterViewModel>> GetAllTestMasterGroup(int cmpid, int testid);
        Task<int> GetAllTestMasterGroupTrueFalse(int cmpid, int testid);
        Task<List<TestMasterViewModel>> GetAllTestMasterName(int cmpid, int rptid, string testname);
        Task<List<TestMasterViewModel>> GetAllTestMasterCompany(int cmpid);
        Task<int> TransferTestOneUserToAnotherUser(int fromcompId, int uptocompid);
        Task<int> TransferTestOneUserToAnotherUser(int fromcompId, int uptocompid, int fromTestId);
        Task<List<TestRateDetailViewModel>> GetTestRateList(int cmpid);
        Task<List<TestRateDetailViewModel>> GetTestRateList(int id, int cmpid);
        Task<bool> UpdateTestRateList(TestRateViewModel models);

        // Patient Master File
        Task<PatientIIViewModel> GetPatientMasterByMobileNo(string mobileno);
        Task<string> PatientSrNoCreation(int CmpId);
        Task<string> PatientRefCreation(int CmpId, string type, string dt1);
        Task<int> PatientHeadDoctorId(string doctcode);
        Task<string> PatientHeadDoctorCode(int doctid);
        Task<int> AddNewPatientMaster(PatientViewModel models);
        Task<bool> UpdatePatientMaster(PatientViewModel models);
        Task<bool> UpdatePatientDrInlabMaster(int id, int drId);
        Task<bool> UpdatePatientMasterCancel(int id, string canceltrufalse);
        Task<bool> UpdatePatientMasterApproved(int id, string canceltrufalse);
        Task<bool> PatientMasterApproved(int id, string rptdate);
        Task<bool> UpdatePatientMasterIssue(int id, string canceltrufalse);
        Task<bool> UpdatePatientMasterHold(int id, string canceltrufalse);
        Task<bool> UpdatePatientMasterRecipt(int id, string canceltrufalse);
        Task<bool> UpdatePatientMasterDispatch(int id, string canceltrufalse);
        Task<PatientViewModel> GetPatientMasterById(int id);
        Task<PatientViewModel> GetPatientMasterByReportNo(string voucherno);
        Task<bool> GetPatientMasterValidByReportNo(string voucherno);
        Task<PatientViewModel> GetPatientMasterByVoucherNo(string id);
        Task<List<int>> GetPatientDetailsDiscountMasterById(int id, int cmdid, int testGroupid, string userid);
        Task<bool> DeletePatientMaster(int id);
        Task<bool> DeletePatientDetails(string VchNo, string Userid, int? cmpid);
        Task<bool> DeletePatientMasterOne(int id, int tno);
        Task<List<PatientDetailsMasterViewModel>> GetPatientDetailsById(int id);
        Task<List<PatientViewModel>> PatientDoctorIPDateWise(int CmpId, int doctId, DateTime dt1, DateTime dt2);
        Task<List<PatientViewModel>> SearchPatientMasterDateWise(int CmpId, string UCode, string patienttype, DateTime dt1, DateTime dt2);
        Task<List<PatientViewModel>> GetAllPatientMasterName(int cmpid, string UCode, string mobileno, int sexid, string type, string name, int age, string address, string emailaddress, int doctorid, DateTime FromDt, DateTime UptoDt, string paymentype, string paymentmode, int testdrId, bool datetrue, int clntId);
        Task<List<PatientViewModel>> GetAllPatientMasterResultSearch(int cmpid, string UCode, string mobileno, int sexid, string type, string name, int age, string address, string emailaddress, int doctorid, DateTime FromDt, DateTime UptoDt, string paymentype, string paymentmode, int testdrId, bool datetrue, int clntId, string searchfilder);
        Task<List<PatientViewModel>> GetAllPatientMasterResultSearchDispatch(int cmpid);
        Task<bool> UpdateAllPatientMasterResultApproved(int cmpid, string UCode, string mobileno, int sexid, string name, int age, string address, string emailaddress, int doctorid, DateTime FromDt, DateTime UptoDt);
        Task<List<PatientViewModel>> GetPatientDateWise(int cmpid, string UCode, string patienttype, int AgentId, int DoctorId, DateTime FromDt, DateTime UptoDt, string paymentmode, int testdrId);
        Task<List<PatientViewModel>> GetPatientDateTestWise(int cmpid, string UCode, DateTime FromDt, DateTime UptoDt);
        Task<List<PatientDetailsMasterViewModel>> GetPatientDateTestGroup(int mainId, int TestGroupId, int TestId);
        Task<List<int>> GetDetailsPatientDiscountMasterById(int id, int cmdid, int testGroupid);
        Task<List<PatientInvestigationViewModel>> GetPatientTestInvestigation(int PatId, int testid);
        Task<bool> UpdatePatientInvestigation(TempResultViewFile model);
        Task<List<PatientDetailsMasterViewModel>> GetPatientTestDetails(int PatId, int compid, string rpttype); // RptType Reading/Document
        Task<List<PatientDetailsMasterViewModel>> GetPatientTestGroupDetails(int PatId, int compid, string rpttype); // RptType Reading/Document
        Task<List<PatientDetailsMasterViewModel>> GetPatientTestDetails(int PatId, int compid, string rpttype, string rpttype2); // RptType Reading/Document
        Task<List<PatientDetailsMasterViewModel>> GetPatientTestGroupDetails(int PatId, int compid, string rpttype, string rpttype2); // RptType Reading/Document
        Task<List<PatientViewModel>> GetALLPatientCompanyWiseWeekly(DateTime dateTime);
        Task<List<PatientViewModel>> GetALLPatientCompanyWiseMonthly(DateTime dateTime);
        Task<List<PatientViewModel>> GetALLPatientRecord(DateTime dateTime, int BranchId);

        // Patient Audit Table
        Task<List<PatientAuditViewModel>> SearchPatientAudit(int patid);
        Task<List<PatientAuditViewModel>> SearchPatientAuditDateWise(int CmpId, string UCode, DateTime dt1, DateTime dt2);
        Task<bool> DeletePatientAuditDetails(int CmpId, string UCode, DateTime dt1, DateTime dt2);
        Task<bool> UpdateAuditFileForDelete(int id, bool canceltrufalse);
        Task<bool> UpdateALLAuditFileForDelete(int CmpId, string UCode, DateTime dt1, DateTime dt2,bool chvalues);
        Task<bool> AuditFileForValid(int patid);

        // Patient Due Recipt File
        Task<int> AddNewPatientDueReciptMaster(PatientDueReciptViewModel models);
        Task<bool> UpdatePatientDueReciptMaster(PatientDueReciptViewModel models);
        Task<PatientDueReciptViewModel> GetPatientDueReciptMasterById(int id);
        Task<bool> GetPatientDueReciptValidedByVoucherNo(string voucherno);
        Task<bool> DeletePatientDueReciptMaster(int id);
        Task<List<PatientDueReciptViewModel>> GetPatientDueReciptDateWise(string UCode, DateTime FromDt, DateTime UptoDt, string paymentmode);
        Task<List<PatientViewModel>> GetAllPatientMasterDueAnalysis(int cmpid, string UCode, string mobileno, int sexid, string name, int age, string address, string emailaddress, int doctorid, DateTime FromDt, DateTime UptoDt, string paymentmode);

        // Test Result Value
        Task<List<TestResultDetailViewModel>> GetTestResultHelp(int testid, string testDetailName);
        Task<List<ReportGroupViewModel>> GetPatientReportGroup(int PatId, string rpttype); // RptType Reading/Document
        Task<List<ReportGroupViewModel>> GetPatientReportGroup(int PatId, string rpttype,string rpttype2); // RptType Reading/Document
        Task<int> GetPatientReportGroupDocRecord(int PatId, string rpttype, int testgid); // RptType Reading/Document;
        Task<bool> GetPatientTestGroupCovid(int PatId);
        Task<List<PatientInvestigationViewModel>> GetPatientTestReport(int PatId, int rptid, int testid);
        Task<List<PatientInvestigationViewModel>> GetPatientTestReport(int PatId, int rptid);
        Task<bool> UpdatePatientPrintOption(int patid, int testid, bool truefalse);
        Task<List<PatientViewModel>> GetAllPatientMasterNameByBranchWise(int cmpid, DateTime UptoDt);
        Task<bool> UpdatePatientReportingDate(int patid, string dtvalue);
        Task<int> GetTestResultFindId(int testid, string testDetailName);
        Task<int> GetTestResultIdByCompTestIdTestSubId(int compid, int testid, string testDetailName);
        Task<int> AddNewTestResult(TestResultViewModel models);
        Task<bool> UpdateTestResult(TestResultViewModel models);
        Task<TestResultViewModel> GetTestResultById(int id);
        Task<List<TestResultViewModel>> GetTestResultList(int cmpid);
        Task<List<TestResultViewModel>> GetTestResultListTestId(int testid, string testDetailName);
        Task<bool> DeleteTestResult(int id);
        Task<bool> DeleteTestResultOne(int id, int tno);

        // Document File Update
        Task<bool> UpdatePatientInvestigationDoctype(int patid, string doctype);
        Task<bool> UpdatePatientInvestigationDoc(TempResultViewFile model);
        Task<PatientInvestigationViewModel> GetPatientTestInvestigationDoc(int PatId, int testid);

        // Med Test File
        Task<int> AddNewMedMasterRecord(MedMasterViewModel models);
        Task<bool> UpdateMedMaster(MedMasterViewModel models);
        Task<MedMasterViewModel> GetMedMasterById(int id);
        Task<bool> DeleteMedMaster(int id);
        Task<List<MedMasterViewModel>> GetAllMedMaster(int cmpid);

        Task<int> AddNewMedFile(MedTestViewModel models);
        Task<bool> UpdateMedFile(MedTestViewModel models);
        Task<MedTestViewModel> GetMedFileById(int id);
        Task<MedTestViewModel> GetMedFileByPtId(int id);
        Task<MedTestViewModel> GetMedFileByIdReport(int id);
        Task<bool> DeleteMedFile(MedTestViewModel models);
        Task<bool> DeleteMedTestFile(int id);
        Task<int> GetMedFileByPatientId(int id);
        Task<MedTestViewModel> GetMedFileByIdNo(string id);
    }
}