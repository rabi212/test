using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKP.Data.ViewModels.Master;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Financial;
using Microsoft.AspNetCore.Mvc;

namespace ITCGKP.Data.ViewModels.Transaction
{
    public class PurchaseRViewModel
    {
        [Key]
        public int STId { get; set; }
        [Required(ErrorMessage = "Company ")]
        [Display(Name = "Branch :")]
        public int CompId { get; set; }
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        [Required(ErrorMessage = "The User Id field must be required")]
        [Display(Name = "User Code")]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required(ErrorMessage = "The Voucher No. field must be required")]
        [Display(Name = "V.No.")]
        [StringLength(6)]
        public string STVNo { get; set; }
        [Required(ErrorMessage = "The Date field must be required")]
        [Display(Name = "Date")]
        public string STDate { get; set; }       
        [Required(ErrorMessage = "The Account No. field must be required")]
        [Remote(action: "IsAccountCodeValidation", controller: "DateCheck")]
        [Display(Name = "A/c No.")]
        public int AcCode { get; set; }
        public virtual LedgerMasterViewModel LedgerMasterViewModel { get; set; }
        [Required(ErrorMessage = "The Name field must be required")]
        [Display(Name = "A/c's Name")]
        [StringLength(100)]
        public string CustName { get; set; }
        [Display(Name = "Address")]
        [StringLength(100)]
        public string CustAddress1 { get; set; }
        public int CustLedStateId { get; set; }
        [Display(Name = "Total Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalAmt { get; set; }
        [Display(Name = "Disc Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscAmt { get; set; }
        [Display(Name = "CGST Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CGSTTotalAmt { get; set; }
        [Display(Name = "SGST Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? SGSTTotalAmt { get; set; }
        [Display(Name = "IGST Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? IGSTTotalAmt { get; set; }
        [Display(Name = "Cess Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CessTotalAmt { get; set; }
        [Display(Name = "Other Ist")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? OtherAmt1 { get; set; }
        [Display(Name = "Other IInd")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? OtherAmt2 { get; set; }        
        [Display(Name = "Net Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? NetAmt { get; set; }
        [Display(Name = "Cash Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CashAmt { get; set; }
        [Display(Name = "Digital Amt. :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DigitalAmt { get; set; }        
        public virtual List<PurchaseRDetailViewModel>  PurchaseRDetailViewModels { get; set; }
        public PurchaseRViewModel()
        {
            PurchaseRDetailViewModels = new List<PurchaseRDetailViewModel>();
        }
        public int CurrentNo { get => PurchaseRDetailViewModels.Count() + 1; }
        public int RowId { get; set; }
    }
}