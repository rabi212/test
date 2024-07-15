using ITCGKP.Data.ViewModels.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class PatientAuditViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Pt.Id")]
        public int? PatId { get; set; }
        [Display(Name = "Branch")]
        public int CompId { get; set; }
        //[ForeignKey("CompId")]
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        [Display(Name = "User")]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Display(Name = "Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public string SDate { get; set; }
        [Display(Name = "Update Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public string ModifDate { get; set; }
        [Display(Name = "V.No.")]
        [StringLength(20)]
        public string VNo { get; set; }
        [Display(Name = "Ref.No.")]
        [StringLength(20)]
        public string RefNo { get; set; }
        [Display(Name = "Patient Details")]
        public string PatientInformation { get; set; }
        [Display(Name = "Pay Pre Information")]
        public string PaidPreInformation { get; set; }
        [Display(Name = "Pay After Information")]
        public string PaidPostInformation { get; set; }
        [Display(Name = "Chagne Type")]
        public string  UpdateType { get; set; }
        public bool SelectDeleted { get; set; }
        [StringLength(128)]
        public string EditUserCode { get; set; }
    }
}
