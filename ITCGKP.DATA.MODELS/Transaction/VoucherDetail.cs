using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Financial;

namespace ITCGKP.Data.Models.Transaction
{
    [Table("VoucherDetailTable")]
    public class VoucherDetail
    {
        [Key]
        public int VMDId { get; set; }
        [Required]
        [StringLength(20)]        
        public string BookType { get; set; }   
        public int? AcCode1 { get; set; }
        [ForeignKey("AcCode1")]
        public virtual LedgerMaster VoucherAcCode1 { get; set; }
        public string VoucherPartyName { get; set; }
        public int? AcCode2 { get; set; }
        [ForeignKey("AcCode2")]
        public virtual LedgerMaster VoucherAcCode2 { get; set; }        
        [StringLength(100)]
        public string ChequeNo { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Dr_Amt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Cr_Amt { get; set; } // IP  Amt
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscAmt { get; set; }
        //[Required(ErrorMessage = "The IPD No. field must be required")]
        //[Display(Name = "IPD No / Test No. / OPD No")]
        [StringLength(20)]
        public string RefNo { get; set; }
        [StringLength(100)]
        public string PatientName { get; set; }
        public string Comments { get; set; }        
        [Required]
        public int TempSrNo { get; set; }
        //[Required]
        public int? CompIdVItemMD { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCodeVItemMD { get; set; }
        [Required]
        [StringLength(20)]
        public string VVNoD { get; set; }
        [Required]
        [StringLength(20)]
        public string VVType { get; set; }
        public int VIMId { get; set; }
        [ForeignKey("VIMId")]        
        public virtual Voucher Voucher { get; set; }
        [StringLength(15)]
        public string CustAcCode1 { get; set; }
        [StringLength(15)]
        public string CustAcCode2 { get; set; }
        
    }
}