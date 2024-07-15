using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ITCGKP.Data.ViewModels.Transaction
{
    public class SaleRDetailViewModel
    {
        [Key]
        public int SRMDId { get; set; }
        [Required(ErrorMessage = "The Item name field must be required")]
        [Remote(action: "IsItemCodeValidation", controller: "DateCheck")]
        public int ItemCode { get; set; }
        public virtual ItemMasterViewModel ItemMasterViewModel { get; set; }
        [Required(ErrorMessage = "The Item name field must be required")]
        [StringLength(100)]
        public string SRItemName { get; set; }
        [Required(ErrorMessage = "The Batch No. field must be required")]
        [Display(Name = "Batch No.")]
        [StringLength(100)]
        public string BatchNo { get; set; }
        //[Required(ErrorMessage = "The Expire date field must be required")]
        //[Remote(action: "IsExpDateValidation", controller: "DateCheck")]
        [Display(Name = "Expire Date")]
        [StringLength(10)]
        public string ExpDate { get; set; }
        [Required(ErrorMessage = "The Pcs field must be required")]
        [Display(Name = "Qty")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? Qty { get; set; }
        [Display(Name = "Disc %")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscPer1 { get; set; }
        [Display(Name = "Total Dis. Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalDiscAmt { get; set; }
        [Required(ErrorMessage = "The Rate field must be required")]
        [Display(Name = "Sale Rate")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal CustSaleRate { get; set; }
        [Display(Name = "GST %")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? GSTPer { get; set; }
        [Required(ErrorMessage = "The Total Amount field must be required")]
        [Display(Name = "Total Amt")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalAmt { get; set; }
        [Required(ErrorMessage = "The Net Total Amount field must be required")]
        [Display(Name = "Net Amt")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? NetTotalAmt { get; set; }
        [Required(ErrorMessage = "The Purchase rate field must be required")]
        [Display(Name = "Pur Rate")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal PurRate { get; set; }
        [Required(ErrorMessage = "The MRP field must be required")]
        [Display(Name = "MRP")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal MRP { get; set; }
        [Required(ErrorMessage = "The Rate field must be required")]
        [Display(Name = "Rate")]
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
        //[Required]
        public int TempSrNo { get; set; }
        //[Required]
        public int CompIdSRItemMD { get; set; }
        //[Required]
        [StringLength(128)]
        public string UserCodeSRItemMD { get; set; }
        //[Required]
        [StringLength(6)]
        public string SRVNoD { get; set; }
        public int SRIMId { get; set; }
        public string RecordType { get; set; }
        public virtual SaleRViewModel SaleRViewModel { get; set; }
    }
}