using ITCGKP.Data.Models;
using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.ViewModels.Setting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ITCGKPLAB.Controllers
{
    //[Authorize(Policy = "AdminRolePolicy")]
    public class AdministrationController : Controller
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManagerx;
        int idno = 0; bool istrasferrecord = false; string _Message = "";
        public AdministrationController(ISettingRepository settingRepository, IAccountRepository accountRepository,
                                        IWebHostEnvironment hostingEnvironment, UserManager<ApplicationUser> userManagerx)
        {
            _settingRepository = settingRepository;
            _accountRepository = accountRepository;
            _hostingEnvironment = hostingEnvironment;
            _userManagerx = userManagerx;
        }       
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet("Roles-List")]
        public IActionResult ListRoles()
        {
            return View();
        }
        [HttpGet("Create-User-Role")]
        [Authorize(Policy = "CreateRolePolicy")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost("Create-User-Role")]
        [Authorize(Policy = "CreateRolePolicy")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {                
                var result = await _accountRepository.CreateUserRoleAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpPost("Delete-Roles")]
        [Authorize(Policy = "DeleteRolePolicy")]
        public async Task<IActionResult> DeleteRole(string id)
        {            
            if (id == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await _accountRepository.DeleteRoleAsync(id);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListRoles");
            }
        }
        [HttpGet("Edit-Role")]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> EditRole(string id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {id} cannot be found";
                return View("NotFound");
            }
            EditRoleViewModel model = await _accountRepository.GetEditRoleAsync(id);
            return View(model);
        }
        [HttpPost("Edit-Role")]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {            
            if (model.Id == null || model.Id == "0")
            {
                ViewBag.ErrorMessage = $"Role with id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await _accountRepository.CreateUserEditRoleAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        [HttpGet("List-Users")]
        public async Task<IActionResult> ListUsers()
        {
            var model = User.IsInRole("SuperAdmin") ? await _accountRepository.GetUserListAsync() : await _accountRepository.GetUserListAsync((int)(await _userManagerx.GetUserAsync(User)).CompanyDetailId);
            return View(model);
        }
        [HttpGet("Edit-User")]
        [Authorize(Policy = "EditUserPolicy")]
        public async Task<IActionResult> EditUser(string id)
        {            
            if (id == null || id == "0")
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            EditUserViewModel model = await _accountRepository.GetEditUserAsync(id);
            return View(model);
        }
        [HttpPost("Edit-User")]
        [Authorize(Policy = "EditUserPolicy")]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {           
            if (model == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {               
                var result = await _accountRepository.EditUserAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        [Authorize(Policy = "DeleteUserPolicy")]
        public async Task<IActionResult> DeleteUser(string id)
        {            
            if (id == null || id == "0")
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await _accountRepository.DeleteUserAsync(id);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListUsers");
            }
        }
        [HttpGet("EditUser-InRole")]
        [Authorize(Policy = "EditUserPolicy")]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;           
            if (roleId == null || roleId == "0")
            {
                ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found..";
                return View("NotFound");
            }
            List<UserRoleViewModel> model = await _accountRepository.GetEditUserInRoleAsync(roleId);
            return View(model);
        }
        [HttpPost("EditUser-InRole")]
        [Authorize(Policy = "EditUserPolicy")]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {            
            if (roleId == null || roleId == "0")
            {
                ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found..";
                return View("NotFound");
            }
            for (int i = 0; i < model.Count; i++)
            {
                var result = await _accountRepository.EditUserInRoleAsync(model[i], roleId);
                if (result == null)
                {
                    continue;
                }
                else
                {
                    if (result.Succeeded)
                    {
                        if (i < model.Count - 1)
                            continue;
                        else
                            return RedirectToAction("EditRole", new { Id = roleId });
                    }
                }
            }
            return RedirectToAction("EditRole", new { Id = roleId });
        }
        [HttpGet("ManageUser-Roles")]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;
          
            if (userId == null || userId == "0")
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            var model = User.IsInRole("SuperAdmin") ? await _accountRepository.GetManageUserRolesAsync(userId): await _accountRepository.GetManageUserRolesAsync(userId,"SuperAdmin");
            //var model = await _accountRepository.GetManageUserRolesAsync(userId);            
            return View(model);
        }
        [HttpPost("ManageUser-Roles")]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {            
            if (userId == null || userId == "0")
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }            
            var result = await _accountRepository.RemoveManageUserRolesAsync(userId);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
             result = await _accountRepository.ManageUserRolesAsync(model, userId);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("EditUser", new { Id = userId });
        }
        [HttpGet("ManageUser-Claims")]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> ManageUserClaims(string userId)
        {          
            if (userId == null || userId == "0")
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            var model = await _accountRepository.GetManageUserClaimsAsync(userId);            
            return View(model);
        }
        [HttpPost("ManageUser-Claims")]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel model)
        {            
            if (model.UserId == null || model.UserId == "0")
            {
                ViewBag.ErrorMessage = $"User with Id = {model.UserId} cannot be found";
                return View("NotFound");
            }
            var result = await _accountRepository.RemoveManageUserClaimsAsync(model.UserId);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }
            result = await _accountRepository.ManageUserClaimsAsync(model, model.UserId);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(model);
            }
            return RedirectToAction("EditUser", new { Id = model.UserId });
        }
        [HttpGet("Fonts-File")]
        public async Task<IActionResult> CreateFontCustom(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            FontCustomViewModel stateDetailView;
            stateDetailView = id == 0 ? new FontCustomViewModel() : await _settingRepository.GetFontCustomById(id);
            return View(stateDetailView);
        }
        [HttpPost("Fonts-File")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFontCustom(FontCustomViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _settingRepository.AddNewFontCustom(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateFontCustom), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _settingRepository.UpdateFontCustom(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateFontCustom), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Fonts-Delete-File")]
        public async Task<IActionResult> DeleteFontsRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _settingRepository.DeleteFontCustom(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateFontCustom), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet("Titles-File")]
        public async Task<IActionResult> CreateTitles(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            TitlesViewModel stateDetailView;
            stateDetailView = id == 0 ? new TitlesViewModel() : await _settingRepository.GetTitlesById(id);
            return View(stateDetailView);
        }
        [HttpPost("Titles-File")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTitles(TitlesViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _settingRepository.AddNewTitles(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateTitles), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _settingRepository.UpdateTitles(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateTitles), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("Titles-Delete-File")]
        public async Task<IActionResult> DeleteTitlesRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _settingRepository.DeleteTitles(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateTitles), new { id = 0, isSuccess = false, message = _Message });
        }
    
        [HttpGet("State-File")]
        public async Task<IActionResult> CreateState(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            StateViewModel stateDetailView;
            stateDetailView = id == 0 ? new StateViewModel() : await _settingRepository.GetStateById(id);
            return View(stateDetailView);
        }
        [HttpPost("State-File")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateState(StateViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.StateId == 0)
                {
                    idno = await _settingRepository.AddNewState(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateState), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _settingRepository.UpdateState(model);
                    idno = model.StateId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateState), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("State-Delete-File")]
        public async Task<IActionResult> DeleteStateRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _settingRepository.DeleteState(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateState), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet("District-File")]
        public async Task<IActionResult> CreateDistrict(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            DistrictViewModel districtView;
            districtView = id == 0 ? new DistrictViewModel() : await _settingRepository.GetDistrictById(id);
            return View(districtView);
        }
        [HttpPost("District-File")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDistrict(DistrictViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.DistId == 0)
                {
                    idno = await _settingRepository.AddNewDistrict(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateDistrict), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _settingRepository.UpdateDistrict(model);
                    idno = model.DistId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateDistrict), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [Route("District-Delete-File")]
        public async Task<IActionResult> DeleteDistrictRecord(int id = 0)
        {
            _Message = "";
            bool isDelete = await _settingRepository.DeleteDistrict(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateDistrict), new { id = 0, isSuccess = false, message = _Message });
        }        
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllDistrictList(int id)
        {
            // populate SelectListItem here
            var model = new SelectList(await _settingRepository.GetAllDistrictByState(id), "DistId", "DistrictName");
            return new JsonResult(model);
        }
        private string ProcessUploadedLeft(CompanyDetailViewModel models)
        {
            string uniqueFileName = null;
            if (models.SignaturePhotoPathLeft != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "CenterSignatureLeft");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + models.SignaturePhotoPathLeft.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    models.SignaturePhotoPathLeft.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
        private string ProcessUploadedLogo(CompanyDetailViewModel models)
        {
            string uniqueFileName = null;
            if (models.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "CenterLogo");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + models.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    models.Photo.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
        private string ProcessUploadedSignature(CompanyDetailViewModel models)
        {
            string uniqueFileName = null;
            if (models.SignaturePhoto != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "CenterSignature");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + models.SignaturePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    models.SignaturePhoto.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
        private string ProcessUploadedFooterFile(CompanyDetailViewModel models)
        {
            string uniqueFileName = "";
            string Filename = Path.Combine(_hostingEnvironment.WebRootPath, "ExportFooterALLPage.html");
            string copyToPath = Path.Combine(_hostingEnvironment.WebRootPath, "CenterSignatureALLPage");
            uniqueFileName = Guid.NewGuid().ToString() + models.Id + "_" + "ExportFooterALLPage.html";
            string filePath = Path.Combine(copyToPath, uniqueFileName);
            //if (System.IO.File.Exists(filePath))
            //{
            //    System.IO.File.Delete(filePath);
            //}
            System.IO.File.Copy(Filename, filePath);
            return uniqueFileName;
        }
        protected string WelcomeHTMLFooterUpdateImage(string name1, string name2, string name3, string exitfilename)
        {
            string Filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterSignatureALLPage", exitfilename);
            var html = System.IO.File.ReadAllText(Filename);
            html = html.Replace("{{FooterImage1}}", name1);
            html = html.Replace("{{FooterImage2}}", name2);
            html = html.Replace("{{FooterImage3}}", name3);
            System.IO.File.WriteAllText(Filename, html);
            return html;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetBranchSrNo(int stateid = 0, int distid = 0)
        {
            var model = await _settingRepository.BranchSrNoCreation(stateid, distid);
            return Ok(model);
        }
        [HttpGet("Create-Branches")]
        public async Task<IActionResult> CreateCompany(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            CompanyDetailViewModel companyDetailView;
            companyDetailView = id == 0 ? new CompanyDetailViewModel() : await _settingRepository.GetCompanyById(id);
            return View(companyDetailView);
        }
        [HttpPost("Create-Branches")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompany(CompanyDetailViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    model.ExitPhotoPath = model.Photo != null ? ProcessUploadedLogo(model) : null;
                    model.ExitSignaturePhotoPath = model.SignaturePhoto != null ? ProcessUploadedSignature(model) : null;
                    model.ExitSignaturePhotoPathLeft = model.SignaturePhotoPathLeft != null ? ProcessUploadedLeft(model) : null;
                    
                    model.ExitFooterReport = ProcessUploadedFooterFile(model);
                    WelcomeHTMLFooterUpdateImage(model.ExitSignaturePhotoPathLeft ,model.ExitSignaturePhotoPath, model.ExitPhotoPath, model.ExitFooterReport);
                    
                    idno = await _settingRepository.AddNewCompany(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateCompany), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {                    

                    if (model.SignaturePhotoPathLeft != null)
                    {
                        if (model.ExitSignaturePhotoPathLeft != null)
                        {
                            string filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterSignatureLeft", model.ExitSignaturePhotoPathLeft);
                            if (System.IO.File.Exists(filename))
                            {
                                System.IO.File.Delete(filename);
                            }
                        }
                        model.ExitSignaturePhotoPathLeft = ProcessUploadedLeft(model);
                    }
                    if (model.Photo != null)
                    {
                        if (model.ExitPhotoPath != null)
                        {
                            string filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterLogo", model.ExitPhotoPath);
                            if (System.IO.File.Exists(filename))
                            {
                                System.IO.File.Delete(filename);
                            }
                        }
                        model.ExitPhotoPath = ProcessUploadedLogo(model);
                    }
                    if (model.SignaturePhoto != null)
                    {
                        if (model.ExitSignaturePhotoPath != null)
                        {
                            string filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterSignature", model.ExitSignaturePhotoPath);
                            if (System.IO.File.Exists(filename))
                            {
                                System.IO.File.Delete(filename);
                            }
                        }
                        model.ExitSignaturePhotoPath = ProcessUploadedSignature(model);
                    }
                    if (model.ExitFooterReport != null)
                    {
                        string filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterSignatureALLPage", model.ExitFooterReport);
                        if (System.IO.File.Exists(filename))
                        {
                            System.IO.File.Delete(filename);
                        }
                    }
                    model.ExitFooterReport = ProcessUploadedFooterFile(model);
                    WelcomeHTMLFooterUpdateImage(model.ExitSignaturePhotoPathLeft, model.ExitSignaturePhotoPath, model.ExitPhotoPath, model.ExitFooterReport);
                    istrasferrecord = await _settingRepository.UpdateCompany(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateCompany), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [HttpGet("Create-Delete-Branches")]
        public async Task<IActionResult> DeleteCompRecord(int id = 0)
        {
            CompanyDetailViewModel model = await _settingRepository.GetCompanyById(id);
            _Message = "";
            if (model.ExitPhotoPath != null)
            {
                string filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterLogo", model.ExitPhotoPath);
                System.IO.File.Delete(filename);
            }
            if (model.ExitSignaturePhotoPath != null)
            {
                string filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterSignature", model.ExitSignaturePhotoPath);
                System.IO.File.Delete(filename);
            }
            if (model.ExitSignaturePhotoPathLeft != null)
            {
                string filename = Path.Combine(_hostingEnvironment.WebRootPath, "CenterSignatureLeft", model.ExitSignaturePhotoPathLeft);
                System.IO.File.Delete(filename);
            }
            bool isDelete = await _settingRepository.DeleteCompany(id);
            _Message = "Record Delete Successfully..";
            return RedirectToAction(nameof(CreateCompany), new { id = 0, isSuccess = false, message = _Message });
        }
        [HttpGet("Upload-Front-Photos")]
        public async Task<IActionResult> CreateUploadPhotoFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            UploadPhotoFrontViewModel uploadDetailView;
            uploadDetailView = id == 0 ? new UploadPhotoFrontViewModel() : await _settingRepository.GetUploadPhotoFileById(id);
            return View(uploadDetailView);
        }
        [HttpPost("Upload-Front-Photos")]
        public async Task<IActionResult> CreateUploadPhotoFile(UploadPhotoFrontViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    model.ExitPhotoPath = model.Photo != null ? ProcessUploadedFile(model) : null;
                    idno = await _settingRepository.AddNewUploadPhotoFile(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateUploadPhotoFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    if (model.Photo != null)
                    {
                        if (model.ExitPhotoPath != null)
                        {
                            string filename = Path.Combine(_hostingEnvironment.WebRootPath, "ImagesFront", model.ExitPhotoPath);
                            if (System.IO.File.Exists(filename))
                            {
                                System.IO.File.Delete(filename);
                            }
                        }
                        model.ExitPhotoPath = ProcessUploadedFile(model);
                    }
                    istrasferrecord = await _settingRepository.UpdateUploadPhotoFile(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateUploadPhotoFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [HttpGet("Delete-Front-Photos")]
        public async Task<IActionResult> DeleteUploadPhotoFile(int id = 0)
        {

            UploadPhotoFrontViewModel model = await _settingRepository.GetUploadPhotoFileById(id);
            _Message = "";
            bool isDelete = await _settingRepository.DeleteUploadPhoto(id);
            _Message = "Record Delete Successfully..";
            if (model.ExitPhotoPath != null)
            {
                string filename = Path.Combine(_hostingEnvironment.WebRootPath, "ImagesFront", model.ExitPhotoPath);
                if (System.IO.File.Exists(filename))
                {
                    System.IO.File.Delete(filename);
                }
            }
            return RedirectToAction(nameof(CreateUploadPhotoFile), new { id = 0, isSuccess = false, message = _Message });
        }
        private string ProcessUploadedFile(UploadPhotoFrontViewModel models)
        {
            string uniqueFileName = null;
            if (models.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "ImagesFront");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + models.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    models.Photo.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
        [HttpGet("Create-SMSKey")]
        public async Task<IActionResult> CreateSMSKey(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            SMSKeyViewModel smskeyDetailView;
            smskeyDetailView = id == 0 ? new SMSKeyViewModel() : await _settingRepository.GetSMSKeyById(id);
            return View(smskeyDetailView);
        }
        [HttpPost("Create-SMSKey")]
        public async Task<IActionResult> CreateSMSKey(SMSKeyViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.SMSKeyId == 0)
                {
                    idno = await _settingRepository.AddNewSMSKey(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateSMSKey), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _settingRepository.UpdateSMSKey(model);
                    idno = model.SMSKeyId;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateSMSKey), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSearchASMSKey(int CompId1)
        {
            var model = await _settingRepository.GetALLSMSKey(CompId1);
            return Ok(model);
        }
        [HttpGet("SMS-File")]
        public async Task<IActionResult> CreateSMSFile(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            SMSFileViewModel smsfileDetailView;
            smsfileDetailView = id == 0 ? new SMSFileViewModel() : await _settingRepository.GetSMSFileById(id);
            return View(smsfileDetailView);
        }
        [HttpPost("SMS-File")]
        public async Task<IActionResult> CreateSMSFile(SMSFileViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _settingRepository.AddNewSMSFile(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateSMSFile), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _settingRepository.UpdateSMSFile(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateSMSFile), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSearchASMSFile(int CompId1)
        {
            var model = await _settingRepository.GetALLSMSFile(CompId1);
            return Ok(model);
        }
        [HttpGet("Money-Master-File")]
        public async Task<IActionResult> CreateMoneyMaster(int id = 0, bool isSuccess = false, string message = "")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = message;
            MoneyMasterViewModel moneyMasterDetailView;
            moneyMasterDetailView = id == 0 ? new MoneyMasterViewModel() : await _settingRepository.GetMoneyMasterById(id);
            return View(moneyMasterDetailView);
        }
        [HttpPost("Money-Master-File")]
        public async Task<IActionResult> CreateMoneyMaster(MoneyMasterViewModel model)
        {
            idno = 0; istrasferrecord = false; _Message = "";
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    idno = await _settingRepository.AddNewMoneyMaster(model);
                    istrasferrecord = false;
                    _Message = "New Record Save Successfully..";
                    return RedirectToAction(nameof(CreateMoneyMaster), new { id = idno, isSuccess = true, message = _Message });
                }
                else
                {
                    istrasferrecord = await _settingRepository.UpdateMoneyMaster(model);
                    idno = model.Id;
                    _Message = "Record Update Successfully..";
                    return RedirectToAction(nameof(CreateMoneyMaster), new { id = idno, isSuccess = true, message = _Message });
                }
            }
            return View();
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetSearchAMoneyFile(int CompId1)
        {
            var model = await _settingRepository.GetALLMoneyMaster(CompId1);
            return Ok(model);
        }
    }
}
