using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
namespace ITCGKP.Data.ViewModels.Transaction
{
    public class SaleRViewModel
    {
        [Key]
        public int SRId { get; set; }
        //[Required(ErrorMessage = " ")]
        [Display(Name = "Branch")]
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        [Required(ErrorMessage = "The User Code field must be required")]
        [Display(Name = "User Code")]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required(ErrorMessage = "The Voucher No. field must be required")]
        [Display(Name = "V.No.")]
        [StringLength(6)]
        public string SRVNo { get; set; }
        [Required(ErrorMessage = "The Date field must be required")]
        [Display(Name = "Date")]
        public string SDate { get; set; }        
        [Required(ErrorMessage = "The Name field must be required")]
        [Display(Name = "Name")]
        [StringLength(100)]
        public string CustName { get; set; }
        [Display(Name = "Address")]
        [StringLength(100)]
        public string CustAddress1 { get; set; }       
        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
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
        [Display(Name = "Tax Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TaxAmt { get; set; }        
        [Display(Name = "Net Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? NetAmt { get; set; }
        public virtual List<SaleRDetailViewModel> SaleRDetailViewModels { get; set; }
        public SaleRViewModel()
        {
            SaleRDetailViewModels = new List<SaleRDetailViewModel>();
        }
        public int CurrentNo { get => SaleRDetailViewModels.Count() + 1; }
        public int RowId { get; set; }
    }
}