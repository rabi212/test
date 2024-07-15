using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ITCGKP.Data.Models.Financial
{
    [Table("UQCMasterTable")]
    public class UQCMaster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(3)]
        public string Code { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }       
    }
}
