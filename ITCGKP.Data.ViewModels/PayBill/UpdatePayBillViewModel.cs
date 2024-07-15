using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.Setting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.PayBill
{
    public class UpdatePayBillViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Branch")]
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel  CompanyDetailViewModel { get; set; }
        [Required(ErrorMessage = "The User Code field must be required")]
        [Display(Name = "User Code")]
        [StringLength(128)]
        public string UserCode { get; set; }        
        [Required(ErrorMessage = "The Date field must be required")]
        [Remote(action: "IsVInvoiceDateValidation", controller: "DateCheck")]
        [Display(Name = "Date")]
        public string VDate { get; set; }
        [Required(ErrorMessage = "The Executive Id field must be required")]
        [Remote(action: "IsExecutiveIdValidation", controller: "DateCheck")]
        [Display(Name = "Executive Id")]
        public decimal? EmpId { get; set; }        
        public virtual AgentFileViewModel AgentFileViewModel { get; set; }
        [Required(ErrorMessage = "The Basic Pay field must be required")]
        [Display(Name = "Basic Pay")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? BasicPay { get; set; }
        [Required(ErrorMessage = "The Attends Days field must be required")]
        [Display(Name = "Days")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? AttendDays { get; set; }
        [Required(ErrorMessage = "The New Basic Pay field must be required")]
        [Display(Name = "New Basic Pay")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? NewBasicPay { get; set; }
        [Display(Name = "D.A.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DA { get; set; }
        [Display(Name = "T.A.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TA { get; set; }
        [Display(Name = "H.R.A.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? HRA { get; set; }
        [Display(Name = "C.C.A.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CCA { get; set; }
        [Display(Name = "I.P. Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? IPAmt { get; set; }
        [Display(Name = "Bonus")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? BonusAmt { get; set; }
        [Display(Name = "Remarks")]        
        [StringLength(100)]
        public string Remarks { get; set; }
        [Display(Name = "Total Pay")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalPay { get; set; }
        [Display(Name = "E.P.F.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? EFP { get; set; }
        [Display(Name = "Advance Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? AdvAmt { get; set; }
        [Display(Name = "Adv. Remarks")]
        [StringLength(100)]
        public string AdvRemarks { get; set; }
        [Display(Name = "L.I.C.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? LIC { get; set; }
        [Display(Name = "Total Deducation")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalDedPay { get; set; }
        [Display(Name = "Net Pay")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? NetPay { get; set; }
        public bool TransferStatus { get; set; }

    }
}
