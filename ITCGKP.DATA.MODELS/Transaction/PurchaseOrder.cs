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
    [Table("PurchaseOrderTable")]
    public class PurchaseOrder
    {
        [Key]
        public int SOId { get; set; }
        //[Required]
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail  CompanyDetail { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required]
        [StringLength(6)]
        public string SOVNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? ODate { get; set; }       
        [Required]
        public int AcCode { get; set; }
        [ForeignKey("AcCode")]
        public virtual LedgerMaster LedgerMasterSaleOrder  { get; set; }
        [Required]
        [StringLength(100)]
        public string CustName { get; set; }
        [StringLength(100)]
        public string CustAddress1 { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }      

    }
}