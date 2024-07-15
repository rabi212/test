using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Setting
{
    [Table("DistrictTable")]
    public class District
    {
        [Key]
        public int DistId { get; set; }
        [Required]
        [StringLength(100)]
        public string DistrictName { get; set; }
        public int DistStateId { get; set; }
        [ForeignKey("DistStateId")]
        public virtual State StateDetails { get; set; }
       
    }
}
