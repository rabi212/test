using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Setting;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TempReportDetailViewModel
    {
        [Key]      
        public int Id { get; set; }       
        [Required(ErrorMessage = "The Name Field Required")]
        [StringLength(150)]
        [Display(Name ="Report Name :")]
        public string Name { get; set; }
        [Display(Name = "Print Order :")]
        public int TempSrNo { get; set; }
        public virtual TempReportViewFile TempReportViewFile { get; set; }
    }
}