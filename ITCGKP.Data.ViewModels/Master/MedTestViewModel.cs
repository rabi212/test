
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Setting;
using Microsoft.AspNetCore.Http;

namespace ITCGKP.Data.ViewModels.Master
{
    public class MedTestViewModel
    {
        [Key]
        [Display(Name = "Id :")]
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel DoctorCompanyDetailsViews { get; set; }
        public int? PtId { get; set; }        
        public virtual PatientViewModel PatientViewModel { get; set; }
        [Required(ErrorMessage = "The Passport No.Field Required")]
        [Display(Name ="Passport No.")]
        [StringLength(20)]
        public string PassportNo { get; set; }
        [Required(ErrorMessage = "The Date of issue Field Required")]
        [Display(Name = "Date Of Issue")]
        [StringLength(10)]
        public string DateOfIssue { get; set; }
        [Required(ErrorMessage = "The Nationality Field Required")]
        [Display(Name = "Nationality")]
        [StringLength(15)]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "The Date of birth Field Required")]
        [Display(Name = "Date Of Birth")]
        [StringLength(10)]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "The Trade Field Required")]
        [Display(Name = "Trade")]
        [StringLength(25)]
        public string Trade { get; set; }
        [Required(ErrorMessage = "The Examination Date Field Required")]
        [Display(Name = "Exam. Date")]
        [StringLength(10)]
        public string ExamDate { get; set; }
        [Required(ErrorMessage = "The Expiry Date Field Required")]
        [Display(Name = "Expiry Date")]
        [StringLength(10)]
        public string ExpiryDate { get; set; }
        [Display(Name = "Visa No. Date")]
        [StringLength(30)]
        public string VisaNoDate { get; set; }
        public IFormFile Photo { get; set; }
        public string ExitPhotoPath { get; set; }
        [Display(Name = "Remarks")]
        public string MedRemarks { get; set; }
        [Display(Name = "Report Type")]
        public PatientFitType MedPatientType { get; set; } // Fit = 0 : Unfit =1
        [Display(Name = "Height")]
        [StringLength(15)]
        public string PatHeight { get; set; }
        [Display(Name = "Weight")]
        [StringLength(15)]
        public string PatWeight { get; set; }
        [Display(Name = "Status")]
        public PatientMarriedType PatientMarried { get; set; } //
        [Display(Name = "Religion")]
        public PatientReligionType PatientReligion { get; set; } // Religion
        [StringLength(25)]
        [Display(Name ="Place of Issue")]
        public string PlaceIssue { get; set; }
        [StringLength(25)]
        [Display(Name ="Agency")]
        public string RecrutingAgency { get; set; }
        [StringLength(25)]
        [Display(Name = "Allergy")]
        public string AllergyIssue { get; set; }
        [StringLength(25)]
        [Display(Name = "Others")]
        public string OtherIssue { get; set; }
        public MedTestViewModel()
        {
            MedTestDetailViewModels = new List<MedTestDetailViewModel>();
        }
        public virtual List<MedTestDetailViewModel> MedTestDetailViewModels { get; set; }
        [StringLength(25)]
        public string RptDate { get; set; }
    }
}