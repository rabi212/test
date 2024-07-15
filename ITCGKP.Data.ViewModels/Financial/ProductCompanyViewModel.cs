using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Financial
{
    public class ProductCompanyViewModel
    {
        [Key]
        public int ProdId { get; set; }
        [Required(ErrorMessage ="The Product company code field must be required")]
        [Display(Name ="Code")]
        [StringLength(3)]
        public string ProdCode { get; set; }
        [Required(ErrorMessage = "The Product company name field must be required")]
        [Display(Name = "Company Name")]
        [StringLength(128)]
        public string ProdName { get; set; }
    }
}
