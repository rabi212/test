using ITCGKP.Data.Models;
using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKP.Data.ViewModels.PayBill;
using ITCGKP.Data.ViewModels.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ITCGKP.Data.ViewModels;

namespace ITCGKPLAB.Controllers
{
    public class ReportingController : Controller
    {
        private readonly IPayBillRepository _prepository = null;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMasterRepository mrepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAccountRepository _accountRepository;
        private readonly ISettingRepository _settingRepository;
        public ReportingController(ISettingRepository settingRepository,IMasterRepository imrepository,
                                   IWebHostEnvironment hostingEnvironment,
                                   UserManager<ApplicationUser> userManager,
                                   IPayBillRepository PayBillRepository,
                                   ITransactionRepository transactionRepository,
                                   IAccountRepository accountRepository)
        {
            mrepository = imrepository;
            _hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
            _prepository = PayBillRepository;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _settingRepository = settingRepository;
        }
        public PageSetupViewModel pageSetup { get; set; }
        [ViewData]
        public PatientDateViewModel DateDetails { get; set; }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Header()
        {            
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Footer(PageSetupViewModel  model)
        {
            PageSetupViewModel viewModel = model;
            return View(viewModel);
        }
        [Route("Barcode-Print")]
        public async Task<IActionResult> BarcodePrint(int idno)
        {
            PatientViewModel model = await mrepository.GetPatientMasterById(idno);
            pageSetup = await mrepository.GetPageSetupById(model.CompId);

            var report = new ViewAsPdf("BarcodePrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeC,
                PageMargins = { Left = (int?)pageSetup.LeftC, Bottom = (int?)pageSetup.BottomC,
                    Right = (int?)pageSetup.RightC, Top = (int?)pageSetup.TopC },
                PageOrientation = (int?)pageSetup.CustomOrientationC == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Patient-Due-Collection-Print")]
        public async Task<IActionResult> DueReciptCollectionPrint(OpenSearchViewModel model)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            var report = new ViewAsPdf("DueReciptCollectionPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("DueReceipt-Voucher-Print")]
        public async Task<IActionResult> DueReciptBillPrint(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            PatientDueReciptViewModel model = await mrepository.GetPatientDueReciptMasterById(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("DueReciptBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,
                PageMargins = { Left = (int?)pageSetup.LeftB, Bottom = (int?)pageSetup.BottomB,
                    Right = (int?)pageSetup.RightB, Top = (int?)pageSetup.TopB },
                PageOrientation = (int?)pageSetup.CustomOrientationB == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("CashRecipt-Voucher-Print")]
        public async Task<IActionResult> CashReciptBillPrint(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            VoucherViewModel model = await _transactionRepository.GetVoucherById(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("CashReciptBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,
                PageMargins = { Left = (int?)pageSetup.LeftB, Bottom = (int?)pageSetup.BottomB,
                    Right = (int?)pageSetup.RightB, Top = (int?)pageSetup.TopB },
                PageOrientation = (int?)pageSetup.CustomOrientationB == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Credit-Note-Print")]
        public async Task<IActionResult> CreditNoteBillPrint(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            SaleRViewModel model = await _transactionRepository.GetSaleReturnFileById(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("CreditNoteBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Sale-Bill-Print")]
        public async Task<IActionResult> SaleBillPrint(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            SaleViewModel model = await _transactionRepository.GetSaleFileById(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("SaleBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Order-Bill-Print")]
        public async Task<IActionResult> OrderBillPrint(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            PurchaseOrderViewModel model = await _transactionRepository.GetPurchaseOrderFileById(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("OrderBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("DebitNote-Bill-Print")]
        public async Task<IActionResult> DebitNoteBillPrint(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            PurchaseRViewModel model = await _transactionRepository.GetPurchaseReturnFileById(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("DebitNoteBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("PayBill-Print")]
        public async Task<IActionResult> SalaryBillPrint(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            UpdatePayBillViewModel model = await _prepository.GetPayBillById(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("SalaryBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,
                PageMargins = { Left = (int?)pageSetup.LeftB, Bottom = (int?)pageSetup.BottomB,
                    Right = (int?)pageSetup.RightB, Top = (int?)pageSetup.TopB },
                PageOrientation = (int?)pageSetup.CustomOrientationB == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("PayBill-ALL-Print")]
        public async Task<IActionResult> SalaryALLBillPrint(string fromdate)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            List<UpdatePayBillViewModel> model = await _prepository.PayBillMonthly(fromdate);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("SalaryALLBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,
                PageMargins = { Left = (int?)pageSetup.LeftB, Bottom = (int?)pageSetup.BottomB,
                    Right = (int?)pageSetup.RightB, Top = (int?)pageSetup.TopB },
                PageOrientation = (int?)pageSetup.CustomOrientationB == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("PayBill-Monthly-Print")]
        public async Task<IActionResult> SalaryMonthlyBillPrint(string fromdate)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            List<UpdatePayBillViewModel> model = await _prepository.PayBillMonthly(fromdate);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("SalaryMonthlyBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftB, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Bill-Print-File")]
        public async Task<IActionResult> PatientBillPrint(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            PatientViewModel model = await mrepository.GetPatientMasterById(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);

            var report = new ViewAsPdf("PatientBillPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,
                PageMargins = { Left = (int?)pageSetup.LeftB, Bottom = (int?)pageSetup.BottomB,
                    Right = (int?)pageSetup.RightB, Top = (int?)pageSetup.TopB },
                PageOrientation = (int?)pageSetup.CustomOrientationB == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape
                
                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };            
            return report;
        }
       
       
        protected string WelcomeHTML(string name)
        {
            string Filename = Path.Combine(_hostingEnvironment.WebRootPath, "ExportHeader.html");
            var html = System.IO.File.ReadAllText(Filename);
            html = html.Replace("{{name}}", name);
            System.IO.File.WriteAllText(Filename, html);            
            return html;
        }
        [HttpGet("welcome")]
        [Produces("text/html")]
        public ContentResult Welcome(string name)
        {
            var html = WelcomeHTML(name);
            var filenxx = base.Content(html, "text/html", Encoding.UTF8);
            return base.Content(html, "text/html", Encoding.UTF8);
        }
        private StringBuilder htmlCodeing()
        {
            var html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<style type=\"text/css\">");
            html.AppendLine(
                "* { font-family: Arial, Helvetica, sans-serif;} " +
                "img { margin-right: 5px; width: 100%; }" +
                "footer { border-top: 1px solid #ccc;padding: 10px;text-align: center;}" +
                "div.relative {position: relative;width: 100%;}" +
                "div..absolute1 {position: .absolute;left: 0;width: 25%;}" +
                "div..absolute2 {position: .absolute;left: 20%;width: 25%;}" +
                "div..absolute3 {position: .absolute;right: 0;width: 25%;}"
                );
            html.AppendLine("</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body onload='subst();'>");
            html.AppendLine("<footer>");
            html.AppendLine("<div class='relative'>");
            html.AppendLine("<div class='absolute1'><img src='/CenterSignatureLeft/'   height='55'></div>");
            html.AppendLine("<div class='absolute2'><img src='/CenterSignature/'  height='55'></div>");
            html.AppendLine("<div class='absolute3'><img src='/CenterLogo/'  height='55'></div>");
            html.AppendLine("</div>");
            html.AppendLine("</footer>");
            html.AppendLine("<script>");
            html.AppendLine(" function subst() { " +
                " var vars = {}; var query_strings_from_url = document.location.search.substring(1).split('&');" +
                "for (var query_string in query_strings_from_url) { if (query_strings_from_url.hasOwnProperty(query_string)) { var temp_var = query_strings_from_url[query_string].split('=', 2); vars[temp_var[0]] = decodeURI(temp_var[1]); }}" +
                " var css_selector_classes = ['page', 'frompage', 'topage', 'webpage', 'section', 'subsection', 'date', 'isodate', 'time', 'title', 'doctitle', 'sitepage', 'sitepages'];" +
                " for (var css_class in css_selector_classes) {if (css_selector_classes.hasOwnProperty(css_class)) { var element = document.getElementsByClassName(css_selector_classes[css_class]); for (var j = 0; j < element.length; ++j) { element[j].textContent = vars[css_selector_classes[css_class]]; " +
                "} } } }");
            html.AppendLine("</script>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            return html;
        }
        [AllowAnonymous]
        public ActionResult FooterPrint(FooterViewModel model)
        {
            return View(model);
        }
        [Route("Patient-Report-Print")]
        public async Task<IActionResult> PatientReportPrint(int id,bool headprint)
        {           
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            PatientViewModel model = await mrepository.GetPatientMasterById(id);
            bool covidCorrect = await mrepository.GetPatientTestGroupCovid(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            CompanyDetailViewModel companyDetailViewModel = await _settingRepository.GetCompanyById((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            FooterViewModel footerViewModel = new FooterViewModel()
            {
                SigLeft = companyDetailViewModel.ExitSignaturePhotoPathLeft,
                SigCenter = companyDetailViewModel.ExitSignaturePhotoPath,
                SigRight = companyDetailViewModel.ExitPhotoPath,
                SigLeftTrueFalse = companyDetailViewModel.SignaturePrintLeft,
                SigCenterTrueFalse = companyDetailViewModel.SignaturePrint,
                SigRightTrueFalse = companyDetailViewModel.PhotoPathPrint,
                FooterImages = pageSetup.ExitFooterPhotoPath,
                FooterImagesTrueFalse = headprint,
                BarCodeTopTrue = pageSetup.BarcodeTop,
                VNo = model.VNo,
                QRCodePrint = pageSetup.QRCodePrint,
                BarCodePrint = pageSetup.BarCodePrint
            };
            
            var hft = "";
            //if (!covidCorrect)
            //{
                if (headprint)
                {                
                    var headerfile = pageSetup.HeaderPhotoFile;
                    var footerfile = pageSetup.FooterPhotoFile;
                    string authority = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
                    string headerHtml = $"{authority}/{"CenterHeader"}/{headerfile}";
                    string footerHtml = $"{authority}/{"CenterFooter"}/{footerfile}";
                //hft = $"--header-html \"{headerHtml}\" --footer-html \"{footerHtml}\" --header-spacing 2 --footer-spacing 2";
                hft = $"--header-html \"{headerHtml}\" --footer-html \"{Url.Action("FooterPrint", "Reporting", footerViewModel, (Request.IsHttps ? "https" : "http"))}\" --header-spacing 2 --footer-spacing 2";

                //string headerHtml = string.Format("--print-media-type --allow {0} --header-html {0} --header-spacing -10", Url.Action("Header", "Report", "https"));
                //hft = headerHtml;
            }
                //else
                //{
                //    hft = $"--page-offset 0 --footer-center \"" + "  Page: [page]/[toPage]\"" +
                //                     " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Segoe UI\"";
                //}
            //}
            else
            {
                //hft = $"--page-offset 0 --footer-center \"" + "  Page: [page]/[toPage]\"" +
                 //     " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Segoe UI\"";
                var footerfilex = companyDetailViewModel.ExitFooterReport;
                string authorityx = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
                string footerHtmlx = $"{authorityx}/{"CenterSignatureALLPage"}/{footerfilex}";
                //hft = $"--footer-html \"{footerHtmlx}\"  --footer-spacing 2";
                hft = $"--footer-html \"{Url.Action("FooterPrint", "Reporting", footerViewModel, (Request.IsHttps ? "https" : "http")) }\"  --footer-spacing 2"; 
            }            
            

            var report = new ViewAsPdf("PatientReportPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                //PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,
                
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = { Left = (int?)pageSetup.LeftR, Bottom = (int?)pageSetup.BottomR,
                    Right = (int?)pageSetup.RightR, Top = headprint == true ? (int?)pageSetup.TopR : (int?)pageSetup.TopR },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = hft

                //CustomSwitches = "--print-media-type --header-center \"Infotech Corporation\""
                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("PatientReport-Print")]
        [AllowAnonymous]
        public async Task<IActionResult> PatientReportPrintQ(string id)
        {
            //int cmpid = 1; //await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            PatientViewModel model = await mrepository.GetPatientMasterByReportNo(id);
            if (model == null)
            {
                ViewBag.ErrorMessage = $"Report cannot be found";
                return View("NotFound");
            }
            pageSetup = await mrepository.GetPageSetupById(model.CompId);
            CompanyDetailViewModel companyDetailViewModel = await _settingRepository.GetCompanyById(model.CompId);
            FooterViewModel footerViewModel = new FooterViewModel()
            {
                SigLeft = companyDetailViewModel.ExitSignaturePhotoPathLeft,
                SigCenter = companyDetailViewModel.ExitSignaturePhotoPath,
                SigRight = companyDetailViewModel.ExitPhotoPath,
                SigLeftTrueFalse = companyDetailViewModel.SignaturePrintLeft,
                SigCenterTrueFalse = companyDetailViewModel.SignaturePrint,
                SigRightTrueFalse = companyDetailViewModel.PhotoPathPrint,
                FooterImages = pageSetup.ExitFooterPhotoPath,
                FooterImagesTrueFalse = true,
                BarCodeTopTrue = pageSetup.BarcodeTop,
                VNo = model.VNo,
                QRCodePrint = pageSetup.QRCodePrint,
                BarCodePrint = pageSetup.BarCodePrint
            };
            var headerfile = pageSetup.HeaderPhotoFile;
            var footerfile = pageSetup.FooterPhotoFile;

            string authority = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
            string headerHtml = $"{authority}/{"CenterHeader"}/{headerfile}";
            string footerHtml = $"{authority}/{"CenterFooter"}/{footerfile}";

            var report = new ViewAsPdf("PatientReportPrintQ", model)
            {
                //FileName = "Invoice.pdf",                  
                //PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = { Left = (int?)pageSetup.LeftR, Bottom = (int?)pageSetup.BottomR,
                    Right = (int?)pageSetup.RightR, Top = (int?)pageSetup.TopR },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                //CustomSwitches = $"--header-html \"{headerHtml}\" --footer-html \"{footerHtml}\" --header-spacing 2 --footer-spacing 2"
                CustomSwitches = $"--header-html \"{headerHtml}\" --footer-html \"{Url.Action("FooterPrint", "Reporting", footerViewModel, (Request.IsHttps ? "https" : "http"))}\" --header-spacing 2 --footer-spacing 2"
                
                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Patient-Multiple-Report-Print")]
        public async Task<IActionResult> PatientReportPrintMultple(OpenSearchViewModel modelx)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            List<PatientViewModel> model = await mrepository.GetAllPatientMasterResultSearchDispatch(modelx.CompId);
            
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            CompanyDetailViewModel companyDetailViewModel = await _settingRepository.GetCompanyById((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            var hft = "";           
            if ( modelx.HeaderPrint)
            {
                var headerfile = pageSetup.HeaderPhotoFile;
                var footerfile = pageSetup.FooterPhotoFile;
                string authority = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
                string headerHtml = $"{authority}/{"CenterHeader"}/{headerfile}";
                string footerHtml = $"{authority}/{"CenterFooter"}/{footerfile}";
                hft = $"--header-html \"{headerHtml}\" --footer-html \"{footerHtml}\" --header-spacing 2 --footer-spacing 2";
            }
            else
            {
                //hft = $"--page-offset 0 --footer-center \"" + "  Page: [page]/[toPage]\"" +
                //     " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Segoe UI\"";
                var footerfilex = companyDetailViewModel.ExitFooterReport;
                string authorityx = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
                string footerHtmlx = $"{authorityx}/{"CenterSignatureALLPage"}/{footerfilex}";
                hft = $"--footer-html \"{footerHtmlx}\"  --footer-spacing 2";
            }


            var report = new ViewAsPdf("PatientReportPrintMultple", model)
            {
                //FileName = "Invoice.pdf",                  
                //PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,

                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = { Left = (int?)pageSetup.LeftR, Bottom = (int?)pageSetup.BottomR,
                    Right = (int?)pageSetup.RightR, Top = modelx.HeaderPrint == true ? (int?)pageSetup.TopR : (int?)pageSetup.TopR },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = hft

                //CustomSwitches = "--print-media-type --header-center \"Infotech Corporation\""
                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Patient-ReportDoc-Print")]
        public async Task<IActionResult> PatientReportPrintDoc(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            PatientViewModel model = await mrepository.GetPatientMasterById(id);
            ////bool covidCorrect = await mrepository.GetPatientTestGroupCovid(id);
            ////pageSetup = await mrepository.GetPageSetupById(cmpid);
            ////var hft = "";
            ////if (!covidCorrect)
            ////{
            ////    if (pageSetup.ReportHeaderPrint)
            ////    {
            ////        var headerfile = pageSetup.HeaderPhotoFile;
            ////        var footerfile = pageSetup.FooterPhotoFile;
            ////        string authority = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
            ////        string headerHtml = $"{authority}/{"CenterHeader"}/{headerfile}";
            ////        string footerHtml = $"{authority}/{"CenterFooter"}/{footerfile}";
            ////        hft = $"--header-html \"{headerHtml}\" --footer-html \"{footerHtml}\" --header-spacing 2 --footer-spacing 2";

            ////        //string headerHtml = string.Format("--print-media-type --allow {0} --header-html {0} --header-spacing -10", Url.Action("Header", "Report", "https"));
            ////        //hft = headerHtml;
            ////    }
            ////    //else
            ////    //{
            ////    //    hft = $"--page-offset 0 --footer-center \"" + "  Page: [page]/[toPage]\"" +
            ////    //                     " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Segoe UI\"";
            ////    //}
            ////}
            ////else
            ////{
            ////    hft = $"--page-offset 0 --footer-center \"" + "  Page: [page]/[toPage]\"" +
            ////          " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Segoe UI\"";
            ////}
            ////var report = new ViewAsPdf("PatientReportPrintDoc", model)
            ////{
            ////    //FileName = "Invoice.pdf",                  
            ////    //PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,

            ////    PageSize = Rotativa.AspNetCore.Options.Size.A4,
            ////    PageMargins = { Left = (int?)pageSetup.LeftR, Bottom = (int?)pageSetup.BottomR,
            ////        Right = (int?)pageSetup.RightR, Top = (int?)pageSetup.TopR },
            ////    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
            ////    CustomSwitches = hft

            ////    //CustomSwitches = "--print-media-type --header-center \"Infotech Corporation\""
            ////    //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
            ////    //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
            ////    //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            ////};
            ////return report;
            return View(model);
        }
        [Route("Medical-Report-Print")]
        public async Task<IActionResult> PatientMedReportPrint(int id)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            MedTestViewModel model = await mrepository.GetMedFileByIdReport(id);
            bool covidCorrect = await mrepository.GetPatientTestGroupCovid(id);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
          
            var hft = "";
            
                if (pageSetup.ReportHeaderPrint)
                {
                    var headerfile = pageSetup.HeaderPhotoFile;
                    var footerfile = pageSetup.FooterPhotoFile;
                    string authority = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
                    string headerHtml = $"{authority}/{"CenterHeader"}/{headerfile}";
                    string footerHtml = $"{authority}/{"CenterFooter"}/{footerfile}";
                    hft = $"--header-html \"{headerHtml}\" --footer-html \"{footerHtml}\" --header-spacing 2 --footer-spacing 2";
                    //hft = $"--header-html \"{headerHtml}\" --footer-html \"{Url.Action("FooterPrint", "Reporting", footerViewModel, (Request.IsHttps ? "https" : "http"))}\" --header-spacing 2 --footer-spacing 2";
                    //string headerHtml = string.Format("--print-media-type --allow {0} --header-html {0} --header-spacing -10", Url.Action("Header", "Report", "https"));
                    //hft = headerHtml;
                }
                else
                {
                var footerfilex = ""; //companyDetailViewModel.ExitFooterReport;
                    string authorityx = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
                    string footerHtmlx = $"{authorityx}/{"CenterSignatureALLPage"}/{footerfilex}";
                    //hft = $"--footer-html \"{footerHtmlx}\"  --footer-spacing 2";
                    //hft = $"--footer-html \"{Url.Action("FooterPrint", "Reporting", footerViewModel, (Request.IsHttps ? "https" : "http")) }\"  --footer-spacing 2";
                    //hft = $"--page-offset 0 --footer-center \"" + "  \"" +
                     //               " --footer-line --footer-font-size \"5\" --footer-spacing 1 --footer-font-name \"Segoe UI\"";
                }
            
            var report = new ViewAsPdf("PatientMedReportPrint", model)
            {
                //FileName = "Invoice.pdf",                  
                //PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,

                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = { Left = (int?)pageSetup.LeftR, Bottom = (int?)pageSetup.BottomR,
                    Right = (int?)pageSetup.RightR, Top = (int?)pageSetup.TopR },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = hft

                //CustomSwitches = "--print-media-type --header-center \"Infotech Corporation\""
                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("PatientReportMedical-Print")]
        [AllowAnonymous]
        public async Task<IActionResult> PatientMedReportPrintQ(string id)
        {
            //int cmpid = 1; //await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            MedTestViewModel model = await mrepository.GetMedFileByIdNo(id);
            if (model == null)
            {
                ViewBag.ErrorMessage = $"Report cannot be found";
                return View("NotFound");
            }
            pageSetup = await mrepository.GetPageSetupById((int)model.CompId);            
            var headerfile = pageSetup.HeaderPhotoFile;
            var footerfile = pageSetup.FooterPhotoFile;

            string authority = $"{(Request.IsHttps ? "https" : "http")}://{Request.Host}";
            string headerHtml = $"{authority}/{"CenterHeader"}/{headerfile}";
            string footerHtml = $"{authority}/{"CenterFooter"}/{footerfile}";

            var report = new ViewAsPdf("PatientMedReportPrintQ", model)
            {
                //FileName = "Invoice.pdf",                  
                //PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeB,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = { Left = (int?)pageSetup.LeftR, Bottom = (int?)pageSetup.BottomR,
                    Right = (int?)pageSetup.RightR, Top = (int?)pageSetup.TopR },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = $"--header-html \"{headerHtml}\" --footer-html \"{footerHtml}\" --header-spacing 2 --footer-spacing 2"

                //CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                 DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                 " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Daily-Collection-Print")]
        public async Task<IActionResult> DailyCollectionPrint(PatientDateViewModel model)
        {
            //int cmpid = await mrepository.GetPageSetupByCompId(model.CompId);
            pageSetup = await mrepository.GetPageSetupById(model.CompId);            
            var report = new ViewAsPdf("DailyCollectionPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

              //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
              //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
              //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Date-Wise-Summary-Print")]
        public async Task<IActionResult> DailySummaryPrint(PatientDateViewModel model)
        {
            //int cmpid = await mrepository.GetPageSetupByCompId(model.CompId);
            pageSetup = await mrepository.GetPageSetupById(model.CompId);
            var report = new ViewAsPdf("DailySummaryPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("IP-Details-Print")]
        public async Task<IActionResult> IPReportPrint(PatientDateViewModel model)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            var report = new ViewAsPdf("IPReportPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("IP-Summary-Print")]
        public async Task<IActionResult> IPSummaryPrint(PatientDateViewModel model)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            var report = new ViewAsPdf("IPSummaryPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Executive-Collection-Print")]
        public async Task<IActionResult> ExecutiveCollectionPrint(PatientDateViewModel model)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            var report = new ViewAsPdf("ExecutiveCollectionPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Doctor-Collection-Print")]
        public async Task<IActionResult> DoctorCollectionPrint(PatientDateViewModel model)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            var report = new ViewAsPdf("DoctorCollectionPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("TestGroup-Collection-Print")]
        public async Task<IActionResult> TestGroupCollectionPrint(PatientDateViewModel model)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            var report = new ViewAsPdf("TestGroupCollectionPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Test-Collection-Print")]
        public async Task<IActionResult> TestCollectionPrint(PatientDateViewModel model)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            var report = new ViewAsPdf("TestCollectionPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Test-ListRate-Print")]
        public async Task<IActionResult> TestRatePrint(PatientDateViewModel model)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            var report = new ViewAsPdf("TestRatePrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
        [Route("Doctor-List")]
        public async Task<IActionResult> DoctorListPrint(PatientDateViewModel model)
        {
            int cmpid = await mrepository.GetPageSetupByCompId((int)(await userManager.GetUserAsync(User)).CompanyDetailId);
            pageSetup = await mrepository.GetPageSetupById(cmpid);
            var report = new ViewAsPdf("DoctorListPrint", model)
            {
                //FileName = "Invoice.pdf",
                PageSize = (Rotativa.AspNetCore.Options.Size?)pageSetup.CustomPapersizeA,
                PageMargins = { Left = (int?)pageSetup.LeftA, Bottom = (int?)pageSetup.BottomA,
                    Right = (int?)pageSetup.RightA, Top = (int?)pageSetup.TopA },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape // (int?)pageSetup.CustomOrientationA == 0 ? Rotativa.AspNetCore.Options.Orientation.Portrait : Rotativa.AspNetCore.Options.Orientation.Landscape,

                //  CustomSwitches = "--page-offset 0 --footer-center \"  Created Date: " +
                //                   DateTime.Now.Date.ToString("dd/MM/yyyy") + "  Page: [page]/[toPage]\"" +
                //                   " --footer-line --footer-font-size \"12\" --footer-spacing 1 --footer-font-name \"Segoe UI\""
            };
            return report;
        }
    }
}
