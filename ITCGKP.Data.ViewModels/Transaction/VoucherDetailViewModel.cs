using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Financial;

namespace ITCGKP.Data.ViewModels.Transaction
{
    public class VoucherDetailViewModel
    {
        [Key]
        public int VMDId { get; set; }
        //[Required]
        [StringLength(20)]
        public string BookType { get; set; }
        [Display(Name = "Opn Type")]
        public AccountDrCr AccountMode { get; set; }
        public int? AcCode1 { get; set; }       
        public virtual LedgerMasterViewModel VDLedger1 { get; set; }
        public int? AcCode2 { get; set; }        
        public virtual LedgerMasterViewModel VDLedger2 { get; set; }
        [Required(ErrorMessage = "A/c Name field must be required")]
        public string VoucherPartyName { get; set; }
        [StringLength(100)]
        public string ChequeNo { get; set; }        
        [Display(Name = "Debit Amt. :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? Dr_Amt { get; set; }
        [Display(Name = "Credit Amt. :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? Cr_Amt { get; set; }
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
        //[Required]
        public int TempSrNo { get; set; }
        //[Required]
        public int? CompIdVItemMD { get; set; }
        //[Required]
        [StringLength(128)]
        public string UserCodeVItemMD { get; set; }
        //[Required]
        [StringLength(20)]
        public string VVNoD { get; set; }
        //[Required(ErrorMessage =" ")]
        [StringLength(20)]
        public string VVType { get; set; }
        public int VIMId { get; set; }        
        public virtual VoucherViewModel VoucherViewModel { get; set; }
        [StringLength(15)]
        public string CustAcCode1 { get; set; }
        [StringLength(15)]
        public string CustAcCode2 { get; set; }       
        public string RecordType { get; set; }  // Old Or New Record
    }
}