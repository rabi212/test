using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Setting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class PatientDueReciptViewModel
    {
        [Key]
        public int Id { get; set; }       
        [Required(ErrorMessage ="The User Code Field Required")]
        [Display(Name = "User Code :")]
        [StringLength(128)]
        public string UserCode { get; set; }        
        [Required(ErrorMessage = "The  Date Field Required")]
        [Remote(action: "IsVInvoiceDateValidation", controller: "DateCheck")]
        [Display(Name = "Date")]        
        public string VDate { get; set; }
        [Required(ErrorMessage = "The Voucher No. Field Required")]
        [Display(Name = "UID")]
        [StringLength(20)]
        public string VNo { get; set; }
        [Required]
        public int PatId { get; set; }
        //[ForeignKey("PatId")]
        public virtual PatientViewModel PatientViewModel { get; set; }        
        [Display(Name = "Total Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalAmt { get; set; }
        [Display(Name = "Disc Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal DiscAmt { get; set; }
        [Display(Name = "Paid Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? PaidAmt { get; set; }        
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        [Required(ErrorMessage = "The Pay Mode field must be required")]
        [Display(Name = "Pay Mode")]
        public PayMode PaymentType { get; set; } // Digital Payment, Cash       
    }
}
