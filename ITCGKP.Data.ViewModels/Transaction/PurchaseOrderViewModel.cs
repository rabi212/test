using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
using Microsoft.AspNetCore.Mvc;

namespace ITCGKP.Data.ViewModels.Transaction
{
    public class PurchaseOrderViewModel
    {
        [Key]
        public int SOId { get; set; }
        //[Required(ErrorMessage =" ")]
        [Display(Name ="Branch")]
        public int? CompId { get; set; }        
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        [Required(ErrorMessage ="The User Code field must be required")]
        [Display(Name = "User Code")]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required (ErrorMessage ="The Voucher No. field must be required")]
        [Display(Name = "V.No.")]
        [StringLength(6)]
        public string SOVNo { get; set; }
        [Required(ErrorMessage ="The Date field must be required")]
        [Display(Name = "Date")]
        public string ODate { get; set; }       
        [Required (ErrorMessage ="The A/c Name field must be required")]
        [Remote(action: "IsAccountCodeValidation", controller: "DateCheck")]
        [Display(Name = "A/c No.")]
        public int AcCode { get; set; }        
        public virtual LedgerMasterViewModel LedgerMasterViewModel { get; set; }
        [Required(ErrorMessage ="The Name field must be required")]
        [Display(Name = "Name")]
        [StringLength(100)]
        public string CustName { get; set; }
        [Display(Name = "Address")]
        [StringLength(100)]
        public string CustAddress1 { get; set; }
        public string Remark { get; set; }
        public virtual List<PurchaseOrderDetailViewModel> PurchaseOrderDetailViewModels { get; set; }
        public PurchaseOrderViewModel()
        {
            PurchaseOrderDetailViewModels = new List<PurchaseOrderDetailViewModel>();
        }
        public int CurrentNo { get => PurchaseOrderDetailViewModels.Count() + 1; }
        public int RowId { get; set; }
    }
}