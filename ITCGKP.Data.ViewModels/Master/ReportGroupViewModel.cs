using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Setting;

namespace ITCGKP.Data.ViewModels.Master
{
    public class ReportGroupViewModel
    {
        [Key]      
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel ReportGroupCompanyDetailsViews { get; set; }       
        [Required(ErrorMessage = "The Name Field Required")]
        [StringLength(150)]
        [Display(Name ="Report Name :")]
        public string Name { get; set; }
        [Display(Name = "Print Order :")]
        public int? TempNo { get; set; }
        public string  DocReading { get; set; }
        public int TempTestId { get; set; }
    }
}