using ITCGKP.Data.Models;
using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.ViewModels;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCGKPLAB.Controllers
{
    [ResponseCache(Duration = 2, Location = ResponseCacheLocation.Client, NoStore = false)]
    public class TransactionController : Controller
    {
        private readonly ISettingRepository _repository;
        //private readonly IMasterRepository _mrepository;
        private readonly IFinancialRepository _frepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        int idno = 0; bool istrasferrecord = false; string _Message = ""; bool detailvailedDate = false;
        public TransactionController(IFinancialRepository financialRepository,
                                     ITransactionRepository transactionRepository,
                                     ISettingRepository settingRepository,
                                     UserManager<ApplicationUser> userManager)
        {

            _frepository = financialRepository;
            _userManager = userManager;
            _transactionRepository = transactionRepository;
            _repository = settingRepository;
        }
        public string userid { get; set; }
        public int cmpId { get; set; }
        [HttpGet("Search-Purchase-File")]
        public async Task<ActionResult> SearchPurchaseFile()
        {
            ViewBag.CompId = 0; ViewBag.userId = null;
            return View(new OpenSearchViewModel() { CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId, FromDate = DateTime.Today, UptoDate = DateTime.Today,SearchRecordFinder ="No" });
        }
        [HttpPost("Search-Purchase-File")]
        public async Task<ActionResult> SearchPurchaseFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId ; ViewBag.userId = await Task.FromResult(model.UserId);
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetPurchaseFileLastItem(int itemId)
        {
            var model = await _transactionRepository.PurchaseDetailFileLastRecord(itemId);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetPurchaseFileSrNo(int cmpId)
        {
            var model = await _transactionRepository.PurchaseSrNoCreation(cmpId);
            return Ok(model);
        }
        [HttpGet("Purchase-File")]
        [Authorize(Policy = "AddEditPurchaseFilePolicy")]
        public async Task<IActionResult> CreatePurchaseFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var model = new PurchaseViewModel()
            {
                //STDate = await _repository.DateTimeServer(),
                TotalAmt = 0,
                DiscAmt = 0,
                CGSTTotalAmt = 0,
                SGSTTotalAmt = 0,
                IGSTTotalAmt = 0,
                OtherAmt1 = 0,
                CessTotalAmt = 0,
                OtherAmt2 = 0,
                CashAmt = 0,
                DigitalAmt = 0
            };
            model.PurchaseDetailViewModels.Add(new PurchaseDetailViewModel() { TempSrNo = model.CurrentNo });
            PurchaseViewModel detailView;
            detailView = id == 0 ? model : await _transactionRepository.GetPurchaseFileById(id);
            return View(detailView);
        }
        [HttpPost("Purchase-File")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditPurchaseFilePolicy")]
        public async Task<IActionResult> CreatePurchaseFile(PurchaseViewModel model)
        {
            var countLastRecord = model.PurchaseDetailViewModels.LastOrDefault(x => x.STItemName == null);
            if (countLastRecord != null)
            {
                model.PurchaseDetailViewModels.RemoveAt(countLastRecord.TempSrNo - 1);
            }
            idno = 0; istrasferrecord = false; _Message = "";
            detailvailedDate = false;
            foreach (var item in model.PurchaseDetailViewModels)
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
                if (model.STId == 0)
                {
                    idno = await _transactionRepository.AddNewPurchaseFile(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreatePurchaseFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _transactionRepository.UpdatePurchaseFile(model);
                    idno = model.STId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreatePurchaseFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("Purchase-Delete-File")]
        [Authorize(Policy = "DeletePurchaseFilePolicy")]
        public async Task<IActionResult> DeletePurchaseFileRecord(int id)
        {
            _Message = "";
            PurchaseViewModel model = await _transactionRepository.GetPurchaseFileById(id);
            bool isDelete = await _transactionRepository.DeletePurchaseFile(model);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchPurchaseFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderPurchaseFileItem([Bind("PurchaseDetailViewModels")] PurchaseViewModel order)
        {
            order.PurchaseDetailViewModels.Add(new PurchaseDetailViewModel() { TempSrNo = await Task.FromResult(order.CurrentNo) });
            return PartialView("_PurchaseDetailViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrderPurchaseFileItem([Bind("PurchaseDetailViewModels,STId,RowId")] PurchaseViewModel order)
        {
            // int removeIndex = order.PrarupADetailViewModels.FindIndex(o => o.TempSrNo == order.RowId);
            if (order.RowId != 0 && order.STId != 0)
            {
                bool isDelete = await _transactionRepository.DeletePurchaseOne(order.STId, order.RowId);
            }
            else {
                if (order.RowId != 0)
                {
                    order.PurchaseDetailViewModels.RemoveAt(order.RowId);
                }
            }
            
            return PartialView("_PurchaseDetailViewItems", order);
        }
        [HttpGet("Search-DebitNote-File")]
        public async Task<ActionResult> SearchDebitNoteFile()
        {
            ViewBag.CompId = 0; ViewBag.userId = null;
            return View(new OpenSearchViewModel() { CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId, FromDate = DateTime.Today, UptoDate = DateTime.Today,SearchRecordFinder ="No" });
        }
        [HttpPost("Search-DebitNote-File")]
        public async Task<ActionResult> SearchDebitNoteFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = await Task.FromResult(model.UserId);
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetDebitNoteFileSrNo(int cmpId)
        {
            var model = await _transactionRepository.PurchaseReturnSrNoCreation(cmpId);
            return Ok(model);
        }
        [HttpGet("Debit-Note-File")]
        [Authorize(Policy = "AddEditDebitNotePolicy")]
        public async Task<IActionResult> CreateDebitNoteFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var model = new PurchaseRViewModel()
            {
                //STDate = await _repository.DateTimeServer(),
                TotalAmt = 0,
                DiscAmt = 0,
                CGSTTotalAmt = 0,
                SGSTTotalAmt = 0,
                IGSTTotalAmt = 0,
                OtherAmt1 = 0,
                CessTotalAmt = 0,
                OtherAmt2 = 0,
                CashAmt = 0,
                DigitalAmt = 0
            };
            model.PurchaseRDetailViewModels.Add(new PurchaseRDetailViewModel() { TempSrNo = model.CurrentNo });
            PurchaseRViewModel detailView;
            detailView = id == 0 ? model : await _transactionRepository.GetPurchaseReturnFileById(id);
            return View(detailView);
        }
        [HttpPost("Debit-Note-File")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditDebitNotePolicy")]
        public async Task<IActionResult> CreateDebitNoteFile(PurchaseRViewModel model)
        {
            var countLastRecord = model.PurchaseRDetailViewModels.LastOrDefault(x => x.STItemName == null);
            if (countLastRecord != null)
            {
                model.PurchaseRDetailViewModels.RemoveAt(countLastRecord.TempSrNo - 1);
            }
            idno = 0; istrasferrecord = false; _Message = "";
            detailvailedDate = false;
            foreach (var item in model.PurchaseRDetailViewModels)
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
                if (model.STId == 0)
                {
                    idno = await _transactionRepository.AddNewPurchaseReturnFile(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateDebitNoteFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _transactionRepository.UpdatePurchaseReturnFile(model);
                    idno = model.STId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateDebitNoteFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("DebitNote-Delete-File")]
        [Authorize(Policy = "DeleteDebitNotePolicy")]
        public async Task<IActionResult> DeleteDebitNoteFileRecord(int id)
        {
            _Message = "";
            PurchaseRViewModel model = await _transactionRepository.GetPurchaseReturnFileById(id);
            bool isDelete = await _transactionRepository.DeletePurchaseReturnFile(model);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchDebitNoteFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderDebiteNoteFileItem([Bind("PurchaseRDetailViewModels")] PurchaseRViewModel order)
        {
            order.PurchaseRDetailViewModels.Add(new PurchaseRDetailViewModel() { TempSrNo = await Task.FromResult(order.CurrentNo) });
            return PartialView("_PurchaseRDetailViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrderDebitNoteFileItem([Bind("PurchaseRDetailViewModels,STId,RowId")] PurchaseRViewModel order)
        {
            // int removeIndex = order.PrarupADetailViewModels.FindIndex(o => o.TempSrNo == order.RowId);
            if (order.RowId != 0 && order.STId != 0)
            {
                bool isDelete = await _transactionRepository.DeletePurchaseReturnOne(order.STId, order.RowId);
            }
            else
            {
                if (order.RowId != 0)
                {
                    order.PurchaseRDetailViewModels.RemoveAt(order.RowId);
                }
            }
            
            return PartialView("_PurchaseRDetailViewItems", order);
        }
        [HttpGet("Search-Order-File")]
        public async Task<ActionResult> SearchOrderFile()
        {
            ViewBag.CompId = 0; ViewBag.userId = null;
            return View(new OpenSearchViewModel() { CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId, FromDate = DateTime.Today, UptoDate = DateTime.Today,SearchRecordFinder ="No" });
        }
        [HttpPost("Search-Order-File")]
        public async Task<ActionResult> SearchOrderFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = await Task.FromResult(model.UserId);
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetOrderFileSrNo(int cmpId)
        {
            var model = await _transactionRepository.PurchaseOrderSrNoCreation(cmpId);
            return Ok(model);
        }
        [HttpGet("Order-File")]
        [Authorize(Policy = "AddEditPurchaseOrderFilePolicy")]
        public async Task<IActionResult> CreateOrderFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var model = new PurchaseOrderViewModel(); // { ODate = await _repository.DateTimeServer() };
            model.PurchaseOrderDetailViewModels.Add(new PurchaseOrderDetailViewModel() { TempSrNo = model.CurrentNo });
            PurchaseOrderViewModel detailView;
            detailView = id == 0 ? model : await _transactionRepository.GetPurchaseOrderFileById(id);
            return View(detailView);
        }
        [HttpPost("Order-File")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditPurchaseOrderFilePolicy")]
        public async Task<IActionResult> CreateOrderFile(PurchaseOrderViewModel model)
        {
            var countLastRecord = model.PurchaseOrderDetailViewModels.LastOrDefault(x => x.SSItemName == null);
            if (countLastRecord != null)
            {
                model.PurchaseOrderDetailViewModels.RemoveAt(countLastRecord.TempSrNo - 1);
            }
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.SOId == 0)
                {
                    idno = await _transactionRepository.AddNewPurchaseOrderFile(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateOrderFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _transactionRepository.UpdatePurchaseOrderFile(model);
                    idno = model.SOId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateOrderFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("Order-Delete-File")]
        [Authorize(Policy = "DeletePurchaseOrderFilePolicy")]
        public async Task<IActionResult> DeleteOrderFileRecord(int id)
        {
            _Message = "";
            PurchaseOrderViewModel model = await _transactionRepository.GetPurchaseOrderFileById(id);
            bool isDelete = await _transactionRepository.DeletePurchaseOrderFile(model);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchOrderFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderFileItem([Bind("PurchaseOrderDetailViewModels")] PurchaseOrderViewModel order)
        {
            order.PurchaseOrderDetailViewModels.Add(new PurchaseOrderDetailViewModel() { TempSrNo = await Task.FromResult(order.CurrentNo) });
            return PartialView("_PurchaseOrderDetailViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrderFileItem([Bind("PurchaseOrderDetailViewModels,SOId,RowId")] PurchaseOrderViewModel order)
        {
            // int removeIndex = order.PrarupADetailViewModels.FindIndex(o => o.TempSrNo == order.RowId);
            if (order.RowId != 0 && order.SOId != 0)
            {
                bool isDelete = await _transactionRepository.DeletePurchaseOrderFileOne(order.SOId, order.RowId);
            }
            else 
            {
                if (order.RowId != 0)
                {
                    order.PurchaseOrderDetailViewModels.RemoveAt(order.RowId);
                }
            }
            
            return PartialView("_PurchaseOrderDetailViewItems", order);
        }
        [HttpGet("Search-Sale-File")]
        public async Task<ActionResult> SearchSaleFile()
        {
            ViewBag.CompId = 0; ViewBag.userId = null;
            return View(new OpenSearchViewModel() { CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId, FromDate = DateTime.Today, UptoDate = DateTime.Today,SearchRecordFinder ="No" });
        }
        [HttpPost("Search-Sale-File")]
        public async Task<ActionResult> SearchSaleFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = await Task.FromResult(model.UserId);
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSaleFileSrNo(int cmpId)
        {
            var model = await _transactionRepository.SaleSrNoCreation(cmpId);
            return Ok(model);
        }
        [HttpGet("Sale-File")]
        [Authorize(Policy = "AddEditSaleFilePolicy")]
        public async Task<IActionResult> CreateSaleFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var model = new SaleViewModel();// { SDate = await _repository.DateTimeServer() };
            model.SaleDetailViewModels.Add(new SaleDetailViewModel() { TempSrNo = model.CurrentNo });
            SaleViewModel detailView;
            detailView = id == 0 ? model : await _transactionRepository.GetSaleFileById(id);
            return View(detailView);
        }
        [HttpPost("Sale-File")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditSaleFilePolicy")]
        public async Task<IActionResult> CreateSaleFile(SaleViewModel model)
        {
            var countLastRecord = model.SaleDetailViewModels.LastOrDefault(x => x.SSItemName == null);
            if (countLastRecord != null)
            {
                model.SaleDetailViewModels.RemoveAt(countLastRecord.TempSrNo - 1);
            }
            idno = 0; istrasferrecord = false; _Message = "";
            detailvailedDate = false;
            foreach (var item in model.SaleDetailViewModels)
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
                if (model.SSId == 0)
                {
                    idno = await _transactionRepository.AddNewSaleFile(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateSaleFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _transactionRepository.UpdateSaleFile(model);
                    idno = model.SSId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateSaleFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("Sale-Delete-File")]
        [Authorize(Policy = "DeleteSaleFilePolicy")]
        public async Task<IActionResult> DeleteSaleFileRecord(int id)
        {
            _Message = "";
            SaleViewModel model = await _transactionRepository.GetSaleFileById(id);
            bool isDelete = await _transactionRepository.DeleteSaleFile(model);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchSaleFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderSaleFileItem([Bind("SaleDetailViewModels")] SaleViewModel order)
        {
            order.SaleDetailViewModels.Add(new SaleDetailViewModel() { TempSrNo = await Task.FromResult(order.CurrentNo) });
            return PartialView("_SaleDetailViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrderSaleFileItem([Bind("SaleDetailViewModels,SSId,RowId")] SaleViewModel order)
        {
            // int removeIndex = order.PrarupADetailViewModels.FindIndex(o => o.TempSrNo == order.RowId);
            if (order.RowId != 0 && order.SSId != 0)
            {
                bool isDelete = await _transactionRepository.DeleteSaleFileOne(order.SSId, order.RowId);
            }
            else 
            {
                if (order.RowId != 0)
                {
                    order.SaleDetailViewModels.RemoveAt(order.RowId);
                }
            }           
            return PartialView("_SaleDetailViewItems", order);
        }
        [HttpGet("Search-CreditNote-File")]
        public async Task<ActionResult> SearchCreditNoteFile()
        {
            ViewBag.CompId = 0; ViewBag.userId = null;
            return View(new OpenSearchViewModel() { CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId, FromDate = DateTime.Today, UptoDate = DateTime.Today,SearchRecordFinder ="No" });
        }
        [HttpPost("Search-CreditNote-File")]
        public async Task<ActionResult> SearchCreditNoteFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = await Task.FromResult(model.UserId);
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetCreditNoteFileSrNo(int cmpId)
        {
            var model = await _transactionRepository.SaleReturnSrNoCreation(cmpId);
            return Ok(model);
        }
        [HttpGet("Credit-Note-File")]
        [Authorize(Policy = "AddEditCreditNotePolicy")]
        public async Task<IActionResult> CreateCreditNoteFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            var model = new SaleRViewModel();// { SDate = await _repository.DateTimeServer() };
            model.SaleRDetailViewModels.Add(new SaleRDetailViewModel() { TempSrNo = model.CurrentNo });
            SaleRViewModel detailView;
            detailView = id == 0 ? model : await _transactionRepository.GetSaleReturnFileById(id);
            return View(detailView);
        }
        [HttpPost("Credit-Note-File")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditCreditNotePolicy")]
        public async Task<IActionResult> CreateCreditNoteFile(SaleRViewModel model)
        {
            var countLastRecord = model.SaleRDetailViewModels.LastOrDefault(x => x.SRItemName == null);
            if (countLastRecord != null)
            {
                model.SaleRDetailViewModels.RemoveAt(countLastRecord.TempSrNo - 1);
            }
            idno = 0; istrasferrecord = false; _Message = "";
            detailvailedDate = false;
            foreach (var item in model.SaleRDetailViewModels)
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
                if (model.SRId == 0)
                {
                    idno = await _transactionRepository.AddNewSaleReturnFile(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateCreditNoteFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _transactionRepository.UpdateSaleReturnFile(model);
                    idno = model.SRId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateCreditNoteFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("CreditNote-Delete-File")]
        [Authorize(Policy = "DeleteCreditNotePolicy")]
        public async Task<IActionResult> DeleteCreditNoteFileRecord(int id)
        {
            _Message = "";
            SaleRViewModel model = await _transactionRepository.GetSaleReturnFileById(id);
            bool isDelete = await _transactionRepository.DeleteSaleReturnFile(model);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchCreditNoteFile), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrderCreditNoteFileItem([Bind("SaleRDetailViewModels")] SaleRViewModel order)
        {
            order.SaleRDetailViewModels.Add(new SaleRDetailViewModel() { TempSrNo = await Task.FromResult(order.CurrentNo) });
            return PartialView("_SaleRDetailViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteOrderCreditNoteFileItem([Bind("SaleRDetailViewModels,SRId,RowId")] SaleRViewModel order)
        {
            // int removeIndex = order.PrarupADetailViewModels.FindIndex(o => o.TempSrNo == order.RowId);
            if (order.RowId != 0 && order.SRId != 0)
            {
                bool isDelete = await _transactionRepository.DeleteSaleReturnFileOne(order.SRId, order.RowId);

            }
            else 
            {
                if (order.RowId != 0)
                {
                    order.SaleRDetailViewModels.RemoveAt(order.RowId);
                }
            }
            //order.PrarupADetailViewModels.RemoveAt(1);
            return PartialView("_SaleRDetailViewItems", order);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetOpenVoucherSrNo(int cmpId, string vtype)
        {
            var model = await _transactionRepository.VoucherSrNoCreation(cmpId, vtype);
            return Ok(model);
        }
        [HttpGet("Search-Voucher-File")]
        public async Task<ActionResult> SearchVoucherFile(string vouchertype)
        {
            ViewBag.CompId = 0; ViewBag.userId = null; ViewBag.VoucherType = vouchertype;
            return View(new OpenSearchViewModel() 
            { 
                VoucherType = vouchertype, CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId, 
                FromDate = DateTime.Today, UptoDate = DateTime.Today ,
                SearchRecordFinder ="No"
            });
        }
        [HttpPost("Search-Voucher-File")]
        public async Task<ActionResult> SearchVoucherFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = model.UserId; 
            ViewBag.VoucherType = await Task.FromResult(model.VoucherType);
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddVoucherItemDetails([Bind("VoucherDetailViewModels")] VoucherViewModel order)
        {
            decimal? dramt = 0; decimal? cramt = 0; decimal? dramtx = 0; decimal? cramtx = 0;
            dramt = order.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Dr).Sum(x => (x.Dr_Amt != null ? x.Dr_Amt : 0));
            cramt = order.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Cr).Sum(x => (x.Cr_Amt != null ? x.Cr_Amt : 0));
            dramtx = cramt > dramt ? cramt - dramt : 0; cramtx = dramt > cramt ? dramt - cramt : 0;
            order.VoucherDetailViewModels.Add(new VoucherDetailViewModel()
            {
                TempSrNo = await Task.FromResult(order.CurrentNo),
                AccountMode = dramt > cramt ? AccountDrCr.Cr : AccountDrCr.Dr,
                Dr_Amt = dramtx,
                Cr_Amt = cramtx
            }); ;
            return PartialView("_VoucherDetailViewItems", order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteVoucherItemDetails([Bind("VoucherDetailViewModels,VId,RowId")] VoucherViewModel order)
        {
            if (order.RowId != 0)
            {
                order.VoucherDetailViewModels.RemoveAt(order.RowId);
            }
            bool isDelete = await _transactionRepository.DeleteVoucherOneRecord(order.VId, order.RowId);
            return PartialView("_VoucherDetailViewItems", order);
        }
        [HttpGet("Receipt-Voucher")]
        [Authorize(Policy = "AddEditCashReciptFilePolicy")]
        public async Task<IActionResult> CreateCashReciptFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            //var model = new VoucherViewModel() { VType = "Receipt", VDate = await _repository.DateTimeServer(), DrAmt = 0, CrAmt = 0 };
            var model = new VoucherViewModel() { VType = "Receipt", DrAmt = 0, CrAmt = 0 };
            model.VoucherDetailViewModels.Add(new VoucherDetailViewModel()
            {
                TempSrNo = model.CurrentNo,
                AccountMode = AccountDrCr.Cr,
                Dr_Amt = 0,
                Cr_Amt = 0
            });
            VoucherViewModel detailView;
            detailView = id == 0 ? model : await _transactionRepository.GetVoucherById(id);
            return View(detailView);
        }
        [HttpPost("Receipt-Voucher")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditCashReciptFilePolicy")]
        public async Task<IActionResult> CreateCashReciptFile(VoucherViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.DrAmt != model.CrAmt)
                {
                    ModelState.AddModelError("", "Debit & Credit not equal......");
                    return View(model);
                }
                if (model.VId == 0)
                {
                    idno = await _transactionRepository.AddNewVoucherRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateCashReciptFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _transactionRepository.UpdateVoucherRecord(model);
                    idno = model.VId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateCashReciptFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("Receipt-Delete-File")]
        [Authorize(Policy = "DeleteCashReciptFilePolicy")]
        public async Task<IActionResult> DeleteCashReciptFile(int id, string vouchertype)
        {
            _Message = "";
            bool isDelete = await _transactionRepository.DeleteVoucherRecord(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchVoucherFile), new { vouchertype = vouchertype });
        }
        [HttpGet("Payment-Voucher")]
        [Authorize(Policy = "AddEditCashPaymentFilePolicy")]
        public async Task<IActionResult> CreateCashPaymentFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            //var model = new VoucherViewModel() { VType = "Payment", VDate = await _repository.DateTimeServer(), DrAmt = 0, CrAmt = 0 };
            var model = new VoucherViewModel() { VType = "Payment", DrAmt = 0, CrAmt = 0 };
            model.VoucherDetailViewModels.Add(new VoucherDetailViewModel()
            {
                TempSrNo = model.CurrentNo,
                AccountMode = AccountDrCr.Dr,
                Dr_Amt = 0,
                Cr_Amt = 0
            });
            VoucherViewModel detailView;
            detailView = id == 0 ? model : await _transactionRepository.GetVoucherById(id);
            return View(detailView);
        }
        [HttpPost("Payment-Voucher")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditCashPaymentFilePolicy")]
        public async Task<IActionResult> CreateCashPaymentFile(VoucherViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.DrAmt != model.CrAmt)
                {
                    ModelState.AddModelError("", "Debit & Credit not equal......");
                    return View(model);
                }
                if (model.VId == 0)
                {
                    idno = await _transactionRepository.AddNewVoucherRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateCashPaymentFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _transactionRepository.UpdateVoucherRecord(model);
                    idno = model.VId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateCashPaymentFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("Payment-Delete-File")]
        [Authorize(Policy = "DeleteCashPaymentFilePolicy")]
        public async Task<IActionResult> DeleteCashPaymentFile(int id, string vouchertype)
        {
            _Message = "";
            bool isDelete = await _transactionRepository.DeleteVoucherRecord(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchVoucherFile), new { vouchertype = vouchertype });
        }
        [HttpGet("Bank-Payment-Voucher")]
        [Authorize(Policy = "AddEditBankPaymentFilePolicy")]
        public async Task<IActionResult> CreateBankPaymentFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            //var model = new VoucherViewModel() { VType = "Bank Payment", VDate = await _repository.DateTimeServer(), DrAmt = 0, CrAmt = 0 };
            var model = new VoucherViewModel() { VType = "Bank Payment", DrAmt = 0, CrAmt = 0 };
            model.VoucherDetailViewModels.Add(new VoucherDetailViewModel()
            {
                TempSrNo = model.CurrentNo,
                AccountMode = AccountDrCr.Dr,
                Dr_Amt = 0,
                Cr_Amt = 0
            });
            VoucherViewModel detailView;
            detailView = id == 0 ? model : await _transactionRepository.GetVoucherById(id);
            return View(detailView);
        }
        [HttpPost("Bank-Payment-Voucher")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditBankPaymentFilePolicy")]
        public async Task<IActionResult> CreateBankPaymentFile(VoucherViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.DrAmt != model.CrAmt)
                {
                    ModelState.AddModelError("", "Debit & Credit not equal......");
                    return View(model);
                }
                if (model.VId == 0)
                {
                    idno = await _transactionRepository.AddNewVoucherRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateBankPaymentFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _transactionRepository.UpdateVoucherRecord(model);
                    idno = model.VId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateBankPaymentFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("Bank-Payment-Delete-File")]
        [Authorize(Policy = "DeleteBankPaymentFilePolicy")]
        public async Task<IActionResult> DeleteBankPaymentFile(int id, string vouchertype)
        {
            _Message = "";
            bool isDelete = await _transactionRepository.DeleteVoucherRecord(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchVoucherFile), new { vouchertype = vouchertype });
        }
        [HttpGet("Bank-Receipt-Voucher")]
        [Authorize(Policy = "AddEditBankReciptFilePolicy")]
        public async Task<IActionResult> CreateBankReciptFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            //var model = new VoucherViewModel() { VType = "Bank Receipt", VDate = await _repository.DateTimeServer(), DrAmt = 0, CrAmt = 0 };
            var model = new VoucherViewModel() { VType = "Bank Receipt", DrAmt = 0, CrAmt = 0 };
            model.VoucherDetailViewModels.Add(new VoucherDetailViewModel()
            {
                TempSrNo = model.CurrentNo,
                AccountMode = AccountDrCr.Cr,
                Dr_Amt = 0,
                Cr_Amt = 0
            });
            VoucherViewModel detailView;
            detailView = id == 0 ? model : await _transactionRepository.GetVoucherById(id);
            return View(detailView);
        }
        [HttpPost("Bank-Receipt-Voucher")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditBankReciptFilePolicy")]
        public async Task<IActionResult> CreateBankReciptFile(VoucherViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.DrAmt != model.CrAmt)
                {
                    ModelState.AddModelError("", "Debit & Credit not equal......");
                    return View(model);
                }
                if (model.VId == 0)
                {
                    idno = await _transactionRepository.AddNewVoucherRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateBankReciptFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _transactionRepository.UpdateVoucherRecord(model);
                    idno = model.VId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateBankReciptFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("Bank-Receipt-Delete-File")]
        [Authorize(Policy = "DeleteBankReciptFilePolicy")]
        public async Task<IActionResult> DeleteBankReciptFile(int id, string vouchertype)
        {
            _Message = "";
            bool isDelete = await _transactionRepository.DeleteVoucherRecord(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchVoucherFile), new { vouchertype = vouchertype });
        }
        [HttpGet("Ledger-File")]
        public async Task<ActionResult> SearchLedgerFile(string vouchertype)
        {
            ViewBag.CompId = 0; ViewBag.userId = null; ViewBag.VoucherType = vouchertype;
            return View(new OpenSearchViewModel()
            { 
                VoucherType = vouchertype,
                CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId, 
                FromDate = DateTime.Today, UptoDate = DateTime.Today,SearchRecordFinder ="No" });
        }
        [HttpPost("Ledger-File")]
        public async Task<ActionResult> SearchLedgerFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = model.UserId; 
            ViewBag.VoucherType = await Task.FromResult(model.VoucherType);
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
    }
}