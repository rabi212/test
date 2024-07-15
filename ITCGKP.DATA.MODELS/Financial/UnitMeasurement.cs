using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ITCGKP.Data.Models.Financial
{
    [Table("UnitMeasurementTable")]
    public class UnitMeasurement
    {
        [Key]        
        public int Id { get; set; }
        [Required]
        [StringLength(3)]
        public string UnitCode { get; set; }
        [Required]
        [StringLength(100)]
        public string UnitName { get; set; }
        public int? UQCId { get; set; }
        [ForeignKey("UQCId")]
        public virtual UQCMaster UQCMaster { get; set; }
    }
}