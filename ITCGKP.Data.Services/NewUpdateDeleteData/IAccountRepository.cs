using ITCGKP.Data.Models;
using ITCGKP.Data.ViewModels.Setting;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserRoleAsync(CreateRoleViewModel model);
        Task<EditRoleViewModel> GetEditRoleAsync(string id);
        Task<IdentityResult> CreateUserEditRoleAsync(EditRoleViewModel model);
        Task<IEnumerable<IdentityRole>> GetRoleListAsync();
        Task<IdentityResult> DeleteRoleAsync(string id);

        Task<IEnumerable<ApplicationUser>> GetUserListAsync();
        Task<IEnumerable<ApplicationUser>> GetUserListAsync(int compId);
        Task<EditUserViewModel> GetEditUserAsync(string id);
        Task<IdentityResult> EditUserAsync(EditUserViewModel model);
        Task<IdentityResult> EditUserLockAsync(string userid);
        Task<IdentityResult> DeleteUserAsync(string id);

        Task<List<UserRoleViewModel>> GetEditUserInRoleAsync(string roleId);
        Task<IdentityResult> EditUserInRoleAsync(UserRoleViewModel model, string roleId);
        Task<List<UserRolesViewModel>> GetManageUserRolesAsync(string userId);
        Task<List<UserRolesViewModel>> GetManageUserRolesAsync(string userId, string userroles);
        Task<IdentityResult> RemoveManageUserRolesAsync(string userId);
        Task<IdentityResult> ManageUserRolesAsync(List<UserRolesViewModel> model, string userId);

        Task<UserClaimsViewModel> GetManageUserClaimsAsync(string userId);
        Task<IdentityResult> RemoveManageUserClaimsAsync(string userId);
        Task<IdentityResult> ManageUserClaimsAsync(UserClaimsViewModel model, string userId);

        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(RegisterViewModel model);
        Task GenerateEmialConfirmationTokenAsync(ApplicationUser user);
        Task<SignInResult> PasswordSignInAsync(LoginViewModel model);
        Task SignOutAsync();
        Task<bool> CheckPassword(LoginViewModel model);
        Task<IdentityResult> ChangeUserPasswordAsync(ChangePasswordViewModel model);
        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
        Task GenerateForgotPasswordTokenAsync(ApplicationUser user);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordViewModel model);
    }
}