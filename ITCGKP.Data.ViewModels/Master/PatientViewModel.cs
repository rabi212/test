using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Setting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class PatientViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Branch")]
        public int CompId { get; set; }       
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        [Required(ErrorMessage ="The User Code Field Required")]
        [Display(Name = "User Code :")]
        [StringLength(128)]
        public string UserCode { get; set; }
        [Required(ErrorMessage = "The Voucher No. Field Required")]
        [Display(Name = "V.No.:")]
        [StringLength(20)]
        public string VNo { get; set; }
        [Required(ErrorMessage = "The Sample Date Field Required")]
        [Remote(action: "IsRegistrationSampleDateValidation", controller: "DateCheck")]
        [Display(Name = "Sample Dt")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public string SDate { get; set; }
        [StringLength(15)]
        public string STime { get; set; }
        [Required(ErrorMessage = "The Report Date Field Required")]
        [Remote(action: "IsRegistrationReportDateValidation", controller: "DateCheck")]
        [Display(Name = "Reg. Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public string RDate { get; set; }
        [StringLength(15)]
        public string RTime { get; set; }
        [Required(ErrorMessage = "The Type Field Required")]
        [Display(Name = "Type")]
        [StringLength(10)]
        public string Type { get; set; } // pathology x-ray ultrasound
        [Required(ErrorMessage = "The Reference  No. Field Required")]
        [Display(Name = "Ref.No.")]
        [StringLength(20)]
        public string RefNo { get; set; }
        [Required(ErrorMessage = "The Title Field Required")]
        [Display(Name = "Title")]
        [StringLength(20)]
        public string TitleName { get; set; }
        [Required(ErrorMessage = "The Patient Name Field Required")]
        [Display(Name = "Pt. Name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Adhaar No")]
        [StringLength(12)]
        public string AdharNo { get; set; }
        [Required(ErrorMessage = "The Gender Field Required")]
        [Display(Name = "Gender")]
        public Gender Sex { get; set; }
        [Required(ErrorMessage = "The Age Field Required")]
        [Display(Name = "Age")]
        [Range(0, 150, ErrorMessage = "The field {0} must be greater than {1}. and less 151 ")]
        public decimal? Age { get; set; }
        [Required(ErrorMessage = "The Age Category Field Required")]        
        [StringLength(10)]
        public string AgeType { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The Mobile No. Field Required")]
        [Display(Name = "Cell No.")]
        [StringLength(10)]
        public string MobileNo { get; set; }
        [Display(Name = "E-mail")]
        public string EmailAddress { get; set; }
        [Display(Name = "Auto Mail")]
        public bool EmailAuto { get; set; }
        [Display(Name = "Phone No.")]
        [StringLength(10)]
        public string PhoneNo { get; set; }        

        [Required(ErrorMessage = "The Client Field Required")]
        [Display(Name = "Client")]
        public int ClientCode { get; set; }
        public virtual ClientFileViewModel ClientFileViewModel { get; set; }
        [Required(ErrorMessage = "The Client Field Required")]
        public string ClientName { get; set; }
        public int? TempPanel { get; set; }
        [Required(ErrorMessage = "The Collected In  Field Required")]
        [Display(Name = "Collected")]
        [StringLength(50)]
        public string CollectedIn { get; set; }
        [Required(ErrorMessage = "The Collected by Field Required")]
        [Display(Name = "By:")]
        public int AgentAcCode { get; set; }
        public virtual AgentFileViewModel AgentFileViewModel { get; set; }
        [Required(ErrorMessage = "The Doctor's Name Field Required")]
        [Display(Name = "Doctor's Name")]
        public string DrName { get; set; }
        public int? DoctorAcCode { get; set; }
        public virtual LedgerMasterViewModel LedgerMasterViewModel{ get; set; }
        public string DoctorAcCodeX { get; set; }
        [Required(ErrorMessage = "The Payment Mode Field Required")]
        [Display(Name = "Paid Mode")]       
        public PayMode PaymentType { get; set; }
        [Display(Name = "Total Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalAmt { get; set; }
        [Display(Name = "Total IP Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TotalIPAmt { get; set; }
        [Display(Name = "Discount Reason")]
        [StringLength(50)]
        public string DiscountReasion { get; set; }
        [Display(Name = "Approved By")]
        [StringLength(50)]
        public string ApprovalBy { get; set; }
        [Display(Name="Disc. By")]
        [StringLength(20)]
        public string DiscountType { get; set; }
        [Display(Name = "Disc %.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal DiscPer { get; set; }
        [Display(Name = "Disc Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal DiscAmt { get; set; }
        [Required(ErrorMessage ="The Area Field Required")]
        [Display(Name ="Area")]
        //[ForeignKey("PatientAreaCode")]
        public int AreaCode { get; set; }
        public virtual AreaFileViewModel PatientAreadCodeViewModel { get; set; }
        [Display(Name = "Collection Charges")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CollectionCharge { get; set; }
        [Display(Name = "Collection Boy")]
        public string CollectionBoy { get; set; }
        [Display(Name = "Delivery Charges")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DeliveryCharge { get; set; }
        [Display(Name = "Delivery Boy")]
        public string DeliveryBoy { get; set; }
        [Display(Name = "Paid Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? PaidAmt { get; set; }
        [Display(Name = "Bal Amt.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? BalAmt { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        [Display(Name = "Today List")]
        public int? UpdateRecord { get; set; }
        public string TestDetailRecord { get; set; }
        public string SoftwareType { get; set; } // ALL / One
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "Report Date:")]
        public string  ReportDate { get; set; }
        [Display(Name = "Report Cancel")]
        [StringLength(5)]
        public string ReportCancel { get; set; }
        [Display(Name = "Report Not Done")]
        [StringLength(5)]
        public string ResultNotDone { get; set; }
        [Display(Name = "Report Done")]
        [StringLength(5)]
        public string ResultDone { get; set; }
        [Display(Name = "Approved")]
        [StringLength(5)]
        public string ReportApproved { get; set; }
        [Display(Name = "Report Issue")]
        [StringLength(5)]
        public string ReportIssue { get; set; }
        [Display(Name = "Report Hold")]
        [StringLength(5)]
        public string ReportHold { get; set; }
        [Display(Name = "Report Recipt")]
        [StringLength(5)]
        public string ReportRecipt { get; set; }
        [Display(Name = "Report Dispatch")]
        [StringLength(5)]
        public string ReportDispatch { get; set; }
        [Display(Name = "Dispatch Color Hold")]
        [StringLength(5)]
        public string DispatchColorHold { get; set; }
        //[Required(ErrorMessage = "The Collected by Field Required")]
        [Display(Name = "Investigation By")]
        public int? DrLabId { get; set; }
        public virtual DoctorLabViewModel DoctorLabViewModel { get; set; }
        public PatientViewModel()
        {
            PatientDetailsMasterViewModels = new List<PatientDetailsMasterViewModel>();
            PatientDiscountMasterViewModels = new List<PatientDiscountMasterViewModel>();
        }
        public virtual List<PatientDetailsMasterViewModel> PatientDetailsMasterViewModels  { get; set; }
        public virtual List<PatientDiscountMasterViewModel> PatientDiscountMasterViewModels { get; set; }
        public virtual List<PatientInvestigationViewModel> PatientInvestigationViewModels { get; set; }
        public int CurrentNo { get => PatientDetailsMasterViewModels.Count + 1; }
        public int RowId { get; set; }
        [StringLength(128)]
        public string EditUserCode { get; set; }
    }
}
