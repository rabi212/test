
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Setting;

namespace ITCGKP.Data.ViewModels.Master
{
    public class MedMasterViewModel
    {
        [Key]
        [Display(Name = "Id :")]
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel DoctorCompanyDetailsViews { get; set; }
        [Required(ErrorMessage = "The Field Required")]
        [Display(Name ="Test")]
        public string TestDetailsA { get; set; }
        [Display(Name = "Default Value")]
        public string PatResultA { get; set; }
        [Display(Name = "Range")]
        public string RangeDetailsA { get; set; }
        public bool TestLineA { get; set; }
        [Required(ErrorMessage = "The Field Required")]
        [Display(Name = "Test")]
        public string TestDetailsB { get; set; }
        [Display(Name = "Default Value")]
        public string PatResultB { get; set; }
        [Display(Name = "Range")]
        public string RangeDetailsB { get; set; }
        public bool TestLineB { get; set; }
    }
}