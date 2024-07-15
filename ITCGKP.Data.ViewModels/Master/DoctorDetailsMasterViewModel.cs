using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Setting;
namespace ITCGKP.Data.ViewModels.Master
{
    public class DoctorDetailsMasterViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? DoctorId { get; set; }       
        public virtual DoctorViewModel DoctorViewModel { get; set; }
        public int? CompId { get; set; }       
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        public int? TestGId { get; set; }       
        public virtual TestGroupMasterViewModel TestGroupMasterViewModel { get; set; }
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