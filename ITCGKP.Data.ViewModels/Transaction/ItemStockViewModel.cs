using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCGKP.Data.ViewModels.Transaction
{
    public class ItemStockViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Type { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCode { get; set; }
        //[Required]
        public int? CompId { get; set; }        
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        [Required]
        [StringLength(6)]
        public string VouchVNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? VouchDate { get; set; }
        [Required]
        public int ItemCode { get; set; }        
        public virtual ItemMasterViewModel ItemMasterViewModel { get; set; }
        public string ItemNamex { get; set; }
        public decimal? UnitCaseX { get; set; }
        public string Trancode { get; set; }
        [Required]
        [StringLength(100)]
        public string BatchNo { get; set; }
        [Required]
        [StringLength(10)]
        public string ExpDate { get; set; }
        [Required]
        public int OpnPCS { get; set; }        
        [Required]
        public int PurPCS { get; set; }
        [Required]
        public int PurRtPCS { get; set; }        
        [Required]
        public int SalePCS { get; set; }
        [Required]
        public int SaleRtPCS { get; set; }
        //[Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscAmt { get; set; }
        //[Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? GSTPer { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal SaleRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal NetSaleRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal PurRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal NetPurRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal MRP { get; set; }       
        [Required]
        public int TempSrNo { get; set; }
       
    }
}