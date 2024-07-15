using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("TestDocMasterTable")]  // Vender
    public class TestDocMaster
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail TestCompanyDetails { get; set; }
        [Required]
        [StringLength(100)]
        public string TestCode { get; set; }       
        public int? TestGroupId { get; set; }
        [ForeignKey("TestGroupId")]
        public virtual TestGroupMaster TestGroupMaster { get; set; }        
        [Required]
        public string documentFile { get; set; } // Reading or ducument Details Files
    }
}
