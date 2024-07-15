using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCGKP.Data.ViewModels.Financial
{ 
    public class ItemMasterViewModel
    {
        [Key]
        public int ItemId { get; set; }
        [Required(ErrorMessage = "The Item code field mubst be required")]
        [StringLength(4)]
        [Display(Name = "Code")]
        public string ItemCode { get; set; }
        [Required(ErrorMessage = "The Packing field must be required ")]
        [Display(Name = "Pack's Name")]
        public int? PackId { get; set; }
        public virtual PackingMasterViewModel PackingMasterViewModel { get; set; }
        [Required(ErrorMessage = "The Item's group name field must be required")]
        [Display(Name = "Item Group's Name")]
        public int? ItGPCode { get; set; }
        public virtual ItemGroupViewModel ItemGroupViewModel { get; set; }
        [Required(ErrorMessage = "The Under Compnay name field must be required")]
        [Display(Name = "Company's Name")]
        public int? ProdId { get; set; }
        public virtual ProductCompanyViewModel ProductCompanyViewModel { get; set; }
        [Required(ErrorMessage = "The Unit's Name field must be required")]
        [Display(Name = "Unit's Name")]
        public int? UnitId { get; set; }
        public virtual UnitMeasurementViewModel UnitMeasurementViewModel { get; set; }
        [Required(ErrorMessage = "The Item's name field must be required")]
        [Display(Name = "Item's Name")]
        [StringLength(100)]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "The HSN code field must be required")]
        [Display(Name = "HSN Code")]
        [StringLength(8)]
        public string IHSNCode { get; set; }
        //[Required(ErrorMessage = "The Discount from Purchase Field Required")]
        [Display(Name = "Disc. %")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscPer { get; set; }
        [Required(ErrorMessage = "The GST % field must be required")]
        [Display(Name = "GST %")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GSTPer { get; set; }
        [Display(Name = "Cess %")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CessPer { get; set; }
        [Display(Name = "IP(+/-)")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ProfitPer { get; set; }
        [Required(ErrorMessage = "The Unit of one case field must be required")]
        [Display(Name = "Unit Of Case")]
        public decimal? UnitCase { get; set; }
        [Required(ErrorMessage = "The Show Stock field must be required")]
        [Display(Name = "Show Stock")]
        public StockTransfer ShowStock { get; set; } // 0 = Yes 1 = No
        [Required(ErrorMessage = "The Reverse Charge field must be required")]
        [Display(Name = "Reverse Charges")]
        public ReverseCharged ReversCharge { get; set; } // 0 = No 1 = Yes
    }
}