using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCGKPLAB.Models
{
    public class RazorPayOptionsModel
    {
        public string Key { get; set; }
        public decimal AmountInSubUnits { get; set; }
        public string Currency { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLogUrl { get; set; }
        public string OrderId { get; set; }
        public string ProfileName { get; set; }
        public string ProfileContact { get; set; }
        public string ProfileEmail { get; set; }
        public int? CustomerId { get; set; }
        public int? InstallId { get; set; }
        public int PayAmount { get; set; }
        public Dictionary<string, string> Notes { get; set; }
    }
}
