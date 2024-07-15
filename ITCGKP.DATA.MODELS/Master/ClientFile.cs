using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("ClientFileTable")]
    public class ClientFile
    {
        [Key]
        public int Id { get; set; }
        //[Required]        
        public int? CompIdA { get; set; }
        [ForeignKey("CompIdA")]
        public virtual CompanyDetail ClientCompanyDetail  { get; set; }
        [Required]
        [StringLength(15)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Address1 { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(10)]
        public string PinNo { get; set; }
        [Required]
        [StringLength(100)]
        public string MobileNo { get; set; }
        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [Required]
        public int RegPanel { get; set; } // Normal Patient,Pathology Patient, Client Patient
        public bool ActiveType { get; set; }
    }
}
