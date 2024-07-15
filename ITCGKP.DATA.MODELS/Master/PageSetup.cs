using ITCGKP.Data.Models.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Master
{
    [Table("PageSetupTable")]
    public class PageSetup
    {
        public int Id { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        public virtual CompanyDetail PageSetupCompanyDetails { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? LeftA { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? RightA { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TopA { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? BottomA { get; set; }
        [Required]
        public int CustomPapersizeA { get; set; }
        [Required]        
        public int CustomOrientationA { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? LeftB { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? RightB { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TopB { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? BottomB { get; set; }
        [Required]
        public int CustomPapersizeB { get; set; }
        [Required]
        public int CustomOrientationB { get; set; }        
        public string PageHeaderB { get; set; }        
        public string PageFooterB { get; set; }
        public bool PrintHeaderB { get; set; }
        public bool PrintFooterB { get; set; }
        public string HeaderPhotoPath { get; set; }
        public string HeaderPhotoFile { get; set; }
        public bool ReportHeaderPrint { get; set; }       
        public string FooterPhotoPath { get; set; }
        public string FooterPhotoFile { get; set; }
        public bool ReportFooterPrintA { get; set; }
        public string ReportFooterB { get; set; }
        public bool ReportFooterPrintB { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? LeftR { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? RightR { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TopR { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? BottomR { get; set; }
        [Required]
        public int CustomPapersizeR { get; set; }
        [Required]
        public int CustomOrientationR { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? LeftC { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? RightC { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? TopC { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? BottomC { get; set; }
        [Required]
        public int CustomPapersizeC { get; set; }
        [Required]
        public int CustomOrientationC { get; set; }

        public string HeaderFont { get; set; }
        public string HeaderSize { get; set; }
        public string HeaderStyle { get; set; }
        public string HeaderWeight { get; set; }
        public string HeaderColor { get; set; }
        public string HeaderDecorate { get; set; }
        public string HeaderDetails { get; set; }

        public string HeaderSecondFont { get; set; }
        public string HeaderSecondSize { get; set; }
        public string HeaderSecondStyle { get; set; }
        public string HeaderSecondWeight { get; set; }
        public string HeaderSecondColor { get; set; }
        public string HeaderSecondDecorate { get; set; }
        public string HeaderSecondDetails { get; set; }

        public string ReportHeaderFont { get; set; }
        public string ReportHeaderSize { get; set; }
        public string ReportHeaderStyle { get; set; }
        public string ReportHeaderWeight { get; set; }
        public string ReportHeaderLineHeight { get; set; }
        public string ReportHeaderColor { get; set; }
        public string ReportHeaderDecorate { get; set; }
        public string ReportHeaderDetails { get; set; }

        public string TestLockTypeNFont { get; set; }
        public string TestLockTypeNSize { get; set; }
        public string TestLockTypeNStyle { get; set; }
        public string TestLockTypeNWeight { get; set; }
        public string TestLockTypeNLineHeight { get; set; }
        public string TestLockTypeNColor { get; set; }
        public string TestLockTypeNDecorate { get; set; }
        public string TestLockTypeNDetails { get; set; }

        public string TestLockTypeLFont { get; set; }
        public string TestLockTypeLSize { get; set; }
        public string TestLockTypeLStyle { get; set; }
        public string TestLockTypeLWeight { get; set; }
        public string TestLockTypeLLineHeight { get; set; }
        public string TestLockTypeLColor { get; set; }
        public string TestLockTypeLDecorate { get; set; }
        public string TestLockTypeLDetails { get; set; }

        public string TestLockTypeMFont { get; set; }
        public string TestLockTypeMSize { get; set; }
        public string TestLockTypeMStyle { get; set; }
        public string TestLockTypeMWeight { get; set; }
        public string TestLockTypeMLineHeight { get; set; }
        public string TestLockTypeMColor { get; set; }
        public string TestLockTypeMDecorate { get; set; }
        public string TestLockTypeMDetails { get; set; }

        public string TestLockTypeYFont { get; set; }
        public string TestLockTypeYSize { get; set; }
        public string TestLockTypeYStyle { get; set; }
        public string TestLockTypeYWeight { get; set; }
        public string TestLockTypeYLineHeight { get; set; }
        public string TestLockTypeYColor { get; set; }
        public string TestLockTypeYDecorate { get; set; }
        public string TestLockTypeYDetails { get; set; }

        public string TestLockTypeSFont { get; set; }
        public string TestLockTypeSSize { get; set; }
        public string TestLockTypeSStyle { get; set; }
        public string TestLockTypeSWeight { get; set; }
        public string TestLockTypeSLineHeight { get; set; }
        public string TestLockTypeSColor { get; set; }
        public string TestLockTypeSDecorate { get; set; }
        public string TestLockTypeSDetails { get; set; }

        public string TestLockTypeBFont { get; set; }
        public string TestLockTypeBSize { get; set; }
        public string TestLockTypeBStyle { get; set; }
        public string TestLockTypeBWeight { get; set; }
        public string TestLockTypeBLineHeight { get; set; }
        public string TestLockTypeBColor { get; set; }
        public string TestLockTypeBDecorate { get; set; }
        public string TestLockTypeBDetails { get; set; }

        public string TestLockTypeNormalFont { get; set; }
        public string TestLockTypeNormalSize { get; set; }
        public string TestLockTypeNormalStyle { get; set; }
        public string TestLockTypeNormalWeight { get; set; }
        public string TestLockTypeNormalLineHeight { get; set; }
        public string TestLockTypeNormalColor { get; set; }
        public string TestLockTypeNormalDecorate { get; set; }
        public string TestLockTypeNormalDetails { get; set; }

        public string TestLockTypeUnnormalFont { get; set; }
        public string TestLockTypeUnnormalSize { get; set; }
        public string TestLockTypeUnnormalStyle { get; set; }
        public string TestLockTypeUnnormalWeight { get; set; }
        public string TestLockTypeUnnormalLineHeight { get; set; }
        public string TestLockTypeUnnormalColor { get; set; }
        public string TestLockTypeUnnormalDecorate { get; set; }
        public string TestLockTypeUnnormalDetails { get; set; }

        public string TestLockTypeRangeFont { get; set; }
        public string TestLockTypeRangeSize { get; set; }
        public string TestLockTypeRangeStyle { get; set; }
        public string TestLockTypeRangeWeight { get; set; }
        public string TestLockTypeRangeLineHeight { get; set; }
        public string TestLockTypeRangeColor { get; set; }
        public string TestLockTypeRangeDecorate { get; set; }
        public string TestLockTypeRangeDetails { get; set; }
        public bool PrintMedReport { get; set; }
        public int? MedReportType { get; set; }
        public bool BarcodeTop { get; set; } // Report Print true  == top falase bottotm
        public bool TestHeaderTop { get; set; } // Test Header true  == top false Report Wise
        public bool PatientRefNo { get; set; } // Patient Ref. No. Auto
        public bool PatientRefNoGroupwise { get; set; } // Patient Ref. No. Group Wise Auto

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? PagePrintLine { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? OnePrintChart { get; set; }
        public bool QRCodePrint { get; set; }
        public bool BarCodePrint { get; set; }
        public bool TestFormulaApply { get; set; }
        public int? FormulaDecimalPlace { get; set; }
        public bool PrintBillOneTwo { get; set; } // True = Double , False = Single 
    }
}
