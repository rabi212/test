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
    [Table("VoucherTable")]
    public class Voucher
    {
        [Key]
        public int VId { get; set; }
        //[Required]        
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail CompVoucher { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required]
        [StringLength(20)]
        public string VType { get; set; }
        [Required]
        [StringLength(20)]
        public string VVNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? VDate { get; set; }        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DrAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CrAmt { get; set; }       
        public string Remark { get; set; }
        public virtual ICollection<VoucherDetail>  VoucherDetails { get; set; }
      
    }
}