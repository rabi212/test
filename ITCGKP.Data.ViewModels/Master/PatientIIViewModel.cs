using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class PatientIIViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string MobileNo { get; set; }
        [Required]
        [StringLength(20)]
        public string TitleName { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public Gender Sex { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(10)]
        public string AgeType { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
    }
}
