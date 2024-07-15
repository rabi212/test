using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TestRateViewModel
    {
        [Display(Name = "Test Group Name")]
        public int? Id { get; set; } // Test Group Id
        public int ? CompId { get; set; }
        public TestRateViewModel()
        {
            TestRateDetailViewModels = new List<TestRateDetailViewModel>();
        }
        public virtual List<TestRateDetailViewModel> TestRateDetailViewModels { get; set; }
        public int CurrentNo { get => TestRateDetailViewModels.Count + 1; }
        [Display(Name = "Total Rows")]
        public int TotalRows { get; set; }
        [Display(Name = "Total Page No.")]
        public int TotalPageNo { get; set; }
        [Display(Name = "Page No.")]
        public int PageNo { get; set; }

    }
}
