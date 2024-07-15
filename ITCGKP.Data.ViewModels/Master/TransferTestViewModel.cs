using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TransferTestViewModel
    {
        [Display(Name = "From Center :")]
        public int FromCompId { get; set; }
        [Display(Name = "Upto Center :")]
        public int UptoCompId { get; set; }
        public int TestId { get; set; }
        [Display(Name = "Check Update & Uncheck transfer")]
        public bool UpdateRecord { get; set; }
        [Display(Name = "A/c Record")]
        public string HeadRecordType { get; set; } // No = 21 Yes = ALL
        [Display(Name = "Doctor Record")]
        public string DoctorRecordType { get; set; } // No = 1 Yes = ALL
        [BindProperty, DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "Upto Date")]
        public DateTime UptoDate { get; set; }
    }
}
