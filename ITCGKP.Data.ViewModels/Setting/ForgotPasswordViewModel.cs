using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class ForgotPasswordViewModel
    {
        [Required, EmailAddress, Display(Name ="Registered email address :")]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
