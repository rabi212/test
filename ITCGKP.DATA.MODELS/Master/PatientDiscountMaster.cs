using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("PatientDiscountMasterTable")] 
    public class PatientDiscountMaster
    {
        [Key]
        public int Id { get; set; }       
        public int TestGId { get; set; }
        [ForeignKey("TestGId")]
        public virtual TestGroupMaster TestGroupMaster { get; set; }        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscPer1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscAmt1 { get; set; }       
        public int PtIMId { get; set; }
        [ForeignKey("PtIMId")]
        public virtual Patient Patient { get; set; }
        public int CompIdX { get; set; }       
        [StringLength(128)]
        public string UserCodeX { get; set; }
        [Required]
        [StringLength(20)]
        public string VNoX { get; set; }
    }
}