using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class MoneyMasterViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel MoneyCompanyDetailsViews { get; set; }
        [Required(ErrorMessage = "Merchant Id Required")]
        [Display(Name = "Merchant Id :")]
        [StringLength(100)]
        public string MerchantId { get; set; }
        [Required(ErrorMessage = "API Key Required")]
        [Display(Name = "API Key :")]
        [StringLength(100)]
        public string APIKey { get; set; }
        [Required(ErrorMessage = "API Salt Key Required")]
        [Display(Name = "API Salt Key :")]
        [StringLength(100)]
        public string APISalt { get; set; }
        [Required(ErrorMessage = "Authorized Key Required")]
        [Display(Name = "Authorized Key :")]
        [StringLength(100)]
        public string AuthKey { get; set; }
        [Required(ErrorMessage = "Post URL Required")]
        [Display(Name = "Post URL :")]
        [StringLength(200)]
        public string PostURL { get; set; }
        [Required(ErrorMessage = "Successfully URL Required")]
        [Display(Name = "Sur URL :")]
        [StringLength(200)]
        // Successfully URL
        public string SurURL { get; set; }
        [Required(ErrorMessage = "Fail URL Required")]
        [Display(Name = "Fail URL :")]
        [StringLength(200)]
        // Fail URL
        public string FurURL { get; set; }
    }
}
