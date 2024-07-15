using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
using Microsoft.AspNetCore.Mvc;

namespace ITCGKP.Data.ViewModels.Transaction
{
    public class PurchaseRDetailViewModel
    {
        [Key]
        public int STMDId { get; set; }
        [Required(ErrorMessage = "The Item name field must be required")]
        [Remote(action: "IsItemCodeValidation", controller: "DateCheck")]
        [Display(Name = "Item Code")]
        public int ItemCode { get; set; }
        public virtual ItemMasterViewModel ItemMasterViewModel { get; set; }
        [Required(ErrorMessage = "The Item name field must be required")]
        [Display(Name = "Item Name")]
        [StringLength(100)]
        public string STItemName { get; set; }
        [Required(ErrorMessage = "The Batch No. field must be required")]
        [Display(Name = "Batch No.")]
        [StringLength(100)]
        public string BatchNo { get; set; }
        //[Required(ErrorMessage = "The Expire date field must be required")]
        //[Remote(action: "IsExpDateValidation", controller: "DateCheck")]
        [Display(Name = "Expire Date")]
        [StringLength(10)]
        public string ExpDate { get; set; }
        [Required(ErrorMessage = "The Unit Case field must be required")]
        [Display(Name = "Unit")]
        public decimal? CasePcs { get; set; }
        //[Required]
        [Display(Name = "On Free Case")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? OnFreeCase { get; set; }     // 10 strip par 1 strip free
        [Display(Name = "Unit of One Case")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? UnitCase { get; set; }
        //[Required(ErrorMessage = "The Free Pcs field must be required")]
        [Display(Name = "Free Pcs")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? FreePcs { get; set; }
        [Required(ErrorMessage = "The Total Pcs field must be required")]
        [Display(Name = "Total Pcs")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalPcs { get; set; }
        [Required(ErrorMessage = "The Purchase rate field must be required")]
        [Display(Name = "Pur Rate")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal PurRate { get; set; }
        [Display(Name = "Disc % 1")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscPer1 { get; set; }
        [Display(Name = "Disc Amt. 1")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscAmt1 { get; set; }
        [Display(Name = "Disc % 2")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscPer2 { get; set; }
        [Display(Name = "Disc Amt. 2")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscAmt2 { get; set; }
        [Display(Name = "Disc % 3")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscPer3 { get; set; }
        [Display(Name = "Disc Amt. 3")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscAmt3 { get; set; }
        [Display(Name = "Total Disc Amt")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalDiscAmt { get; set; }
        //[Required(ErrorMessage = "The GST % field must be required")]
        [Display(Name = "GST %")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? GSTPer { get; set; }
        [Display(Name = "CGST")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CGSTAmt { get; set; }
        [Display(Name = "SGST")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? SGSTAmt { get; set; }
        [Display(Name = "IGST")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? IGSTAmt { get; set; }
        [Required(ErrorMessage = "The MRP field must be required")]
        [Display(Name = "MRP")]
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
        //[Required]
        public int TempSrNo { get; set; }
        //[Required]
        public int CompIdSTItemMD { get; set; }
        //[Required]
        [StringLength(128)]
        public string UserCodeSTItemMD { get; set; }

        //[Required]
        [StringLength(6)]
        public string STVNoD { get; set; }
        public int STIMId { get; set; }
        public string RecordType { get; set; }
        public virtual PurchaseRViewModel PurchaseRViewModel { get; set; }
    }
}