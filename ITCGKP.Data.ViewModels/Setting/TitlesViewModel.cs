using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class TitlesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title Field's Name Required")]
        [Display(Name = "Title's Name")]
        [StringLength(100)]
        public string Name { get; set; }        
    }
}
