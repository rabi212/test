using ITCGKP.Data.Services.NewUpdateDeleteData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCGKPLAB.Controllers
{
    public class DateCheckController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public DateCheckController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsOrderDateValidation(string OrderDate)
        {
            if (await Task.FromResult(OrderDate == null))
            {
                return Json(true);
            }
            else
            {
                string[] sdate = OrderDate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + OrderDate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsAccountCodeValidation(int AcCode)
        {
            if (await Task.FromResult(AcCode == 0))
            {
                return Json($"Please Enter Valided A/c Name");
            }
            else
            {
                return Json(true);
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsItemCodeValidation(int ItemCode)
        {
            if (await Task.FromResult(ItemCode == 0))
            {
                return Json($"Please Enter Valided Item's Name");
            }
            else
            {
                return Json(true);
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUser(string email)
        {
            var user = await _accountRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsFromDateValidation(string Fromdate)
        {
            if (await Task.FromResult(Fromdate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = Fromdate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + Fromdate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsUptoDateValidation(string Uptodate)
        {
            if (await Task.FromResult(Uptodate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = Uptodate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + Uptodate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsBillDateValidation(string Billdate)
        {
            if (await Task.FromResult(Billdate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = Billdate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + Billdate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsPaidDateValidation(string Paiddate)
        {
            if (await Task.FromResult(Paiddate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = Paiddate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + Paiddate);
                }
            }
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsFirstFromDateValidation(string Firstfromdate)
        {
            if (await Task.FromResult(Firstfromdate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = Firstfromdate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + Firstfromdate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsFirstUptoDateValidation(string Firstuptodate)
        {
            if (await Task.FromResult(Firstuptodate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = Firstuptodate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + Firstuptodate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsSecondFromDateValidation(string Secondfromdate)
        {
            if (await Task.FromResult(Secondfromdate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = Secondfromdate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + Secondfromdate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsSecondUptoDateValidation(string Seconduptodate)
        {
            if (await Task.FromResult(Seconduptodate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = Seconduptodate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + Seconduptodate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsAppointDateValidation(string DateOfAppoint)
        {
            if (await Task.FromResult(DateOfAppoint == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = DateOfAppoint.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + DateOfAppoint);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsSalaryIncreaseDateValidation(string SalarIncrDate)
        {
            if (await Task.FromResult(SalarIncrDate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = SalarIncrDate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + SalarIncrDate);
                }
            }
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsIncreaseDateValidation(string IncreaseDate)
        {
            if (await Task.FromResult(IncreaseDate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = IncreaseDate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + IncreaseDate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsVInvoiceDateValidation(string VDate)
        {
            if (await Task.FromResult(VDate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = VDate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + VDate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsInvoiceDateValidation(string InvoiceDate)
        {
            if (await Task.FromResult(InvoiceDate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = InvoiceDate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + InvoiceDate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsConnectionDateValidation(string ConnectionDate)
        {
            if (await Task.FromResult(ConnectionDate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = ConnectionDate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + ConnectionDate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsMaturityDateValidation(string DateOfMaturity)
        {
            if (await Task.FromResult(DateOfMaturity == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = DateOfMaturity.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + DateOfMaturity);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsAnniversaryDateValidation(string DateOfAnniversary)
        {
            if (await Task.FromResult(DateOfAnniversary == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = DateOfAnniversary.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + DateOfAnniversary);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsDateBirthValidation(string DateOfBith)
        {
            if (await Task.FromResult(DateOfBith == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = DateOfBith.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + DateOfBith);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsRegistrationDateValidation(string RegistDate)
        {
            if (await Task.FromResult(RegistDate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = RegistDate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + RegistDate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsRegistrationSampleDateValidation(string SDate)
        {
            if (await Task.FromResult(SDate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = SDate.Split('/');

                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + SDate);
                }
            }
        }
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsRegistrationReportDateValidation(string RDate)
        {
            if (await Task.FromResult(RDate == null))
            {
                return Json($"Please Enter Date Field");
            }
            else
            {
                string[] sdate = RDate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                if (isCorrectFormat)
                {
                    return Json(true);
                }
                else
                {
                    return Json($"Please Enter Correct Date Format(dd/mm/yyyy) " + RDate);
                }
            }
        }
    }
}
