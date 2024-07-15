using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Setting
{
    [Table("MoneyMasterTable")]
    public class MoneyMaster
    {
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail MoneyCompanyDetails { get; set; }
        [Required]
        [StringLength(100)]
        public string MerchantId { get; set; }
        [Required]
        [StringLength(100)]
        public string APIKey { get; set; }
        [Required]
        [StringLength(100)]
        public string APISalt { get; set; }
        [Required]
        [StringLength(100)]
        public string AuthKey { get; set; }
        [Required]
        [StringLength(200)]
        public string PostURL { get; set; }
        [Required]
        [StringLength(200)]
        // Successfully URL
        public string SurURL { get; set; }
        [Required]
        [StringLength(200)]
        // Fail URL
        public string FurURL { get; set; }
    }
}
