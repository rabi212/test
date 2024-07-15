using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;
using ITCGKP.Data.Models.Financial;

namespace ITCGKP.Data.Models.Master
{
    [Table("PatientIITable")] //  Platter
    public class PatientII
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        [StringLength(200)]
        public string MobileNo { get; set; }
        //[Required]
        [StringLength(20)]
        public string TitleName { get; set; }
        //[Required]
        [StringLength(100)]
        public string Name { get; set; }
        //[Required]
        public int? Sex { get; set; }
        //[Required]
        public int? Age { get; set; }
        //[Required]
        [StringLength(10)]
        public string AgeType { get; set; }
        public string Address { get; set; }        
        public string EmailAddress { get; set; }        
    }
}