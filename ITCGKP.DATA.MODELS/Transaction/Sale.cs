using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;
using ITCGKP.Data.Models.Financial;
using ITCGKP.Data.Models.Master;

namespace ITCGKP.Data.Models.Transaction
{
    [Table("SaleTable")]
    public class Sale
    {
        [Key]
        public int SSId { get; set; }                     
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail CompanyDetail { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required]
        [StringLength(6)]
        public string SSVNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? SDate { get; set; }        
        [Required]
        public int PayMode { get; set; }        
        [Required]
        [StringLength(100)]
        public string CustName { get; set; }
        [StringLength(100)]
        public string CustAddress1 { get; set; }       
        public string Remark { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscAmt { get; set; }        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TaxAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CreditAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PaidAmt { get; set; }
        [StringLength(8)]
        public string CustAcCode { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }       
    }
}