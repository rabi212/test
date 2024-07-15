using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Financial
{
    [Table("ProductCompanyTable")]
   public class ProductCompany
    {
        [Key]
        public int ProdId { get; set; }
        [Required]
        [StringLength(3)]
        public string ProdCode { get; set; }
        [Required]
        [StringLength(128)]
        public string ProdName { get; set; }
    }
}
