using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ITCGKP.Data.ViewModels.Financial
{
    public class PackingMasterViewModel
    {
        [Key]        
        public int PackId { get; set; }
        [Required (ErrorMessage ="The Packing code field must be required")]
        [Display(Name = "Code")]
        [StringLength(3)]
        public string PackCode { get; set; }

        [Required(ErrorMessage = "The Packing  name field must be required")]
        [Display(Name = "Pack's Name :")]
        [StringLength(128)]
        public string PackName { get; set; }        
        public virtual ICollection<ItemMasterViewModel> ItemMasterViewModels { get; set; }
    }
}