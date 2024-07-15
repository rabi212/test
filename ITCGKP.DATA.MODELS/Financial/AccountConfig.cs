using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Financial
{
    [Table("AccountConfigTable")]
    public class AccountConfig
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail CompanyDetail { get; set; }
        [Required]
        public int SaleCode { get; set; }
        [Required]
        public int CreditCode { get; set; }
        [Required]
        public int PurCode { get; set; }
        [Required]
        public int DebitCode { get; set; }
        [Required]
        public int FreightCode { get; set; } // Purchcase Freight Exp. Director
        [Required]
        public int FreightOut { get; set; } // Sale out Freight Exp. Indirector
        [Required]
        public int CGSTCode { get; set; }
        [Required]
        public int SGSTCode { get; set; }
        [Required]
        public int IGSTCode { get; set; }
        [Required]
        public int CessCode { get; set; }
        [Required]
        public int DiscCode { get; set; }  // Direct Income Disc. Received
        [Required]
        public int DiscAllowed { get; set; } // Indirect Exp. Dis. Allowed
        [Required]
        public int CashCode { get; set; }
        [Required]
        public int DigitalCode { get; set; }
        [Required]
        public int AdvCode { get; set; }
        [Required]
        public int CommissionCode { get; set; }
        [Required]
        public int ServiceCode { get; set; }
        [Required]
        public int ServiceOut { get; set; }  // outstanding Service Charge
        [Required]
        public int StockCode { get; set; }  // Stock Code
        [Required]
        public int ProfitCode { get; set; }  // Profit Loss Account Code
    }
}