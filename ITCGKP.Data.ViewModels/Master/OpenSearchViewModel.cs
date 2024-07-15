using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
   public class OpenSearchViewModel
    {
        [Display(Name = "User")]
        public string UserId { get; set; }
        [Display(Name = "Branch")]
        public int CompId { get; set; }
        [Display(Name = "Client Name")]
        public int ClientId { get; set; }
        [BindProperty,DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }
        [BindProperty,DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "Upto Date")]
        public DateTime UptoDate  { get; set; }
        public string InvoiceNo { get; set; }
        [Display(Name = "A/c Group's Name")]
        public int AcGId { get; set; }
        [Display(Name = "A/c Name")]
        public int AcId { get; set; }
        public string ItemName { get; set; }
        [Display(Name = "Product's Name")]
        public int ProdId { get; set; }
        [Display(Name = "Item Group's Name")]
        public int ItemGroupId { get; set; }
        [Display(Name = "Item Name")]
        public int ItemId { get; set; }
        [Display(Name = "Platter's Name")]
        public int PltId { get; set; }
        [Display(Name = "Vender's Name")]
        public int VendId { get; set; }
        [Display(Name = "Reffered Name")]
        public string Reffered { get; set; }
        [Display(Name = "S/o,D/o,W/o Name")]
        public string FatherName { get; set; }
        public string sex { get; set; }
        public int Age { get; set; }
        public string  Address { get; set; }
        public string EmailAddress { get; set; }
        public int  DoctorId { get; set; }
        [Display(Name = "Doctor's Name")]
        public string DrName { get; set; }
        [Display(Name = "From Pur.")]
        public decimal FromPurRate { get; set; }
        [Display(Name = "Upto Pur.")]
        public decimal UptoPurRate { get; set; }
        [Display(Name = "From MRP")]
        public decimal FromMRP { get; set; }
        [Display(Name = "Upto MRP")]
        public decimal UptoMRP { get; set; }
        [Display(Name = "Executive's Name")]
        public int EmpId { get; set; }
        [Display(Name = "Customer's Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }
        [Display(Name = "Total Amt.")]
        public decimal TotalAmt  { get; set; }        
        [Display(Name = "Disc Amt.")]
        public decimal DiscAmt { get; set; }
        [Display(Name = "Cash Amt")]
        public decimal CashAmt { get; set; }
        [Display(Name = "Pending Amt.")]
        public decimal Pending { get; set; }
        [Display(Name = "Paid Amt.")]
        public decimal PaidAmt { get; set; }
        [Display(Name = "HSN NO.")]
        public string HSNCode { get; set; }
        [Display(Name ="Voucher Type")]
        public string VoucherType { get; set; }
        [Display(Name = "Date")]
        public string PayUptoDate { get; set; }
        [Display(Name = "Days")]
        public decimal? PayBillDays { get; set; }
        [Display(Name ="Zero Balance Show")]
        public bool ZeroBal { get; set; }
        [Display(Name = "Report Wise")]
        public LocalWiseStock reportWise { get; set; }
        [Display(Name = "Tag Wise")]
        public TagWiseStock TagWise { get; set; }
        public string TagNo { get; set; }
        public string  PaymentType { get; set; } // F = Full Paid, P = Partial Paid, U = fully unpaid , A = for ALL
        public SaleReportEnum SaleWise { get; set; }
        public SaleReturnReportEnum SaleReturnReportWise { get; set; }
        public SaleOrderReportEnum SaleOrderReportWise { get; set; }
        public GSTEnum GstWise { get; set; }        
        public int MediaId { get; set; }
        public int PackId { get; set; }
        public string TestGroupName { get; set; }
        [Display(Name = "Payment Mode")]
        public string PaymentMode { get; set; } // Cash Digital
        public int TestDoctorId { get; set; }
        public string SearchRecordFinder { get; set; }
        public bool SearchDate { get; set; }
        [Display(Name = "Header Print")]
        public bool HeaderPrint { get; set; }
    }
}
