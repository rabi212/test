using System;
using System.Collections.Generic;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TestRateDetailViewModel
    {
        public int Id { get; set; } // Test Id
        public int? CompIdX { get; set; }
        public string TestCode { get; set; }
        public decimal?  Rate { get; set; }        
        public decimal? PPRate { get; set; }
        public decimal? CCRate { get; set; }
        public int? TempNo { get; set; }
    }
}
