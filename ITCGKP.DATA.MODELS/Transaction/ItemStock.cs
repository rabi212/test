using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;
using ITCGKP.Data.Models.Financial;
using ITCGKP.Data.Models.Master;

namespace ITCGKP.Data.Models.Transaction
{
    [Table("ItemStockTable")]
    public class ItemStock
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Type { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCode { get; set; }       
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail CompanyDetail { get; set; }
        [Required]
        [StringLength(6)]
        public string VouchVNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? VouchDate { get; set; }
        [Required]
        public int ItemCode { get; set; }
        [ForeignKey("ItemCode")]
        public virtual ItemMaster ItemMaster { get; set; }
        [Required]
        [StringLength(100)]
        public string BatchNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? ExpDate { get; set; }
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
        public decimal? DiscAmt { get; set; }
        //[Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GSTPer { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaleRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSaleRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetPurRate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MRP { get; set; }       
        public int? TempNo { get; set; }       
    }
}