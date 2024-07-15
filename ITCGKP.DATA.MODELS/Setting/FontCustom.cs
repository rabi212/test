using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Setting
{
    [Table("FontCustomTable")]
    public class FontCustom
    {
        [Key]
        public int Id { get; set; }
        [Required]       
        public string Name { get; set; }
    }
}
