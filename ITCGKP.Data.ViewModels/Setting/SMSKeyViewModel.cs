using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class SMSKeyViewModel
    {
        [Key]
        public int SMSKeyId { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel SMSKeyCompanyDetailsViews { get; set; }
        [Required(ErrorMessage = "API Key Required")]
        [StringLength(300)]
        [Display(Name = "API Key No. : ")]
        public string APIKeyNo { get; set; }
        [Required(ErrorMessage = "Sender's Name Required")]
        [StringLength(100)]
        [Display(Name = "Sender's Name : ")]
        public string SenderName { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Message Details : ")]
        public string MessageDetail { get; set; }
        [Required(ErrorMessage = "Message Type Required")]
        [StringLength(20)]
        [Display(Name = "Message Type : ")]
        public string MessageType { get; set; }
        [Display(Name = "Message Active : ")]
        public bool MessageActive { get; set; }
        [Required(ErrorMessage = "URL required")]
        [Display(Name = "Link URL :")]
        public string URLName { get; set; }
    }
}
