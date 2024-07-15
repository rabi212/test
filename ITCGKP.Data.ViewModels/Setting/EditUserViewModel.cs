using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        [Required]
        [Display(Name = "Center's Name")]
        public int? CompanyDetailId { get; set; }
        [Required]
        [Display(Name = "Center Client Name")]
        public int? ClientId { get; set; }        

        //public CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}
