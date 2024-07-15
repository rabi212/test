
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Setting;

namespace ITCGKP.Data.ViewModels.Master
{
    public class DoctorViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel DoctorCompanyDetailsViews { get; set; }
        [Required(ErrorMessage = "The Code Field Required")]
        [StringLength(15)]
        [Display(Name = "Code")]
        public string Code { get; set; }        
        [Required(ErrorMessage = "The Name Field Required")]
        [StringLength(100)]
        [Display(Name = "Doctor's Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Address 1 Field Required")]
        [StringLength(200)]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "The Address 2 Field Required")]
        [StringLength(200)]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "The Mobile No. Field Required")]
        [StringLength(200)]
        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "The Qualification Field Required")]
        [StringLength(200)]
        [Display(Name = "Qualification")]
        public string Eduction { get; set; }
        public DoctorViewModel()
        {
            DoctorDetailsMasterViewModel = new List<DoctorDetailsMasterViewModel>();
        }
        public virtual List<DoctorDetailsMasterViewModel> DoctorDetailsMasterViewModel { get; set; }
    }
}