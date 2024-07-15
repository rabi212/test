using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ITCGKP.Data.Models.Financial
{
    [Table("ItemGroupTable")]
    public class ItemGroup
    {
        [Key]        
        public int Id { get; set; }
        [Required]
        [StringLength(3)]
        public string ItGPCode { get; set; }
        [Required]
        [StringLength(100)]
        public string ItemGroupName { get; set; }
        [StringLength(8)]
        public string IHSNCode { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IGSTPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CGSTPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SGSTPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CessPer { get; set; }
    }
}