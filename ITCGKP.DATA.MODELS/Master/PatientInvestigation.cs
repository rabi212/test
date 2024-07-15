using ITCGKP.Data.Models.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Master
{
    [Table("PatientInvestigationTable")]
    public class PatientInvestigation
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
        public string PatResult { get; set; }
        public bool VisualTrueFalse { get; set; }
        [StringLength(5)]
        public string TestLocked { get; set; }
        [StringLength(2)]
        public string Gender { get; set; }
        [StringLength(20)]
        public string Units { get; set; }
        [StringLength(20)]
        public string FromRange { get; set; }
        [StringLength(20)]
        public string UptoRange { get; set; }
        [StringLength(5)]
        public string RangeSymble { get; set; }
        public string RangeDetails { get; set; }
        public int FromAge { get; set; }
        public int UptoAge { get; set; }
        public string DefaultResult { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MiniRange { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxRange { get; set; }
        public bool PrintTrueFalse { get; set; }
        public int? TempNo { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail TestSubCompanyDetails { get; set; }
        public int? TestIdX { get; set; }
        [ForeignKey("TestIdX")]
        public virtual TestMaster TestMaster { get; set; }
        public int? TestSubId { get; set; }
        [ForeignKey("TestSubId")]
        public virtual TestSubMaster TestSubMaster { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
    }
}
