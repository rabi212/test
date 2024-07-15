using ITCGKP.Data.Models.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Master
{
    [Table("MedMasterTable")]
    public class MedMaster
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail DoctorCompanyDetails { get; set; }
        public string TestDetailsA { get; set; }
        public string PatResultA { get; set; }
        public string RangeDetailsA { get; set; }
        public bool TestLineA { get; set; }
        public string TestDetailsB { get; set; }
        public string PatResultB { get; set; }
        public string RangeDetailsB { get; set; }
        public bool TestLineB { get; set; }
    }
}
