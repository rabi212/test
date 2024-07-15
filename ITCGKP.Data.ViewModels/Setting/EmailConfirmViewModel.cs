using System;
using System.Collections.Generic;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class EmailConfirmViewModel
    {
        public string Email { get; set; }
        public bool IsConfirm { get; set; }
        public bool EmailSend { get; set; }
        public bool EmailVerified { get; set; }
    }
}
