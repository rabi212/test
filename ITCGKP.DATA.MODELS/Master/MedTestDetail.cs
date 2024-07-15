using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("MedTestDetailTable")]  // Size Master
    public class MedTestDetail
    {
        [Key]
        public int Id { get; set; }
        public int? MedId { get; set; }
        [ForeignKey("MedId")]
        public virtual MedTest MedTest { get; set; }
        public string TestDetailsA { get; set; }
        public string PatResultA { get; set; }
        public string RangeDetailsA { get; set; }
        public bool TestLineA { get; set; }
        public string TestDetailsB { get; set; }
        public string PatResultB { get; set; }
        public string RangeDetailsB { get; set; }
        public bool TestLineB { get; set; }
        [Required]
        public int TempSrNo { get; set; }
    }
}