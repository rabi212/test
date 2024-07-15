using ITCGKP.Data.Models;
using ITCGKP.Data.Services.ProvideService;
using ITCGKP.Data.ViewModels.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager, IUserService userService, 
                                IEmailService emailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
           _roleManager = roleManager;
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
        }
        public async Task<IdentityResult> CreateUserRoleAsync(CreateRoleViewModel model)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };                           
            return await _roleManager.CreateAsync(identityRole);
        }
        public async Task<EditRoleViewModel> GetEditRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var model = new EditRoleViewModel();
            if (role == null)
            {
                model.Id = "0";
            }
            else
            {
                model.Id = role.Id;
                model.RoleName = role.Name;
                foreach (var user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        model.Users.Add(user.UserName);
                    }
                }
            }
            return model;
        }
        public async Task<IdentityResult> CreateUserEditRoleAsync(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            role.Name = model.RoleName;
            var result = await _roleManager.UpdateAsync(role);
            return result;
        }
        public async Task<IEnumerable<IdentityRole>> GetRoleListAsync()
        {
            return await Task.FromResult( _roleManager.Roles);
        }
        public async Task<IdentityResult> DeleteRoleAsync(string id )
        {
            return await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id));
        }
        public async Task<IEnumerable<ApplicationUser>> GetUserListAsync()
        {
            return await Task.FromResult(_userManager.Users);
        }
        public async Task<IEnumerable<ApplicationUser>> GetUserListAsync(int compId)
        {
            return await Task.FromResult(_userManager.Users.Where(x => x.CompanyDetailId == compId));
        }
        public async Task<EditUserViewModel> GetEditUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var model = new EditUserViewModel();
            if (user == null)
            {
                model.Id = "0";
            }
            else
            {
                var userClaims = await _userManager.GetClaimsAsync(user);
                var userRoles = await _userManager.GetRolesAsync(user);

                model.Id = user.Id;
                model.Email = user.Email;
                model.UserName = user.UserName;
                model.City = user.City;
                model.CompanyDetailId = user.CompanyDetailId;
                model.ClientId = user.ClientId;
                model.Claims = userClaims.Select(c => c.Type + " : " + c.Value).ToList();
                model.Roles = userRoles;
            }
            return model;
        }
        public async Task<IdentityResult> EditUserAsync(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.City = model.City;
            user.CompanyDetailId = model.CompanyDetailId;
            user.ClientId = model.ClientId;
            var result = await _userManager.UpdateAsync(user);
            return result;
        }
        public async Task<IdentityResult> EditUserLockAsync(string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            user.LockoutEnd = DateTime.Now.AddDays(1);            
            var result = await _userManager.UpdateAsync(user);
            return result;
        }
        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            return await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id));
        }
        public async Task<List<UserRoleViewModel>> GetEditUserInRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            var model = new List<UserRoleViewModel>();
            foreach (var user in _userManager.Users)
            {
                var UserRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                //UserRoleViewModel.IsSelected = (await userManager.IsInRoleAsync(user, role.Name) == true ? true:false);
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    UserRoleViewModel.IsSelected = true;
                }
                else
                {
                    UserRoleViewModel.IsSelected = false;
                }
                model.Add(UserRoleViewModel);
            }
            return model;
        }
        public async Task<IdentityResult> EditUserInRoleAsync(UserRoleViewModel model, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);            
                var user = await _userManager.FindByIdAsync(model.UserId);
                IdentityResult result = null;
                if (model.IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model.IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                
            return result;
        }
        public async Task<List<UserRolesViewModel>> GetManageUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var model = new List<UserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var UserRolesViewModel = new UserRolesViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    UserRolesViewModel.IsSelected = true;
                }
                else
                {
                    UserRolesViewModel.IsSelected = false;
                }
                model.Add(UserRolesViewModel);
            }
            return model;
        }
        public async Task<List<UserRolesViewModel>> GetManageUserRolesAsync(string userId,string userroles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            List<UserRolesViewModel> model = new List<UserRolesViewModel>();
            foreach (var role in _roleManager.Roles.Where(x => x.Name != userroles))
            {
                var UserRolesViewModel = new UserRolesViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    UserRolesViewModel.IsSelected = true;
                }
                else
                {
                    UserRolesViewModel.IsSelected = false;
                }
                model.Add(UserRolesViewModel);
            }
            return model;
        }
        public async Task<IdentityResult> RemoveManageUserRolesAsync(string userId)
        {            
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            return result;
        }
        public async Task<IdentityResult> ManageUserRolesAsync(List<UserRolesViewModel> model,string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.AddToRolesAsync(user,
                    model.Where(x => x.IsSelected).Select(y => y.RoleName));
            return result;
        }
        public async Task<UserClaimsViewModel> GetManageUserClaimsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);          
            var existingUserClaims = await _userManager.GetClaimsAsync(user);
            var model = new UserClaimsViewModel { UserId = userId };
            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };
                if (existingUserClaims.Any(c => c.Type == claim.Type && c.Value == "true"))
                {
                    userClaim.IsSelected = true;
                }
                model.Claims.Add(userClaim);
            }
            return model;
        }       
        public async Task<IdentityResult> RemoveManageUserClaimsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);

            return result;
        }
        public async Task<IdentityResult> ManageUserClaimsAsync(UserClaimsViewModel model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.AddClaimsAsync(user,
                model.Claims.Select(c => new Claim(c.ClaimType, c.IsSelected ? "true" : "false")));
            return result;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<IdentityResult> CreateUserAsync(RegisterViewModel model)
        {
            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                City = model.City,
                Address = model.Address,
                CompanyDetailId = model.CompanyDetailId,
                ClientId = model.ClientId
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (!string.IsNullOrEmpty(token))
                {
                    await GenerateEmialConfirmationTokenAsync(user);
                }
            }
            return result;
        }
        public async Task GenerateEmialConfirmationTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailConfirmationEmail(user, token);
            }
        }
        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token);
            }
        }
        public async Task<SignInResult> PasswordSignInAsync(LoginViewModel model)
        {
          return  await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,true);            
        }
        public async Task<bool> CheckPassword(LoginViewModel model)
        {
             var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, model.Password)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task SignOutAsync()
        {
           await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> ChangeUserPasswordAsync(ChangePasswordViewModel model)
        {
            var userId = await _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            return result;
        }
        public async Task<IdentityResult> ConfirmEmailAsync(string uid,string token)
        {
           return  await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        }
        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token,model.NewPassword);
        }
        private async Task SendEmailConfirmationEmail(ApplicationUser user , string token)
        {
            string AppDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationlink = _configuration.GetSection("Application:EmailConfirmation").Value;
            UserEmailOptions userEmailOptions = new UserEmailOptions
            {
                ToEmails = new List<string>() {user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{username}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(AppDomain + confirmationlink,user.Id,token))
                }
            };
            await _emailService.SendEmailForEmailConfirmation(userEmailOptions);
        }
        private async Task SendForgotPasswordEmail(ApplicationUser user, string token)
        {
            string AppDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationlink = _configuration.GetSection("Application:ForgotPassword").Value;
            UserEmailOptions userEmailOptions = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{username}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(AppDomain + confirmationlink,user.Id,token))
                }
            };
            await _emailService.SendEmailForForgotPassword(userEmailOptions);
        }        
    }
}
