using ITCGKP.Data.Models;
using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.Services.ProvideService;
using ITCGKP.Data.ViewModels.Master;
using ITCGKPLAB.Tags;
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
    public class HomeController : Controller
    {
        private readonly IMasterRepository _masterRepository;        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public HomeController(IMasterRepository masterRepository, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _masterRepository = masterRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //UserEmailOptions userEmailOptions = new UserEmailOptions
            //{
            //    ToEmails = new List<string>() { "ramsingh201213@gmail.com" },
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{username}}","Sudhakar")
            //    }
            //};
            //await _emailService.SendTestEmail(userEmailOptions);

            // return View();            
            var model = new OpenSearchViewModel()
            {
                CompId = _signInManager.IsSignedIn(User) ? (int)(await _userManager.GetUserAsync(User)).CompanyDetailId : 1,
                FromDate = DateTime.Today,
                UptoDate = DateTime.Today,
                SearchRecordFinder ="No",
                SearchDate = true
            };
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(OpenSearchViewModel model)
        {
            model.SearchRecordFinder = "Yes";
            if (ModelState.IsValid)
            {
                return View( await Task.FromResult(model));
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Contacts()
        {
            return View();
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ChartListWeekly(DateTime dateTime)
        {
            var model = await _masterRepository.GetALLPatientCompanyWiseWeekly(dateTime);
            return Ok(model);
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> ChartListMonthly(DateTime dateTime)
        {
            var model = await _masterRepository.GetALLPatientCompanyWiseMonthly(dateTime);
            return Ok(model);
        }
       
    }
}
