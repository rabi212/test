using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Setting;

namespace ITCGKP.Data.ViewModels.Master
{
    public class AreaFileViewModel
    {
        [Key]
        public int Id { get; set; }
        //[Required]        
        public int? CompIdA { get; set; }
        //[ForeignKey("CompIdA")]
        public virtual CompanyDetailViewModel  AreaCompanyDetail { get; set; }
        [Required(ErrorMessage = "The Area Name Field Required")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The District Field Required")]
        public int DistId { get; set; }
        //[ForeignKey("DistId")]
        public virtual DistrictViewModel DistrictDetail { get; set; }
    }
}
