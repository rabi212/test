using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Setting;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TestDocMasterViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        //[ForeignKey("CompId")]
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        [Required(ErrorMessage = "Test File Name Field Rquired")]
        [Display(Name = "File Name ")]
        [StringLength(100)]
        public string TestCode { get; set; }
        [Required(ErrorMessage = "Test Test Group Field Rquired")]
        [Display(Name = "Group's Name ")]
        public int? TestGroupId { get; set; }
        //[ForeignKey("TestGroupId")]
        public virtual TestGroupMasterViewModel TestGroupMasterViewModel { get; set; }
        [Required(ErrorMessage = "Test File Details Field Rquired")]
        [Display(Name = "Document ")]
        public string documentFile { get; set; } // Reading or ducument Details Files
    }
}
