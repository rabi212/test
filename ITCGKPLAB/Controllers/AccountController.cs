using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKPLAB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCGKPLAB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SoftwareConfigMode _softwareConfig;
        private readonly IMasterRepository _mrepository;
        public AccountController(IAccountRepository accountRepository, IOptions<SoftwareConfigMode> softwareConfig
            , IMasterRepository MasterRepository,ISettingRepository settingRepository)
        {
            _accountRepository = accountRepository;
            _softwareConfig = softwareConfig.Value;
            _mrepository = MasterRepository;            
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllUserToCompany(int cmpId)
        {
            var model = cmpId == 0 ? new SelectList(await _accountRepository.GetUserListAsync(), "Id", "UserName") :new SelectList(await _accountRepository.GetUserListAsync(cmpId),"Id","UserName");
            return Ok(model);
        }
        [Authorize(Policy = "CreateUserPolicy")]
        [HttpGet("NewUserRegister")]
        public IActionResult Register()
        {
            return View();
        }
        [Authorize(Policy = "CreateUserPolicy")]
        [HttpPost("NewUserRegister")]
        public async Task<IActionResult> Register(RegisterViewModel models)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(models);
                if (!result.Succeeded)
                {
                    foreach (var errormessage in result.Errors)
                    {
                        ModelState.AddModelError("", errormessage.Description);
                    }
                    return View(models);
                }
                if (!_softwareConfig.SoftwareMode)
                {
                    if (! await _mrepository.AddNewPageSetupValidedMultipleBranch(Convert.ToInt32(models.CompanyDetailId)))
                    {
                        int pgsetId = await _mrepository.AddNewPageSetupNewUserMultipleBranch(Convert.ToInt32(models.CompanyDetailId));
                    }
                }
                ModelState.Clear();
                return RedirectToAction("ConfirmEmail", new { email = models.Email });
            }
            return View();
        }
        [Route("Login")]
        [AllowAnonymous, HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Login(LoginViewModel models, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(models);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                }
                else if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Credentials");
                }
            }
            return View();
        }
        [Route("Logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Route("Change-Password")]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Route("Change-Password")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel models)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangeUserPasswordAsync(models);
                if (result.Succeeded)
                {
                    return View("ChangePasswordConfirmation");
                }
                foreach (var errormessage in result.Errors)
                {
                    ModelState.AddModelError("", errormessage.Description);
                }
            }
            return View();
        }
        [AllowAnonymous, HttpGet("Confirm-Email")]
        public async Task<IActionResult> ConfirmEmail(string uId, string token,string email)
        {
            EmailConfirmViewModel model = new EmailConfirmViewModel
            {
                Email = email
            };

            if (!string.IsNullOrEmpty(uId) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(" ", "+");
                var result = await _accountRepository.ConfirmEmailAsync(uId, token);
                if (result.Succeeded)
                {
                    model.EmailVerified = true;
                }
            }
            return View(model);
        }
        [AllowAnonymous, HttpPost("Confirm-Email")]
        public async Task<IActionResult> ConfirmEmail(EmailConfirmViewModel model)
        {
            var user = await _accountRepository.GetUserByEmailAsync(model.Email);
            if (user != null)
            {
                if (user.EmailConfirmed)
                {
                    model.IsConfirm = true;
                    return View(model);
                }
               await _accountRepository.GenerateEmialConfirmationTokenAsync(user);
                model.EmailSend = true;
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Somthing went wrong.");
            }
            return View(model);
        }
        [AllowAnonymous, HttpGet ("Forgot-Password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous, HttpPost("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountRepository.GetUserByEmailAsync(model.Email);
                if (user !=null)
                {
                    await _accountRepository.GenerateForgotPasswordTokenAsync(user);
                    return View("ForgotPasswordConfirmation");
                }
                ModelState.Clear();
                model.EmailSent = true;
            }
            return View(model);
        }
        [AllowAnonymous, HttpGet("Reset-Password")]
        public IActionResult ResetPassword(string uId, string token)
        {
            ResetPasswordViewModel ResetPasswordViewModel = new ResetPasswordViewModel
            {
                Token = token,
                UserId = uId
            };
            return View(ResetPasswordViewModel);
        }
        [AllowAnonymous, HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(" ", "+");
                var result = await _accountRepository.ResetPasswordAsync(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }
                foreach (var errormessage in result.Errors)
                {
                    ModelState.AddModelError("", errormessage.Description);
                }
            }
            return View(model);
        }
    }
}
