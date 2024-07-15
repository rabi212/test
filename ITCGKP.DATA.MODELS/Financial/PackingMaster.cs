using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ITCGKP.Data.Models.Financial
{
    [Table("PackingTable")]
    public class PackingMaster
    {
        [Key]
        public int PackId { get; set; }
        [Required]
        [StringLength(3)]
        public string PackCode { get; set; }
        [Required]
        [StringLength(128)]
        public string PackName { get; set; }
        
        public virtual ICollection<ItemMaster> ItemMasters { get; set; }
    }
}