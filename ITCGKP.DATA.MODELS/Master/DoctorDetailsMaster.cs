using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("DoctorDetailsMasterTable")]  // Size Master
    public class DoctorDetailsMaster
    {
        [Key]
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail DoctorDetailsCompanyDetails { get; set; }
        public int? TestGId { get; set; }
        [ForeignKey("TestGId")]
        public virtual TestGroupMaster TestGroupMasters { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPPer1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPAmt1 { get; set; }
    }
}