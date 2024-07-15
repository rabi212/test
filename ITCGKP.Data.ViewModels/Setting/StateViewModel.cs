using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class StateViewModel
    {
        public int StateId { get; set; }

        [Required(ErrorMessage = "State's name must be required")]
        [Display(Name = "State's Name :")]
        [StringLength(100)]
        public string StateName { get; set; }
        public virtual ICollection<DistrictViewModel> DistrictViewModel { get; set; }
    }
}
