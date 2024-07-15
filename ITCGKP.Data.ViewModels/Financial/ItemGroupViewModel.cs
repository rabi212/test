using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCGKP.Data.ViewModels.Financial
{
    public class ItemGroupViewModel
    {
        [Key]       
        public int Id { get; set; }
        [Required(ErrorMessage = "The Code Field Required ")]       
        [StringLength(3)]
        [Display(Name ="Code :")]
        public string ItGPCode { get; set; }
        [Required(ErrorMessage = "The Group's Name Field Required ")]
        [StringLength(100)]
        [Display(Name ="Item Group Name :")]
        public string ItemGroupName { get; set; }
        [Display(Name = "HSN Code")]
        [StringLength(8)]
        public string IHSNCode { get; set; }
        [Display(Name = "IGST %")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IGSTPer { get; set; }
        [Display(Name = "CGST %")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CGSTPer { get; set; }
        [Display(Name = "SGST %")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SGSTPer { get; set; }
        [Display(Name = "Cess %")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CessPer { get; set; }
    }
}