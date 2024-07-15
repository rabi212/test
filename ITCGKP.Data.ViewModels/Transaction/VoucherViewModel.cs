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
    public class VoucherViewModel
    {
        [Key]
        public int VId { get; set; }
        //[Required(ErrorMessage =" ")]
        [Display(Name ="Branch :")]
        public int? CompId { get; set; }        
        public virtual CompanyDetailViewModel VCompanyDetails { get; set; }
        [Required(ErrorMessage ="The User field must be required")]
        [Display(Name ="User :")]
        [StringLength(128)]
        public string UserCode { get; set; }
        // Cash Payment,Cash Received,Bank Payment, Bank Recived
        [Required(ErrorMessage = "The Voucher Type field must be required")]
        [Display(Name ="V.Type")] 
        [StringLength(20)]
        public string VType { get; set; }
        [Required(ErrorMessage = "The Voucher No. field must be required")]
        [Display(Name ="V.No.")]
        [StringLength(20)]
        public string VVNo { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The Date field must be required")]
        [Display(Name ="Date")]
        public string VDate { get; set; }        
        [Required(ErrorMessage = "The Debit Amount Field Required")]
        [Display(Name = "Debit Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DrAmt { get; set; }
        [Required(ErrorMessage = "The Credit Amount Field Required")]
        [Display(Name = "Credit Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CrAmt { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        public virtual List<VoucherDetailViewModel> VoucherDetailViewModels { get; set; }
        public VoucherViewModel()
        {
            VoucherDetailViewModels = new List<VoucherDetailViewModel>();
        }
        public int CurrentNo { get => VoucherDetailViewModels.Count() + 1; }
        public int RowId { get; set; }
    }
}