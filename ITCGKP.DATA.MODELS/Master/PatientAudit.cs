using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.Models.Setting;
using ITCGKP.Data.Models.Financial;

namespace ITCGKP.Data.Models.Master
{
    [Table("PatientAuditTable")] //  Platter
    public class PatientAudit
    {
        [Key]
        public int Id { get; set; }
        public int? PatId { get; set; }
        public int CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail  CompanyDetail { get; set; }        
        [StringLength(128)]
        public string UserCode { get; set; }        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? SDate { get; set; }        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? ModifDate { get; set; }        
        [StringLength(20)]
        public string VNo { get; set; }
        [StringLength(20)]
        public string RefNo { get; set; }
        public string PatientInformation { get; set; }        
        public string PaidPreInformation { get; set; }
        public string PaidPostInformation { get; set; }
        public string UpdateType { get; set; }
        public bool SelectDeleted { get; set; }
        [StringLength(128)]
        public string EditUserCode { get; set; }
    }
}