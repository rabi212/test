using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string UserId { get; set; } 
        public string Token { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }
        public bool IsSuccess { get; set; }

    }
}
