using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ITCGKP.Data.ViewModels.Financial
{
    public class UnitMeasurementViewModel
    {
        [Key]       
        public int Id { get; set; }
        [Required(ErrorMessage = "The Code field must be required ")]       
        [StringLength(3)]
        [Display(Name ="Code")]
        public string UnitCode { get; set; }
        [Required(ErrorMessage = "The Unit's name field must be required ")]
        [StringLength(100)]
        [Display(Name ="Unit's Name")]
        public string UnitName { get; set; }
        [Required]
        [Display(Name ="UQC(Name)")]
        public int? UQCId { get; set; }
        public virtual UQCMasterViewModel UQCMasterViewModel { get; set; }
    }
}