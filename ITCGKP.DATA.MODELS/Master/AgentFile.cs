 using ITCGKP.Data.Models.PayBill;
using ITCGKP.Data.Models.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Master
{
    [Table("AgentFileTable")]
    public class AgentFile
    {
        [Key]
        public int Id { get; set; }
        //[Required]        
        public int? CompIdA { get; set; }
        [ForeignKey("CompIdA")]        
        public virtual CompanyDetail AgentCompanyDetails { get; set; }
        [Required]
        [StringLength(15)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]       
        public string Address1 { get; set; }               
        [StringLength(100)]
        public string City { get; set; }        
        [StringLength(10)]
        public string PinNo { get; set; }        
        [Required]
        [StringLength(100)]
        public string MobileNo { get; set; }
        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPAmt1 { get; set; }
        [Required]
        [StringLength(100)]
        public string BankName { get; set; }
        [Required]
        [StringLength(20)]
        public string BankAcNo { get; set; }
        [Required]
        [StringLength(12)]
        public string IFSC { get; set; }
        [StringLength(20)]
        public string EPFAcNo { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? BasicPay { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TA { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DA { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? HRA { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CCA { get; set; }
        public bool TransferStatus { get; set; }
        public bool ActiveType { get; set; }
        public virtual ICollection<UpdatePayBill> UpdatePayBills { get; set; }
    }
}
