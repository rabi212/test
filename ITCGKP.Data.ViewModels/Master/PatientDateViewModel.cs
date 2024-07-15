using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class PatientDateViewModel
    {
        [Display(Name = "Center Id")]
        public int CompId { get; set; }
        [Display(Name = "User's Id")]
        public string UserCode { get; set; }
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }
        [Display(Name = "Upto Date")]
        public DateTime UptoDate { get; set; }
        [Display(Name = "Executive's Name")]
        public int AgentAcCode { get; set; }        
        [Display(Name = "Doctor's Name")]
        public int DoctorAcCode { get; set; }

        [Display(Name = "Test Group's Name")]
        public int TestGroupId { get; set; }
        [Display(Name = "Test's Name")]
        public int TestId { get; set; }
        [Display(Name = "Test Group's Name")]
        public string TestGroupName { get; set; }
        [Display(Name = "Payment Mode")]
        public string PaymentMode { get; set; } // Cash Digital
        [Display(Name = "Investigation By")]
        public int DrInLab { get; set; }
        [Display(Name = "Grouping Mode")]
        public bool GroupTypeReport { get; set; }
        [Display(Name = "Total Amt. Show")]
        public bool TotalAmtShow { get; set; }
    }
}
