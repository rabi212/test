using ITCGKP.Data.Models.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Master
{
    [Table("TestResultTable")]
    public class TestResult
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail CompanyDetail { get; set; }
        public int? TestIdX { get; set; }
        public string TestDetailName { get; set; }
        public virtual ICollection<TestResultDetail> TestResultDetails { get; set; }
    }
}
