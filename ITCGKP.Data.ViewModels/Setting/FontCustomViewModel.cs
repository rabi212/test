using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class FontCustomViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Fonts Field's Name Required")]
        [Display(Name = "Font's Name")]        
        public string Name { get; set; }        
    }
}
