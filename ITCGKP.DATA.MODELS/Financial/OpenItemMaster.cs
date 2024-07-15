using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;
using ITCGKP.Data.Models.Master;

namespace ITCGKP.Data.Models.Financial
{
    [Table("OpenItemMasterTable")]
    public class OpenItemMaster
    {
        [Key]
        public int OpnId { get; set; }
        [Required]
        public int CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail CompanyDetail { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required]
        [StringLength(6)]
        public string OpnVNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? OpnDate { get; set; }
        public virtual ICollection<OpenItemMasterDetail>  OpenItemMasterDetails { get; set; }
       
    }
}