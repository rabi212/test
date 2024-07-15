using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITCGKP.Data.Models.Financial
{
    [Table("HeadGroupTable")]
    public class AccountGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(3)]
        public string HDGCode { get; set; }
        [Required]
        [StringLength(100)]
        public string Ledger_Name { get; set; }
        [Required]
        [StringLength(100)]       
        public string Under_Name { get; set; }               
        public int? Nature { get; set; }
        [Required]
        public int TNo1 { get; set; }
        public bool EffectGrossProfit { get; set; }
    }
}