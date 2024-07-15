using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("TestSubMasterTable")]
    public class TestSubMaster
    {
        [Key]
        public int Id { get; set; }        
        public string TestDetails { get; set; }
        [StringLength(100)]
        public string ColFirst { get; set; }
        [StringLength(100)]
        public string ColSecond { get; set; }
        [StringLength(100)]
        public string ColThird { get; set; }
        [StringLength(100)]
        public string ColFourth { get; set; }
        [StringLength(100)]
        public string ColFifth { get; set; }
        [StringLength(100)]
        public string ColSixth { get; set; }
        public bool VisualTrueFalse { get; set; }
        [StringLength(5)]
        public string TestLocked { get; set; }
        [StringLength(2)]
        public string Gender { get; set; }
        [StringLength(20)]
        public string Units { get; set; }
        [StringLength(20)]
        public string  FromRange { get; set; }
        [StringLength(20)]
        public string UptoRange { get; set; }
        [StringLength(5)]
        public string RangeSymble { get; set; }
        public string RangeDetails { get; set; }        
        [StringLength(10)]
        public string AgeType { get; set; }
        public int FromAge { get; set; }
        public int UptoAge { get; set; }
        public string  DefaultResult { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MiniRange { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxRange { get; set; }
        public int? TempNo { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail TestSubCompanyDetails { get; set; }
        public int TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual TestMaster TestMaster { get; set; }
    }
}