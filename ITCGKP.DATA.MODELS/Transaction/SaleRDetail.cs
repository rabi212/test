using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Financial;
using ITCGKP.Data.Models.Master;

namespace ITCGKP.Data.Models.Transaction
{
    [Table("SaleRDetailTable")]
    public class SaleRDetail
    {
        [Key]
        public int SRMDId { get; set; }
        [Required]
        public int ItemCode { get; set; }
        [ForeignKey("ItemCode")]
        public virtual ItemMaster ItemMaster { get; set; }
        [Required]
        [StringLength(100)]
        public string SRItemName { get; set; }
        [Required]
        [StringLength(100)]
        public string BatchNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? ExpDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Qty { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscPer1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalDiscAmt { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CustSaleRate { get; set; }
        //[Required(ErrorMessage = "The GST % field must be required")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GSTPer { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmt { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetTotalAmt { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MRP { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaleRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetPurRate { get; set; }
        [Required]
        public int TempSrNo { get; set; }
        [Required]
        public int CompIdSRItemMD { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCodeSRItemMD { get; set; }
        [Required]
        [StringLength(6)]
        public string SRVNoD { get; set; }
        public int SRIMId { get; set; }
        [ForeignKey("SRIMId")]
        public virtual SaleR SaleR { get; set; }       
    }
}