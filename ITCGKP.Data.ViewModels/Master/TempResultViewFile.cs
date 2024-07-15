using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TempResultViewFile
    {
        public int PatientId { get; set; }
        public int CompId { get; set; }
        [Display(Name = "Select Test Group")]
        public int TestListId { get; set; }
        public string TestDocumentain { get; set; }
        public string DocType { get; set; }
        public int RowId { get; set; }
        public TempResultViewFile()
        {
            PatientInvestigationViewModels = new List<PatientInvestigationViewModel>();
        }
        public virtual List<PatientInvestigationViewModel> PatientInvestigationViewModels { get; set; }
        public int flexRadioDefault { get; set; }
        public bool DLCCount { get; set; }
        [StringLength(25)]
        public string RptDate { get; set; }
        [Display(Name = "Investigation By")]
        public int DrInLab { get; set; }
        [Display(Name = "Select New File")]
        public int ALLTestCode { get; set; }
        public int? CountGroupRecord { get; set; }
        public string TestFormulaApply { get; set; }
        public int? FormulaDecimalPlace { get; set; }
    }
}
