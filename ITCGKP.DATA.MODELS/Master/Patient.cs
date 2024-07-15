using ITCGKP.Data.Models.Financial;
using ITCGKP.Data.Models.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCGKP.Data.Models.Master
{
    [Table("PatientTable")] //  Platter
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public int CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail  PatientCompanyDetails { get; set; }
        [Required]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required]
        [StringLength(20)]
        public string VNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? SDate { get; set; }
        [StringLength(10)]
        public string STime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? RDate { get; set; }
        [StringLength(20)]
        public string RTime { get; set; }
        [StringLength(10)]
        public string Type { get; set; } // pathology x-ray ultrasound
        [Required]
        [StringLength(20)]
        public string RefNo { get; set; }
        [Required]
        [StringLength(20)]
        public string TitleName { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(12)]
        public string AdharNo { get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(10)]
        public string AgeType { get; set; }
        public string Address { get; set; }
        [Required]
        [StringLength(200)]
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailAuto { get; set; }
        [StringLength(10)]
        public string PhoneNo { get; set; }                                                  
        [Required]
        [ForeignKey("PatientClientCode")]
        public int ClientCode { get; set; }
        public virtual ClientFile PatientClientCode { get; set; }

        [Required]
        [StringLength(50)]
        public string CollectedIn { get; set; }
        [Required]
        [ForeignKey("PatientAgentAcCode")]
        public int AgentAcCode { get; set; }
        public virtual AgentFile PatientAgentAcCode { get; set; }
        public string DrName { get; set; }
        //[Required]
        [ForeignKey("PatientDoctorAcCode")]
        public int? DoctorAcCode { get; set; }
        public virtual LedgerMaster PatientDoctorAcCode { get; set; }
        [Required]       
        public int PaymentType { get; set; }  // Digital Payment, Cash

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalIPAmt { get; set; }
        [StringLength(50)]
        public string DiscountReasion { get; set; }
        [StringLength(50)]
        public string ApprovalBy { get; set; }
        [StringLength(20)]
        public string DiscountType { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscPer { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscAmt { get; set; }
        [Required]
        [ForeignKey("PatientAreaCode")]
        public int AreaCode { get; set; }
        public virtual AreaFile PatientAreadCode { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CollectionCharge { get; set; }
        public string CollectionBoy { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DeliveryCharge { get; set; }
        public string DeliveryBoy { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PaidAmt { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? BalAmt { get; set; }
        public string  Remark { get; set; }
        public string TestDetailRecord { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        [StringLength(25)]
        public string ReportDate { get; set; }
        [StringLength(5)]
        public string ReportCancel { get; set; }
        [StringLength(5)]
        public string ResultNotDone { get; set; }
        [StringLength(5)]
        public string ResultDone { get; set; }
        [StringLength(5)]
        public string ReportApproved { get; set; }
        [StringLength(5)]
        public string ReportIssue { get; set; }
        [StringLength(5)]
        public string ReportHold { get; set; }
        [StringLength(5)]
        public string ReportRecipt { get; set; }
        [StringLength(5)]
        public string ReportDispatch { get; set; }
        [StringLength(5)]
        public string DispatchColorHold { get; set; }
        public int? DrLabId { get; set; }
        [ForeignKey("DrLabId")]
        public virtual DoctorLab DoctorLab { get; set; }
        public virtual ICollection<PatientDetailsMaster> PatientDetailsMasters { get; set; }
        public virtual ICollection<PatientDiscountMaster> PatientDiscountMasters { get; set; }
        public virtual ICollection<PatientInvestigation> PatientInvestigations { get; set; }
        public bool PrintBill { get; set; }        
        [StringLength(128)]
        public string EditUserCode { get; set; }
    }
}