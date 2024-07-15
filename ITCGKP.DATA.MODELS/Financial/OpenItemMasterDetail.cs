using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.Models.Master;

namespace ITCGKP.Data.Models.Financial
{
    [Table("OpenItemMasterDetailTable")]
    public class OpenItemMasterDetail
    {
        [Key]
        public int OpnIMDId { get; set; }        
        [Required]
        public int ItemCode { get; set; }
        [ForeignKey("ItemCode")]
        public virtual ItemMaster ItemMaster { get; set; }
        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }
        [Required]
        [StringLength(100)]
        public string BatchNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? ExpDate { get; set; }
        //[Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CasePcs { get; set; }        
        //[Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? FreePcs { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPcs { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurRate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GSTPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CessPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CessAmt { get; set; }
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
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurAmt { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetPurAmt { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MRPAmt { get; set; }        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? UnitCase { get; set; }
        [Required]
        public int TempSrNo { get; set; }
        [Required]
        public int CompIdOpnItemMD { get; set; }                
        [Required]
        [StringLength(128)]
        public string UserCodeOpnItemMD { get; set; }
        [Required]
        [StringLength(6)]
        public string OpnVNoD { get; set; }

        public int OpnIMId { get; set; }
        [ForeignKey("OpnIMId")]
        public virtual OpenItemMaster OpenItemMaster1 { get; set; }
       
    }
}