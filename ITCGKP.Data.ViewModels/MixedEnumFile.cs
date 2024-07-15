using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels
{
    public enum MenuPanel
    {
        [Display(Name = "Setting File")]
        Setting = 0,
        [Display(Name = "Lab Master File")]
        LabMaster = 1,
        [Display(Name = "Laboratory File")]
        Laboratory = 2,
        [Display(Name = "Financial File")]
        FinancialFile = 3,
        [Display(Name = "PayRoll File")]
        PayRollFile = 4,
        [Display(Name = "Transaction File")]
        TransactionFile = 5,
        [Display(Name = "Report File")]
        ReportFile = 6
    }
    public enum PatientMarriedType
    {
        Unmarried = 0,
        Married = 1
    }
    public enum PatientReligionType
    {
        Hindu = 0,
        Muslim = 1,
        Sikh =2,
        Isai = 3,
        Crisium = 4
    }
    public enum PatientFitType
    {
       FIT = 0,
       UNFIT = 1
    }
    public enum PatientPanel
    {
        [Display(Name = "Normal Patient")]
        NPatient = 0,
        [Display(Name = "Pathology Patient")]
        PPatient = 1,
        [Display(Name = "Client Patient")]
        CPatient = 2
    }
    public enum PayMode
    {
        [Display(Name ="Cash")]
        Cash = 0,
        [Display(Name = "Phone Pay")]
        PhonePay = 1,
        [Display(Name = "Google Pay")]
        Google = 2,
        [Display(Name = "Bhim App Pay")]
        BhimApp = 3,
        [Display(Name = "PayTM Pay")]
        PayTM = 4,
        [Display(Name = "Whatsapp Pay")]
        WhatsApp = 5,
        [Display(Name = "Net Banking Pay")]
        NetBanking = 6
    }
    public enum LocalWiseStock
    {
        Product = 0,
        Group = 1,
        Item = 2,
        Design = 3,
        Size = 4,
        Vender = 5,
        Platter = 6
    }
    public enum TagWiseStock
    {
        Purchase = 0,
        Inward = 1,
        Outward = 2,
        SaleReturn = 3,
        Sale = 4,
        OldStock = 5,
        StockOnly = 6,
    }
    public enum SaleReportEnum
    {       
        SaleReport = 0,
        SaleRegister = 1,
        ItemWiseSale = 2,
        PartyWiseSale = 3,
        MediaWiseSale = 4,
        DateWiseSale = 5
    }
    public enum SaleReturnReportEnum
    {       
        CreditNoteReport = 0,
        CreditNoteRegister = 1,
        ItemWiseCreditNote = 2,
        PartyWiseCreditNote = 3,
        MediaWiseCreditNote = 4,
        DateWiseCreditNote = 5
    }
    public enum SaleOrderReportEnum
    {        
        SaleOrderReport = 0,
        SaleOrderRegister = 1,
        ItemWiseSaleOrder = 2,
        PartyWiseSaleOrder = 3,
        MediaWiseSaleOrder = 4,
        DateWiseSaleOrder = 5
    }
    public enum GSTEnum
    {
        GSTR1 = 0,
        GSTR2 = 1,
        GSTR3 = 2
    }
    public enum PaymentMode
    {
        Credit = 0,
        Payment = 1
    }
    public enum TaxRegistration
    {
        Unknown = 0,
        Composition = 1,
        Consumer = 2,
        Regular = 3,
        Unregistered = 4
    }
    public enum SupplyType
    {
        Unknown = 0,
        Goods = 1,
        Services = 2
    }
    public enum GSTType
    {
        No = 0,
        Yes = 1
    }
    public enum PatientCategory
    {
        OPD = 0,
        IPD = 1,
        Other = 2
    }
    public enum StockTransfer
    {
        No = 0,
        Yes = 1
    }
    public enum ReverseCharged
    {
        No = 0,
        Yes = 1
    }
    public enum FooterSignature
    {
        Pathologist = 0,
        Radiologist = 1
    }
    public enum Gender
    {
        Male = 0,
        Female = 1,
        None = 2
    }
    public enum GenderX
    {
        Male = 0,
        Female = 1,
        None = 2,
        ALL = 3
    }
    public enum Collected
    {
        InLab = 0,
        OutLab= 1
    }
    public enum PensionContribution
    {
        Yes = 0,
        No = 1
    }
    public enum BhawanSelfCategory
    {
        Self = 0,
        Renter = 1,
        Anawasiy =2,
        Other = 3
    }
    public enum BhawanWaterSupply
    {
        Nikay = 0,
        SelfHandpump = 1,
        Both = 2
    }
    public enum AccountNature
    {
        Assets = 1,
        Liabilities = 2,
        Expenses = 3,
        Incomes = 4
    }
    public enum AccountDrCr
    {
        Dr = 1,
        Cr = 2
    }
    public enum ItemType
    {
        Immitation = 1,
        Stone = 2
    }
    public enum CustomPapersize
    {
        A0 = 0,
        A1 = 1,
        A2 = 2,
        A3 = 3,
        A4 = 4,
        A5 = 5,
        A6 = 6,
        A7 = 7,
        A8 = 8,
        A9 = 9,
        B0 = 10,
        B1 = 11,
        B2 = 12,
        B3 = 13,
        B4 = 14,
        B5 = 15,
        B6 = 16,
        B7 = 17,
        B8 = 18,
        B9 = 19,
        B10 = 20,
        C5E = 21,
        Comm10E = 22,
        Dle = 23,
        Executive = 24,
        Folio = 25,
        Ledger = 26,
        Legal = 27,
        Letter = 28,
        Tabloid = 29
    }
    public enum CustomOrientation
    {
        Portrait = 0,
        Landscape = 1
    }
    public enum CustomerLanguage
    {
        English = 0,
        Hindi = 1,
        Mixed = 2
    }
    public enum CaptureCustomerNo
    {
        CustomerId = 0,
        MobileNo = 1
    }
    public enum CaptureCustomerTrue
    {
        ALL = 0,
        True = 1,
        False = 2
    }
}
