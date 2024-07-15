using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("TestMasterTable")]  // Vender
    public class TestMaster
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail TestCompanyDetails { get; set; }
        [Required]
        [StringLength(100)]
        public string TestCode { get; set; }
        public int? ReportId { get; set; }
        [ForeignKey("ReportId")]
        public virtual ReportGroup ReportGroup { get; set; }
        public int? TestGroupId { get; set; }
        [ForeignKey("TestGroupId")]
        public virtual TestGroupMaster TestGroupMaster { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPPer1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPAmt1 { get; set; }
        [Required]
        [StringLength(15)]
        public string documentType  { get; set; } // Reading or ducument
        [Required]       
        public int ColumnsNo { get; set; }  // reading time columns
        [Required]
        [StringLength(5)]
        public string GraphsType { get; set; }  // reading time Fixed 3 columns Yes/No
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PPRate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CCRate { get; set; }
        public virtual ICollection<TestSubMaster> TestSubMasters { get; set; }
    }
}