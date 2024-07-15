using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("TestResultDetailTable")]
    public class TestResultDetail
    {
        [Key]
        public int Id { get; set; }        
        public string PatientValue { get; set; }        
        public int? TempNo { get; set; }
        public int TestResultId { get; set; }
        [ForeignKey("TestResultId")]
        public virtual TestResult TestResult { get; set; }
    }
}