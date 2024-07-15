using ITCGKP.Data.ViewModels.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITCGKP.Data.ViewModels.Financial
{
    public class AccountConfigViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Branch")]
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel CompanyDetailsView { get; set; }
        [Required(ErrorMessage = "The Sale Code Field Required")]
        [Display(Name = "Sale A/c Code")]
        public int SaleCode { get; set; }
        [Required(ErrorMessage = "The Credit Note Field Required")]
        [Display(Name = "Credit Note A/c Code")]
        public int CreditCode { get; set; }
        [Required(ErrorMessage = "The Purchase Code Field Required")]
        [Display(Name = "Purchase A/c Code")]
        public int PurCode { get; set; }
        [Required(ErrorMessage = "The Debit Note Field Required")]
        [Display(Name = "Debit Note A/c Code")]
        public int DebitCode { get; set; }
        [Required(ErrorMessage = "The Freight Field Required")]
        [Display(Name = "Freight Direct Exp.")]
        public int FreightCode { get; set; } // Purchase direct Exp.
        [Required(ErrorMessage = "The Freight Field Required")]
        [Display(Name = "Freight Indirect Exp.")]
        public int FreightOut { get; set; }   // Sale Indirect Exp.
        [Required(ErrorMessage = "The CGST Code Field Required")]
        [Display(Name = "CGST Code")]
        public int CGSTCode { get; set; }
        [Required(ErrorMessage = "The SGST Code Field Required")]
        [Display(Name = "SGST Code")]
        public int SGSTCode { get; set; }
        [Required(ErrorMessage = "The IGST Code Field Required")]
        [Display(Name = "IGST Code")]
        public int IGSTCode { get; set; }
        [Required(ErrorMessage = "The Cess Code Field Required")]
        [Display(Name = "Cess Code")]
        public int CessCode { get; set; }
        [Required(ErrorMessage = "The Discount Code Field Required")]
        [Display(Name = "Discount Received A/c")]
        public int DiscCode { get; set; } // Direct Income Disc. Received
        [Required(ErrorMessage = "The Discount Code Field Required")]
        [Display(Name = "Discount Allowed A/c")]
        public int DiscAllowed { get; set; } // Indirect Exp. Dis. Allowed
        [Required(ErrorMessage = "The Cash Code Field Required")]
        [Display(Name = "Cash A/c Code")]
        public int CashCode { get; set; }
        [Required(ErrorMessage = "The Digital Code Field Required")]
        [Display(Name = "Digital A/c Code")]
        public int DigitalCode { get; set; }
        [Required(ErrorMessage = "The Advance Code Field Required")]
        [Display(Name = "Adv A/c Code")]
        public int AdvCode { get; set; }
        [Required(ErrorMessage = "The Commission Code Field Required")]
        [Display(Name = "Commission Code")]
        public int CommissionCode { get; set; }
        [Required(ErrorMessage = "The Service Code Field Required")]
        [Display(Name = "Service A/c")]
        public int ServiceCode { get; set; }
        [Required(ErrorMessage = "The Outstanding Service Charge Field Required")]
        [Display(Name = "Outstanding Service A/c")]
        public int ServiceOut { get; set; }
        [Required(ErrorMessage = "The Stock A/c Field Required")]
        [Display(Name = "Stock A/c")]
        public int StockCode { get; set; }  // Stock Code
        [Required(ErrorMessage = "The Profit & Loss  Field Required")]
        [Display(Name = "Profit & Loss A/c")]
        public int ProfitCode { get; set; }  // Profit Loss Account Code
    }
}