using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("ReportGroupTable")] // Media
    public class ReportGroup
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail ReportGroupCompanyDetails { get; set; }       
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public int? TempNo { get; set; }
    }
}