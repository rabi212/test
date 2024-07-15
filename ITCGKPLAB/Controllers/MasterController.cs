using ITCGKP.Data.Models;
using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.ViewModels;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKPLAB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ITCGKPLAB.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,Manager,User")]
    [ResponseCache(Duration = 2, Location = ResponseCacheLocation.Client, NoStore = false)]
    public class MasterController : Controller
    {        
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ISettingRepository _repository ;
        private readonly IMasterRepository _mrepository ;
        private readonly IFinancialRepository _frepository ;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SoftwareConfigMode _softwareConfig;
        int idno = 0; bool istrasferrecord = false; string _Message = "";
        const int DispalRows = 150; int PageNo = 1;
        double TotalRows = 0; int TotalPageNo = 0;
        [ViewData]
        public List<CompanyDetailViewModel> ListCompanyViewModels { get; set; }
        [ViewData]
        public List<AgentFileViewModel> ListAgentViewModels { get; set; }
        [ViewData]
        public SMSFileViewModel ListSMSFileViewModels { get; set; }
       
        //private readonly decimal Amt1 = 0; decimal Amt2 = 0; decimal Amt3 = 0; decimal Amt4 = 0; string date1 = "";
        //decimal Amt5 = 0; decimal Amt6 = 0; decimal Amt7 = 0;
        //string st11 = ""; string st12 = ""; string st2 = "";

        public MasterController(ISettingRepository SettingRepository, IMasterRepository MasterRepository,
            IFinancialRepository FinancialRepository, UserManager<ApplicationUser> userManager
            ,IOptions<SoftwareConfigMode> softwareConfig, IWebHostEnvironment hostingEnvironment)
        {
            _repository = SettingRepository;
            _mrepository = MasterRepository;
            _frepository = FinancialRepository;
            _userManager = userManager;
            _softwareConfig = softwareConfig.Value;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("Test-Formula-File")]        
        public IActionResult CreateTestFormulaFile()
        {            
            return View();
        }
        [HttpGet("TestDoc-File")]
        [Authorize(Policy = "AddEditTestDocPolicy")]
        public async Task<IActionResult> CreateTestDocFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            TestDocMasterViewModel stateDetailView;
            stateDetailView = id == 0 ? new TestDocMasterViewModel() : await _mrepository.GetTestDocMasterById(id);
            return View(stateDetailView);
        }
        [HttpPost("TestDoc-File")]
        [Authorize(Policy = "AddEditTestDocPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTestDocFile(TestDocMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewTestDocMasterRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateTestDocFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateTestDocMaster(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateTestDocFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("TestDoc-Delete-File")]
        [Authorize(Policy = "DeleteTestDocPolicy")]
        public async Task<IActionResult> DeleteTestDocRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteTestDocMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateTestDocFile), new { id = 0, isSuccess = false, message = _Message });
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSearchTestDocFile(int CompId, string NameX, int testgidX)
        {
            var model = await _mrepository.GetAllTestDocMaster(CompId , NameX, testgidX);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetTestDocMasterFile(int CompId, int testgidX)
        {
            var model = await _mrepository.GetAllTestDocMaster(CompId, testgidX);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetPatientDocTrueFalse(int patid, int testgidX)
        {
            var model = await _mrepository.GetPatientReportGroupDocRecord(patid, "PathDoc", testgidX);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindClientRecord(int cmpid)
        {
            var model = await _mrepository.GetAllClient(_softwareConfig.SoftwareMode == true ? cmpid : 1);
            return Ok(model);
        }
        [HttpGet("Client-File")]
        [Authorize(Policy = "AddEditClientPolicy")]
        public async Task<IActionResult> CreateClientFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
             ClientFileViewModel districtView;
            districtView = id == 0 ? new ClientFileViewModel() 
            {
                Id=0, Code = await _mrepository.ClientSrNoCreation(_softwareConfig.SoftwareMode == true ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 1) ,
                Address1 = "-", MobileNo = "-",PinNo = "-", City = "-",EmailAddress = "g@gmail.com"
            } : await _mrepository.GetClientById(id);
            return View(districtView);
        }
        [HttpPost("Client-File")]
        [Authorize(Policy = "AddEditClientPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClientFile(ClientFileViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewClient(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateClientFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateClient(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateClientFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Client-Delete-File")]
        [Authorize(Policy = "DeleteClientPolicy")]
        public async Task<IActionResult> DeleteClientRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteClient(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateClientFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ClientDetailSearchRecord(int cmpid,string NameX = "")
        {
            var models = await _mrepository.GetAllClientBranchWise(cmpid,NameX);
            return Ok(models);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> AreaDetailSearchRecord(int cmpid, string NameX = "")
        {
            var models = await _mrepository.GetAllAreaDetails(cmpid, NameX);
            return Ok(models);
        }
        [HttpGet("Area-Files")]
        [Authorize(Policy = "AddEditAreaPolicy")]
        public async Task<IActionResult> CreateAreaFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            AreaFileViewModel districtView;
            districtView = id == 0 ? new AreaFileViewModel(){ Id = id} : await _mrepository.GetAreaById(id);
            return View(districtView);
        }
        [HttpPost("Area-Files")]
        [Authorize(Policy = "AddEditAreaPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAreaFile(AreaFileViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewArea(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateAreaFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateArea(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateAreaFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Area-Delete-File")]
        [Authorize(Policy = "DeleteAreaPolicy")]
        public async Task<IActionResult> DeleteAreaRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteArea(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateAreaFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSearchPatientFile(string mobileno)        {
            
            var model = await _mrepository.GetPatientMasterByMobileNo(mobileno);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSearchAgentFile(int CompId1, string NameX = "", string MobileX = "", string CityX = "")
        {
            var model = await _mrepository.GetAllAgentBranchWise( _softwareConfig.SoftwareMode == true ? CompId1 : 1, NameX, MobileX, CityX);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAgentSrNo()
        {
            var model = await _mrepository.AgentSrNoCreation( _softwareConfig.SoftwareMode == true ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 1);
            return Ok(model);
        }
        [HttpGet("Executive-File")]        
        [Authorize(Policy = "AddEditExecutivePolicy")]        
        public async Task<IActionResult> CreateAgent(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            AgentFileViewModel detailView;
            detailView = id == 0 ? new AgentFileViewModel()
            {
                IPAmt1 =0,DA=0,TA=0,CCA=0,HRA =0
            }
            : await _mrepository.GetAgentById(id);
            return View(detailView);
        }
        [HttpPost("Executive-File")]
        [Authorize(Policy = "AddEditExecutivePolicy")]
        [ValidateAntiForgeryToken]       
        public async Task<IActionResult> CreateAgent(AgentFileViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewAgent(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateAgent), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateAgent(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateAgent), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Agent-Delete-File")]
        [Authorize(Policy = "DeleteExecutivePolicy")]
        public async Task<IActionResult> DeleteAgentRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteAgent(id);
            _Message = "Record Delete Successfully..";
            ListAgentViewModels = await _mrepository.GetAllAgent((int)(await _userManager.GetUserAsync(User)).CompanyDetailId);
            return RedirectToAction(nameof(CreateAgent), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet]
        public ActionResult SMSSingleRecord()
        {
            ViewBag.message = " "; ViewBag.isSuccess = false;
            SingleSMSViewModel singleSMS = new SingleSMSViewModel()
            {
            };
            return View( singleSMS);
        }
        [HttpPost]
        public async Task<ActionResult> SMSSingleRecord(SingleSMSViewModel model)
        {
            string dataname = "";
            if (ModelState.IsValid)
            {
                switch (model.Language)
                {
                    case CustomerLanguage.English:
                        dataname = await _repository.SendSingleMessage(model.CellNo, model.MessageBody);
                        break;
                    case CustomerLanguage.Hindi:
                        dataname = await _repository.SendSingleMessage(model.CellNo, model.MessageBodyHindi);
                        break;
                    case CustomerLanguage.Mixed:
                        dataname = await _repository.SendSingleMessage(model.CellNo, model.MessageBody + model.MessageBodyHindi);
                        break;
                    default:
                        dataname = await _repository.SendSingleMessage(model.CellNo, model.MessageBody);
                        break;
                }
                //dataname = await _repository.SendSingleMessage(model.CellNo, model.MessageBody);
                ViewBag.message = dataname;
                ViewBag.isSuccess = true;
            }
            return View();
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetCurrentDateTime()
        {
            var model = await _repository.DateTimeServer();
            return Ok(model);
        }
        private string ProcessUploadedHeader(PageSetupViewModel models)
        {
            string uniqueFileName = null;
            if (models.HeaderPhoto != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "CenterHeader");
                uniqueFileName = "Header" + models.CompId + "_" + models.HeaderPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    models.HeaderPhoto.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
        private string ProcessUploadedFooter(PageSetupViewModel models)
        {
            string uniqueFileName = null;
            if (models.FooterPhoto != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "CenterFooter");
                uniqueFileName = "Footer" + models.CompId + "_" + models.FooterPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    models.FooterPhoto.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
        protected string WelcomeHTMLHeaderUpdateImage(string name,string exitfilename)
        {
            string Filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterHeader",exitfilename);
            var html = System.IO.File.ReadAllText(Filename);
            html = html.Replace("{{HeaderImage}}", name);
            System.IO.File.WriteAllText(Filename, html);
            return html;
        }
        protected string WelcomeHTMLFooterUpdateImage(string name, string signatureleft, string signatureright, string signaturecenter,string exitfilename)
        {
            string Filename = Path.Combine(_hostingEnvironment.WebRootPath,"CenterFooter", exitfilename);
            var html = System.IO.File.ReadAllText(Filename);
            html = html.Replace("{{FooterImage}}", name);

            html = html.Replace("{{FooterImage1}}", signatureleft);
            html = html.Replace("{{FooterImage2}}", signatureright);
            html = html.Replace("{{FooterImage3}}", signaturecenter);
            System.IO.File.WriteAllText(Filename, html);
            return html;
        }
        private string ProcessUploadedHeaderFile(PageSetupViewModel models)
        {
            string uniqueFileName="";
            string Filename = Path.Combine(_hostingEnvironment.WebRootPath, "ExportHeader.html");
            string copyToPath = Path.Combine(_hostingEnvironment.WebRootPath, "CenterHeader");
            uniqueFileName = Guid.NewGuid().ToString() + models.CompId + "_" + "ExportHeader.html";
            string filePath = Path.Combine(copyToPath, uniqueFileName);          
                //if (System.IO.File.Exists(filePath))
                //{
                //    System.IO.File.Delete(filePath);
                //}
                System.IO.File.Copy(Filename, filePath);            
            return uniqueFileName;
        }
        private string ProcessUploadedFooterFile(PageSetupViewModel models)
        {
            string uniqueFileName = "";
            string Filename = Path.Combine(_hostingEnvironment.WebRootPath,"ExportFooter.html");
            string copyToPath = Path.Combine(_hostingEnvironment.WebRootPath, "CenterFooter");
            uniqueFileName = Guid.NewGuid().ToString() + models.CompId + "_" + "ExportFooter.html";
            string filePath = Path.Combine(copyToPath, uniqueFileName);           
                //if (System.IO.File.Exists(filePath))
                //{
                //    System.IO.File.Delete(filePath);
                //}
                System.IO.File.Copy(Filename, filePath); 
            return uniqueFileName;
        }
        public async Task<IActionResult> PageSetupList()
        {
            List<PageSetupViewModel> companyDetailViewModels = await _mrepository.GetAllPageSetup(_softwareConfig.SoftwareMode == true ? (User.IsInRole("SuperAdmin") ? 0 : (int)(await _userManager.GetUserAsync(User)).CompanyDetailId) :0);
            return View(companyDetailViewModels);
        }
        [HttpGet("Page-Setup-File")]
        [Authorize(Policy = "EditPageSetupPolicy")]
        public async Task<IActionResult> PageSetupFile(int id = 0, bool isSuccess = false, string message = "")
        {
            //id = await _mrepository.GetPageSetupByCompId((int)(await _userManager.GetUserAsync(User)).CompanyDetailId);
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            PageSetupViewModel detailView;
            detailView = id == 0 ? new PageSetupViewModel() : await _mrepository.GetPageSetupById(id);
            return View(detailView);
        }
        [HttpPost("Page-Setup-File")]
        [Authorize(Policy = "EditPageSetupPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PageSetupFile(PageSetupViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                CompanyDetailViewModel companyDetailView = await _repository.GetCompanyById((int)model.CompId);
                if (model.Id == 0)
                {
                    model.ExitHeaderPhotoPath = model.HeaderPhoto != null ? ProcessUploadedHeader(model) : null;
                    model.ExitFooterPhotoPath = model.FooterPhoto != null ? ProcessUploadedFooter(model) : null;

                    idno = await _mrepository.AddNewPageSetup(model);
                    WelcomeHTMLHeaderUpdateImage(model.ExitHeaderPhotoPath, model.HeaderPhotoFile);
                    WelcomeHTMLFooterUpdateImage(model.ExitFooterPhotoPath, companyDetailView.ExitSignaturePhotoPathLeft, companyDetailView.ExitSignaturePhotoPath, companyDetailView.ExitPhotoPath, model.FooterPhotoFile);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(PageSetupFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {                    
                    if (model.HeaderPhoto != null)
                    {
                        if (model.ExitHeaderPhotoPath != null)
                        {
                            string filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterHeader", model.ExitHeaderPhotoPath);
                            if (System.IO.File.Exists(filename))
                            {
                                System.IO.File.Delete(filename);
                            }                            
                        }
                        if (model.HeaderPhotoFile != null)
                        {
                            string filenameh = Path.Combine(_hostingEnvironment.WebRootPath, "CenterHeader", model.HeaderPhotoFile);
                            if (System.IO.File.Exists(filenameh))
                            {
                                System.IO.File.Delete(filenameh);
                            }
                        }
                        model.HeaderPhotoFile = ProcessUploadedHeaderFile(model);
                        model.ExitHeaderPhotoPath = ProcessUploadedHeader(model);
                       WelcomeHTMLHeaderUpdateImage(model.ExitHeaderPhotoPath, model.HeaderPhotoFile);
                    }
                    if (model.FooterPhoto != null)
                    {
                        if (model.ExitFooterPhotoPath != null)
                        {
                            string filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterFooter", model.ExitFooterPhotoPath);
                            if (System.IO.File.Exists(filename))
                            {
                                System.IO.File.Delete(filename);
                            }
                            if (model.FooterPhotoFile != null)
                            {
                                string filenameh = Path.Combine(_hostingEnvironment.WebRootPath, "CenterFooter", model.FooterPhotoFile);
                                if (System.IO.File.Exists(filenameh))
                                {
                                    System.IO.File.Delete(filenameh);
                                }
                            }
                        }
                        model.FooterPhotoFile = ProcessUploadedFooterFile(model);
                        model.ExitFooterPhotoPath = ProcessUploadedFooter(model);
                        WelcomeHTMLFooterUpdateImage(model.ExitFooterPhotoPath, companyDetailView.ExitSignaturePhotoPathLeft, companyDetailView.ExitSignaturePhotoPath, companyDetailView.ExitPhotoPath, model.FooterPhotoFile);
                    }
                    istrasferrecord = await _mrepository.UpdatePageSetup(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(PageSetupFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }

        [HttpGet("ReportGroup-File")]
        [Authorize(Policy = "AddEditReportMasterPolicy")]
        public async Task<IActionResult> CreateReportGroupFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            ReportGroupViewModel stateDetailView;
            stateDetailView = id == 0 ? new ReportGroupViewModel() 
            { 
                TempNo = await _mrepository.ReportGroupOrderNo(_softwareConfig.SoftwareMode == true ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 0) 
            } : await _mrepository.GetReportGroupMasterById(id);
            return View(stateDetailView);
        }
        [HttpPost("ReportGroup-File")]
        [Authorize(Policy = "AddEditReportMasterPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReportGroupFile(ReportGroupViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewReportGroupMasterRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateReportGroupFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateReportGroupMaster(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateReportGroupFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("ReportGroup-Delete-File")]
        [Authorize(Policy = "DeleteReportMasterPolicy")]
        public async Task<IActionResult> DeleteReportGroupRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteReportGroupMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateReportGroupFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet("Report-Change-SerialNo-File")]
        //[Authorize(Policy = "AddEditPurchaseFilePolicy")]
        public async Task<IActionResult> CreateReportSerialNoFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = await Task.FromResult(message);
            var model = new TempReportViewFile();
            //model.TempReportDetailViewModels.Add(new TempReportDetailViewModel() { TempSrNo = await Task.FromResult(model.CurrentNo) });                        
            return View(model);
        }
        [HttpPost("Report-Change-SerialNo-File")]        
        //[Authorize(Policy = "AddEditPurchaseFilePolicy")]
        public async Task<IActionResult> CreateReportSerialNoFile(TempReportViewFile model)
        {         
            idno = 0; istrasferrecord = false; _Message = ""; 
            List<ReportGroupViewModel> reportComp  = await _mrepository.GetAllReportGroupMaster((int)(await _userManager.GetUserAsync(User)).CompanyDetailId);
            int currentcount = model.TempReportDetailViewModels.Count();
            if (reportComp.Count() != currentcount)
            {
                ModelState.AddModelError("", "Please Selected Report No. Not Equal--------");
                return View(model);
            }
            if (ModelState.IsValid)
            {                
                    bool  idnoX = await _mrepository.UpdateReportSerialNo(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateReportSerialNoFile), new { id = idno, isSuccess = true, message = _Message });                
            }
            return View(model);
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderSerialNoFileItem([Bind("TempReportDetailViewModels,RptId")] TempReportViewFile order,int rptno)
        {
            ReportGroupViewModel reportGroupViewModel = await _mrepository.GetReportGroupMasterById(Convert.ToInt32(order.RptId));
            order.TempReportDetailViewModels.Add(new  TempReportDetailViewModel()
            {
                TempSrNo = await Task.FromResult(order.CurrentNo), 
                Id = reportGroupViewModel.Id,
                Name = reportGroupViewModel.Name
            });
            return PartialView("_TempReportDetailViewItems", order);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrderSerialNoFileItem([Bind("TempReportDetailViewModels,CompId,RowId")] TempReportViewFile order)
        {          
             order.TempReportDetailViewModels.RemoveAt(await Task.FromResult(order.RowId));                
            return PartialView("_TempReportDetailViewItems", order);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSearchTestFile(int CompId, int TestGroupIdx, string NameX)
        {
            var model = await _mrepository.GetAllTestMasterName(_softwareConfig.SoftwareMode == true ? CompId : 1, TestGroupIdx, NameX);
            return Ok(model);
        }
        [HttpGet("Test-File")]
        [Authorize(Policy = "AddEditTestPolicy")]
        public async Task<IActionResult> CreateTestFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            TestMasterViewModel model = new TestMasterViewModel() { Id = 0};
            //model.TestSubMasterViewModels.Add(new TestSubMasterViewModel() { TempNo = model.CurrentNo,VisualTrueFalse= true ,FromAge =0,UptoAge =0 });
            TestMasterViewModel stateDetailView;
            stateDetailView = id == 0 ? model : await _mrepository.GetTestMasterById(id);
            return View(stateDetailView);
        }
        [HttpPost("Test-File")]
        [Authorize(Policy = "AddEditTestPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTestFile(TestMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewTestMasterRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateTestFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateTestMaster(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateTestFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Test-Delete-File")]
        [Authorize(Policy = "DeleteTestPolicy")]
        public async Task<IActionResult> DeleteTestRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteTestMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(ListSearchTestFile), new { CompId1 = ((int)(await _userManager.GetUserAsync(User)).CompanyDetailId), ReportId = 0, TestGId = 0 });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ResponseCache(Duration = 10, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<ActionResult> DeleteTestSubItem([Bind("TestSubMasterViewModels,Id,RowId")] TestMasterViewModel order)
        {         
            if (order.Id != 0 && order.RowId != 0)
            {
                bool isDelete = await _mrepository.DeleteTestMasterOne(order.Id, order.RowId);
            }
            else
            {
                if (order.RowId != 0)
                {
                    order.TestSubMasterViewModels.RemoveAt(order.RowId);
                }
            }         
            return PartialView("_TestSubMasterViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTestDetailsAddrows([Bind("TestSubMasterViewModels,AddNo")] TestMasterViewModel order)
        {
            for (int i = 0; i < order.AddNo; i++)
            {
                order.TestSubMasterViewModels.Add(new TestSubMasterViewModel()
                { 
                    TempNo = await Task.FromResult(order.CurrentNo),
                    FromAge =0,UptoAge =150,
                    VisualTrueFalse = true
                });
            }
            return PartialView("_TestSubMasterViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTestSubItem([Bind("TestSubMasterViewModels")] TestMasterViewModel order)
        {
            order.TestSubMasterViewModels.Add(new TestSubMasterViewModel() 
            { 
                TempNo = await Task.FromResult(order.CurrentNo), FromAge = 0, UptoAge = 150 ,                
                VisualTrueFalse = true
            });
            return PartialView("_TestSubMasterViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTestSelectedItem([Bind("TestSubMasterViewModels,TempTestIdAdd")] TestMasterViewModel order)
        {           
            List<TestSubMasterViewModel> list = new List<TestSubMasterViewModel>();
            list.AddRange(await _mrepository.GetTestMasterSuId(Convert.ToInt32(order.TempTestIdAdd)));
            foreach (var item in list)
            {
                order.TestSubMasterViewModels.Add(new TestSubMasterViewModel()
                {
                    TestDetails = item.TestDetails,  ColFirst = item.ColFirst, ColSecond = item.ColSecond,
                    ColThird = item.ColThird,  ColFourth = item.ColFourth,  ColFifth = item.ColFifth,
                    ColSixth = item.ColSixth,  VisualTrueFalse = item.VisualTrueFalse, TestLocked = item.TestLocked,
                    Gender = item.Gender, Units = item.Units, FromRange = item.FromRange,  UptoRange = item.UptoRange,
                    RangeSymble = item.RangeSymble,  RangeDetails = item.RangeDetails,  AgeType = item.AgeType,
                    FromAge = item.FromAge, UptoAge = item.UptoAge,  DefaultResult = item.DefaultResult,
                    MiniRange = item.MiniRange,  MaxRange = item.MaxRange,
                    TempNo = await Task.FromResult(order.CurrentNo)
                });
            }            
            return PartialView("_TestSubMasterViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTestBetweenInsertRow([Bind("TestSubMasterViewModels,FromNo,UptoNo,Id,CompId")] TestMasterViewModel order)
        {
            bool insertrowscorrect = await _mrepository.UpdateInsertTestMaster(order.Id, (int)order.FromNo, (int)order.UptoNo,(int)order.CompId);           
            return RedirectToAction(nameof(CreateTestFile), new { id = order.Id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTestBetweenRow([Bind("TestSubMasterViewModels,FromNo")] TestMasterViewModel order)
        {
            TestMasterViewModel testmodel = new TestMasterViewModel();
            testmodel.TestSubMasterViewModels.AddRange(await Task.FromResult(order.TestSubMasterViewModels));

            testmodel.TestSubMasterViewModels.Insert(Convert.ToInt32(order.FromNo), new TestSubMasterViewModel()
            {
                TempNo = 0,
                FromAge = 0,
                UptoAge = 0,
                VisualTrueFalse = true
            });            
            //order.TestSubMasterViewModels.RemoveRange(0,order.TestSubMasterViewModels.Count());
            // order.TestSubMasterViewModels.Clear();
            return PartialView("_TestSubMasterViewItems", testmodel);
        }
        private TestMasterViewModel AddModelList(TestMasterViewModel order)
        {
            int tempno = 1;
            List<TestSubMasterViewModel> list = new List<TestSubMasterViewModel>();
            list.AddRange(order.TestSubMasterViewModels.Where(x => x.TempNo <= order.FromNo));

            List<TestSubMasterViewModel> list2 = new List<TestSubMasterViewModel>();
            list2.AddRange(order.TestSubMasterViewModels.Where(x => x.TempNo > order.FromNo));

            List<TestSubMasterViewModel> AddlistFirst = new List<TestSubMasterViewModel>();
            foreach (var item in list)
            {
                AddlistFirst.Add(new TestSubMasterViewModel()
                {
                    TestDetails = item.TestDetails,
                    ColFirst = item.ColFirst,
                    ColSecond = item.ColSecond,
                    ColThird = item.ColThird,
                    ColFourth = item.ColFourth,
                    ColFifth = item.ColFifth,
                    ColSixth = item.ColSixth,
                    VisualTrueFalse = item.VisualTrueFalse,
                    TestLocked = item.TestLocked,
                    Gender = item.Gender,
                    Units = item.Units,
                    FromRange = item.FromRange,
                    UptoRange = item.UptoRange,
                    RangeSymble = item.RangeSymble,
                    RangeDetails = item.RangeDetails,
                    AgeType = item.AgeType,
                    FromAge = item.FromAge,
                    UptoAge = item.UptoAge,
                    DefaultResult = item.DefaultResult,
                    MiniRange = item.MiniRange,
                    MaxRange = item.MaxRange,
                    TempNo = tempno
                });
                tempno++;
            }

            TestSubMasterViewModel blanklist = new TestSubMasterViewModel()
            {
                TestDetails = "",
                TempNo = tempno,
                VisualTrueFalse = true
            };
            List<TestSubMasterViewModel> AddlistSecond = new List<TestSubMasterViewModel>();

            tempno++;
            foreach (var item in list2)
            {
                AddlistSecond.Add(new TestSubMasterViewModel()
                {
                    TestDetails = item.TestDetails,
                    ColFirst = item.ColFirst,
                    ColSecond = item.ColSecond,
                    ColThird = item.ColThird,
                    ColFourth = item.ColFourth,
                    ColFifth = item.ColFifth,
                    ColSixth = item.ColSixth,
                    VisualTrueFalse = item.VisualTrueFalse,
                    TestLocked = item.TestLocked,
                    Gender = item.Gender,
                    Units = item.Units,
                    FromRange = item.FromRange,
                    UptoRange = item.UptoRange,
                    RangeSymble = item.RangeSymble,
                    RangeDetails = item.RangeDetails,
                    AgeType = item.AgeType,
                    FromAge = item.FromAge,
                    UptoAge = item.UptoAge,
                    DefaultResult = item.DefaultResult,
                    MiniRange = item.MiniRange,
                    MaxRange = item.MaxRange,
                    TempNo = tempno
                });
                tempno++;
            }
            TestMasterViewModel list33 = new TestMasterViewModel();
            list33.TestSubMasterViewModels.AddRange(AddlistFirst);list33.TestSubMasterViewModels.Add(blanklist);
            list33.TestSubMasterViewModels.AddRange(AddlistSecond);
            return list33;
        }        
        [HttpGet("Test-Search-List-File")]
        public async Task<IActionResult> ListSearchTestFile(int CompId1, int ReportId, int TestGId,string TestName)
        {
            ViewBag.CompId1 = CompId1; ViewBag.ReportId = ReportId; 
            ViewBag.TestGId = TestGId; ViewBag.TestName = TestName;
            var model = await _mrepository.GetAllTestMaster(_softwareConfig.SoftwareMode == true ? CompId1:1, ReportId, TestGId, TestName);
            return View(model);
        }
        [HttpGet("DoctorInLab-File")]
        [Authorize(Policy = "AddEditDoctorLabPolicy")]
        public async Task<IActionResult> CreateDoctorInLabsFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            DoctorLabViewModel stateDetailView;
            stateDetailView = id == 0 ? new DoctorLabViewModel() { Id = 0, IPAmt = 0} : await _mrepository.GetDoctorMasterLabById(id);
            return View(stateDetailView);
        }
        [HttpPost("DoctorInLab-File")]
        [Authorize(Policy = "AddEditDoctorLabPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDoctorInLabsFile(DoctorLabViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewDoctorMasterLabRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateDoctorInLabsFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateDoctorMasterLab(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateDoctorInLabsFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("DoctorInLab-Delete-File")]
        [Authorize(Policy = "DeleteDoctorLabPolicy")]
        public async Task<IActionResult> DeleteDoctorInLabsRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteDoctorMasterLab(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateDoctorInLabsFile), new { id = 0, isSuccess = false, message = _Message });
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSearchDoctorFile(int CompId1, string NameX, string MobileX, string CityX)
        {
            var model = await _mrepository.GetAllDoctorMasterName(_softwareConfig.SoftwareMode == true ? CompId1 : 1, NameX, MobileX, CityX);
            return Ok(model);
        }
        [HttpGet("Doctor-File")]
        [Authorize(Policy = "AddEditDoctorPolicy")]
        public async Task<IActionResult> CreateDoctorFile(int id = 0, bool isSuccess = false, string message = "")
        {
            List<TestGroupMasterViewModel> testGroupMasterViewModelsx = await _mrepository.GetAllTestGroupMaster(_softwareConfig.SoftwareMode == true ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 1);
            ViewBag.listCount = testGroupMasterViewModelsx.Count();
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var doctorDetailView = new DoctorViewModel() { Id = 0, Code = await _mrepository.DoctorSrNoCreation(_softwareConfig.SoftwareMode == true ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 1),Address1 ="-",Address2 ="-",MobileNo ="-",Eduction ="-" };
            if (id == 0)
            {
                foreach (var item in testGroupMasterViewModelsx)
                {
                    doctorDetailView.DoctorDetailsMasterViewModel.Add(new DoctorDetailsMasterViewModel()
                    {
                        Id = 0,
                        CompId = item.CompId,
                        TestGId = item.Id,
                        TestGroupMasterViewModel = new TestGroupMasterViewModel()
                        {
                            Name = item.Name,
                            ShortName = item.ShortName
                        },
                        IPPer1 = item.IPPer1,
                        IPAmt1 = item.IPAmt1
                    });
                }
            }
            DoctorViewModel doctorViewModelsx = await _mrepository.GetDoctorMasterById(id);
            if (id != 0)
            {
                foreach (var item in testGroupMasterViewModelsx)
                {
                    var xx = await _mrepository.GetDetailsDoctorMasterById(id, Convert.ToInt32(item.CompId), item.Id);
                    doctorViewModelsx.DoctorDetailsMasterViewModel.Add(new DoctorDetailsMasterViewModel()
                    {
                        Id = 0,
                        CompId = item.CompId,
                        TestGId = item.Id,
                        TestGroupMasterViewModel = new TestGroupMasterViewModel()
                        {
                            Name = item.Name,
                            ShortName = item.ShortName
                        },
                        IPPer1 = xx[0],
                        IPAmt1 = xx[1]
                    });
                }
            }
            DoctorViewModel stateDetailView;
            stateDetailView = id == 0 ? doctorDetailView : doctorViewModelsx;
            return View(stateDetailView);
        }
        [HttpPost("Doctor-File")]
        [Authorize(Policy = "AddEditDoctorPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDoctorFile(DoctorViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewDoctorMasterRecord(model);
                    int idnox = await _mrepository.AddNewDoctorMasterAccountRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateDoctorFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateDoctorMaster(model);
                    bool istrasferrecordx = await _mrepository.UpdateDoctorMasterAccount(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateDoctorFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Doctor-Delete-File")]
        [Authorize(Policy = "DeleteDoctorPolicy")]
        public async Task<IActionResult> DeleteDoctorRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteDoctorMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateDoctorFile), new { id = 0, isSuccess = false, message = _Message });
        }
        // Direct Registration Doctor File
        [HttpGet]
        [Authorize(Policy = "AddEditDoctorPolicy")]
        public async Task<IActionResult> CreateDoctorFileR()
        {
            List<TestGroupMasterViewModel> testGroupMasterViewModelsx = await _mrepository.GetAllTestGroupMaster(_softwareConfig.SoftwareMode == true ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 1);

            DoctorViewModel doctorDetailView = new DoctorViewModel() { 
                   Id = 0, Code = await _mrepository.DoctorSrNoCreation(_softwareConfig.SoftwareMode == true ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 1) ,
                   CompId = _softwareConfig.SoftwareMode == true ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 1,
                   Address1 ="-",Address2 ="-",MobileNo ="-",Eduction="-"
            };
            
                foreach (var item in testGroupMasterViewModelsx)
                {
                    doctorDetailView.DoctorDetailsMasterViewModel.Add(new DoctorDetailsMasterViewModel()
                    {
                        Id = 0,
                        CompId = item.CompId,
                        TestGId = item.Id,
                        TestGroupMasterViewModel = new TestGroupMasterViewModel()
                        {
                            Name = item.Name,
                            ShortName = item.ShortName
                        },
                        IPPer1 = item.IPPer1,
                        IPAmt1 = item.IPAmt1
                    });
                }                      
            return PartialView("_CreateDoctorFileR", doctorDetailView);
        }
        [HttpPost]
        [Authorize(Policy = "AddEditDoctorPolicy")]        
        public async Task<IActionResult> CreateDoctorFileR(DoctorViewModel model)
        {
            idno = 0; 
            if (ModelState.IsValid)
            {
                
                    idno = await _mrepository.AddNewDoctorMasterRecord(model);
                    int idnox = await _mrepository.AddNewDoctorMasterAccountRecord(model);
                return PartialView("_CreateDoctorFileR", model);
            }
            return PartialView("_CreateDoctorFileR", model);
        }
        [HttpGet("TestGroup-File")]
        [Authorize(Policy = "AddEditTestGroupPolicy")]
        public async Task<IActionResult> CreateTestGroupFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            TestGroupMasterViewModel stateDetailView;
            stateDetailView = id == 0 ? new TestGroupMasterViewModel() {Id =0,IPAmt1 =0,IPPer1 =0 } : await _mrepository.GetTestGroupMasterById(id);
            return View(stateDetailView);
        }
        [HttpPost("TestGroup-File")]
        [Authorize(Policy = "AddEditTestGroupPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTestGroupFile(TestGroupMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewTestGroupMasterRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateTestGroupFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateTestGroupMaster(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateTestGroupFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("TestGroup-Delete-File")]
        [Authorize(Policy = "DeleteTestGroupPolicy")]
        public async Task<IActionResult> DeleteTestGroupRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteTestGroupMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateTestGroupFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePatientByCancel(int id, string statusvalue)
        {
            var model = await _mrepository.UpdatePatientMasterCancel(id, statusvalue);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> PatientDateWiseRecord(int cmpid, string patienttype, DateTime fromdate,DateTime uptodate)
        {
            var model = await _mrepository.SearchPatientMasterDateWise(cmpid, "0", patienttype,fromdate, uptodate);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> PatientTodayDateWiseRecord(int cmpid, string patienttype)
        {
            var model = await _mrepository.SearchPatientMasterDateWise(cmpid, "0", patienttype, DateTime.Today,DateTime.Today);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> NewPatientVoucherNo(int cmpid)
        {
            var model = await _mrepository.PatientSrNoCreation(cmpid);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> PatientCurrentDtRefNo(int cmpid, string type, string dt1)
        {
            var model = await _mrepository.PatientRefCreation(cmpid, type, dt1);
            return Ok(model);
        }
        [HttpGet("Registration-File")]
        [Authorize(Policy = "AddEditRegistrationPolicy")]
        public async Task<IActionResult> CreateRegistrationFile(int id = 0, bool isSuccess = false, string message = "")
        {            
            List<TestGroupMasterViewModel> testGroupMasterViewModelsx = await _mrepository.GetAllTestGroupMaster(_softwareConfig.SoftwareMode == true ? (int)((await _userManager.GetUserAsync(User)).CompanyDetailId) :1);
            ViewBag.listCount = testGroupMasterViewModelsx.Count();
            var clientdetails = User.IsInRole("SuperAdmin") || User.IsInRole("Admin") || User.IsInRole("Manager") ? await _mrepository.GetClientDefaultValue(_softwareConfig.SoftwareMode == true ? (int)((await _userManager.GetUserAsync(User)).CompanyDetailId) : 1) : await _mrepository.GetClientById((int)(await _userManager.GetUserAsync(User)).ClientId);
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var model = new PatientViewModel()
            {
                //SDate = await _repository.DateTimeServer(),
                //STime = DateTime.Now.ToString("hh:mm tt"), //await _repository.DateTimeServerTime(),
                //RDate = await _repository.DateTimeServer(),
                //RTime = DateTime.Now.ToString("hh:mm tt"), // await _repository.DateTimeServerTime(),                
                Id = 0,
                CollectionCharge = 0,
                DeliveryCharge = 0,
                MobileNo = "-",
                ClientCode = clientdetails.Id,
                TempPanel = (int)clientdetails.RegPanel,
                ClientName = clientdetails.Name
                //DoctorAcCode = 0
            };
            if (id == 0)
            {
                foreach (var item in testGroupMasterViewModelsx)
                {
                    model.PatientDiscountMasterViewModels.Add(new PatientDiscountMasterViewModel()
                    {
                        Id = 0,
                        CompIdX = (int)item.CompId,
                        TestGId = item.Id,
                        TestGroupMasterViewModel = new TestGroupMasterViewModel()
                        {
                            Name = item.Name
                        },
                        DiscPer1 = 0,
                        DiscAmt1 = 0                       
                    });
                }
            }
            PatientViewModel patientViewModelsx = await _mrepository.GetPatientMasterById(id);
            if (id != 0)
            {
                foreach (var item in testGroupMasterViewModelsx)
                {
                    var xx = await _mrepository.GetDetailsPatientDiscountMasterById(id, Convert.ToInt32(item.CompId), item.Id);
                    patientViewModelsx.PatientDiscountMasterViewModels.Add(new PatientDiscountMasterViewModel()
                    {
                        Id = 0,
                        CompIdX = (int)item.CompId,
                        TestGId = item.Id,
                        TestGroupMasterViewModel = new TestGroupMasterViewModel()
                        {
                            Name = item.Name
                        },
                        DiscPer1 = 0,
                        DiscAmt1 = xx[1]
                    });
                }
            }
            model.PatientDetailsMasterViewModels.Add(new PatientDetailsMasterViewModel() { TempSrNo = model.CurrentNo });
            PatientViewModel detailView;
            detailView = id == 0 ? model : patientViewModelsx;
            return View(detailView);
        }
        [HttpPost("Registration-File")]
        [Authorize(Policy = "AddEditRegistrationPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRegistrationFile(PatientViewModel model)
        {
            var countLastRecord = model.PatientDetailsMasterViewModels.LastOrDefault(x => x.TestMasterViewModels.TestCode == null);
            if (countLastRecord != null)
            {
                model.PatientDetailsMasterViewModels.RemoveAt(countLastRecord.TempSrNo - 1);
            }
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewPatientMaster(model);
                    //int voucherid = await _frepository.TransferPatientToVoucher(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateRegistrationFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdatePatientMaster(model);
                    //bool voucherTrans = await _frepository.TransferPatientToUpdateVoucher(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateRegistrationFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("Registration-Delete-File")]
        [Authorize(Policy = "DeleteRegistrationPolicy")]
        public async Task<IActionResult> DeleteRegistrationRecord(int id)
        {
            _Message = "";
            var PatRecord = await _mrepository.GetPatientMasterById(id);
            var PatRecordMed = await _mrepository.GetMedFileByPtId(id);
            if (PatRecordMed != null)
            {
                if (PatRecordMed.ExitPhotoPath != null)
                {
                    string filename = Path.Combine(_hostingEnvironment.WebRootPath, "MedicalImage", PatRecordMed.ExitPhotoPath);
                    if (System.IO.File.Exists(filename))
                    {
                        System.IO.File.Delete(filename);
                    }
                }
            }
            bool isDeletex = await _mrepository.DeleteMedTestFile(id);
            bool isDelete = await _mrepository.DeletePatientMaster(id);
            bool isDeleteVoucher = await _frepository.DeletePatientVoucher(PatRecord.VNo, PatRecord.UserCode, PatRecord.CompId);
            _Message = "Record Delete Successfully..";
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderItem([Bind("PatientDetailsMasterViewModels")] PatientViewModel order)
        {
            order.PatientDetailsMasterViewModels.Add(new PatientDetailsMasterViewModel() { TempSrNo = await Task.FromResult(order.CurrentNo) });
            return PartialView("_PatientDetailsMasterViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrderItem([Bind("PatientDetailsMasterViewModels,Id,RowId")] PatientViewModel order)
        {
            if (order.Id != 0 && order.RowId != 0)
            {
                bool isDelete = await _mrepository.DeletePatientMasterOne(order.Id, order.RowId);
            }
            else
            {
                if (order.RowId != 0)
                {
                    order.PatientDetailsMasterViewModels.RemoveAt(order.RowId);
                }
            }            
            return PartialView("_PatientDetailsMasterViewItems", order);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindDoctorByLedgerRecord(int cmpid)
        {
            var model = await _mrepository.GetAllDoctorMasterLedger(_softwareConfig.SoftwareMode == true ? cmpid : 1);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindTestRecord(int cmpid, int testgid)
        {
            var model = await _mrepository.GetAllTestMasterGroup(_softwareConfig.SoftwareMode == true ? cmpid : 1);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindTestGroupByShortName(int cmpid,string shortname)
        {
            var model = await _mrepository.GetAllTestGroupMasterName(_softwareConfig.SoftwareMode == true ? cmpid : 1,shortname.ToUpper());
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ApprovedByDoctor(int id, string rptdate)
        {
            var model = await _mrepository.PatientMasterApproved(id,rptdate);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindTestGoupRecord(int cmpid)
        {
            var model = await _mrepository.GetAllTestGroupMaster(_softwareConfig.SoftwareMode == true ? cmpid :1);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetDoctorIP(string doctorid, int cmdid, int testGroupid)
        {
            var model = await _mrepository.GetDetailsDoctorMasterTestGroup(doctorid, _softwareConfig.SoftwareMode == true ? cmdid : 1, testGroupid);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindDoctorAcCode(int doctid)
        {
            var model = await _mrepository.PatientHeadDoctorCode(doctid);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindLedgerCode(string doctid)
        {
            var model = await _mrepository.PatientHeadDoctorId(doctid);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetPatientByVoucherNo(string patientNo)
        {
            var model = await _mrepository.GetPatientMasterByVoucherNo(patientNo);
            return Ok(model);
        }
        //[HttpGet]
        //[Produces("application/json")]
        //public async Task<IActionResult> PatientSearchDateWiseRecord(int CompId1, string userid, string NameX, string MobileX, DateTime FromDt1, DateTime UptoDt1)
        //{
        //    var model = await _mrepository.GetAllPatientMasterName(CompId1, userid, NameX, MobileX, FromDt1, UptoDt1);
        //    return Ok(model);
        //}
        [HttpGet("Patient-Result-File")]
        [Authorize(Policy = "PatientResultPolicy")]
        public async Task<IActionResult> CreatePatientResultFile(int Ptid = 0, int testid = 0, int compid = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess; ViewBag.message = message;
            List<string> vs = await _mrepository.PageSetupTestFormulaApply(compid);
            TempResultViewFile tempResultViewFile = new TempResultViewFile() { PatientId = Ptid, TestListId = testid, CompId = compid,TestFormulaApply = vs[0],FormulaDecimalPlace = Convert.ToInt32(vs[1]) };
            //List<PatientInvestigationViewModel> modeldetail = await _mrepository.GetPatientTestInvestigation(Ptid,testid);
            return View(await Task.FromResult(tempResultViewFile));
        }
        [HttpPost("Patient-Result-File")]
        [Authorize(Policy = "PatientResultPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePatientResultFile(TempResultViewFile order)
        {
            _Message = ""; bool datevalue = await _mrepository.UpdatePatientReportingDate(order.PatientId,order.RptDate);
            //List<PatientDetailsMasterViewModel> detailtestList = await _mrepository.GetPatientTestDetails(order.PatientId, order.CompId);
            //int index = detailtestList.IndexOf(detailtestList.FirstOrDefault(x => x.TestId == order.TestListId));
            List<PatientDetailsMasterViewModel> detailtestList = await _mrepository.GetPatientTestGroupDetails(order.PatientId, order.CompId,"Reading","PathDoc");
            int index = detailtestList.IndexOf(detailtestList.FirstOrDefault(x => x.Id == order.TestListId));
            int prev = index > 0 ? index - 1 : -1;
            int next = index < detailtestList.Count - 1 ? index + 1 : -1;
            //var txtid = detailtestList.Select(x => new { x.TestId, x.TempSrNo }).FirstOrDefault(x => x.TempSrNo == (next < detailtestList.Count ? (next == -1 ? 1 : next + 1) : next));
            var txtid = detailtestList.Select(x => new { x.Id, x.TempSrNo }).FirstOrDefault(x => x.TempSrNo == (next < detailtestList.Count ? (next == -1 ? 1 : next + 1) : next));            
            if (ModelState.IsValid)
            {               
                _Message = "Record Update Successfully..";
                bool istruefalse = await _mrepository.UpdatePatientInvestigation(order);
                //return RedirectToAction(nameof(CreatePatientResultFile), new { Ptid = order.PatientId, testid = txtid.TestId, CompId = order.CompId });
                return RedirectToAction(nameof(CreatePatientResultFile), new { Ptid = order.PatientId, testid = txtid.Id, CompId = order.CompId, isSuccess = true, message = _Message });
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPatientResultItem([Bind("PatientInvestigationViewModels,PatientId,TestListId")]  TempResultViewFile order)
        {
            //List<PatientInvestigationViewModel> listinvestigation = new List<PatientInvestigationViewModel>();
            // listinvestigation = await _mrepository.GetPatientTestInvestigation(order.PatientId, order.TestListId);
            //order.PatientInvestigationViewModels.Clear();           
            order.PatientInvestigationViewModels.AddRange(await _mrepository.GetPatientTestInvestigation(order.PatientId, order.TestListId));
            return PartialView("_PatientInvestigationViewItems", order);
        }
        [HttpGet("Patient-Result-DocFile")]
        public async Task<IActionResult> CreatePatientResultDocFile(int Ptid = 0, int testid = 0, int compid = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess; ViewBag.message = message;

            TempResultViewFile tempResultViewFile = new TempResultViewFile() { PatientId = Ptid, TestListId = testid, CompId = compid };
            //List<PatientInvestigationViewModel> modeldetail = await _mrepository.GetPatientTestInvestigation(Ptid,testid);
            return View(await Task.FromResult(tempResultViewFile));
        }
        [HttpPost("Patient-Result-DocFile")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePatientResultDocFile(TempResultViewFile order)
        {
            _Message = ""; bool datevalue = await _mrepository.UpdatePatientReportingDate(order.PatientId, order.RptDate);
            bool doctorupdateRecord = await _mrepository.UpdatePatientDrInlabMaster(order.PatientId, order.DrInLab);
            List<PatientDetailsMasterViewModel> detailtestList = await _mrepository.GetPatientTestDetails(order.PatientId, order.CompId, "Document");
            int index = detailtestList.IndexOf(detailtestList.FirstOrDefault(x => x.TestId == order.TestListId));
            int prev = index > 0 ? index - 1 : -1;
            int next = index < detailtestList.Count - 1 ? index + 1 : -1;
            //var txtid = detailtestList.Select(x => new { x.TestId, x.TempSrNo }).FirstOrDefault(x => x.TempSrNo == (next < detailtestList.Count ? (next == -1 ? 1 : next + 1) : next));
            var txtid = detailtestList.Select(x => new { x.Id, x.TempSrNo }).FirstOrDefault(x => x.TempSrNo == (next < detailtestList.Count ? (next == -1 ? 1 : next + 1) : next));
            if (ModelState.IsValid)
            {
                _Message = "Record Update Successfully..";
                bool istruefalse = await _mrepository.UpdatePatientInvestigationDoc(order);
                //return RedirectToAction(nameof(CreatePatientResultFile), new { Ptid = order.PatientId, testid = txtid.TestId, CompId = order.CompId });
                return RedirectToAction(nameof(CreatePatientResultDocFile), new { Ptid = order.PatientId, testid = order.TestListId, CompId = order.CompId, isSuccess = true, message = _Message });
            }
            return View();
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> AddResultNewDocMaster(int testid)
        {
            var model = await _mrepository.GetTestDocMasterById(testid);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> AddPatientResultNewDocItem(int testid)
        {
            var model = await _mrepository.GetTestMasterBySubDocId(testid);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> AddListDocumentTest(int cmpid,int testgid)
        {
            var model = await _mrepository.GetAllTestMasterGroup((_softwareConfig.SoftwareMode == true ? cmpid : 1),testgid);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> AddListDocumentTestCount(int cmpid, int testgid)
        {
            var model = await _mrepository.GetAllTestMasterGroupTrueFalse((_softwareConfig.SoftwareMode == true ? cmpid : 1), testgid);
            return Ok(model);
        }
        [HttpGet]        
        [Produces("application/json")]
        public async Task<ActionResult> AddPatientResultDocItem(int ptid, int testid)
        {                      
            var model = await _mrepository.GetPatientTestInvestigationDoc(ptid, testid);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindTestRsult(int testid, string testDetailName)
        {
            var model = await _mrepository.GetTestResultHelp(testid, testDetailName);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindTestMasterDoc(int testid)
        {
            var model = await _mrepository.GetTestMasterById(testid);
            return Ok(model);
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateTestPrintOption(int patid, int testid, bool truefalse)
        {
            bool model = await _mrepository.UpdatePatientPrintOption(patid, testid, truefalse);
            return Ok(model);
        }
        [HttpGet("Test-Result-File")]
        [Authorize(Policy = "AddEditPreResultPolicy")]
        public async Task<IActionResult> CreateTestResultFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var model = new TestResultViewModel();
            model.TestResultDetailViewModels.Add(new TestResultDetailViewModel() { TempNo = model.CurrentNo });
            TestResultViewModel detailView;
            detailView = id == 0 ? model : await _mrepository.GetTestResultById(id);
            return View(detailView);
        }
        [HttpPost("Test-Result-File")]
        [Authorize(Policy = "AddEditPreResultPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTestResultFile(TestResultViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewTestResult(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateTestResultFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateTestResult(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateTestResultFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("TestResult-Delete-File")]
        [Authorize(Policy = "DeletePreResultPolicy")]
        public async Task<IActionResult> DeleteTestResultRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteAgent(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateTestResultFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderTestResultFileItem([Bind("TestResultDetailViewModels")] TestResultViewModel order)
        {
            order.TestResultDetailViewModels.Add(new TestResultDetailViewModel() { TempNo = await Task.FromResult(order.CurrentNo) });
            return PartialView("_TestResultDetailViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrderTestResultFileItem([Bind("TestResultDetailViewModels,Id,RowId")] TestResultViewModel order)
        {
            // int removeIndex = order.PrarupADetailViewModels.FindIndex(o => o.TempSrNo == order.RowId);
            if (order.RowId != 0)
            {
                order.TestResultDetailViewModels.RemoveAt(order.RowId);
            }
            bool isDelete = await _mrepository.DeleteTestResultOne(order.Id, order.RowId);
            //order.PrarupADetailViewModels.RemoveAt(1);
            return PartialView("_TestResultDetailViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTestPreResultALLFileItem([Bind("TestResultDetailViewModels,TestIdX,TestDetailName")] TestResultViewModel order)
        {
            //order.TestResultDetailViewModels.Clear();
            List<TestResultDetailViewModel> listpreresult = await _mrepository.GetTestResultHelp(Convert.ToInt32(order.TestIdX), order.TestDetailName);
            if (listpreresult == null)
            {
                order.TestResultDetailViewModels.Add(new TestResultDetailViewModel() { TempNo = await Task.FromResult(order.CurrentNo) });
            }
            else
            {
                order.TestResultDetailViewModels.AddRange(listpreresult);
            }
            return PartialView("_TestResultDetailViewItems", order);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> TestPreResultFindId(int testid, string testDetailName)
        {
            var model = await _mrepository.GetTestResultFindId(testid, testDetailName);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> TestPreResultList(int testid, string testDetailName)
        {
            var model = await _mrepository.GetTestResultListTestId(testid, testDetailName);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> TestsubList(int testid)
        {
            var model = await _mrepository.GetTestMasterBySubId(testid);
            return Ok(model);
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePageSetupFile(int compid, bool truefalse)
        {
            bool model = await _mrepository.UpdatePageSetupByComp(compid, truefalse);
            return Ok(model);
        }
        [Authorize(Policy = "AdminRolePolicy")]
        [HttpGet("Transfer-Test")]
        public IActionResult CreateTransferTest(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            return View(new TransferTestViewModel());
        }
        [Authorize(Policy = "AdminRolePolicy")]
        [HttpPost("Transfer-Test")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTransferTest(TransferTestViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.FromCompId == model.UptoCompId)
                {
                    istrasferrecord = false;
                    _Message = "Same Center Name Record not transfer ";
                    return RedirectToAction(nameof(CreateTransferTest), new { id = idno, isSuccess = true, message = _Message });

                }
                if (model.UpdateRecord)
                {
                    istrasferrecord = true;
                    idno = await _mrepository.TransferTestOneUserToAnotherUser(model.FromCompId, model.UptoCompId, model.TestId);
                    _Message = "Update Record Successfully..";
                }
                else
                {
                    istrasferrecord = true;
                    idno = await _mrepository.TransferTestOneUserToAnotherUser(model.FromCompId, model.UptoCompId);
                    _Message = "Transfer Record Successfully..";
                }
                //istrasferrecord = true;
                //_Message = "Transfer Record Successfully..";
                return RedirectToAction(nameof(CreateTransferTest), new { id = idno, isSuccess = true, message = _Message });
            }
            return View();
        }        
        [HttpGet("Delete-Patient-Record-BranchWise")]
        public IActionResult CreateDeletePatientRecord(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            return View(new TransferTestViewModel() {UptoDate = DateTime.Today });
        }        
        [HttpPost("Delete-Patient-Record-BranchWise")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDeletePatientRecord(TransferTestViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                List<PatientViewModel> patientViewModels = await _mrepository.GetAllPatientMasterNameByBranchWise(model.FromCompId, model.UptoDate);
               
                if (patientViewModels.Count > 0 )
                {
                    istrasferrecord = true;
                    idno = 0;
                    foreach (var item in patientViewModels)
                    {
                        var PatRecord = await _mrepository.GetPatientMasterById(item.Id);
                        var PatRecordMed = await _mrepository.GetMedFileByPtId(item.Id);
                        if (PatRecordMed != null)
                        {
                            if (PatRecordMed.ExitPhotoPath != null)
                            {
                                string filename = Path.Combine(_hostingEnvironment.WebRootPath, "MedicalImage", PatRecordMed.ExitPhotoPath);
                                if (System.IO.File.Exists(filename))
                                {
                                    System.IO.File.Delete(filename);
                                }
                            }
                        }
                        bool isDeletex = await _mrepository.DeleteMedTestFile(item.Id);
                        bool isDelete = await _mrepository.DeletePatientMaster(item.Id);
                        bool isDeleteVoucher = await _frepository.DeletePatientVoucher(PatRecord.VNo, PatRecord.UserCode, PatRecord.CompId);
                    }
                    _Message = "Patient Record Delete Successfully..";
                }
                else
                {
                    istrasferrecord = true;                    
                    _Message = "Record Not Found............";
                }
                //istrasferrecord = true;
                //_Message = "Transfer Record Successfully..";
                return RedirectToAction(nameof(CreateDeletePatientRecord), new { id = idno, isSuccess = true, message = _Message });
            }
            return View();
        }        
        [HttpGet("Date-Wise-Collection")]
        [Authorize(Policy = "DailyCollectionPrintPolicy")]
        public async Task<IActionResult> DailyCollection()
        {           
            
            return View(new PatientDateViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,UptoDate = DateTime.Today 
            });
            
        }        
        [HttpPost("Date-Wise-Collection")]
        [Authorize(Policy = "DailyCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DailyCollection(PatientDateViewModel model)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("DailyCollectionPrint", "Reporting", model);
            }
            return View();
        }
        [HttpGet("Date-Wise-Summary")]
        [Authorize(Policy = "DailyCollectionPrintPolicy")]
        public async Task<IActionResult> DailySummary()
        {

            return View(new PatientDateViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            });

        }
        [HttpPost("Date-Wise-Summary")]
        [Authorize(Policy = "DailyCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DailySummary(PatientDateViewModel model)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("DailySummaryPrint", "Reporting", model);
            }
            return View();
        }
        [HttpGet("IP-Report-Collection")]
        [Authorize(Policy = "IPCollectionPrintPolicy")]
        public async Task<IActionResult> IPReport()
        {
            return View(new PatientDateViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            });
        }
        [HttpPost("IP-Report-Collection")]
        [Authorize(Policy = "IPCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IPReport(PatientDateViewModel model, string submit)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                if (submit == "Details")
                {
                    return RedirectToAction("IPReportPrint", "Reporting", model);
                }
                else
                {
                    return RedirectToAction("IPSummaryPrint", "Reporting", model);
                }
            }
            return View();
        }
        [HttpGet("Executive-Wise-Collection")]
        [Authorize(Policy = "ExecutiveCollectionPrintPolicy")]
        public async Task<IActionResult> ExecutiveCollection()
        {
            return View(new PatientDateViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            });
        }
        [HttpPost("Executive-Wise-Collection")]
        [Authorize(Policy = "ExecutiveCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExecutiveCollection(PatientDateViewModel model)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("ExecutiveCollectionPrint", "Reporting", model);
            }
            return View();
        }
        [HttpGet("Doctor-Wise-Collection")]
        [Authorize(Policy = "DoctorCollectionPrintPolicy")]
        public async Task<IActionResult> DoctorCollection()
        {
            return View(new PatientDateViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            });
        }
        [HttpPost("Doctor-Wise-Collection")]
        [Authorize(Policy = "DoctorCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorCollection(PatientDateViewModel model)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("DoctorCollectionPrint", "Reporting", model);
            }
            return View();
        }
        [HttpGet("TestGroup-Wise-Collection")]
        [Authorize(Policy = "TestGroupCollectionPrintPolicy")]
        public async Task<IActionResult> TestGroupCollection()
        {
            return View(new PatientDateViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            });
        }
        [HttpPost("TestGroup-Wise-Collection")]
        [Authorize(Policy = "TestGroupCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TestGroupCollection(PatientDateViewModel model)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("TestGroupCollectionPrint", "Reporting", model);
            }
            return View();
        } 
        [HttpGet("Test-Wise-Collection")]
        [Authorize(Policy = "TestCollectionPrintPolicy")]
        public async Task<IActionResult> TestCollection()
        {
            return View(new PatientDateViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            });
        }
        [HttpPost("Test-Wise-Collection")]
        [Authorize(Policy = "TestCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TestCollection(PatientDateViewModel model)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("TestCollectionPrint", "Reporting", model);
            }
            return View();
        }
        [HttpGet("Test-Rate-File")]
        [Authorize(Policy = "AddEditTestRatePolicy")]
        public async Task<IActionResult> CreateTestRateFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var model = new TestRateViewModel();
            var modelx = new List<TestRateDetailViewModel>();            
             modelx = await _mrepository.GetTestRateList(id, (int)(await _userManager.GetUserAsync(User)).CompanyDetailId);
            return View(model);
        }
        [HttpPost("Test-Rate-File")]
        [Authorize(Policy = "AddEditTestRatePolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTestRateFile(TestRateViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    istrasferrecord = await _mrepository.UpdateTestRateList(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateTestRateFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateTestRateList(model);
                    idno = (int)model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateTestRateFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> TotalPageCountTestRate(int testgroupId, int cmpid)
        {
            var model = await _mrepository.GetTestRateList(testgroupId, _softwareConfig.SoftwareMode == true ? cmpid : 1);
             TotalRows = (double) ((decimal)model.Count() / Convert.ToDecimal(DispalRows)) ;
            TotalPageNo = (int)Math.Ceiling(TotalRows);
            return Ok(TotalPageNo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderTestRateFileItem([Bind("TestRateDetailViewModels,Id,TotalPageNo,PageNo,CompId")] TestRateViewModel order)
        {
            List<TestRateDetailViewModel> list = new List<TestRateDetailViewModel>();
            //list.AddRange(await _mrepository.GetTestRateList((int)order.Id, (int)order.CompId));
            // order.TestRateDetailViewModels.AddRange(await _mrepository.GetTestRateList((int)order.Id, _softwareConfig.SoftwareMode == true ? (int)order.CompId : 1));
            var xxx = await _mrepository.GetTestRateList((int)order.Id, _softwareConfig.SoftwareMode == true ? (int)order.CompId : 1);            
            order.PageNo = order.PageNo == 0 ? 1 : order.PageNo > order.TotalPageNo ? order.TotalPageNo : order.PageNo;
            var nn = xxx.Skip((order.PageNo - 1) * DispalRows).Take(DispalRows);
            order.TestRateDetailViewModels.AddRange(nn);
            return PartialView("_TestRateDetailViewItems", order);
        }                
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePatientApproved(int id, string statusvalue)
        {
            var model = await _mrepository.UpdatePatientMasterApproved(id, statusvalue);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePatientIssue(int id, string statusvalue)
        {
            var model = await _mrepository.UpdatePatientMasterIssue(id, statusvalue);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePatientHold(int id, string statusvalue)
        {
            var model = await _mrepository.UpdatePatientMasterHold(id, statusvalue);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePatientRecipt(int id, string statusvalue)
        {
            var model = await _mrepository.UpdatePatientMasterRecipt(id, statusvalue);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePatientDispatch(int id, string statusvalue)
        {
            var model = await _mrepository.UpdatePatientMasterDispatch(id, statusvalue);
            return Ok(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ALLApprovedFileItem([Bind("OpenSearchViewModel,CompId,UserId,MobileNo,sex,CustomerName,Age,Address,EmailAddress,DoctorId,FromDate,UptoDate")] OpenSearchViewModel model)
        {
            var approvedvalue = await _mrepository.UpdateAllPatientMasterResultApproved(model.CompId, model.UserId, model.MobileNo, Convert.ToInt32(model.sex), model.CustomerName, model.Age, model.Address, model.EmailAddress, model.DoctorId, model.FromDate, model.UptoDate);
            return PartialView("_SearchResultApprovedViewItems");
        }
        [HttpGet("Search-Patient-Result")]
        public async Task<IActionResult> ResultSearchRecord(string Search)
        {
            
            var model = new OpenSearchViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = TempData["fromdate"] != null ? Convert.ToDateTime(TempData["fromdate"]) :  DateTime.Today,
                UptoDate = TempData["uptodate"] != null ? Convert.ToDateTime(TempData["uptodate"]) : DateTime.Today,
                SearchRecordFinder =  Search,
                SearchDate =  TempData["dateRecord"] != null ? ( Convert.ToBoolean(TempData["dateRecord"]) == true ? true :false ) : true,
                PaymentType = TempData["searchtype"] != null ? TempData["searchtype"].ToString() : "ALL",
                TestGroupName = TempData["testgroupname"] != null ? TempData["testgroupname"].ToString() : "ALL",
                UserId = User.IsInRole("SuperAdmin") || User.IsInRole("Admin") ? TempData["Username"] != null ? TempData["Username"].ToString() : "ALL" : _userManager.GetUserId(User),
                DoctorId = Convert.ToInt32(TempData["drId"]) > 0 ? Convert.ToInt32(TempData["drId"]) : 0,
                sex = Search == "Yes" ? TempData["genderId"].ToString() != null ? TempData["genderId"].ToString() : "3" : "3",
                PaymentMode = Search == "Yes" ? TempData["paymode"].ToString() != null ? TempData["paymode"].ToString() : "ALL" : "ALL"               
            };
            
            if (Search == "Yes")
            {
                TempData["testgroupname"] = model.TestGroupName;
                TempData["Username"] = model.UserId;
                TempData["drId"] = model.DoctorId;
                TempData["genderId"] = model.sex;
                TempData["paymode"] = model.PaymentMode;
                TempData["dateRecord"] = model.SearchDate;
                TempData["fromdate"] = model.FromDate;
                TempData["uptodate"] = model.UptoDate;
                TempData["searchtype"] = model.PaymentType;
                TempData["searchfilder"] = model.SearchRecordFinder;                
                TempData.Keep();
            }
            return View(model);
        }
        [HttpPost("Search-Patient-Result")]       
        public async Task<IActionResult> ResultSearchRecord(OpenSearchViewModel model,string Search)
        {
            model.SearchRecordFinder = "Yes";
           
            if (ModelState.IsValid)
            {                
                TempData["testgroupname"] = model.TestGroupName;
                TempData["Username"] = model.UserId;
                TempData["drId"] = model.DoctorId;
                TempData["genderId"] =  model.sex;
                TempData["paymode"] = model.PaymentMode;
                TempData["dateRecord"] = model.SearchDate;
                TempData["fromdate"] = model.FromDate;
                TempData["uptodate"] = model.UptoDate;
                TempData["searchtype"] = model.PaymentType;
                TempData["searchfilder"] = model.SearchRecordFinder;                
                TempData.Keep();
                if (Search == "Download")
                {
                    return RedirectToAction("PatientReportPrintMultple", "Reporting",model);
                }
                return View(await Task.FromResult(model));
            }
            return View(model);
        }
        
        public async Task<IActionResult> CustomerEditUserDetailRecord(int itemId)
        {
            List<PatientAuditViewModel> models = new List<PatientAuditViewModel>();
            if (itemId > 0)
            {
                models = await _mrepository.SearchPatientAudit(itemId);
            }
            return PartialView("_CustomerEditUserDetilsRecord", models);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ALLDeletePatientAuditFile([Bind("OpenSearchViewModel,CompId,UserId,FromDate,UptoDate")] OpenSearchViewModel model)
        {
            var approvedvalue = await _mrepository.DeletePatientAuditDetails(model.CompId, model.UserId, model.FromDate, model.UptoDate);
            return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ALLUpdatePatientAuditFile([Bind("OpenSearchViewModel,CompId,UserId,FromDate,UptoDate,ZeroBal")] OpenSearchViewModel model)
        {
            var approvedvalue = await _mrepository.UpdateALLAuditFileForDelete(model.CompId, model.UserId, model.FromDate, model.UptoDate,model.ZeroBal);
            return Ok();
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePatientAuditFile(int id, bool statusvalue)
        {
            var model = await _mrepository.UpdateAuditFileForDelete(id, statusvalue);
            return Ok(model);
        }
        [HttpGet("Patient-Audit-Result")]
        [Authorize(Policy = "AuditFilePrintPolicy")]
        public async Task<IActionResult> SearchAuditRecord()
        {
            var model = new OpenSearchViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            };
            return View(model);
        }
        [HttpPost("Patient-Audit-Result")]
        [Authorize(Policy = "AuditFilePrintPolicy")]
        public async Task<IActionResult> SearchAuditRecord(OpenSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(await Task.FromResult(model));
            }
            return View(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetPatientDetailsFile(string vouchNo)
        {
            var model = await _mrepository.GetPatientMasterByVoucherNo(vouchNo);
            return Ok(model);
        }
        [HttpGet("DueReceipt-File")]
        [Authorize(Policy = "AddEditPatientDueReciptPolicy")]
        public async Task<IActionResult> CreatePatientDueReciptFile(int id = 0,string VoucherNo = "", bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var detailView = id == 0 ? new PatientDueReciptViewModel()
            { 
                //VDate = await _repository.DateTimeServer(),
                VNo = VoucherNo != null ? VoucherNo :"0"
            } 
            : await _mrepository.GetPatientDueReciptMasterById(id);
            return View(detailView);
        }
        [HttpPost("DueReceipt-File")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditPatientDueReciptPolicy")]
        public async Task<IActionResult> CreatePatientDueReciptFile(PatientDueReciptViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    istrasferrecord = await _mrepository.GetPatientMasterValidByReportNo(model.VNo);
                    if (!istrasferrecord)
                    {
                        //ModelState.AddModelError("", "Executive Salary Already Created {0}" + model.VDate);
                        _Message = "Voucher No invalid";
                        return RedirectToAction(nameof(CreatePatientDueReciptFile), new { id = 0, VoucherNo = model.VNo, isSuccess = true, message = _Message });
                    }
                    idno = await _mrepository.AddNewPatientDueReciptMaster(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreatePatientDueReciptFile), new { id = idno, VoucherNo = model.VNo, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdatePatientDueReciptMaster(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreatePatientDueReciptFile), new { id = idno, VoucherNo = model.VNo,isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("PatientDue-Receipt-Delete-File")]
        [Authorize(Policy = "DeletePatientDueReciptPolicy")]
        public async Task<IActionResult> DeletePatientDueReciptFile(int id)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeletePatientDueReciptMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchPatientDueReciptFile));
        }
        [HttpGet("Search-Due-Receipt-File")]
        public async Task<ActionResult> SearchPatientDueReciptFile()
        {
            ViewBag.CompId = 0; ViewBag.userId = await Task.FromResult("X");
            return View(new OpenSearchViewModel() { FromDate = DateTime.Today, UptoDate = DateTime.Today });
        }
        [HttpPost("Search-Due-Receipt-File")]
        public async Task<ActionResult> SearchPatientDueReciptFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = await Task.FromResult(model.UserId);
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet("Patient-Due-Collection")]
        [Authorize(Policy = "DueCollectionPrintPolicy")]
        public async Task<IActionResult> PatientDueCollection()
        {
            return View(new OpenSearchViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            });
        }
        [HttpPost("Patient-Due-Collection")]
        [Authorize(Policy = "DueCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientDueCollection(OpenSearchViewModel model)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("DueReciptCollectionPrint", "Reporting", model);
            }
            return View();
        }
        [HttpGet("Patient-Due-analysis")]
        [Authorize(Policy = "DueAnalysisPrintPolicy")]
        public async Task<IActionResult> PatientDueanalysis()
        {
            var model = new OpenSearchViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            };
            return View(model);
        }
        [HttpPost("Patient-Due-analysis")]
        [Authorize(Policy = "DueAnalysisPrintPolicy")]
        public async Task<IActionResult> PatientDueanalysis(OpenSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(await Task.FromResult(model));
            }
            return View(model);
        }
        [HttpGet("Test-Rate-Print")]
        //[Authorize(Policy = "DailyCollectionPrintPolicy")]
        public async Task<IActionResult> CreateTestRatePrintFile()
        {
            return View(new PatientDateViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            });
        }
        [HttpPost("Test-Rate-Print")]
        //[Authorize(Policy = "DailyCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTestRatePrintFile(PatientDateViewModel model)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("TestRatePrint", "Reporting", model);
            }
            return View();
        }
        [HttpGet("Doctor-List-Print")]
        //[Authorize(Policy = "DailyCollectionPrintPolicy")]
        public async Task<IActionResult> DoctorList()
        {
            return View(new PatientDateViewModel()
            {
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today
            });
        }
        [HttpPost("Doctor-List-Print")]
        //[Authorize(Policy = "DailyCollectionPrintPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorList(PatientDateViewModel model)
        {
            ViewBag.CompId = await Task.FromResult(model.CompId);
            if (ModelState.IsValid)
            {
                return RedirectToAction("DoctorListPrint", "Reporting", model);
            }
            return View();
        }
        [HttpGet("Med-Master-File")]
        [Authorize(Policy = "AddEditMedMasterPolicy")]
        public async Task<IActionResult> CreateMedMasterFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            MedMasterViewModel stateDetailView;
            stateDetailView = id == 0 ? new MedMasterViewModel(): await _mrepository.GetMedMasterById(id);
            return View(stateDetailView);
        }
        [HttpPost("Med-Master-File")]
        [Authorize(Policy = "AddEditMedMasterPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMedMasterFile(MedMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewMedMasterRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateMedMasterFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateMedMaster(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateMedMasterFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("MedMaster-Delete-File")]
        [Authorize(Policy = "DeleteMedMasterPolicy")]
        public async Task<IActionResult> DeleteMedMasterRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteMedMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateMedMasterFile), new { id = 0, isSuccess = false, message = _Message });
        }
        private string ProcessUploadedFile(MedTestViewModel models)
        {
            string uniqueFileName = null;
            if (models.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "MedicalImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + models.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    models.Photo.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
        [HttpGet("Medical-Report-File")]
        [Authorize(Policy = "MedicalResultPolicy")]
        public async Task<IActionResult> CreateMedicalFile(int id = 0, int ptid = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            List<MedMasterViewModel> medMasterViewModel = await _mrepository.GetAllMedMaster((int)(await _userManager.GetUserAsync(User)).CompanyDetailId);
            id = await _mrepository.GetMedFileByPatientId(ptid);
            var model = new MedTestViewModel()
            {
                //STDate = await _repository.DateTimeServer(),
                Id = id,
                PtId = ptid,
                PatHeight =" CM",PatWeight ="Kg.",
                Nationality ="INDIAN",
                MedRemarks ="NORMAL ( NO ACTIVE LUNG LESION IS EVIDENT)",
                DateOfIssue = DateTime.Now.ToString("dd/MM/yyyy"),
                ExamDate = DateTime.Now.ToString("dd/MM/yyyy")
            };
            int x = 1;
            //model.MedTestDetailViewModels.Add(new MedTestDetailViewModel() { TempSrNo = model.CurrentNo });
            foreach (var item in medMasterViewModel)
            {
                model.MedTestDetailViewModels.Add(new MedTestDetailViewModel()
                {
                    TempSrNo =x,
                    TestDetailsA = item.TestDetailsA,
                    PatResultA = item.PatResultA,
                    RangeDetailsA = item.RangeDetailsA,
                    TestLineA = item.TestLineA,
                    TestDetailsB = item.TestDetailsB,
                    PatResultB = item.PatResultB,
                    RangeDetailsB = item.RangeDetailsB,
                    TestLineB = item.TestLineB
                });
                x++;
            }
            MedTestViewModel detailView;
            detailView = id == 0 ? model : await _mrepository.GetMedFileById(id);
            return View(detailView);
        }
        [HttpPost("Medical-Report-File")]
        [Authorize(Policy = "MedicalResultPolicy")]        
        public async Task<IActionResult> CreateMedicalFile(MedTestViewModel model)
        {           
            if (ModelState.IsValid)
            {
                bool datevalue = await _mrepository.UpdatePatientReportingDate((int)model.PtId, model.RptDate);
                if (model.Id == 0)
                {
                    model.ExitPhotoPath = model.Photo != null ? ProcessUploadedFile(model) : null;
                    idno = await _mrepository.AddNewMedFile(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateMedicalFile), new { id = idno,ptid=model.PtId, isSuccess = true, message = _Message });
                }
                else
                {
                    if (model.Photo != null)
                    {
                        if (model.ExitPhotoPath != null)
                        {
                            string filename = Path.Combine(_hostingEnvironment.WebRootPath, "MedicalImage", model.ExitPhotoPath);
                            if (System.IO.File.Exists(filename))
                            {
                                System.IO.File.Delete(filename);
                            }
                        }
                        model.ExitPhotoPath = ProcessUploadedFile(model);
                    }
                    istrasferrecord = await _mrepository.UpdateMedFile(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateMedicalFile), new { id = idno, ptid = model.PtId, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
    }
}