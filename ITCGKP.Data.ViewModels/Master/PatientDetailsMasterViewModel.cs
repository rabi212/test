using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class PatientDetailsMasterViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="The Mode Field Required :")]
        [StringLength(10)]
        public string Mode { get; set; } // Test Group Short Name for filter
        [Required(ErrorMessage = "The Test Code Field Required :")]  
        [Range(1,3000000, ErrorMessage = "Test name invalid Please Select Valid Test Name")]
        public int TestId { get; set; }        
        public virtual TestMasterViewModel TestMasterViewModels { get; set; }        
        public int? TestGId { get; set; }
        public virtual TestGroupMasterViewModel TestGroupMasterViewModel { get; set; }
        //[Required(ErrorMessage = "The Test's Name Invalid")]
        //[Display(Name = "Test's Name")]
        //[StringLength(100)]
        //public string OpnItemName { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? StanderRate { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPPer1 { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IPAmt1 { get; set; }
        //[Required]
        public int TempSrNo { get; set; }
        public int PtIMId { get; set; }       
        public virtual PatientViewModel PatientViewModel { get; set; }
        public int CompIdX { get; set; }
        [StringLength(128)]
        public string UserCodeX { get; set; }
        //[Required]
        [StringLength(20)]
        public string VNoX { get; set; }
        public bool isSelected { get; set; }
    }
}
