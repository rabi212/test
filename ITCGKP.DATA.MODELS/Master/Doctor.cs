using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("DoctorTable")] //  Platter
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail DoctorCompanyDetails { get; set; }
        [Required]
        [StringLength(15)]
        public string Code { get; set; }       
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Address1 { get; set; }
        [Required]
        [StringLength(200)]
        public string Address2 { get; set; }
        [Required]
        [StringLength(200)]
        public string MobileNo { get; set; }
        [Required]
        [StringLength(200)]
        public string Education { get; set; }
        public virtual ICollection<DoctorDetailsMaster> DoctorDetailsMasters { get; set; }
    }
}