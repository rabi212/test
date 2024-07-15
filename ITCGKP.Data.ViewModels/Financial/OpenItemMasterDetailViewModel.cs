using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Master;
using Microsoft.AspNetCore.Mvc;

namespace ITCGKP.Data.ViewModels.Financial
{
    public class OpenItemMasterDetailViewModel
    {
        [Key]
        public int OpnIMDId { get; set; }
        [Required(ErrorMessage ="The Item's Name Invalid")]
        [Display(Name ="Code")]
        public int ItemCode { get; set; }        
        public virtual ItemMasterViewModel ItemMasterViewModel { get; set; }
        [Required(ErrorMessage = "The Item's name invalid")]
        [Display(Name ="Item's Name")]
        [StringLength(100)]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "The Batch No. field must be required")]
        [Display(Name ="Batch No.")]
        [StringLength(100)]
        public string BatchNo { get; set; }
        //[Required(ErrorMessage = "The Expire date field must be required")]
        //[Remote(action: "IsExpDateValidation", controller: "DateCheck")]
        [Display(Name ="Expire Date")]        
        [StringLength(10)]
        public string ExpDate { get; set; }
        //[Required(ErrorMessage = "The Open Case field must be required")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name ="Opn Case")]        
        public decimal? CasePcs { get; set; }
        //[Required(ErrorMessage ="The Free Pcs field must be required")]
        [Display(Name ="Free Pcs")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? FreePcs { get; set; }
        [Required(ErrorMessage = "The Total Pcs field must be required")]
        [Display(Name = "Total Pcs")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal TotalPcs { get; set; }
        [Required(ErrorMessage = "The Purchase rate field must be required")]
        [Display(Name ="Pur Rate")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal PurRate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GSTPer { get; set; }
        [Required(ErrorMessage = "The MRP field must be required")]
        [Display(Name ="MRP")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal MRP { get; set; }
        [Required(ErrorMessage = "The Sale Rate field must be required")]
        [Display(Name = "Sale Rate")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal SaleRate { get; set; }
        [Required(ErrorMessage = "The Net Purchase Rate field must be required")]
        [Display(Name = "Net Pur Rate")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal NetPurRate { get; set; }
        [Required(ErrorMessage = "The Purchase Amount field must be required")]
        [Display(Name = "Pur. Amt")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal PurAmt { get; set; }
        [Required(ErrorMessage = "The Net Purchase Amount field must be required")]
        [Display(Name = "Net Pur Amt")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal NetPurAmt { get; set; }
        [Required(ErrorMessage = "The MRP Amount field must be required")]
        [Display(Name = "MRP Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal MRPAmt { get; set; }
        [Display(Name = "Cess %")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CessPer { get; set; }
        [Display(Name = "Cess Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CessAmt { get; set; }
        [Display(Name = "Unit Case")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? UnitCase { get; set; }
        // [Required]
        public int? TempSrNo { get; set; }
        //[Required]
        public int CompIdOpnItemMD { get; set; }
        //[Required]        
        public string UserCodeOpnItemMD { get; set; }
        //[Required]
        [StringLength(6)]
        public string OpnVNoD { get; set; }
        public int OpnIMId { get; set; }        
        public virtual OpenItemMasterViewModel OpenItemMasterViewModels { get; set; }
       
    }
}