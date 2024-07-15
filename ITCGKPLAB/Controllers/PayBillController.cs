using ITCGKP.Data.Models;
using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.PayBill;
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
    public class PayBillController : Controller
    {
        private readonly IPayBillRepository _prepository = null;
        private readonly ISettingRepository _repository = null;
        private readonly IMasterRepository _mrepository = null;
        private readonly UserManager<ApplicationUser> _userManager;
        int idno = 0; bool istrasferrecord = false; string _Message = "";
        public PayBillController(IMasterRepository MasterRepository,
                                 ISettingRepository SettingRepository,
                                 IPayBillRepository payBillRepository,
                                 UserManager<ApplicationUser> userManager)
        {
            _mrepository = MasterRepository;
            _repository = SettingRepository;
            _prepository = payBillRepository;
            _userManager = userManager;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAgentDetailsFile(int id)
        {
            var model = await _mrepository.GetAgentById(id);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAgentDetailsBasicAmtFile(int id, string uptoDate)
        {
            var model = await _prepository.GetPayBillByEmpId(id, uptoDate);
            return Ok(model);
        }
        [HttpGet("PayBill-File")]
        [Authorize(Policy = "AddEditSalaryFilePolicy")]
        public async Task<IActionResult> CreatePayBillFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            //var detailView = id == 0 ? new UpdatePayBillViewModel() { VDate = await _repository.DateTimeServer() } : await _prepository.GetPayBillById(id);
            var detailView = id == 0 ? new UpdatePayBillViewModel() : await _prepository.GetPayBillById(id);
            return View(detailView);
        }
        [HttpPost("PayBill-File")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AddEditSalaryFilePolicy")]
        public async Task<IActionResult> CreatePayBillFile(UpdatePayBillViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    istrasferrecord = await _prepository.PayBillByEmpIdValid((int)model.EmpId, model.VDate);
                    if (istrasferrecord)
                    {
                        //ModelState.AddModelError("", "Executive Salary Already Created {0}" + model.VDate);
                        _Message = "Executive Salary Already Created";
                        return RedirectToAction(nameof(CreatePayBillFile), new { id = 0, isSuccess = true, message = _Message });
                    }
                    idno = await _prepository.AddNewPayBillRecord(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreatePayBillFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _prepository.UpdatePayBillRecord(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreatePayBillFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View(model);
        }
        [Route("PayBill-Delete-File")]
        [Authorize(Policy = "DeleteSalaryFilePolicy")]
        public async Task<IActionResult> DeletePayBillFile(int id)
        {
            _Message = "";
            bool isDelete = await _prepository.DeletePayBillRecord(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(SearchPayBillFile));
        }
        [HttpGet("Search-PayBill-File")]
        public async Task<ActionResult> SearchPayBillFile()
        {
            ViewBag.CompId = 0; ViewBag.userId = null;
            return View(new OpenSearchViewModel() {CompId = (int)(await _userManager.GetUserAsync(User)).CompanyDetailId, FromDate = DateTime.Today, UptoDate = DateTime.Today,SearchRecordFinder ="No" });
        }
        [HttpPost("Search-PayBill-File")]
        public async Task<ActionResult> SearchPayBillFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = await Task.FromResult(model.UserId);
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        [HttpGet("Automation-PayBill-File")]
        [Authorize(Policy = "AddEditSalaryFilePolicy")]
        public async Task<ActionResult> AutomationPayBillFile(bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            ViewBag.CompId = 0; ViewBag.userId = null;
            return View(new OpenSearchViewModel() { PayUptoDate = await _repository.DateTimeServer() });
        }
        [HttpPost("Automation-PayBill-File")]
        [Authorize(Policy = "AddEditSalaryFilePolicy")]
        public async Task<ActionResult> AutomationPayBillFile(OpenSearchViewModel model)
        {
            ViewBag.CompId = model.CompId; ViewBag.userId = model.UserId;
            if (ModelState.IsValid)
            {
                istrasferrecord = await _prepository.PayBillByMonthValid(model.PayUptoDate);
                if (istrasferrecord)
                {
                    ModelState.AddModelError("", "Salary Alread Created Month " + model.PayUptoDate);
                    return View(model);
                }
                idno = await _prepository.AutomationPayBill(model);
                _Message = "Salary Create Successfully..";
                return RedirectToAction(nameof(AutomationPayBillFile), new { isSuccess = true, message = _Message });
            }
            return View(model);
        }
        [Route("PayBill-Month-Delete-File")]
        [Authorize(Policy = "DeleteSalaryFilePolicy")]
        public async Task<IActionResult> DeletePayBillFileMonth(string fromUptoDate)
        {
            _Message = "";
            bool isDelete = await _prepository.DeletePayBillOneMonthRecord(fromUptoDate);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(AutomationPayBillFile));
        }
        [HttpGet("Automation-PayBill-ALL-File")]
        [Authorize(Policy = "SalaryBillPrintFilePolicy")]
        public async Task<ActionResult> ALLPayBillFile()
        {
            return View(new OpenSearchViewModel() { PayUptoDate = await _repository.DateTimeServer() });
        }
        [HttpGet("PayBill-Monthly-Sheet")]
        [Authorize(Policy = "MonthlySalarySheetPrintFilePolicy")]
        public async Task<ActionResult> MonthlySheetPayBillFile()
        {
            return View(new OpenSearchViewModel() { PayUptoDate = await _repository.DateTimeServer() });
        }
        [HttpGet("Executive-Monthly-List")]
        [Authorize(Policy = "MonthlyExecutivePrintFilePolicy")]
        public async Task<ActionResult> ExecutiveMonthlyPayBillFile()
        {
            ViewBag.searchDate = await _repository.DateTimeServer();
            return View(new OpenSearchViewModel() { PayUptoDate = await _repository.DateTimeServer() });
        }
        [HttpPost("Executive-Monthly-List")]
        [Authorize(Policy = "MonthlyExecutivePrintFilePolicy")]
        public async Task<ActionResult> ExecutiveMonthlyPayBillFile(OpenSearchViewModel model)
        {
            ViewBag.searchDate = await Task.FromResult( model.PayUptoDate);
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
        [HttpGet("Executive-Monthly-BankStatement")]
        [Authorize(Policy = "MonthlyBankStatementPrintFilePolicy")]
        public async Task<ActionResult> ExecutiveMonthlyBankStatement()
        {
            ViewBag.searchDate = await _repository.DateTimeServer();
            return View(new OpenSearchViewModel() { PayUptoDate = await _repository.DateTimeServer() });
        }
        [HttpPost("Executive-Monthly-BankStatement")]
        [Authorize(Policy = "MonthlyBankStatementPrintFilePolicy")]
        public async Task<ActionResult> ExecutiveMonthlyBankStatement(OpenSearchViewModel model)
        {
            ViewBag.searchDate = await Task.FromResult( model.PayUptoDate);
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }
        [HttpGet("Executive-Monthly-Deductation")]
        [Authorize(Policy = "MonthlyDeductationPrintFilePolicy")]
        public async Task<ActionResult> ExecutiveMonthlyDeductation()
        {
            ViewBag.searchDate = await _repository.DateTimeServer();
            return View(new OpenSearchViewModel() { PayUptoDate = await _repository.DateTimeServer() });
        }
        [HttpPost("Executive-Monthly-Deductation")]
        [Authorize(Policy = "MonthlyDeductationPrintFilePolicy")]
        public async Task<ActionResult> ExecutiveMonthlyDeductation(OpenSearchViewModel model)
        {
            ViewBag.searchDate = await Task.FromResult( model.PayUptoDate);
            if (ModelState.IsValid)
            {
                return View();
            }
            return View();
        }

    }
}
