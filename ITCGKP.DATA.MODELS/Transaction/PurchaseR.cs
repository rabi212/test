using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;
using ITCGKP.Data.Models.Master;
using ITCGKP.Data.Models.Financial;

namespace ITCGKP.Data.Models.Transaction
{
    [Table("PurchaseRTable")] // Tag Cancel
    public class PurchaseR
    {
        [Key]
        public int STId { get; set; }
        [Required]
        public int CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail CompanyDetail { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required]
        [StringLength(6)]
        public string STVNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? STDate { get; set; }       
        [Required]
        public int AcCode { get; set; }
        [ForeignKey("AcCode")]
        public virtual LedgerMaster LedgerMaster { get; set; }
        [Required]
        [StringLength(100)]
        public string CustName { get; set; }
        [StringLength(100)]
        public string CustAddress1 { get; set; }
        public int CustLedStateId { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CGSTTotalAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SGSTTotalAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IGSTTotalAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CessTotalAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OtherAmt1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OtherAmt2 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CashAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DigitalAmt { get; set; }
        public virtual ICollection<PurchaseRDetail> PurchaseRDetails { get; set; }      
    }
}