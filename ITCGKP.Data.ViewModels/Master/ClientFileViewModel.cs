using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Setting;

namespace ITCGKP.Data.ViewModels.Master
{
    public class ClientFileViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? CompIdA { get; set; }
        public virtual CompanyDetailViewModel ClientCompanyDetailView { get; set; }
        [Required(ErrorMessage = "The Client Code Field Required")]
        [StringLength(15)]
        [Display(Name = "Client Code :")]
        public string Code { get; set; }
        [Required(ErrorMessage = "The Client Field Required")]
        [StringLength(100)]
        [Display(Name = "Name :")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Address Field Required")]
        [Display(Name = "Address :")]
        public string Address1 { get; set; }
        [StringLength(100)]
        [Display(Name = "City :")]
        public string City { get; set; }
        [StringLength(10)]
        [Display(Name = "Pin No. :")]
        public string PinNo { get; set; }
        [Required(ErrorMessage = "The Mobile No. Field Required")]
        [StringLength(100)]
        [Display(Name = "Mobile No.:")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "The Email Address Field Required")]
        [StringLength(100)]
        [Display(Name = "Email Address :")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string NameAddress { get; set; }
        [Required(ErrorMessage = "The Panel Field Required")]
        [Display(Name = "Panel")]
        public PatientPanel RegPanel { get; set; } // Normal Patient,Pathology Patient, Client Patient   
        [Display(Name = "Active")]
        public bool ActiveType { get; set; }
    }
}
