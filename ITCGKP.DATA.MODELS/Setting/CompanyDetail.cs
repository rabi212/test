using ITCGKP.Data.Models.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Setting
{
    [Table("CompanyDetailTable")]
    public class CompanyDetail
    {        
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CompName { get; set; }
        [Required]
        [StringLength(100)]
        public string Address1 { get; set; }
        [StringLength(100)]
        public string Address2 { get; set; }
        [StringLength(100)]
        public string Address3 { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(10)]
        public string PinNo { get; set; }
        //[Required]       
        public int? StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }       
        public int? DistId { get; set; }
        [ForeignKey("DistId")]
        public virtual District District { get; set; }
        [Required]
        [StringLength(100)]
        public string PhoneNo { get; set; }
        [Required]
        [StringLength(100)]
        public string MobileNo { get; set; }
        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(100)]
        public string GSTNo { get; set; }
        [Required]
        [StringLength(100)]
        public string Jurisdiction { get; set; }
        [Required]
        [StringLength(20)]
        public string TransCode { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? UptoDate { get; set; }
        [StringLength(10)]
        public string ActionForm { get; set; }
        public string PhotoPath { get; set; }
        public string SignaturePhotoPath { get; set; }
        public string SignaturePhotoPathLeft { get; set; }
        public bool PhotoPathPrint { get; set; }
        public bool SignaturePrint { get; set; }        
        public bool SignaturePrintLeft { get; set; }
        public string ExitFooterReport { get; set; }
        public virtual ICollection<AgentFile> AgentFilesCompany { get; set; }
        // public virtual ICollection<LedgerMaster> LedgerMasters { get; set; }
        // public virtual ICollection<OpenItemMaster> OpenItemMasters { get; set; }
        // public virtual ICollection<Sale> Sales { get; set; }
    }
}
