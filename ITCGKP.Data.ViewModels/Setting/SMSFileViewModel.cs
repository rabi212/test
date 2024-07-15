using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class SMSFileViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel SMSFileCompanyDetailsViews { get; set; }
        [Required]
        [Display(Name ="Date of Birth Message :")]
        public string Dateofbirth { get; set; }
        [Required]
        [Display(Name = "Date of Anniversary Message :")]
        public string DateofAnniversary { get; set; }
        [Required]
        [Display(Name = "Date of Registration Message :")]
        public string DateOfInstallment { get; set; }
        [Required]
        [Display(Name = "Date of Complete Report Message :")]
        public string DateOfMaturity { get; set; }
    }
}
