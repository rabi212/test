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
    [Table("SaleDetailTable")]
    public class SaleDetail
    {
        [Key]
        public int SSMDId { get; set; }
        [Required]
        public int ItemCode { get; set; }
        [ForeignKey("ItemCode")]
        public virtual ItemMaster ItemMaster { get; set; }
        [Required]
        [StringLength(100)]
        public string SSItemName { get; set; }
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
        public int CompIdSSItemMD { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCodeSSItemMD { get; set; }
        [Required]
        [StringLength(6)]
        public string SSVNoD { get; set; }        
        public int SSIMId { get; set; }
        [ForeignKey("SSIMId")]
        public virtual Sale Sale { get; set; }       
    }
}