using ITCGKP.Data.ViewModels.Setting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class PageSetupViewModel
    {
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel PageSetupCompanyDetailsViews { get; set; }
        [Required(ErrorMessage = "The Left field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Left")]
        public decimal? LeftA { get; set; }
        [Required(ErrorMessage = "The Right field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Right")]
        public decimal? RightA { get; set; }
        [Required(ErrorMessage = "The Top field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Top")]
        public decimal? TopA { get; set; }
        [Required(ErrorMessage = "The Bottom field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Bottom")]
        public decimal? BottomA { get; set; }
        [Required(ErrorMessage = "The Paper Size field is required")]
        [Display(Name = "Paper Size")]
        public CustomPapersize CustomPapersizeA { get; set; }
        [Required(ErrorMessage = "The Orientation field is required")]       
        [Display(Name = "Orientation")]
        public CustomOrientation CustomOrientationA { get; set; }

        [Required(ErrorMessage = "The Left field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Left")]
        public decimal? LeftB { get; set; }
        [Required(ErrorMessage = "The Right field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Right")]
        public decimal? RightB { get; set; }
        [Required(ErrorMessage = "The Top field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Top")]
        public decimal? TopB { get; set; }
        [Required(ErrorMessage = "The Bottom field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Bottom")]
        public decimal? BottomB { get; set; }
        [Required(ErrorMessage = "The Paper Size field is required")]
        [Display(Name = "Paper Size")]
        public CustomPapersize CustomPapersizeB { get; set; }
        [Required(ErrorMessage = "The Orientation field is required")]
        [Display(Name = "Orientation :")]
        public CustomOrientation CustomOrientationB { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Bill Header")]
        public string PageHeaderB { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Bill Footer")]
        public string PageFooterB { get; set; }        
        [Display(Name = "Print Bill Header")]
        public bool PrintHeaderB { get; set; }
        [Display(Name = "Print Bill Footer")]
        public bool PrintFooterB { get; set; }

        [Display(Name = "Select Header Photo")]
        public IFormFile HeaderPhoto { get; set; }
        [Display(Name = "Report Header")]
        public string ExitHeaderPhotoPath { get; set; }
        public string HeaderPhotoFile { get; set; }
        [Display(Name = "Print Report Header")]
        public bool ReportHeaderPrint { get; set; }

        [Display(Name = "Select Footer Photo")]
        public IFormFile FooterPhoto { get; set; }
        [Display(Name = "Print Report Footer-A")]
        public string ExitFooterPhotoPath { get; set; }
        public string FooterPhotoFile { get; set; }
        [Display(Name = "Print Report Footer-A")]
        public bool ReportFooterPrintA { get; set; }

        
        [DataType(DataType.MultilineText)]
        [Display(Name = "Print Report Footer-B")]
        public string ReportFooterB { get; set; }
        [Display(Name = "Print Report Footer-B")]
        public bool ReportFooterPrintB { get; set; }
        public string MyProperty { get; set; }

        [Required(ErrorMessage = "The Left field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Left")]
        public decimal? LeftR { get; set; }
        [Required(ErrorMessage = "The Right field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Right")]
        public decimal? RightR { get; set; }
        [Required(ErrorMessage = "The Top field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Top")]
        public decimal? TopR { get; set; }
        [Required(ErrorMessage = "The Bottom field is required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Bottom")]
        public decimal? BottomR { get; set; }
        [Required(ErrorMessage = "The Paper Size field is required")]
        [Display(Name = "Paper Size")]
        public CustomPapersize CustomPapersizeR { get; set; }
        [Required(ErrorMessage = "The Orientation field is required")]
        [Display(Name = "Orientation")]
        public CustomOrientation CustomOrientationR { get; set; }

        [Required(ErrorMessage = "The Left field must be required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Left")]
        public decimal? LeftC { get; set; }
        [Required(ErrorMessage = "The Right field must be required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Right")]
        public decimal? RightC { get; set; }
        [Required(ErrorMessage = "The Top field must be required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Top")]
        public decimal? TopC { get; set; }
        [Required(ErrorMessage = "The Bottom field must be required")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Bottom")]
        public decimal? BottomC { get; set; }
        [Required(ErrorMessage = "The Paper Size field must be required")]
        [Display(Name = "Paper Size")]
        public CustomPapersize CustomPapersizeC { get; set; }
        [Required(ErrorMessage = "The Orientation field must be required")]
        [Display(Name = "Orientation :")]
        public CustomOrientation CustomOrientationC { get; set; }
        public string AddFontName { get; set; }

        [Display(Name = "Font")]
        public string HeaderFont { get; set; }
        [Display(Name = "Size")]
        public string HeaderSize { get; set; }
        [Display(Name = "Style")]
        public string HeaderStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string HeaderWeight { get; set; }
        [Display(Name = "Color")]
        public string HeaderColor { get; set; }
        [Display(Name = "Decoration")]
        public string HeaderDecorate { get; set; }
        public string HeaderDetails { get; set; }
        [Display(Name = "Font")]
        public string HeaderSecondFont { get; set; }
        [Display(Name = "Size")]
        public string HeaderSecondSize { get; set; }
        [Display(Name = "Style")]
        public string HeaderSecondStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string HeaderSecondWeight { get; set; }
        [Display(Name = "Color")]
        public string HeaderSecondColor { get; set; }
        [Display(Name = "Decoration")]
        public string HeaderSecondDecorate { get; set; }
        public string HeaderSecondDetails { get; set; }
        [Display(Name = "Font")]
        public string ReportHeaderFont { get; set; }
        [Display(Name = "Size")]
        public string ReportHeaderSize { get; set; }
        [Display(Name = "Style")]
        public string ReportHeaderStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string ReportHeaderWeight { get; set; }
        [Display(Name = "Line Height")]
        public string ReportHeaderLineHeight { get; set; }
        [Display(Name = "Color")]
        public string ReportHeaderColor { get; set; }
        [Display(Name = "Decoration")]
        public string ReportHeaderDecorate { get; set; }
        public string ReportHeaderDetails { get; set; }
        [Display(Name = "Font")]
        public string TestLockTypeNFont { get; set; }
        [Display(Name = "Size")]
        public string TestLockTypeNSize { get; set; }
        [Display(Name = "Style")]
        public string TestLockTypeNStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string TestLockTypeNWeight { get; set; }
        [Display(Name = "Line Height")]
        public string TestLockTypeNLineHeight { get; set; }
        [Display(Name = "Color")]
        public string TestLockTypeNColor { get; set; }
        [Display(Name = "Decoration")]
        public string TestLockTypeNDecorate { get; set; }
        public string TestLockTypeNDetails { get; set; }
        [Display(Name = "Font")]
        public string TestLockTypeLFont { get; set; }
        [Display(Name = "Size")]
        public string TestLockTypeLSize { get; set; }
        [Display(Name = "Style")]
        public string TestLockTypeLStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string TestLockTypeLWeight { get; set; }
        [Display(Name = "Line Height")]
        public string TestLockTypeLLineHeight { get; set; }
        [Display(Name = "Color")]
        public string TestLockTypeLColor { get; set; }
        [Display(Name = "Decoration")]
        public string TestLockTypeLDecorate { get; set; }
        public string TestLockTypeLDetails { get; set; }
        [Display(Name = "Font")]
        public string TestLockTypeMFont { get; set; }
        [Display(Name = "Size")]
        public string TestLockTypeMSize { get; set; }
        [Display(Name = "Style")]
        public string TestLockTypeMStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string TestLockTypeMWeight { get; set; }
        [Display(Name = "Line height")]
        public string TestLockTypeMLineHeight { get; set; }
        [Display(Name = "Color")]
        public string TestLockTypeMColor { get; set; }
        [Display(Name = "Decoration")]
        public string TestLockTypeMDecorate { get; set; }
        public string TestLockTypeMDetails { get; set; }
        [Display(Name = "Font")]
        public string TestLockTypeYFont { get; set; }
        [Display(Name = "Size")]
        public string TestLockTypeYSize { get; set; }
        [Display(Name = "Style")]
        public string TestLockTypeYStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string TestLockTypeYWeight { get; set; }
        [Display(Name = "Line Height")]
        public string TestLockTypeYLineHeight { get; set; }
        [Display(Name = "Color")]
        public string TestLockTypeYColor { get; set; }
        [Display(Name = "Decoration")]
        public string TestLockTypeYDecorate { get; set; }
        public string TestLockTypeYDetails { get; set; }
        [Display(Name = "Font")]
        public string TestLockTypeSFont { get; set; }
        [Display(Name = "Size")]
        public string TestLockTypeSSize { get; set; }
        [Display(Name = "Style")]
        public string TestLockTypeSStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string TestLockTypeSWeight { get; set; }
        [Display(Name = "Line height")]
        public string TestLockTypeSLineHeight { get; set; }
        [Display(Name = "Color")]
        public string TestLockTypeSColor { get; set; }
        [Display(Name = "Decoration")]
        public string TestLockTypeSDecorate { get; set; }
        public string TestLockTypeSDetails { get; set; }
        [Display(Name = "Font")]
        public string TestLockTypeBFont { get; set; }
        [Display(Name = "Size")]
        public string TestLockTypeBSize { get; set; }
        [Display(Name = "Style")]
        public string TestLockTypeBStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string TestLockTypeBWeight { get; set; }
        [Display(Name = "Line height")]
        public string TestLockTypeBLineHeight { get; set; }
        [Display(Name = "Color")]
        public string TestLockTypeBColor { get; set; }
        [Display(Name = "Decoration")]
        public string TestLockTypeBDecorate { get; set; }
        public string TestLockTypeBDetails { get; set; }
        [Display(Name = "Font")]
        public string TestLockTypeNormalFont { get; set; }
        [Display(Name = "Size")]
        public string TestLockTypeNormalSize { get; set; }
        [Display(Name = "Style")]
        public string TestLockTypeNormalStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string TestLockTypeNormalWeight { get; set; }
        [Display(Name = "Line Height")]
        public string TestLockTypeNormalLineHeight { get; set; }
        [Display(Name = "Color")]
        public string TestLockTypeNormalColor { get; set; }
        [Display(Name = "Decoration")]
        public string TestLockTypeNormalDecorate { get; set; }
        public string TestLockTypeNormalDetails { get; set; }
        [Display(Name = "Font")]
        public string TestLockTypeUnnormalFont { get; set; }
        [Display(Name = "Size")]
        public string TestLockTypeUnnormalSize { get; set; }
        [Display(Name = "Style")]
        public string TestLockTypeUnnormalStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string TestLockTypeUnnormalWeight { get; set; }
        [Display(Name = "Line height")]
        public string TestLockTypeUnnormalLineHeight { get; set; }
        [Display(Name = "Color")]
        public string TestLockTypeUnnormalColor { get; set; }
        [Display(Name = "Decoration")]
        public string TestLockTypeUnnormalDecorate { get; set; }
        public string TestLockTypeUnnormalDetails { get; set; }
        [Display(Name = "Font")]
        public string TestLockTypeRangeFont { get; set; }
        [Display(Name = "Size")]
        public string TestLockTypeRangeSize { get; set; }
        [Display(Name = "Style")]
        public string TestLockTypeRangeStyle { get; set; }
        [Display(Name = "Font Weight")]
        public string TestLockTypeRangeWeight { get; set; }
        [Display(Name = "Line Height")]
        public string TestLockTypeRangeLineHeight { get; set; }
        [Display(Name = "Color")]
        public string TestLockTypeRangeColor { get; set; }
        [Display(Name = "Decoration")]
        public string TestLockTypeRangeDecorate { get; set; }
        public string TestLockTypeRangeDetails { get; set; }
        [Display(Name = "Medical Report Photo")]
        public bool PrintMedReport { get; set; }
        [Display(Name = "Medical Report No")]
        public int? MedReportType { get; set; }
        [Display(Name = "Report Barcode Top")]
        public bool BarcodeTop { get; set; } // Report Print true  == top falase bottotm
        [Display(Name = "Test Header After Report Header")]
        public bool TestHeaderTop { get; set; } // Test Header true  == top false Report Wise
        [Display(Name = "Ref.No. Auto")]
        public bool PatientRefNo { get; set; } // Patient Ref. No. Auto
        [Display(Name = "Ref.No. Group Wise Auto")]
        public bool PatientRefNoGroupwise { get; set; } // Patient Ref. No. Group Wise Auto
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Page Print Line")]
        public decimal? PagePrintLine { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "One Print Character")]
        public decimal? OnePrintChart { get; set; }
        [Display(Name = "Report Print QR Code")]
        public bool QRCodePrint { get; set; }
        [Display(Name = "Report Print Barcode")]
        public bool BarCodePrint { get; set; }
        [Display(Name = "CBC Formula Apply")]
        public bool TestFormulaApply { get; set; }
        [Display(Name = "Formula Decimal Place")]
        public int? FormulaDecimalPlace { get; set; }
        [Display(Name = "Print Bill Double")]
        public bool PrintBillOneTwo { get; set; } // True = Double , False = Single 
    }
}
