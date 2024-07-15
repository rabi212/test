using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class DistrictViewModel
    {
        public int DistId { get; set; }

        [Required(ErrorMessage = "The District's Name Field Required")]
        [Display(Name = "District's Name :")]
        [StringLength(100)]
        public string DistrictName { get; set; }
        [Required(ErrorMessage = "The State's Name Field Required")]
        [Display(Name = "State's Name :")]
        public int? DistStateId { get; set; }
        public StateViewModel StateViewModel { get; set; }
        public virtual ICollection<CompanyDetailViewModel> CompanyViewModels { get; set; }
    }
}
