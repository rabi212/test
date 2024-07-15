using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ITCGKP.Data.ViewModels.Financial
{
    public class AccountGroupViewModel
    {
        [Key]        
        [Display(Name = "Id :")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Code Field Required")]
        [StringLength(3)]
        [Display(Name ="Code :")]
        public string HDGCode { get; set; }
        [Required(ErrorMessage = "The Group Name Field Required")]
        [StringLength(100)]
        [Display(Name ="A/c Group Name :")]
        public string Ledger_Name { get; set; }
        [Required(ErrorMessage = "The Under Group Name Field Required")]
        [StringLength(100)]
        [Display(Name ="Under :")]
        public string Under_Name { get; set; }
        [Required(ErrorMessage = "The Accont Group Nature Field Required")]        
        [Display(Name ="Nature :")]
        public AccountNature Nature { get; set; }
        [Required]
        [Display(Name ="First No. :")]
        public int TNo1 { get; set; }
        [Display(Name = "Effect Gross Profit")]
        public bool EffectGrossProfit { get; set; }
    }
}