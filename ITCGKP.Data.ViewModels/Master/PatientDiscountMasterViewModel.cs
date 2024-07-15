using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class PatientDiscountMasterViewModel
    {
        [Key]
        public int Id { get; set; }       
        //[Required(ErrorMessage = "The Test Group Code Field Required :")]
        public int TestGId { get; set; }        
        public virtual TestGroupMasterViewModel TestGroupMasterViewModel { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscPer1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DiscAmt1 { get; set; }
        public int PtIMId { get; set; }       
        public virtual PatientViewModel PatientViewModel { get; set; }
        public int CompIdX { get; set; }
        [StringLength(128)]
        public string UserCodeX { get; set; }
        //[Required]
        [StringLength(20)]
        public string VNoX { get; set; }
    }
}
