using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TempReportViewFile
    {
        public int? RptId { get; set; }
        public int CompId { get; set; }     
        public TempReportViewFile()
        {
            TempReportDetailViewModels = new List<TempReportDetailViewModel>();
        }
        public virtual List<TempReportDetailViewModel> TempReportDetailViewModels { get; set; }
        public int RowId { get; set; }
        public int CurrentNo { get => TempReportDetailViewModels.Count + 1; }

    }
}
