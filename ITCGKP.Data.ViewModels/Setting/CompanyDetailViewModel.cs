using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class CompanyDetailViewModel
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string EncriptedId { get; set; }
        [Required(ErrorMessage ="Company Name Field Required..")]
        [Display(Name ="Name :")]
        [StringLength(100)]
        public string CompName { get; set; }
        [Required(ErrorMessage = "Address1 Field Required..")]
        [Display(Name = "Address1 :")]
        [StringLength(100)]
        public string Address1 { get; set; }
        [Display(Name = "Address2 :")]
        [StringLength(100)]
        public string Address2 { get; set; }
        [Display(Name = "Address3 :")]
        [StringLength(100)]
        public string Address3 { get; set; }
        [Required(ErrorMessage = "City Field Required..")]
        [Display(Name = "City :")]
        [StringLength(100)]
        public string City { get; set; }
        [Required(ErrorMessage = "Pin No Field Required..")]
        [Display(Name = "Pin No :")]
        [StringLength(10)]
        public string PinNo { get; set; }
        //[Required]    
        [Required(ErrorMessage = "State Field Required..")]
        [Display(Name = "State :")]
        public int? StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual StateViewModel StateInCompany { get; set; }
        [Required(ErrorMessage = "District Field Required..")]
        [Display(Name = "District :")]
        public int? DistId { get; set; }
        [ForeignKey("DistId")]
        public virtual DistrictViewModel DistrictInCompany { get; set; }
        [Required(ErrorMessage = "Phone No Field Required..")]
        [Display(Name = "Phone No :")]
        [StringLength(100)]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Mobile No Field Required..")]
        [Display(Name = "Mobile No :")]
        [StringLength(100)]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Email Address Field Required..")]
        [Display(Name = "Email Address :")]
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "GST No Field Required..")]
        [Display(Name = "GST No :")]
        [StringLength(100)]
        public string GSTNo { get; set; }
        [Required(ErrorMessage = "Jurisdiction Field Required..")]
        [Display(Name = "Jurisdiction :")]
        [StringLength(100)]
        public string Jurisdiction { get; set; }
        [Required(ErrorMessage = "Code Field Required..")]
        [Display(Name = "Branch Code")]        
        [StringLength(20),MinLength(5)]
        public string TransCode { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        //[CustomDateValidation(ErrorMessage ="From Date Required")]
        [Remote(action: "IsFromDateValidation", controller: "DateCheck")]
        [Display(Name = "From Date")]
        public string FromDate { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        //[CustomDateValidation(ErrorMessage ="Upto Date Required")]
        [Remote(action: "IsUptoDateValidation", controller: "DateCheck")]
        [Display(Name = "Upto Date")]
        public string UptoDate { get; set; }
        [StringLength(10)]
        public string ActionForm { get; set; }
        public string NameAddress { get; set; }
        [Display(Name = "Covid Print Right")]
        public IFormFile Photo { get; set; }
        public string ExitPhotoPath { get; set; }
        [Display(Name = "Signature :")]
        public IFormFile SignaturePhoto { get; set; }
        public string ExitSignaturePhotoPath { get; set; }

        [Display(Name = "Covid Print Left")]
        public IFormFile SignaturePhotoPathLeft { get; set; }
        public string ExitSignaturePhotoPathLeft { get; set; }

        [Display(Name = "Covid Right Print")]
        public bool PhotoPathPrint { get; set; }
        [Display(Name = "Signature Print Report")]
        public bool SignaturePrint { get; set; }

        [Display(Name = "Covid Left Print")]
        public bool SignaturePrintLeft { get; set; }
        public DateTime? ValidedDate { get; set; }

        [Display(Name = "Print Report Footer")]
        public string ExitFooterReport { get; set; }
    }
}
