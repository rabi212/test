using ITCGKP.Data.Models.Financial;
using ITCGKP.Data.Models.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCGKP.Data.Models.Master
{
    [Table("PatientDueReciptTable")] //  Platter
    public class PatientDueRecipt
    {
        [Key]
        public int Id { get; set; }        
        [Required]
        [StringLength(128)]
        public string UserCode { get; set; }        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? VDate { get; set; }
        [Required]
        [StringLength(20)]
        public string VNo { get; set; }
        [Required]
        public int PatId { get; set; }
        [ForeignKey("PatId")]
        public virtual Patient Patient { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmt { get; set; }        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PaidAmt { get; set; }        
        public string  Remark { get; set; }
        [Required]
        public int PaymentType { get; set; } // Digital Payment, Cash
    }
}