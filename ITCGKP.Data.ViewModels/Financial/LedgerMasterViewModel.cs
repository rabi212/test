using ITCGKP.Data.ViewModels.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITCGKP.Data.ViewModels.Financial
{
    public class LedgerMasterViewModel
    {
        [Key]       
        [Display(Name ="Id")]
        public int LedgerMasterId { get; set; }
       // [Required(ErrorMessage =" ")]
        [Display(Name ="Branch :")]
        public int? CompId { get; set; }        
        public virtual CompanyDetailViewModel CompanyDetailsLedgerView { get; set; }
        [Required (ErrorMessage ="The User Code Field Required ")]
        [StringLength(15)]
        [Display(Name ="Code :")]
        public string LedCode { get; set; }       
        [Required (ErrorMessage = "The Account Name Field Required ")]
        [Display(Name ="A/c Name :")]
        [StringLength(100)]
        public string PartyName { get; set; }
        [Display(Name = "Address 1 :")]
        [StringLength(100)]    
        public string Address1 { get; set; }
        [Display(Name = "Address 2 :")]
        [StringLength(100)]   
        public string Address2 { get; set; }
        [Display(Name = "Address 3 :")]
        [StringLength(100)]
        public string Address3 { get; set; }
        [Display(Name ="City :")]
        [StringLength(100)]
        public string City { get; set; }
        [Display(Name ="Pin Code :")]
        [StringLength(100)]
        public string PinNo { get; set; }
        [Required(ErrorMessage =" ")]
        [Display(Name ="State's Name :")]
        public int LedStateId { get; set; }       
        public virtual StateViewModel StateLedgerMasterView { get; set; }
        [Display(Name ="Email Address :")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [Display(Name ="Phone No. :")]
        [StringLength(100)]
        public string PhoneNo { get; set; }
        [Display(Name = "Mobile No.1 :")]
        [StringLength(100)]
        public string MobileNo1 { get; set; }
        [Display(Name ="Mobile No.2 :")]
        [StringLength(100)]
        public string MobileNo2 { get; set; }
        [Display(Name ="Pan No. :")]
        [StringLength(100)]
        public string PanNo { get; set; }
        [Display(Name ="Adhar No. :")]
        [StringLength(100)]
        public string AdharNo { get; set; }
        [Display(Name ="GST No. :")] 
        [StringLength(100)]
        public string GSTNo { get; set; }
        [Required(ErrorMessage =" ")]
        [Display(Name ="A/c Group Name :")]
        public int AcGroupId { get; set; }        
        public virtual AccountGroupViewModel AccountGroupViewLedger { get; set; }
       
        [Display(Name = "Date Of Birth :")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }       
        [Display(Name = "A.Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public string DateOfAnversary { get; set; }
        [Display(Name ="Opn Amt.")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OpnAmt { get; set; }
        [Display(Name ="Opn Type")]       
        public AccountDrCr OpnAc { get; set; }
        [Display(Name = "Close Amt.")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CloseAmt { get; set; }
        public AccountDrCr CloseAc { get; set; }
       
    }
}