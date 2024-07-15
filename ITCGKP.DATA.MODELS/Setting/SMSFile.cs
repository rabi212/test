using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Setting
{
    [Table("SMSFileTable")]
    public class SMSFile
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail SMSFileCompanyDetails { get; set; }
        [Required]       
        public string Dateofbirth { get; set; }
        [Required]        
        public string DateofAnniversary { get; set; }
        [Required]        
        public string DateOfInstallment { get; set; }
        [Required]       
        public string DateOfMaturity { get; set; }        
    }
}
