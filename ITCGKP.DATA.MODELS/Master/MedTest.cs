using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("MedTestTable")] //  Platter
    public class MedTest
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail DoctorCompanyDetails { get; set; }
        public int? PtId { get; set; }
        [ForeignKey("PtId")]
        public virtual Patient Patient { get; set; }
        [Required]
        [StringLength(20)]
        public string PassportNo { get; set; }       
        [Required]
        [StringLength(10)]
        public string DateOfIssue { get; set; }
        [Required]
        [StringLength(15)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(10)]
        public string DateOfBirth { get; set; }
        [Required]
        [StringLength(25)]
        public string Trade { get; set; }
        [Required]
        [StringLength(10)]
        public string ExamDate { get; set; }
        [Required]
        [StringLength(10)]
        public string ExpiryDate { get; set; }        
        [StringLength(30)]
        public string VisaNoDate { get; set; }
        public string PhotoPath { get; set; }
        public string MedRemarks { get; set; }
        public int? MedPatientType { get; set; } // Fit = 0 : Unfit =1
        [StringLength(15)]
        public string  PatHeight { get; set; }
        [StringLength(15)]
        public string PatWeight { get; set; }
        public int? PatientMarried { get; set; } //
        public int? PatientReligion { get; set; } // Religion
        [StringLength(25)]
        public string PlaceIssue { get; set; }
        [StringLength(25)]
        public string RecrutingAgency { get; set; }
        [StringLength(25)]
        public string AllergyIssue { get; set; }
        [StringLength(25)]
        public string OtherIssue { get; set; }
        public virtual ICollection<MedTestDetail> MedTestDetails { get; set; }
    }
}