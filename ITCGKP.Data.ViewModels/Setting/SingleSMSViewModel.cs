using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class SingleSMSViewModel
    {
        [Required(ErrorMessage = "Cell No. Required")]
        [Display(Name = "Cell No. :")]
        //[DataType(DataType.MultilineText)]
        public string CellNo { get; set; }
        //[Required(ErrorMessage = "Message Required")]
        [Display(Name = "Message Detail :")]
        [DataType(DataType.MultilineText)]
        
        public string MessageBody { get; set; }
        [Display(Name = "Message Hindi :")]
        [DataType(DataType.MultilineText)]        
        public string  MessageBodyHindi { get; set; }
        [Display(Name = "Message Type :")]
        public CustomerLanguage Language  { get; set; }     
    }
}
