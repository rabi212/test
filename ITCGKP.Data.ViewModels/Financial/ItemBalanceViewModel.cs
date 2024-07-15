using ITCGKP.Data.ViewModels.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Financial
{
   public class ItemBalanceViewModel
    {
        [Key]
        public int Id { get; set; }
        public int CompId { get; set; }        
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }        
        public int ItemCode { get; set; }        
        public virtual ItemMasterViewModel ItemMasterViewModel { get; set; }        
        [Display(Name ="Batch No.")]
        [StringLength(100)]
        public string BatchNo { get; set; }        
        public string ExpDate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "MRP")]
        public decimal MRP { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Pur Rate")]
        public decimal PurRate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Net Pur Rate")]
        public decimal NetPurRate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Sale Rate")]
        public decimal SaleRate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Net Sale Rate")]
        public decimal NetSaleRate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "GST %")]
        public decimal GSTPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Cess %")]
        public decimal CessPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "+  Case")]
        public decimal? OnFreeCase { get; set; } // 10 strip par 1 strip free
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Bal. Qty")]
        public decimal BalQty { get; set; }
    }
}
