using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Setting
{
    [Table("SMSKeyTable")]
    public class SMSKey
    {
        [Key]
        public int SMSKeyId { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail SMSKeyCompanyDetails { get; set; }
        [Required]
        [StringLength(300)]
        public string APIKeyNo { get; set; }
        [Required]
        [StringLength(100)]
        public string SenderName { get; set; }
        public string MessageDetail { get; set; }
        [Required]
        [StringLength(20)]
        public string MessageType { get; set; }
        public bool MessageActive { get; set; }
        [Required]
        public string URLName { get; set; }
    }
}
