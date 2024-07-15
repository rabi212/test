using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class CreateRoleViewModel
    {      
        [Required]
        public string RoleName { get; set; }
    }
}
