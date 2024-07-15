using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Setting;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TestGroupMasterViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel TestGroupCompanyDetailsViews { get; set; }
        [Required(ErrorMessage = "The Name Field Required")]
        [Display(Name ="Group's Name :")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Short Name Field Required")]
        [Display(Name = "Code :")]
        [StringLength(5)]
        public string ShortName { get; set; }
        [Display(Name = "IP % :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? IPPer1 { get; set; }
        [Display(Name = "IP Amt :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? IPAmt1 { get; set; }
    }
}