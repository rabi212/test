using ITCGKP.Data.ViewModels.Master;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class RegisterViewModel
    {
        [Required]        
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUser", controller: "DateCheck")]
        //[ValidEmailDomainAttribute(allowedDomain:"gmail.com",ErrorMessage = "Email domain must be gmail.com")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Center Id")]
        public int? CompanyDetailId { get; set; }        
        public CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        [Required]
        [Display(Name = "Center Client Name")]
        public int? ClientId { get; set; }
        public ClientFileViewModel clientFileViewModel { get; set; }
    }
}
