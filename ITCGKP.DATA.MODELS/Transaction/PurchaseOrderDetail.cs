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
    [Table("PurchaseOrderDetailTable")]
    public class PurchaseOrderDetail
    {
        [Key]
        public int SOMDId { get; set; }
        [Required]
        public int ItemCode { get; set; }
        [ForeignKey("ItemCode")]
        public virtual ItemMaster ItemMaster { get; set; }
        [Required]
        [StringLength(100)]
        public string SSItemName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CasePcs { get; set; }       
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rate { get; set; }
        [StringLength(100)]
        public string UnitName { get; set; }
        [Display(Name = "GST %")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GSTPer { get; set; }
        [Required]
        public int TempSrNo { get; set; }
        [Required]
        public int CompIdSOItemMD { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCodeSOItemMD { get; set; }
        [Required]
        [StringLength(6)]
        public string SOVNoD { get; set; }
        public int SOIMId { get; set; }
        [ForeignKey("SOIMId")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }       
    }
}