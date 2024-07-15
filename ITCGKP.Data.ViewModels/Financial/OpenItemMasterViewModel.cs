using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.Setting;

namespace ITCGKP.Data.ViewModels.Financial
{
    public class OpenItemMasterViewModel
    {
        [Key]
        public int OpnId { get; set; }
        [Required(ErrorMessage = "The Branch name field must be required")]
        [Display(Name ="Branch")]
        public int CompId { get; set; }        
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        [Required(ErrorMessage = "The User Id field must be required")]
        [Display(Name ="User Id")]
        [StringLength(128)]
        public string UserCode { get; set; }        
        [Required(ErrorMessage = "The Voucher No. field must be required")]
        [Display(Name ="V.No.")]
        [StringLength(6)]
        public string OpnVNo { get; set; }
        [Display(Name ="Date")]
        //[CustomDateValidation]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public string OpnDate { get; set; }
        public virtual List<OpenItemMasterDetailViewModel> OpenItemMasterDetailViewModels { get; set; }
        public OpenItemMasterViewModel()
        {
            OpenItemMasterDetailViewModels = new List<OpenItemMasterDetailViewModel>();
        }
        public int CurrentNo { get => OpenItemMasterDetailViewModels.Count() + 1; }
        public int RowId { get; set; }       
    }
}