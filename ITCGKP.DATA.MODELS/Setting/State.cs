using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Setting
{
    [Table("StateTable")]
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        [StringLength(100)]
        public string StateName { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
