using Microsoft.AspNetCore.Mvc;
using ITCGKP.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITCGKPLAB.Models
{
    public class RegistrationModel
    {       
        [Required(ErrorMessage = "Please Enter Valid Field Required....")]
        [Remote(action: "IsCustomerIdTrueFalse", controller: "Payment")]
        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public int? CustomerId { get; set; }
        public int? InstallId { get; set; }
        public string InstallmentDetails { get; set; }
    }
}
