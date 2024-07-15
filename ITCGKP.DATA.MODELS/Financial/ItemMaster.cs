using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITCGKP.Data.Models.Financial
{
    [Table("ItemTable")]
    public class ItemMaster
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [StringLength(4)]
        public string ItemCode { get; set; }        
        public int? PackId { get; set; }
        [ForeignKey("PackId")]
        public virtual PackingMaster PackingMaster { get; set; }        
        public int? ItGPCode { get; set; }
        [ForeignKey("ItGPCode")]
        public virtual ItemGroup Itemdetails { get; set; }        
        public int? ProdId { get; set; }
        [ForeignKey("ProdId")]
        public virtual ProductCompany ProductCompany { get; set; }
        public int? UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual UnitMeasurement UnitMeasurement { get; set; }
        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }
        //[Required]
        [StringLength(8)]
        public string IHSNCode { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GSTPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CessPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ProfitPer { get; set; }
        [Required]
        public int UnitCase { get; set; }
        public int ShowStock { get; set; } // 0 = Yes 1 = No
        public int ReversCharge { get; set; } // 0 = No 1 = Yes
    }
}