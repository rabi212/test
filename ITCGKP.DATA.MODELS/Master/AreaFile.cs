using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;

namespace ITCGKP.Data.Models.Master
{
    [Table("AreaFileTable")]
    public class AreaFile
    {
        [Key]
        public int Id { get; set; }
        //[Required]        
        public int? CompIdA { get; set; }
        [ForeignKey("CompIdA")]
        public virtual CompanyDetail AreaCompanyDetail { get; set; }        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int DistId { get; set; }
        [ForeignKey("DistId")]
        public virtual  District DistrictDetail { get; set; }
    }
}
