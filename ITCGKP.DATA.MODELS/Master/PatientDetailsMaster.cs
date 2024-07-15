using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("PatientDetailsMasterTable")] 
    public class PatientDetailsMaster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string  Mode { get; set; } // Test Group Short Name for filter
        public int TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual TestMaster TestMaster { get; set; }        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? StanderRate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPPer1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPAmt1 { get; set; }
        [Required]
        public int TempSrNo { get; set; }
        public int PtIMId { get; set; }
        [ForeignKey("PtIMId")]
        public virtual Patient Patient { get; set; }
        public int CompIdX { get; set; }       
        [StringLength(128)]
        public string UserCodeX { get; set; }
        [Required]
        [StringLength(20)]
        public string VNoX { get; set; }
        public bool PrintTest { get; set; }
    }
}