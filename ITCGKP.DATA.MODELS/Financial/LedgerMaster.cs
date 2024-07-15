using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Financial
{
    [Table("HeadTable")]
    public class LedgerMaster
    {
        [Key]
        public int LedgerMasterId { get; set; }      
        public int? CompId { get; set; }        
        [ForeignKey("CompId")]
        public virtual CompanyDetail CompLedger { get; set; }
        [Required]
        [StringLength(15)]
        public string LedCode { get; set; }       
        [Required]
        [StringLength(100)]
        public string PartyName { get; set; }
        [StringLength(100)]
        public string Address1 { get; set; }
        [StringLength(100)]
        public string Address2 { get; set; }
        [StringLength(100)]
        public string Address3 { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string PinNo { get; set; }
        [Required]
        [ForeignKey("StateLedger")]
        public  int LedStateId { get; set; }        
        public virtual  State StateLedger { get; set; }
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [StringLength(100)]
        public string PhoneNo { get; set; }
        [StringLength(100)]
        public string MobileNo1 { get; set; }
        [StringLength(100)]
        public string MobileNo2 { get; set; }
        [StringLength(100)]
        public string PanNo { get; set; }
        [StringLength(100)]
        public string AdharNo { get; set; }
        [StringLength(100)]
        public string GSTNo { get; set; }
        [Required]
        [ForeignKey("AcGPLedger")]
        public int AcGroupId { get; set; }
        public virtual AccountGroup AcGPLedger { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? DateOfAnversary { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OpnAmt { get; set; }        
        public int? OpnAc { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CloseAmt { get; set; }       
        public int? CloseAc { get; set; }
        [StringLength(10)]
        public string PrintTag { get; set; }
        public string Code { get; set; }
    }
}