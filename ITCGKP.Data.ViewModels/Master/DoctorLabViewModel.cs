
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Setting;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCGKP.Data.ViewModels.Master
{
    public class DoctorLabViewModel
    {
        [Key]
        [Display(Name = "Id :")]
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel DoctorCompanyDetailsViews { get; set; }        
        [Required(ErrorMessage = "The Name Field Required")]
        [StringLength(100)]
        [Display(Name = "Doctor's Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Address 1 Field Required")]
        [StringLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; }        
        [Required(ErrorMessage = "The Mobile No. Field Required")]
        [StringLength(200)]
        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "The Qualification Field Required")]
        [StringLength(200)]
        [Display(Name = "Qualification")]
        public string Eduction { get; set; }
        [Required(ErrorMessage = "The Qualification Field Required")]
        [StringLength(30)]
        [Display(Name = "Print Footer")]
        public string PrintReport { get; set; }
        [Display(Name = "IP Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? IPAmt { get; set; }
        public virtual List<PatientViewModel> Patients { get; set; }
    }
}