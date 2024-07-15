using ITCGKP.Data.Models;
using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
using ITCGKPLAB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCGKPLAB.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,Manager,User")]
    public class FinancialController : Controller
    {
        private readonly ISettingRepository _repository = null;
        private readonly IFinancialRepository _mrepository = null;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SoftwareConfigMode _softwareConfig;
        int idno = 0; bool istrasferrecord = false; string _Message = "";
        public FinancialController(ISettingRepository SettingRepository,
                                    UserManager<ApplicationUser> userManager, 
                                    IFinancialRepository MasterRepository, 
                                    IOptions<SoftwareConfigMode> softwareConfig)
        {
            _repository = SettingRepository;
            _mrepository = MasterRepository;
            _userManager = userManager;
            _softwareConfig = softwareConfig.Value;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetItemBalanceRecordAdd(int itemid, int cmpid)
        {
            var model = await _mrepository.ItemBalanceAutomationAdd(itemid,_softwareConfig.SoftwareMode == true ? cmpid : 1);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindAccountRecord(int CompId)
        {
            var model = await _mrepository.GetLedgerHelpFile(_softwareConfig.SoftwareMode == true ? CompId : 1);
            return Ok(model);
        }
        public string userid { get; set; }
        public int cmpId { get; set; }
        [HttpGet("Account-Group-File")]
        [Authorize(Policy = "AddEditAccountGroupPolicy")]
        public async Task<IActionResult> AccountGroupFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            AccountGroupViewModel detailView;
            detailView = id <= 0 ? new AccountGroupViewModel() { HDGCode = await _mrepository.HeadGroupSrNoCreation() } : await _mrepository.GetAccountGroupMasterById(id);
            return View(detailView);
        }
        [HttpPost("Account-Group-File")]
        [Authorize(Policy = "AddEditAccountGroupPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AccountGroupFile(AccountGroupViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewAccountGroupMaster(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(AccountGroupFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateAccountGroupMaster(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(AccountGroupFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("AccountGroup-Delete-File")]
        [Authorize(Policy = "DeleteAccountGroupPolicy")]
        public async Task<IActionResult> DeleteAccountGroupRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteAccountGroupMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(AccountGroupFile), new { id = 0, isSuccess = false, message = _Message });
        }
        
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductHSNCode(int id)
        {
            var model = await _mrepository.GetItemGroupById(id);
            return Ok(model);
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> AccountGroupGetSearchValue(string Prefix)
        {
            var model = await _mrepository.SearchAccountGroupUnderName(Prefix);
            return Ok(model);
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAddressSrNo(int cmpid)
        {
            var model = await _mrepository.AddressSrNoCreation(_softwareConfig.SoftwareMode == true ? cmpid : 1);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetGroupExpIncomeFile(int id)
        {
            var model = await _mrepository.GetAccountGroupMasterById(id);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetStateFile(int cmpid)
        {
            var model = await _repository.GetCompanyById(_softwareConfig.SoftwareMode == true ? cmpid : 1);
            return Ok(model);
        }
        [HttpGet("AddressBook-File")]
        [Authorize(Policy = "AddEditAccountMasterPolicy")]
        public async Task<IActionResult> AddressBookFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            LedgerMasterViewModel detailView;
            detailView = id <= 0 ? new LedgerMasterViewModel() { LedCode = await _mrepository.AddressSrNoCreation((int)(await _userManager.GetUserAsync(User)).CompanyDetailId) } : await _mrepository.GetAddressMasterById(id);
            return View(detailView);
        }
        [HttpPost("AddressBook-File")]
        [Authorize(Policy = "AddEditAccountMasterPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddressBookFile(LedgerMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.LedgerMasterId == 0)
                {
                    idno = await _mrepository.AddNewAddressMasterRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(AddressBookFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateAddressMaster(model);
                    idno = model.LedgerMasterId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(AddressBookFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("AddressBook-Delete-File")]
        [Authorize(Policy = "DeleteAccountMasterPolicy")]
        public async Task<IActionResult> DeleteAddressBookFile(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteAddressMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(AddressBookFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSearchAddressFile(int CompId1, string NameX = "", string MobileX = "", string CityX = "")
        {
            var model = await _mrepository.GetAllAddressMasterName(_softwareConfig.SoftwareMode == true ? CompId1 : 1, NameX, MobileX, CityX);
            return Ok(model);
        }
        public async Task<IActionResult> AccountConfigureList()
        {
            List<AccountConfigViewModel> companyDetailViewModels = await _mrepository.GetALLAccountConfig(_softwareConfig.SoftwareMode == true ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 1);
            return View(companyDetailViewModels);
        }
        [HttpGet("Account-Configuration-File")]
        [Authorize(Policy = "AddEditAccountConfigurationFilePolicy")]
        public async Task<IActionResult> CreateAccountConfigurationFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            AccountConfigViewModel stateDetailView;
            stateDetailView = id == 0 ? new AccountConfigViewModel() : await _mrepository.GetAccountConfigById(id);
            return View(stateDetailView);
        }
        [HttpPost("Account-Configuration-File")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditAccountConfigurationFilePolicy")]
        public async Task<IActionResult> CreateAccountConfigurationFile(AccountConfigViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewAccountConfigMasterRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateAccountConfigurationFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateAccountConfig(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateAccountConfigurationFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ProductCompanyDetailSearchRecord(string NameX = "")
        {
            var models = await _mrepository.GetAllProductCompanyName(NameX);
            return Ok(models);
        }
        [HttpGet("Product-Company-File")]
        [Authorize(Policy = "AddEditProductCompanyPolicy")]
        public async Task<IActionResult> CreateProductCompanyFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            ProductCompanyViewModel stateDetailView;
            stateDetailView = id == 0 ? new ProductCompanyViewModel() { ProdCode = await _mrepository.ProductCompanySrNoCreation() } : await _mrepository.GetProductCompanyById(id);
            return View(stateDetailView);
        }
        [HttpPost("Product-Company-File")]
        [Authorize(Policy = "AddEditProductCompanyPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductCompanyFile(ProductCompanyViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.ProdId == 0)
                {
                    idno = await _mrepository.AddNewProductCompanyRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateProductCompanyFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateProductCompany(model);
                    idno = model.ProdId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateProductCompanyFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Product-Company-Delete-File")]
        [Authorize(Policy = "DeleteProductCompanyPolicy")]
        public async Task<IActionResult> DeleteProductCompanyRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteProductCompany(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateProductCompanyFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet("Unit-Measurement-File")]
        [Authorize(Policy = "AddEditUnitMeasurementPolicy")]
        public async Task<IActionResult> CreateUnitMeasurementFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            UnitMeasurementViewModel stateDetailView;
            stateDetailView = id == 0 ? new UnitMeasurementViewModel() { UnitCode = await _mrepository.ProductMeasurementSrNoCreation() } : await _mrepository.GetProductMeasurementById(id);
            return View(stateDetailView);
        }
        [HttpPost("Unit-Measurement-File")]
        [Authorize(Policy = "AddEditUnitMeasurementPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUnitMeasurementFile(UnitMeasurementViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewProductMeasurementRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateUnitMeasurementFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateProductMeasurement(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateUnitMeasurementFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Unit-Measurement-Delete-File")]
        [Authorize(Policy = "DeleteUnitMeasurementPolicy")]
        public async Task<IActionResult> DeleteUnitMeasurementRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteProductMeasurement(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateUnitMeasurementFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet("UQC-File")]
        [Authorize(Policy = "AddEditUnitQuantityPolicy")]
        public async Task<IActionResult> CreateUQCFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            UQCMasterViewModel stateDetailView;
            stateDetailView = id == 0 ? new UQCMasterViewModel() { Id = 0 } : await _mrepository.GetUQCById(id);
            return View(stateDetailView);
        }
        [HttpPost("UQC-File")]
        [Authorize(Policy = "AddEditUnitQuantityPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUQCFile(UQCMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewUQCRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateUQCFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateUQC(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateUQCFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("UQC-Delete-File")]
        [Authorize(Policy = "DeleteUnitQuantityPolicy")]
        public async Task<IActionResult> DeleteUQCRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteUQC(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateUQCFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> PackingDetailSearchRecord(string NameX = "")
        {
            var models = await _mrepository.GetALLPackingMasterName(NameX);
            return Ok(models);
        }
        [HttpGet("Packing-File")]
        [Authorize(Policy = "AddEditProductMasterPolicy")]
        public async Task<IActionResult> CreatePackingFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            PackingMasterViewModel stateDetailView;
            stateDetailView = id == 0 ? new PackingMasterViewModel() { PackCode = await _mrepository.PackingSrNoCreation() } : await _mrepository.GetPackingMasterById(id);
            return View(stateDetailView);
        }
        [HttpPost("Packing-File")]
        [Authorize(Policy = "AddEditProductMasterPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePackingFile(PackingMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.PackId == 0)
                {
                    idno = await _mrepository.AddNewPackingRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreatePackingFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdatePackingMaster(model);
                    idno = model.PackId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreatePackingFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Packing-Delete-File")]
        [Authorize(Policy = "DeleteProductMasterPolicy")]
        public async Task<IActionResult> DeletePackingRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeletePackingMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreatePackingFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetPackingHSNCode(int cmpid)
        {
            var model = await _mrepository.GetPackingMasterById(_softwareConfig.SoftwareMode == true ? cmpid : 1);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ItemGroupDetailSearchRecord(string NameX = "")
        {
            var models = await _mrepository.GetAllItemGroupByName(NameX);
            return Ok(models);
        }
        [HttpGet("ItemGroup-File")]
        [Authorize(Policy = "AddEditItemGroupPolicy")]
        public async Task<IActionResult> CreateItemGroupFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            ItemGroupViewModel stateDetailView;
            stateDetailView = id == 0 ? new ItemGroupViewModel() { ItGPCode = await _mrepository.ItemGroupSrNoCreation() } : await _mrepository.GetItemGroupById(id);
            return View(stateDetailView);
        }
        [HttpPost("ItemGroup-File")]
        [Authorize(Policy = "AddEditItemGroupPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItemGroupFile(ItemGroupViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _mrepository.AddNewItemGroupRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateItemGroupFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateItemGroup(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateItemGroupFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("ItemGroup-Delete-File")]
        [Authorize(Policy = "DeleteItemGroupPolicy")]
        public async Task<IActionResult> DeleteItemGroupRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteItemGroup(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateItemGroupFile), new { id = 0, isSuccess = false, message = _Message });
        }       
      
        [HttpGet("Item-File")]
        [Authorize(Policy = "AddEditItemMasterPolicy")]
        public async Task<IActionResult> CreateItemFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            ItemMasterViewModel stateDetailView;
            stateDetailView = id == 0 ? new ItemMasterViewModel() 
            { 
                ItemCode = await _mrepository.ItemSrNoCreation(),
                UnitCase = 1,
                DiscPer = 0,
                GSTPer = 0,
                CessPer = 0,
                ProfitPer = 0
            } 
            : await _mrepository.GetItemMasterById(id);
            return View(stateDetailView);
        }
        [HttpPost("Item-File")]
        [Authorize(Policy = "AddEditItemMasterPolicy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItemFile(ItemMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.ItemId == 0)
                {
                    idno = await _mrepository.AddNewItemMasterRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateItemFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateItemMaster(model);
                    idno = model.ItemId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateItemFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Item-Delete-File")]
        [Authorize(Policy = "DeleteItemMasterPolicy")]
        public async Task<IActionResult> DeleteItemRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _mrepository.DeleteItemMaster(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateItemFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ItemDetailSearchRecord(int ItemGroupId = 0, int ProdCodeX = 0, string NameX = "", string ProdCompCordX = "", string HSNCodeX = "")
        {
            var models = await _mrepository.GetALLItemMasterName(ItemGroupId, ProdCodeX, NameX, ProdCompCordX, HSNCodeX);
            return Ok(models);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> FindItemRecord()
        {
            var model = await _mrepository.SearchItemMasterName("");
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetOpenItemSrNo(int cmpId)
        {
            var model = await _mrepository.OpnSrNoCreation(cmpId);
            return Ok(model);
        }
        [HttpGet("Openning-Item-File")]
        [Authorize(Policy = "AddEditOpenningStockPolicy")]
        public async Task<IActionResult> CreateOpenningItem(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var model = new OpenItemMasterViewModel();// { OpnDate = await _repository.DateTimeServer() };
            model.OpenItemMasterDetailViewModels.Add(new OpenItemMasterDetailViewModel() { TempSrNo = model.CurrentNo });
            OpenItemMasterViewModel detailView;
            detailView = id == 0 ? model : await _mrepository.GetOpenItemMasterById(id);
            return View(detailView);
        }
        [HttpPost("Openning-Item-File")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditOpenningStockPolicy")]
        public async Task<IActionResult> CreateOpenningItem(OpenItemMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            bool detailvailedDate = false;
            foreach (var item in model.OpenItemMasterDetailViewModels)
            {
                detailvailedDate = await _repository.IsExpDateValied(item.ExpDate);
                if (!detailvailedDate)
                {
                    break;
                }
            }
            if (!detailvailedDate)
            {
                ModelState.AddModelError("", "Please Enter Expire Date Field vailided--------");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                if (model.OpnId == 0)
                {
                    idno = await _mrepository.AddNewOpenItemMaster(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateOpenningItem), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _mrepository.UpdateOpenItemMaster(model);
                    idno = model.OpnId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateOpenningItem), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("OpenningItem-Delete-File")]
        [Authorize(Policy = "DeleteOpenningStockPolicy")]
        public async Task<IActionResult> DeleteOpenningItemRecord(int id)
        {
            _Message = "";
            OpenItemMasterViewModel model = await _mrepository.GetOpenItemMasterById(id);
            bool isDelete = await _mrepository.DeleteOpenItemMaster(model);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchOpenningItemFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderItem([Bind("OpenItemMasterDetailViewModels")] OpenItemMasterViewModel order)
        {
            order.OpenItemMasterDetailViewModels.Add(new OpenItemMasterDetailViewModel() { TempSrNo = await Task.FromResult(order.CurrentNo) });
            return PartialView("_OpenItemMasterDetailViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrderItem([Bind("OpenItemMasterDetailViewModels,OpnId,RowId")] OpenItemMasterViewModel order)
        {
            if (order.RowId != 0 && order.OpnId != 0)
            {
                bool isDelete = await _mrepository.DeleteOpenItemMasterOne(order.OpnId, order.RowId);
            }
            else {
                if (order.RowId != 0)
                {
                    order.OpenItemMasterDetailViewModels.RemoveAt(order.RowId);
                }
            }            
            return PartialView("_OpenItemMasterDetailViewItems", order);
        }
        [HttpGet("Search-Openning-Item-File")]
        public ActionResult SearchOpenningItemFile()
        {
            ViewBag.CompId = 0; ViewBag.userId = null;
            return View(new OpenSearchViewModel() { CompId = cmpId, FromDate = DateTime.Today, UptoDate = DateTime.Today,SearchRecordFinder ="No" });
        }
        [HttpPost("Search-Openning-Item-File")]
        public ActionResult SearchOpenningItemFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = model.UserId;
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetItemBalanceRecordHelp(int itemid, int cmpid)
        {
            var model = await _mrepository.SearchItemBalanceByItemId(itemid,_softwareConfig.SoftwareMode == true ? cmpid : 1);
            return Ok(model);
        }
        [HttpGet("Item-Stock-File")]
        [Authorize(Policy = "StockSummaryPrintPolicy")]
        public async Task<ActionResult> ItemStockFile()
        {
            ViewBag.CompId = 0; ViewBag.ProdComp = 0; ViewBag.PackId = 0; ViewBag.itemgroupId = 0;
            return View(new OpenSearchViewModel() { CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId, FromDate = DateTime.Today, UptoDate = DateTime.Today });
        }
        [HttpPost("Item-Stock-File")]
        [Authorize(Policy = "StockSummaryPrintPolicy")]
        public ActionResult ItemStockFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.ProdComp = model.ProdId;
            ViewBag.PackId = model.PackId; ViewBag.itemgroupId = model.ItemGroupId;
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
    }
}
