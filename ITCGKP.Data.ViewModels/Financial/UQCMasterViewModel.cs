using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Financial
{
    public class UQCMasterViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(3)]
        [Display(Name ="Unique Quantity Code(UQC)")]
        public string Code { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name ="Name")]
        public string Name { get; set; }       
    }
}
