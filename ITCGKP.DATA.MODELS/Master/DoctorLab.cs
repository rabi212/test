using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("DoctorLabTable")] //  Platter
    public class DoctorLab
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail DoctorCompanyDetails { get; set; }        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }        
        [Required]
        [StringLength(200)]
        public string MobileNo { get; set; }
        [Required]
        [StringLength(200)]
        public string Education { get; set; }
        [Required]
        [StringLength(30)]
        public string PrintReport { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPAmt { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}