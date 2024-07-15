using ITCGKP.Data.ViewModels.PayBill;
using ITCGKP.Data.ViewModels.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class AgentFileViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? CompIdA { get; set; }       
        public virtual CompanyDetailViewModel AgnetCompanyDetailsViews { get; set; }
        [Required(ErrorMessage = "The Agent Code Field Required")]
        [StringLength(15)]
        [Display(Name = "Agent Code :")]
        public string Code { get; set; }
        [Required(ErrorMessage = "The Agent Field Required")]
        [StringLength(100)]
        [Display(Name ="Name :")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Address Field Required")]
        [Display(Name = "Address :")]
        public string Address1 { get; set; }
        [StringLength(100)]
        [Display(Name = "City :")]
        public string City { get; set; }
        [StringLength(10)]
        [Display(Name = "Pin No. :")]
        public string PinNo { get; set; }
        [Required(ErrorMessage = "The Mobile No. Field Required")]
        [StringLength(100)]
        [Display(Name = "Mobile No.:")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "The Email Address Field Required")]
        [StringLength(100)]
        [Display(Name = "Email Address :")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string NameAddress { get; set; }
        [Display(Name = "IP Amt")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? IPAmt1 { get; set; }
        [Required(ErrorMessage = "The Bank Name field must be required")]
        [Display(Name = "Bank's Name")]
        [StringLength(100)]
        public string BankName { get; set; }
        [Required(ErrorMessage = "The Bank A/c No. field must be required")]
        [Display(Name = "Bank's A/c No.")]
        [StringLength(20)]
        public string BankAcNo { get; set; }
        [Required(ErrorMessage = "The Bank IFSC Code field must be required")]
        [Display(Name = "IFSC Code")]
        [StringLength(12)]
        public string IFSC { get; set; }
        [Display(Name = "E.P.F. No.")]
        [StringLength(20)]
        public string EPFAcNo { get; set; }
        [Display(Name = "Basic Pay")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? BasicPay { get; set; }
        [Display(Name = "T.A.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TA { get; set; }
        [Display(Name = "D.A.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? DA { get; set; }
        [Display(Name = "H.R.A.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? HRA { get; set; }
        [Display(Name = "C.C.A.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? CCA { get; set; }
        [Display(Name = "Active")]
        public bool ActiveType { get; set; }
        public virtual ICollection<UpdatePayBillViewModel> UpdatePayBillViewModels { get; set; }
    }
}
