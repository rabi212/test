using ITCGKP.Data.Models;
using ITCGKP.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKP.Data.Models.Master;
using ITCGKP.Data.Models.Financial;
using ITCGKP.Data.Models.Transaction;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public class MasterRepository : VariableService, IMasterRepository
    {
        string[] myzerothree = { "000", "00", "0" };
        string[] myzero = { "0000", "000", "00", "0" };
        string[] myTwozero = { "00", "0" };
        string[] myzerop = { "00000", "0000", "000", "00", "0" };
        string[] myzerovch = { "000000", "00000", "0000", "000","00","0" };
        private readonly ApplicationDBContext _applicationDbContext = null;        
        public MasterRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDbContext = applicationDBContext;
        }
        public async Task<List<string>> PageSetupTestFormulaApply(int cmpdid)
        {
            // Multiple Branches By Customer Software type (false)
            List<string> vs = new List<string>();
            var result = await _applicationDbContext.PageSetupTable.FirstOrDefaultAsync(x => x.CompId == cmpdid);
            vs.Add(result.TestFormulaApply == true ? "Apply" : "Not Apply");
            vs.Add(result.FormulaDecimalPlace.ToString());
            return vs;
        }
        public async Task<bool> AddNewPageSetupValidedMultipleBranch(int cmpdid)
        {
            // Multiple Branches By Customer Software type (false)
            var result = await _applicationDbContext.PageSetupTable.FirstOrDefaultAsync(x => x.CompId == cmpdid);            
            return result != null ? true : false;
        }
        public async Task<int> AddNewPageSetupNewUserMultipleBranch(int cmpdid)
        {
            // Multiple Branches By Customer Software type (false)
            var result = await _applicationDbContext.PageSetupTable.FirstOrDefaultAsync(x => x.CompId == 1);
            PageSetup newCate = new PageSetup()
            {
                CompId = cmpdid,
                LeftA = result.LeftA,
                RightA = result.RightA,
                TopA = result.TopA,
                BottomA = result.BottomA,
                CustomPapersizeA = Convert.ToInt32(result.CustomPapersizeA),
                CustomOrientationA = Convert.ToInt32(result.CustomOrientationA),
                LeftB = result.LeftB,
                RightB = result.RightB,
                TopB = result.TopB,
                BottomB = result.BottomB,
                CustomPapersizeB = Convert.ToInt32(result.CustomPapersizeB),
                CustomOrientationB = Convert.ToInt32(result.CustomOrientationB),
                PageHeaderB = result.PageHeaderB,
                PageFooterB = result.PageFooterB,
                PrintHeaderB = result.PrintHeaderB,
                PrintFooterB = result.PrintFooterB,

                HeaderPhotoPath = result.HeaderPhotoPath,
                HeaderPhotoFile = result.HeaderPhotoFile,
                ReportHeaderPrint = result.ReportHeaderPrint,

                FooterPhotoPath = result.FooterPhotoPath,
                FooterPhotoFile = result.FooterPhotoFile,
                ReportFooterPrintA = result.ReportFooterPrintA,

                ReportFooterB = result.ReportFooterB,
                ReportFooterPrintB = result.ReportFooterPrintB,

                LeftR = result.LeftR,
                RightR = result.RightR,
                TopR = result.TopR,
                BottomR = result.BottomR,
                CustomPapersizeR = Convert.ToInt32(result.CustomPapersizeR),
                CustomOrientationR = Convert.ToInt32(result.CustomOrientationR),
                LeftC = result.LeftC,
                RightC = result.RightC,
                TopC = result.TopC,
                BottomC = result.BottomC,
                CustomPapersizeC = Convert.ToInt32(result.CustomPapersizeC),
                CustomOrientationC = Convert.ToInt32(result.CustomOrientationC),
                HeaderFont = result.HeaderFont,
                HeaderSize = result.HeaderSize,
                HeaderStyle = result.HeaderStyle,
                HeaderWeight = result.HeaderWeight,
                HeaderColor = result.HeaderColor,
                HeaderDecorate = result.HeaderDecorate,
                HeaderDetails = result.HeaderDetails,
                HeaderSecondFont = result.HeaderSecondFont,
                HeaderSecondSize = result.HeaderSecondSize,
                HeaderSecondStyle = result.HeaderSecondStyle,
                HeaderSecondWeight = result.HeaderSecondWeight,
                HeaderSecondColor = result.HeaderSecondColor,
                HeaderSecondDecorate = result.HeaderSecondDecorate,
                HeaderSecondDetails = result.HeaderSecondDetails,
                ReportHeaderFont = result.ReportHeaderFont,
                ReportHeaderSize = result.ReportHeaderSize,
                ReportHeaderStyle = result.ReportHeaderStyle,
                ReportHeaderWeight = result.ReportHeaderWeight,
                ReportHeaderLineHeight = result.ReportHeaderLineHeight,
                ReportHeaderColor = result.ReportHeaderColor,
                ReportHeaderDecorate = result.ReportHeaderDecorate,
                ReportHeaderDetails = result.ReportHeaderDetails,
                
                TestLockTypeNFont = result.TestLockTypeNFont,
                TestLockTypeNSize = result.TestLockTypeNSize,
                TestLockTypeNStyle = result.TestLockTypeNStyle,
                TestLockTypeNWeight = result.TestLockTypeNWeight,
                TestLockTypeNLineHeight = result.TestLockTypeNLineHeight,
                TestLockTypeNColor = result.TestLockTypeNColor,
                TestLockTypeNDecorate = result.TestLockTypeNDecorate,
                TestLockTypeNDetails = result.TestLockTypeNDetails,

                TestLockTypeLFont = result.TestLockTypeLFont,
                TestLockTypeLSize = result.TestLockTypeLSize,
                TestLockTypeLStyle = result.TestLockTypeLStyle,
                TestLockTypeLWeight = result.TestLockTypeLWeight,
                TestLockTypeLLineHeight = result.TestLockTypeLLineHeight,
                TestLockTypeLColor = result.TestLockTypeLColor,
                TestLockTypeLDecorate = result.TestLockTypeLDecorate,
                TestLockTypeLDetails = result.TestLockTypeLDetails,

                TestLockTypeMFont = result.TestLockTypeMFont,
                TestLockTypeMSize = result.TestLockTypeMSize,
                TestLockTypeMStyle = result.TestLockTypeMStyle,
                TestLockTypeMWeight = result.TestLockTypeMWeight,
                TestLockTypeMLineHeight = result.TestLockTypeMLineHeight,
                TestLockTypeMColor = result.TestLockTypeMColor,
                TestLockTypeMDecorate = result.TestLockTypeMDecorate,
                TestLockTypeMDetails = result.TestLockTypeMDetails,

                TestLockTypeYFont = result.TestLockTypeYFont,
                TestLockTypeYSize = result.TestLockTypeYSize,
                TestLockTypeYStyle = result.TestLockTypeYStyle,
                TestLockTypeYWeight = result.TestLockTypeYWeight,
                TestLockTypeYLineHeight = result.TestLockTypeYLineHeight,
                TestLockTypeYColor = result.TestLockTypeYColor,
                TestLockTypeYDecorate = result.TestLockTypeYDecorate,
                TestLockTypeYDetails = result.TestLockTypeYDetails,

                TestLockTypeSFont = result.TestLockTypeSFont,
                TestLockTypeSSize = result.TestLockTypeSSize,
                TestLockTypeSStyle = result.TestLockTypeSStyle,
                TestLockTypeSWeight = result.TestLockTypeSWeight,
                TestLockTypeSLineHeight = result.TestLockTypeSLineHeight,
                TestLockTypeSColor = result.TestLockTypeSColor,
                TestLockTypeSDecorate = result.TestLockTypeSDecorate,
                TestLockTypeSDetails = result.TestLockTypeSDetails,

                TestLockTypeBFont = result.TestLockTypeBFont,
                TestLockTypeBSize = result.TestLockTypeBSize,
                TestLockTypeBStyle = result.TestLockTypeBStyle,
                TestLockTypeBWeight = result.TestLockTypeBWeight,
                TestLockTypeBLineHeight = result.TestLockTypeBLineHeight,
                TestLockTypeBColor = result.TestLockTypeBColor,
                TestLockTypeBDecorate = result.TestLockTypeBDecorate,
                TestLockTypeBDetails = result.TestLockTypeBDetails,

                TestLockTypeNormalFont = result.TestLockTypeNormalFont,
                TestLockTypeNormalSize = result.TestLockTypeNormalSize,
                TestLockTypeNormalStyle = result.TestLockTypeNormalStyle,
                TestLockTypeNormalWeight = result.TestLockTypeNormalWeight,
                TestLockTypeNormalLineHeight = result.TestLockTypeNormalLineHeight,
                TestLockTypeNormalColor = result.TestLockTypeNormalColor,
                TestLockTypeNormalDecorate = result.TestLockTypeNormalDecorate,
                TestLockTypeNormalDetails = result.TestLockTypeNormalDetails,

                TestLockTypeUnnormalFont = result.TestLockTypeUnnormalFont,
                TestLockTypeUnnormalSize = result.TestLockTypeUnnormalSize,
                TestLockTypeUnnormalStyle = result.TestLockTypeUnnormalStyle,
                TestLockTypeUnnormalWeight = result.TestLockTypeUnnormalWeight,
                TestLockTypeUnnormalLineHeight = result.TestLockTypeUnnormalLineHeight,
                TestLockTypeUnnormalColor = result.TestLockTypeUnnormalColor,
                TestLockTypeUnnormalDecorate = result.TestLockTypeUnnormalDecorate,
                TestLockTypeUnnormalDetails = result.TestLockTypeUnnormalDetails,

                TestLockTypeRangeFont = result.TestLockTypeRangeFont,
                TestLockTypeRangeSize = result.TestLockTypeRangeSize,
                TestLockTypeRangeStyle = result.TestLockTypeRangeStyle,
                TestLockTypeRangeWeight = result.TestLockTypeRangeWeight,
                TestLockTypeRangeLineHeight = result.TestLockTypeRangeLineHeight,
                TestLockTypeRangeColor = result.TestLockTypeRangeColor,
                TestLockTypeRangeDecorate = result.TestLockTypeRangeDecorate,
                TestLockTypeRangeDetails = result.TestLockTypeRangeDetails,
                PrintMedReport = result.PrintMedReport,
                MedReportType = result.MedReportType,
                BarcodeTop = result.BarcodeTop,
                TestHeaderTop = result.TestHeaderTop,
                PatientRefNo = result.PatientRefNo,
                PatientRefNoGroupwise = result.PatientRefNoGroupwise,
                PagePrintLine = result.PagePrintLine,
                OnePrintChart = result.OnePrintChart,
                QRCodePrint = result.QRCodePrint,
                BarCodePrint = result.BarCodePrint,
                TestFormulaApply = result.TestFormulaApply,
                FormulaDecimalPlace = result.FormulaDecimalPlace,
                PrintBillOneTwo = result.PrintBillOneTwo
            };
            _applicationDbContext.Entry(newCate).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newCate.Id;
        }
        public async Task<int> AddNewPageSetup(PageSetupViewModel models)
        {
            PageSetup newCate = new PageSetup()
            {
                CompId = models.CompId,
                LeftA = models.LeftA,
                RightA = models.RightA,
                TopA = models.TopA,
                BottomA = models.BottomA,
                CustomPapersizeA = Convert.ToInt32(models.CustomPapersizeA),
                CustomOrientationA = Convert.ToInt32(models.CustomOrientationA),
                LeftB = models.LeftB,
                RightB = models.RightB,
                TopB = models.TopB,
                BottomB = models.BottomB,
                CustomPapersizeB = Convert.ToInt32(models.CustomPapersizeB),
                CustomOrientationB = Convert.ToInt32(models.CustomOrientationB),
                PageHeaderB = models.PageHeaderB,
                PageFooterB = models.PageFooterB,
                PrintHeaderB = models.PrintHeaderB,
                PrintFooterB = models.PrintFooterB,

                HeaderPhotoPath = models.ExitHeaderPhotoPath,
                HeaderPhotoFile = models.HeaderPhotoFile,
                ReportHeaderPrint = models.ReportHeaderPrint,

                FooterPhotoPath = models.ExitFooterPhotoPath,
                FooterPhotoFile = models.FooterPhotoFile,
                ReportFooterPrintA = models.ReportFooterPrintA,

                ReportFooterB = models.ReportFooterB,
                ReportFooterPrintB = models.ReportFooterPrintB,

                LeftR = models.LeftR,
                RightR = models.RightR,
                TopR = models.TopR,
                BottomR = models.BottomR,
                CustomPapersizeR = Convert.ToInt32(models.CustomPapersizeR),
                CustomOrientationR = Convert.ToInt32(models.CustomOrientationR),
                LeftC = models.LeftC,
                RightC = models.RightC,
                TopC = models.TopC,
                BottomC = models.BottomC,
                CustomPapersizeC = Convert.ToInt32(models.CustomPapersizeC),
                CustomOrientationC = Convert.ToInt32(models.CustomOrientationC),
                HeaderFont = models.HeaderFont,
                HeaderSize = models.HeaderSize,
                HeaderStyle = models.HeaderStyle,
                HeaderWeight = models.HeaderWeight,
                HeaderColor = models.HeaderColor,
                HeaderDecorate = models.HeaderDecorate,
                HeaderDetails = "font-family:" + models.HeaderFont + ";font-size:" + models.HeaderSize + ";font-style:" + models.HeaderStyle + ";font-weight:" + models.HeaderWeight + ";color:" + models.HeaderColor + ";text-decoration:" + models.HeaderDecorate + ";",
                HeaderSecondFont = models.HeaderSecondFont,
                HeaderSecondSize = models.HeaderSecondSize,
                HeaderSecondStyle = models.HeaderSecondStyle,
                HeaderSecondWeight = models.HeaderSecondWeight,
                HeaderSecondColor = models.HeaderSecondColor,
                HeaderSecondDecorate = models.HeaderSecondDecorate,
                HeaderSecondDetails = "font-family:" + models.HeaderSecondFont + ";font-size:" + models.HeaderSecondSize + ";font-style:" + models.HeaderSecondStyle + ";font-weight:" + models.HeaderSecondWeight + ";color:" + models.HeaderSecondColor + ";text-decoration:" + models.HeaderSecondDecorate + ";",
                ReportHeaderFont = models.ReportHeaderFont,
                ReportHeaderSize = models.ReportHeaderSize,
                ReportHeaderStyle = models.ReportHeaderStyle,
                ReportHeaderWeight = models.ReportHeaderWeight,
                ReportHeaderLineHeight = models.ReportHeaderLineHeight,
                ReportHeaderColor = models.ReportHeaderColor,
                ReportHeaderDecorate = models.ReportHeaderDecorate,
                ReportHeaderDetails = "font-family:" + models.ReportHeaderFont + ";font-size:" + models.ReportHeaderSize + ";font-style:" + models.ReportHeaderStyle + ";font-weight:" + models.ReportHeaderWeight + ";line-height:" + models.ReportHeaderLineHeight + ";color:" + models.ReportHeaderColor + ";text-decoration:" + models.ReportHeaderDecorate + ";",
                TestLockTypeNFont = models.TestLockTypeNFont,
                TestLockTypeNSize = models.TestLockTypeNSize,
                TestLockTypeNStyle = models.TestLockTypeNStyle,
                TestLockTypeNWeight = models.TestLockTypeNWeight,
                TestLockTypeNLineHeight = models.TestLockTypeNLineHeight,
                TestLockTypeNColor = models.TestLockTypeNColor,
                TestLockTypeNDecorate = models.TestLockTypeNDecorate,
                TestLockTypeNDetails = "font-family:" + models.TestLockTypeNFont + ";font-size:" + models.TestLockTypeNSize + ";font-style:" + models.TestLockTypeNStyle + ";font-weight:" + models.TestLockTypeNWeight + ";line-height:" + models.TestLockTypeNLineHeight + ";color:" + models.TestLockTypeNColor + ";text-decoration:" + models.TestLockTypeNDecorate + ";",

                TestLockTypeLFont = models.TestLockTypeLFont,
                TestLockTypeLSize = models.TestLockTypeLSize,
                TestLockTypeLStyle = models.TestLockTypeLStyle,
                TestLockTypeLWeight = models.TestLockTypeLWeight,
                TestLockTypeLLineHeight = models.TestLockTypeLLineHeight,
                TestLockTypeLColor = models.TestLockTypeLColor,
                TestLockTypeLDecorate = models.TestLockTypeLDecorate,
                TestLockTypeLDetails = "font-family:" + models.TestLockTypeLFont + ";font-size:" + models.TestLockTypeLSize + ";font-style:" + models.TestLockTypeLStyle + ";font-weight:" + models.TestLockTypeLWeight + ";line-height:" + models.TestLockTypeLLineHeight + ";color:" + models.TestLockTypeLColor + ";text-decoration:" + models.TestLockTypeLDecorate + ";",

                TestLockTypeMFont = models.TestLockTypeMFont,
                TestLockTypeMSize = models.TestLockTypeMSize,
                TestLockTypeMStyle = models.TestLockTypeMStyle,
                TestLockTypeMWeight = models.TestLockTypeMWeight,
                TestLockTypeMLineHeight = models.TestLockTypeMLineHeight,
                TestLockTypeMColor = models.TestLockTypeMColor,
                TestLockTypeMDecorate = models.TestLockTypeMDecorate,
                TestLockTypeMDetails = "font-family:" + models.TestLockTypeMFont + ";font-size:" + models.TestLockTypeMSize + ";font-style:" + models.TestLockTypeMStyle + ";font-weight:" + models.TestLockTypeMWeight + ";line-height:" + models.TestLockTypeMLineHeight + ";color:" + models.TestLockTypeMColor + ";text-decoration:" + models.TestLockTypeMDecorate + ";",

                TestLockTypeYFont = models.TestLockTypeYFont,
                TestLockTypeYSize = models.TestLockTypeYSize,
                TestLockTypeYStyle = models.TestLockTypeYStyle,
                TestLockTypeYWeight = models.TestLockTypeYWeight,
                TestLockTypeYLineHeight = models.TestLockTypeYLineHeight,
                TestLockTypeYColor = models.TestLockTypeYColor,
                TestLockTypeYDecorate = models.TestLockTypeYDecorate,
                TestLockTypeYDetails = "font-family:" + models.TestLockTypeYFont + ";font-size:" + models.TestLockTypeYSize + ";font-style:" + models.TestLockTypeYStyle + ";font-weight:" + models.TestLockTypeYWeight + ";line-height:" + models.TestLockTypeYLineHeight + ";color:" + models.TestLockTypeYColor + ";text-decoration:" + models.TestLockTypeYDecorate + ";",

                TestLockTypeSFont = models.TestLockTypeSFont,
                TestLockTypeSSize = models.TestLockTypeSSize,
                TestLockTypeSStyle = models.TestLockTypeSStyle,
                TestLockTypeSWeight = models.TestLockTypeSWeight,
                TestLockTypeSLineHeight = models.TestLockTypeSLineHeight,
                TestLockTypeSColor = models.TestLockTypeSColor,
                TestLockTypeSDecorate = models.TestLockTypeSDecorate,
                TestLockTypeSDetails = "font-family:" + models.TestLockTypeSFont + ";font-size:" + models.TestLockTypeSSize + ";font-style:" + models.TestLockTypeSStyle + ";font-weight:" + models.TestLockTypeSWeight + ";line-height:" + models.TestLockTypeSLineHeight + ";color:" + models.TestLockTypeSColor + ";text-decoration:" + models.TestLockTypeSDecorate + ";",

                TestLockTypeBFont = models.TestLockTypeBFont,
                TestLockTypeBSize = models.TestLockTypeBSize,
                TestLockTypeBStyle = models.TestLockTypeBStyle,
                TestLockTypeBWeight = models.TestLockTypeBWeight,
                TestLockTypeBLineHeight = models.TestLockTypeBLineHeight,
                TestLockTypeBColor = models.TestLockTypeBColor,
                TestLockTypeBDecorate = models.TestLockTypeBDecorate,
                TestLockTypeBDetails = "font-family:" + models.TestLockTypeBFont + ";font-size:" + models.TestLockTypeBSize + ";font-style:" + models.TestLockTypeBStyle + ";font-weight:" + models.TestLockTypeBWeight + ";line-height:" + models.TestLockTypeBLineHeight + ";color:" + models.TestLockTypeBColor + ";text-decoration:" + models.TestLockTypeBDecorate + ";",

                TestLockTypeNormalFont = models.TestLockTypeNormalFont,
                TestLockTypeNormalSize = models.TestLockTypeNormalSize,
                TestLockTypeNormalStyle = models.TestLockTypeNormalStyle,
                TestLockTypeNormalWeight = models.TestLockTypeNormalWeight,
                TestLockTypeNormalLineHeight = models.TestLockTypeNormalLineHeight,
                TestLockTypeNormalColor = models.TestLockTypeNormalColor,
                TestLockTypeNormalDecorate = models.TestLockTypeNormalDecorate,
                TestLockTypeNormalDetails = "font-family:" + models.TestLockTypeNormalFont + ";font-size:" + models.TestLockTypeNormalSize + ";font-style:" + models.TestLockTypeNormalStyle + ";font-weight:" + models.TestLockTypeNormalWeight + ";line-height:" + models.TestLockTypeNormalLineHeight + ";color:" + models.TestLockTypeNormalColor + ";text-decoration:" + models.TestLockTypeNormalDecorate + ";",

                TestLockTypeUnnormalFont = models.TestLockTypeUnnormalFont,
                TestLockTypeUnnormalSize = models.TestLockTypeUnnormalSize,
                TestLockTypeUnnormalStyle = models.TestLockTypeUnnormalStyle,
                TestLockTypeUnnormalWeight = models.TestLockTypeUnnormalWeight,
                TestLockTypeUnnormalLineHeight = models.TestLockTypeUnnormalLineHeight,
                TestLockTypeUnnormalColor = models.TestLockTypeUnnormalColor,
                TestLockTypeUnnormalDecorate = models.TestLockTypeUnnormalDecorate,
                TestLockTypeUnnormalDetails = "font-family:" + models.TestLockTypeUnnormalFont + ";font-size:" + models.TestLockTypeUnnormalSize + ";font-style:" + models.TestLockTypeUnnormalStyle + ";font-weight:" + models.TestLockTypeUnnormalWeight + ";line-height:" + models.TestLockTypeUnnormalLineHeight + ";color:" + models.TestLockTypeUnnormalColor + ";text-decoration:" + models.TestLockTypeUnnormalDecorate + ";",

                TestLockTypeRangeFont = models.TestLockTypeRangeFont,
                TestLockTypeRangeSize = models.TestLockTypeRangeSize,
                TestLockTypeRangeStyle = models.TestLockTypeRangeStyle,
                TestLockTypeRangeWeight = models.TestLockTypeRangeWeight,
                TestLockTypeRangeLineHeight = models.TestLockTypeRangeLineHeight,
                TestLockTypeRangeColor = models.TestLockTypeRangeColor,
                TestLockTypeRangeDecorate = models.TestLockTypeRangeDecorate,
                TestLockTypeRangeDetails = "font-family:" + models.TestLockTypeRangeFont + ";font-size:" + models.TestLockTypeRangeSize + ";font-style:" + models.TestLockTypeRangeStyle + ";font-weight:" + models.TestLockTypeRangeWeight + ";line-height:" + models.TestLockTypeRangeLineHeight + ";color:" + models.TestLockTypeRangeColor + ";text-decoration:" + models.TestLockTypeRangeDecorate + ";",
                PrintMedReport = models.PrintMedReport,
                MedReportType = models.MedReportType,
                BarcodeTop = models.BarcodeTop,
                TestHeaderTop = models.TestHeaderTop,
                PatientRefNo = models.PatientRefNo,
                PatientRefNoGroupwise = models.PatientRefNoGroupwise,
                PagePrintLine = models.PagePrintLine,
                OnePrintChart = models.OnePrintChart,
                QRCodePrint = models.QRCodePrint,
                BarCodePrint = models.BarCodePrint,
                TestFormulaApply = models.TestFormulaApply,
                FormulaDecimalPlace = models.FormulaDecimalPlace,
                PrintBillOneTwo = models.PrintBillOneTwo
            };
            _applicationDbContext.Entry(newCate).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newCate.Id;
        }
        public async Task<bool> UpdatePageSetup(PageSetupViewModel models)
        {
            var result = await _applicationDbContext.PageSetupTable.FirstOrDefaultAsync(x => x.Id == models.Id && x.CompId == models.CompId);
            if (result != null)
            {
                result.LeftA = models.LeftA;
                result.RightA = models.RightA;
                result.TopA = models.TopA;
                result.BottomA = models.BottomA;
                result.CustomPapersizeA = Convert.ToInt32(models.CustomPapersizeA);
                result.CustomOrientationA = Convert.ToInt32(models.CustomOrientationA);
                result.LeftB = models.LeftB;
                result.RightB = models.RightB;
                result.TopB = models.TopB;
                result.BottomB = models.BottomB;
                result.CustomPapersizeB = Convert.ToInt32(models.CustomPapersizeB);
                result.CustomOrientationB = Convert.ToInt32(models.CustomOrientationB);
                result.PageHeaderB = models.PageHeaderB;
                result.PageFooterB = models.PageFooterB;
                result.CompId = models.CompId;
                result.PrintHeaderB = models.PrintHeaderB;
                result.PrintFooterB = models.PrintFooterB;
                result.HeaderPhotoPath = models.ExitHeaderPhotoPath;
                result.HeaderPhotoFile = models.HeaderPhotoFile;
                result.ReportHeaderPrint = models.ReportHeaderPrint;
                result.FooterPhotoPath = models.ExitFooterPhotoPath;
                result.FooterPhotoFile = models.FooterPhotoFile;                
                result.ReportFooterPrintA = models.ReportFooterPrintA;
                result.ReportFooterB = models.ReportFooterB;
                result.ReportFooterPrintB = models.ReportFooterPrintB;
                result.LeftR = models.LeftR;
                result.RightR = models.RightR;
                result.TopR = models.TopR;
                result.BottomR = models.BottomR;
                result.CustomPapersizeR = Convert.ToInt32(models.CustomPapersizeR);
                result.CustomOrientationR = Convert.ToInt32(models.CustomOrientationR);
                result.LeftC = models.LeftC;
                result.RightC = models.RightC;
                result.TopC = models.TopC;
                result.BottomC = models.BottomC;
                result.CustomPapersizeC = Convert.ToInt32(models.CustomPapersizeC);
                result.CustomOrientationC = Convert.ToInt32(models.CustomOrientationC);
                result.HeaderFont = models.HeaderFont;
                result.HeaderSize = models.HeaderSize;
                result.HeaderStyle = models.HeaderStyle;
                result.HeaderWeight = models.HeaderWeight;
                result.HeaderColor = models.HeaderColor;
                result.HeaderDecorate = models.HeaderDecorate;
                result.HeaderDetails = "font-family:" + models.HeaderFont + ";font-size:" + models.HeaderSize + ";font-style:" + models.HeaderStyle + ";font-weight:" + models.HeaderWeight + ";color:" + models.HeaderColor + ";text-decoration:" + models.HeaderDecorate + ";";
                result.HeaderSecondFont = models.HeaderSecondFont;
                result.HeaderSecondSize = models.HeaderSecondSize;
                result.HeaderSecondStyle = models.HeaderSecondStyle;
                result.HeaderSecondWeight = models.HeaderSecondWeight;
                result.HeaderSecondColor = models.HeaderSecondColor;
                result.HeaderSecondDecorate = models.HeaderSecondDecorate;
                result.HeaderSecondDetails = "font-family:" + models.HeaderSecondFont + ";font-size:" + models.HeaderSecondSize + ";font-style:" + models.HeaderSecondStyle + ";font-weight:" + models.HeaderSecondWeight + ";color:" + models.HeaderSecondColor + ";text-decoration:" + models.HeaderSecondDecorate + ";";
                result.ReportHeaderFont = models.ReportHeaderFont;
                result.ReportHeaderSize = models.ReportHeaderSize;
                result.ReportHeaderStyle = models.ReportHeaderStyle;
                result.ReportHeaderWeight = models.ReportHeaderWeight;
                result.ReportHeaderLineHeight = models.ReportHeaderLineHeight;
                result.ReportHeaderColor = models.ReportHeaderColor;
                result.ReportHeaderDecorate = models.ReportHeaderDecorate;
                result.ReportHeaderDetails = "font-family:" + models.ReportHeaderFont + ";font-size:" + models.ReportHeaderSize + ";font-style:" + models.ReportHeaderStyle + ";font-weight:" + models.ReportHeaderWeight + ";line-height:" + models.ReportHeaderLineHeight + ";color:" + models.ReportHeaderColor + ";text-decoration:" + models.ReportHeaderDecorate + ";";
                result.TestLockTypeNFont = models.TestLockTypeNFont;
                result.TestLockTypeNSize = models.TestLockTypeNSize;
                result.TestLockTypeNStyle = models.TestLockTypeNStyle;
                result.TestLockTypeNWeight = models.TestLockTypeNWeight;
                result.TestLockTypeNLineHeight = models.TestLockTypeNLineHeight;
                result.TestLockTypeNColor = models.TestLockTypeNColor;
                result.TestLockTypeNDecorate = models.TestLockTypeNDecorate;
                result.TestLockTypeNDetails = "font-family:" + models.TestLockTypeNFont + ";font-size:" + models.TestLockTypeNSize + ";font-style:" + models.TestLockTypeNStyle + ";font-weight:" + models.TestLockTypeNWeight + ";line-height:" + models.TestLockTypeNLineHeight + ";color:" + models.TestLockTypeNColor + ";text-decoration:" + models.TestLockTypeNDecorate + ";";
                result.TestLockTypeLFont = models.TestLockTypeLFont;
                result.TestLockTypeLSize = models.TestLockTypeLSize;
                result.TestLockTypeLStyle = models.TestLockTypeLStyle;
                result.TestLockTypeLWeight = models.TestLockTypeLWeight;
                result.TestLockTypeLLineHeight = models.TestLockTypeLLineHeight;
                result.TestLockTypeLColor = models.TestLockTypeLColor;
                result.TestLockTypeLDecorate = models.TestLockTypeLDecorate;
                result.TestLockTypeLDetails = "font-family:" + models.TestLockTypeLFont + ";font-size:" + models.TestLockTypeLSize + ";font-style:" + models.TestLockTypeLStyle + ";font-weight:" + models.TestLockTypeLWeight + ";line-height:" + models.TestLockTypeLLineHeight + ";color:" + models.TestLockTypeLColor + ";text-decoration:" + models.TestLockTypeLDecorate + ";";
                result.TestLockTypeMFont = models.TestLockTypeMFont;
                result.TestLockTypeMSize = models.TestLockTypeMSize;
                result.TestLockTypeMStyle = models.TestLockTypeMStyle;
                result.TestLockTypeMWeight = models.TestLockTypeMWeight;
                result.TestLockTypeMLineHeight = models.TestLockTypeMLineHeight;
                result.TestLockTypeMColor = models.TestLockTypeMColor;
                result.TestLockTypeMDecorate = models.TestLockTypeMDecorate;
                result.TestLockTypeMDetails = "font-family:" + models.TestLockTypeMFont + ";font-size:" + models.TestLockTypeMSize + ";font-style:" + models.TestLockTypeMStyle + ";font-weight:" + models.TestLockTypeMWeight + ";line-height:" + models.TestLockTypeMLineHeight + ";color:" + models.TestLockTypeMColor + ";text-decoration:" + models.TestLockTypeMDecorate + ";";
                result.TestLockTypeYFont = models.TestLockTypeYFont;
                result.TestLockTypeYSize = models.TestLockTypeYSize;
                result.TestLockTypeYStyle = models.TestLockTypeYStyle;
                result.TestLockTypeYWeight = models.TestLockTypeYWeight;
                result.TestLockTypeYLineHeight = models.TestLockTypeYLineHeight;
                result.TestLockTypeYColor = models.TestLockTypeYColor;
                result.TestLockTypeYDecorate = models.TestLockTypeYDecorate;
                result.TestLockTypeYDetails = "font-family:" + models.TestLockTypeYFont + ";font-size:" + models.TestLockTypeYSize + ";font-style:" + models.TestLockTypeYStyle + ";font-weight:" + models.TestLockTypeYWeight + ";line-height:" + models.TestLockTypeYLineHeight + ";color:" + models.TestLockTypeYColor + ";text-decoration:" + models.TestLockTypeYDecorate + ";";
                result.TestLockTypeSFont = models.TestLockTypeSFont;
                result.TestLockTypeSSize = models.TestLockTypeSSize;
                result.TestLockTypeSStyle = models.TestLockTypeSStyle;
                result.TestLockTypeSWeight = models.TestLockTypeSWeight;
                result.TestLockTypeSLineHeight = models.TestLockTypeSLineHeight;
                result.TestLockTypeSColor = models.TestLockTypeSColor;
                result.TestLockTypeSDecorate = models.TestLockTypeSDecorate;
                result.TestLockTypeSDetails = "font-family:" + models.TestLockTypeSFont + ";font-size:" + models.TestLockTypeSSize + ";font-style:" + models.TestLockTypeSStyle + ";font-weight:" + models.TestLockTypeSWeight + ";line-height:" + models.TestLockTypeSLineHeight + ";color:" + models.TestLockTypeSColor + ";text-decoration:" + models.TestLockTypeSDecorate + ";";
                result.TestLockTypeBFont = models.TestLockTypeBFont;
                result.TestLockTypeBSize = models.TestLockTypeBSize;
                result.TestLockTypeBStyle = models.TestLockTypeBStyle;
                result.TestLockTypeBWeight = models.TestLockTypeBWeight;
                result.TestLockTypeBLineHeight = models.TestLockTypeBLineHeight;
                result.TestLockTypeBColor = models.TestLockTypeBColor;
                result.TestLockTypeBDecorate = models.TestLockTypeBDecorate;
                result.TestLockTypeBDetails = "font-family:" + models.TestLockTypeBFont + ";font-size:" + models.TestLockTypeBSize + ";font-style:" + models.TestLockTypeBStyle + ";font-weight:" + models.TestLockTypeBWeight + ";line-height:" + models.TestLockTypeBLineHeight + ";color:" + models.TestLockTypeBColor + ";text-decoration:" + models.TestLockTypeBDecorate + ";";
                result.TestLockTypeNormalFont = models.TestLockTypeNormalFont;
                result.TestLockTypeNormalSize = models.TestLockTypeNormalSize;
                result.TestLockTypeNormalStyle = models.TestLockTypeNormalStyle;
                result.TestLockTypeNormalWeight = models.TestLockTypeNormalWeight;
                result.TestLockTypeNormalLineHeight = models.TestLockTypeNormalLineHeight;
                result.TestLockTypeNormalColor = models.TestLockTypeNormalColor;
                result.TestLockTypeNormalDecorate = models.TestLockTypeNormalDecorate;
                result.TestLockTypeNormalDetails = "font-family:" + models.TestLockTypeNormalFont + ";font-size:" + models.TestLockTypeNormalSize + ";font-style:" + models.TestLockTypeNormalStyle + ";font-weight:" + models.TestLockTypeNormalWeight + ";line-height:" + models.TestLockTypeNormalLineHeight + ";color:" + models.TestLockTypeNormalColor + ";text-decoration:" + models.TestLockTypeNormalDecorate + ";";
                result.TestLockTypeUnnormalFont = models.TestLockTypeUnnormalFont;
                result.TestLockTypeUnnormalSize = models.TestLockTypeUnnormalSize;
                result.TestLockTypeUnnormalStyle = models.TestLockTypeUnnormalStyle;
                result.TestLockTypeUnnormalWeight = models.TestLockTypeUnnormalWeight;
                result.TestLockTypeUnnormalLineHeight = models.TestLockTypeUnnormalLineHeight;
                result.TestLockTypeUnnormalColor = models.TestLockTypeUnnormalColor;
                result.TestLockTypeUnnormalDecorate = models.TestLockTypeUnnormalDecorate;
                result.TestLockTypeUnnormalDetails = "font-family:" + models.TestLockTypeUnnormalFont + ";font-size:" + models.TestLockTypeUnnormalSize + ";font-style:" + models.TestLockTypeUnnormalStyle + ";font-weight:" + models.TestLockTypeUnnormalWeight + ";line-height:" + models.TestLockTypeUnnormalLineHeight + ";color:" + models.TestLockTypeUnnormalColor + ";text-decoration:" + models.TestLockTypeUnnormalDecorate + ";";
                result.TestLockTypeRangeFont = models.TestLockTypeRangeFont;
                result.TestLockTypeRangeSize = models.TestLockTypeRangeSize;
                result.TestLockTypeRangeStyle = models.TestLockTypeRangeStyle;
                result.TestLockTypeRangeWeight = models.TestLockTypeRangeWeight;
                result.TestLockTypeRangeLineHeight = models.TestLockTypeRangeLineHeight;
                result.TestLockTypeRangeColor = models.TestLockTypeRangeColor;
                result.TestLockTypeRangeDecorate = models.TestLockTypeRangeDecorate;
                result.TestLockTypeRangeDetails = "font-family:" + models.TestLockTypeRangeFont + ";font-size:" + models.TestLockTypeRangeSize + ";font-style:" + models.TestLockTypeRangeStyle + ";font-weight:" + models.TestLockTypeRangeWeight + ";line-height:" + models.TestLockTypeRangeLineHeight + ";color:" + models.TestLockTypeRangeColor + ";text-decoration:" + models.TestLockTypeRangeDecorate + ";";
                result.PrintMedReport = models.PrintMedReport;
                result.MedReportType = models.MedReportType;
                result.BarcodeTop = models.BarcodeTop;
                result.TestHeaderTop = models.TestHeaderTop;
                result.PatientRefNo = models.PatientRefNo;
                result.PatientRefNoGroupwise = models.PatientRefNoGroupwise;
                result.PagePrintLine = models.PagePrintLine;
                result.OnePrintChart = models.OnePrintChart;
                result.QRCodePrint = models.QRCodePrint;
                result.BarCodePrint = models.BarCodePrint;
                result.TestFormulaApply = models.TestFormulaApply;
                result.FormulaDecimalPlace = models.FormulaDecimalPlace;
                result.PrintBillOneTwo = models.PrintBillOneTwo;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<bool> UpdatePageSetupByComp(int compid,bool truefalse)
        {
            var result = await _applicationDbContext.PageSetupTable.FirstOrDefaultAsync(x => x.CompId == compid);
            if (result != null)
            {               
                result.ReportFooterPrintA = truefalse;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<PageSetupViewModel> GetPageSetupById(int id)
        {
            var result = await _applicationDbContext.PageSetupTable.Select(x => new PageSetupViewModel()
            {
                Id = x.Id,
                LeftA = x.LeftA,
                RightA = x.RightA,
                TopA = x.TopA,
                BottomA = x.BottomA,
                CustomPapersizeA = (CustomPapersize)x.CustomPapersizeA,
                CustomOrientationA = (CustomOrientation)x.CustomOrientationA,
                LeftB = x.LeftB,
                RightB = x.RightB,
                TopB = x.TopB,
                BottomB = x.BottomB,
                CustomPapersizeB = (CustomPapersize)x.CustomPapersizeB,
                CustomOrientationB = (CustomOrientation)x.CustomOrientationB,
                PageHeaderB = x.PageHeaderB,
                PageFooterB = x.PageFooterB,
                CompId = x.CompId,
                PrintHeaderB = x.PrintHeaderB,
                PrintFooterB = x.PrintFooterB,

                ExitHeaderPhotoPath = x.HeaderPhotoPath,
                HeaderPhotoFile = x.HeaderPhotoFile,
                ReportHeaderPrint = x.ReportHeaderPrint,
                
                ExitFooterPhotoPath = x.FooterPhotoPath,
                FooterPhotoFile = x.FooterPhotoFile,
                ReportFooterPrintA = x.ReportFooterPrintA,
                
                ReportFooterB = x.ReportFooterB,
                ReportFooterPrintB = x.ReportFooterPrintB,
                LeftR = x.LeftR,
                RightR = x.RightR,
                TopR = x.TopR,
                BottomR = x.BottomR,
                CustomPapersizeR = (CustomPapersize)x.CustomPapersizeR,
                CustomOrientationR = (CustomOrientation)x.CustomOrientationR,
                LeftC = x.LeftC,
                RightC = x.RightC,
                TopC = x.TopC,
                BottomC = x.BottomC,
                CustomPapersizeC = (CustomPapersize)x.CustomPapersizeC,
                CustomOrientationC = (CustomOrientation)x.CustomOrientationC,
                HeaderFont = x.HeaderFont,
                HeaderSize = x.HeaderSize,
                HeaderStyle = x.HeaderStyle,
                HeaderWeight = x.HeaderWeight,
                HeaderColor = x.HeaderColor,
                HeaderDecorate = x.HeaderDecorate,
                HeaderDetails = x.HeaderDetails,
                HeaderSecondFont = x.HeaderSecondFont,
                HeaderSecondSize = x.HeaderSecondSize,
                HeaderSecondStyle = x.HeaderSecondStyle,
                HeaderSecondWeight = x.HeaderSecondWeight,
                HeaderSecondColor = x.HeaderSecondColor,
                HeaderSecondDecorate = x.HeaderSecondDecorate,
                HeaderSecondDetails = x.HeaderSecondDetails,
                ReportHeaderFont = x.ReportHeaderFont,
                ReportHeaderSize = x.ReportHeaderSize,
                ReportHeaderStyle = x.ReportHeaderStyle,
                ReportHeaderWeight = x.ReportHeaderWeight,
                ReportHeaderLineHeight = x.ReportHeaderLineHeight,
                ReportHeaderColor = x.ReportHeaderColor,
                ReportHeaderDecorate = x.ReportHeaderDecorate,
                ReportHeaderDetails = x.ReportHeaderDetails,
                TestLockTypeNFont = x.TestLockTypeNFont,
                TestLockTypeNSize = x.TestLockTypeNSize,
                TestLockTypeNStyle = x.TestLockTypeNStyle,
                TestLockTypeNWeight = x.TestLockTypeNWeight,
                TestLockTypeNLineHeight = x.TestLockTypeNLineHeight,
                TestLockTypeNColor = x.TestLockTypeNColor,
                TestLockTypeNDecorate = x.TestLockTypeNDecorate,
                TestLockTypeNDetails = x.TestLockTypeNDetails,

                TestLockTypeLFont = x.TestLockTypeLFont,
                TestLockTypeLSize = x.TestLockTypeLSize,
                TestLockTypeLStyle = x.TestLockTypeLStyle,
                TestLockTypeLWeight = x.TestLockTypeLWeight,
                TestLockTypeLLineHeight = x.TestLockTypeLLineHeight,
                TestLockTypeLColor = x.TestLockTypeLColor,
                TestLockTypeLDecorate = x.TestLockTypeLDecorate,
                TestLockTypeLDetails = x.TestLockTypeLDetails,

                TestLockTypeMFont = x.TestLockTypeMFont,
                TestLockTypeMSize = x.TestLockTypeMSize,
                TestLockTypeMStyle = x.TestLockTypeMStyle,
                TestLockTypeMWeight = x.TestLockTypeMWeight,
                TestLockTypeMLineHeight = x.TestLockTypeMLineHeight,
                TestLockTypeMColor = x.TestLockTypeMColor,
                TestLockTypeMDecorate = x.TestLockTypeMDecorate,
                TestLockTypeMDetails = x.TestLockTypeMDetails,

                TestLockTypeYFont = x.TestLockTypeYFont,
                TestLockTypeYSize = x.TestLockTypeYSize,
                TestLockTypeYStyle = x.TestLockTypeYStyle,
                TestLockTypeYWeight = x.TestLockTypeYWeight,
                TestLockTypeYLineHeight = x.TestLockTypeYLineHeight,
                TestLockTypeYColor = x.TestLockTypeYColor,
                TestLockTypeYDecorate = x.TestLockTypeYDecorate,
                TestLockTypeYDetails = x.TestLockTypeYDetails,

                TestLockTypeSFont = x.TestLockTypeSFont,
                TestLockTypeSSize = x.TestLockTypeSSize,
                TestLockTypeSStyle = x.TestLockTypeSStyle,
                TestLockTypeSWeight = x.TestLockTypeSWeight,
                TestLockTypeSLineHeight = x.TestLockTypeSLineHeight,
                TestLockTypeSColor = x.TestLockTypeSColor,
                TestLockTypeSDecorate = x.TestLockTypeSDecorate,
                TestLockTypeSDetails = x.TestLockTypeSDetails,

                TestLockTypeBFont = x.TestLockTypeBFont,
                TestLockTypeBSize = x.TestLockTypeBSize,
                TestLockTypeBStyle = x.TestLockTypeBStyle,
                TestLockTypeBWeight = x.TestLockTypeBWeight,
                TestLockTypeBLineHeight = x.TestLockTypeBLineHeight,
                TestLockTypeBColor = x.TestLockTypeBColor,
                TestLockTypeBDecorate = x.TestLockTypeBDecorate,
                TestLockTypeBDetails = x.TestLockTypeBDetails,

                TestLockTypeNormalFont = x.TestLockTypeNormalFont,
                TestLockTypeNormalSize = x.TestLockTypeNormalSize,
                TestLockTypeNormalStyle = x.TestLockTypeNormalStyle,
                TestLockTypeNormalWeight = x.TestLockTypeNormalWeight,
                TestLockTypeNormalLineHeight = x.TestLockTypeNormalLineHeight,
                TestLockTypeNormalColor = x.TestLockTypeNormalColor,
                TestLockTypeNormalDecorate = x.TestLockTypeNormalDecorate,
                TestLockTypeNormalDetails = x.TestLockTypeNormalDetails,

                TestLockTypeUnnormalFont = x.TestLockTypeUnnormalFont,
                TestLockTypeUnnormalSize = x.TestLockTypeUnnormalSize,
                TestLockTypeUnnormalStyle = x.TestLockTypeUnnormalStyle,
                TestLockTypeUnnormalWeight = x.TestLockTypeUnnormalWeight,
                TestLockTypeUnnormalLineHeight = x.TestLockTypeUnnormalLineHeight,
                TestLockTypeUnnormalColor = x.TestLockTypeUnnormalColor,
                TestLockTypeUnnormalDecorate = x.TestLockTypeUnnormalDecorate,
                TestLockTypeUnnormalDetails = x.TestLockTypeUnnormalDetails,

                TestLockTypeRangeFont = x.TestLockTypeRangeFont,
                TestLockTypeRangeSize = x.TestLockTypeRangeSize,
                TestLockTypeRangeStyle = x.TestLockTypeRangeStyle,
                TestLockTypeRangeWeight = x.TestLockTypeRangeWeight,
                TestLockTypeRangeLineHeight = x.TestLockTypeRangeLineHeight,
                TestLockTypeRangeColor = x.TestLockTypeRangeColor,
                TestLockTypeRangeDecorate = x.TestLockTypeRangeDecorate,
                TestLockTypeRangeDetails =  x.TestLockTypeRangeDetails,
                PrintMedReport = x.PrintMedReport,
                MedReportType = x.MedReportType,
                BarcodeTop = x.BarcodeTop,
                TestHeaderTop = x.TestHeaderTop,
                PatientRefNo = x.PatientRefNo,
                PatientRefNoGroupwise = x.PatientRefNoGroupwise,
                PagePrintLine = x.PagePrintLine,
                OnePrintChart = x.OnePrintChart,
                QRCodePrint = x.QRCodePrint,
                BarCodePrint = x.BarCodePrint,
                TestFormulaApply = x.TestFormulaApply,
                FormulaDecimalPlace = x.FormulaDecimalPlace,
                PrintBillOneTwo = x.PrintBillOneTwo
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<PageSetupViewModel> GetPageSetuppPrintComp(int cmpid)
        {
            var result = await _applicationDbContext.PageSetupTable.Select(x => new PageSetupViewModel()
            {
                Id = x.Id,                
                LeftA = x.LeftA,
                RightA = x.RightA,
                TopA = x.TopA,
                BottomA = x.BottomA,
                CustomPapersizeA = (CustomPapersize)x.CustomPapersizeA,
                CustomOrientationA = (CustomOrientation)x.CustomOrientationA,
                LeftB = x.LeftB,
                RightB = x.RightB,
                TopB = x.TopB,
                BottomB = x.BottomB,
                CustomPapersizeB = (CustomPapersize)x.CustomPapersizeB,
                CustomOrientationB = (CustomOrientation)x.CustomOrientationB,
                PageHeaderB = x.PageHeaderB,
                PageFooterB = x.PageFooterB,
                CompId = x.CompId,
                PrintHeaderB = x.PrintHeaderB,
                PrintFooterB = x.PrintFooterB,
                ExitHeaderPhotoPath = x.HeaderPhotoPath,
                HeaderPhotoFile = x.HeaderPhotoFile,
                ReportHeaderPrint = x.ReportHeaderPrint,
                ExitFooterPhotoPath = x.FooterPhotoPath,
                FooterPhotoFile = x.FooterPhotoFile,
                ReportFooterPrintA = x.ReportFooterPrintA,
                ReportFooterB = x.ReportFooterB,
                ReportFooterPrintB = x.ReportFooterPrintB,
                LeftR = x.LeftR,
                RightR = x.RightR,
                TopR = x.TopR,
                BottomR = x.BottomR,
                CustomPapersizeR = (CustomPapersize)x.CustomPapersizeR,
                CustomOrientationR = (CustomOrientation)x.CustomOrientationR,
                LeftC = x.LeftC,
                RightC = x.RightC,
                TopC = x.TopC,
                BottomC = x.BottomC,
                CustomPapersizeC = (CustomPapersize)x.CustomPapersizeC,
                CustomOrientationC = (CustomOrientation)x.CustomOrientationC,
                HeaderFont = x.HeaderFont,
                HeaderSize = x.HeaderSize,
                HeaderStyle = x.HeaderStyle,
                HeaderWeight = x.HeaderWeight,
                HeaderColor = x.HeaderColor,
                HeaderDecorate = x.HeaderDecorate,
                HeaderDetails = x.HeaderDetails,
                HeaderSecondFont = x.HeaderSecondFont,
                HeaderSecondSize = x.HeaderSecondSize,
                HeaderSecondStyle = x.HeaderSecondStyle,
                HeaderSecondWeight = x.HeaderSecondWeight,
                HeaderSecondColor = x.HeaderSecondColor,
                HeaderSecondDecorate = x.HeaderSecondDecorate,
                HeaderSecondDetails = x.HeaderSecondDetails,
                ReportHeaderFont = x.ReportHeaderFont,
                ReportHeaderSize = x.ReportHeaderSize,
                ReportHeaderStyle = x.ReportHeaderStyle,
                ReportHeaderWeight = x.ReportHeaderWeight,
                ReportHeaderLineHeight = x.ReportHeaderLineHeight,
                ReportHeaderColor = x.ReportHeaderColor,
                ReportHeaderDecorate = x.ReportHeaderDecorate,
                ReportHeaderDetails = x.ReportHeaderDetails,
                TestLockTypeNFont = x.TestLockTypeNFont,
                TestLockTypeNSize = x.TestLockTypeNSize,
                TestLockTypeNStyle = x.TestLockTypeNStyle,
                TestLockTypeNWeight = x.TestLockTypeNWeight,
                TestLockTypeNLineHeight = x.TestLockTypeNLineHeight,
                TestLockTypeNColor = x.TestLockTypeNColor,
                TestLockTypeNDecorate = x.TestLockTypeNDecorate,
                TestLockTypeNDetails = x.TestLockTypeNDetails,

                TestLockTypeLFont = x.TestLockTypeLFont,
                TestLockTypeLSize = x.TestLockTypeLSize,
                TestLockTypeLStyle = x.TestLockTypeLStyle,
                TestLockTypeLWeight = x.TestLockTypeLWeight,
                TestLockTypeLLineHeight = x.TestLockTypeLLineHeight,
                TestLockTypeLColor = x.TestLockTypeLColor,
                TestLockTypeLDecorate = x.TestLockTypeLDecorate,
                TestLockTypeLDetails = x.TestLockTypeLDetails,

                TestLockTypeMFont = x.TestLockTypeMFont,
                TestLockTypeMSize = x.TestLockTypeMSize,
                TestLockTypeMStyle = x.TestLockTypeMStyle,
                TestLockTypeMWeight = x.TestLockTypeMWeight,
                TestLockTypeMLineHeight = x.TestLockTypeMLineHeight,
                TestLockTypeMColor = x.TestLockTypeMColor,
                TestLockTypeMDecorate = x.TestLockTypeMDecorate,
                TestLockTypeMDetails = x.TestLockTypeMDetails,

                TestLockTypeYFont = x.TestLockTypeYFont,
                TestLockTypeYSize = x.TestLockTypeYSize,
                TestLockTypeYStyle = x.TestLockTypeYStyle,
                TestLockTypeYWeight = x.TestLockTypeYWeight,
                TestLockTypeYLineHeight = x.TestLockTypeYLineHeight,
                TestLockTypeYColor = x.TestLockTypeYColor,
                TestLockTypeYDecorate = x.TestLockTypeYDecorate,
                TestLockTypeYDetails = x.TestLockTypeYDetails,

                TestLockTypeSFont = x.TestLockTypeSFont,
                TestLockTypeSSize = x.TestLockTypeSSize,
                TestLockTypeSStyle = x.TestLockTypeSStyle,
                TestLockTypeSWeight = x.TestLockTypeSWeight,
                TestLockTypeSLineHeight = x.TestLockTypeSLineHeight,
                TestLockTypeSColor = x.TestLockTypeSColor,
                TestLockTypeSDecorate = x.TestLockTypeSDecorate,
                TestLockTypeSDetails = x.TestLockTypeSDetails,

                TestLockTypeBFont = x.TestLockTypeBFont,
                TestLockTypeBSize = x.TestLockTypeBSize,
                TestLockTypeBStyle = x.TestLockTypeBStyle,
                TestLockTypeBWeight = x.TestLockTypeBWeight,
                TestLockTypeBLineHeight = x.TestLockTypeBLineHeight,
                TestLockTypeBColor = x.TestLockTypeBColor,
                TestLockTypeBDecorate = x.TestLockTypeBDecorate,
                TestLockTypeBDetails = x.TestLockTypeBDetails,

                TestLockTypeNormalFont = x.TestLockTypeNormalFont,
                TestLockTypeNormalSize = x.TestLockTypeNormalSize,
                TestLockTypeNormalStyle = x.TestLockTypeNormalStyle,
                TestLockTypeNormalWeight = x.TestLockTypeNormalWeight,
                TestLockTypeNormalLineHeight = x.TestLockTypeNormalLineHeight,
                TestLockTypeNormalColor = x.TestLockTypeNormalColor,
                TestLockTypeNormalDecorate = x.TestLockTypeNormalDecorate,
                TestLockTypeNormalDetails = x.TestLockTypeNormalDetails,

                TestLockTypeUnnormalFont = x.TestLockTypeUnnormalFont,
                TestLockTypeUnnormalSize = x.TestLockTypeUnnormalSize,
                TestLockTypeUnnormalStyle = x.TestLockTypeUnnormalStyle,
                TestLockTypeUnnormalWeight = x.TestLockTypeUnnormalWeight,
                TestLockTypeUnnormalLineHeight = x.TestLockTypeUnnormalLineHeight,
                TestLockTypeUnnormalColor = x.TestLockTypeUnnormalColor,
                TestLockTypeUnnormalDecorate = x.TestLockTypeUnnormalDecorate,
                TestLockTypeUnnormalDetails = x.TestLockTypeUnnormalDetails,

                TestLockTypeRangeFont = x.TestLockTypeRangeFont,
                TestLockTypeRangeSize = x.TestLockTypeRangeSize,
                TestLockTypeRangeStyle = x.TestLockTypeRangeStyle,
                TestLockTypeRangeWeight = x.TestLockTypeRangeWeight,
                TestLockTypeRangeLineHeight = x.TestLockTypeRangeLineHeight,
                TestLockTypeRangeColor = x.TestLockTypeRangeColor,
                TestLockTypeRangeDecorate = x.TestLockTypeRangeDecorate,
                TestLockTypeRangeDetails = x.TestLockTypeRangeDetails,
                PrintMedReport = x.PrintMedReport,
                MedReportType = x.MedReportType,
                BarcodeTop = x.BarcodeTop,
                TestHeaderTop = x.TestHeaderTop,
                PatientRefNo = x.PatientRefNo,
                PatientRefNoGroupwise = x.PatientRefNoGroupwise,
                PagePrintLine = x.PagePrintLine,
                OnePrintChart = x.OnePrintChart,
                QRCodePrint = x.QRCodePrint,
                BarCodePrint = x.BarCodePrint,
                TestFormulaApply = x.TestFormulaApply,
                FormulaDecimalPlace = x.FormulaDecimalPlace,
                PrintBillOneTwo = x.PrintBillOneTwo
            }).FirstOrDefaultAsync(x => x.CompId == cmpid);
            return result;
        }
        public async Task<int> GetPageSetupByCompId(int compId)
        {
            var result = await _applicationDbContext.PageSetupTable.Select(x => new { x.Id, x.CompId }).FirstOrDefaultAsync(x => x.CompId == compId);
            return Convert.ToInt32(result != null ? result.Id : 0);
        }
        public async Task<List<PageSetupViewModel>> GetAllPageSetup(int cmpid)
        {
            var result = await _applicationDbContext.PageSetupTable
                .Where(x => cmpid > 0 ? x.CompId == cmpid : true)
                .Select(x => new PageSetupViewModel()
                {
                    Id = x.Id,
                    PageSetupCompanyDetailsViews = new CompanyDetailViewModel()
                    {
                        TransCode = x.PageSetupCompanyDetails.TransCode,
                        NameAddress = x.PageSetupCompanyDetails.CompName + " " + x.PageSetupCompanyDetails.Address1 + " " + x.PageSetupCompanyDetails.EmailAddress
                    },
                    LeftA = x.LeftA,
                    RightA = x.RightA,
                    TopA = x.TopA,
                    BottomA = x.BottomA,
                    CustomPapersizeA = (CustomPapersize)x.CustomPapersizeA,
                    CustomOrientationA = (CustomOrientation)x.CustomOrientationA,
                    LeftB = x.LeftB,
                    RightB = x.RightB,
                    TopB = x.TopB,
                    BottomB = x.BottomB,
                    CustomPapersizeB = (CustomPapersize)x.CustomPapersizeB,
                    CustomOrientationB = (CustomOrientation)x.CustomOrientationB,
                    PageHeaderB = x.PageHeaderB,
                    PageFooterB = x.PageFooterB,
                    CompId = x.CompId,
                    PrintHeaderB = x.PrintHeaderB,
                    PrintFooterB = x.PrintFooterB,
                    
                    ReportHeaderPrint = x.ReportHeaderPrint,
                    
                    ReportFooterPrintA = x.ReportFooterPrintA,
                    ReportFooterB = x.ReportFooterB,
                    ReportFooterPrintB = x.ReportFooterPrintB,
                    LeftR = x.LeftR,
                    RightR = x.RightR,
                    TopR = x.TopR,
                    BottomR = x.BottomR,
                    CustomPapersizeR = (CustomPapersize)x.CustomPapersizeR,
                    CustomOrientationR = (CustomOrientation)x.CustomOrientationR,
                    LeftC = x.LeftC,
                    RightC = x.RightC,
                    TopC = x.TopC,
                    BottomC = x.BottomC,
                    CustomPapersizeC = (CustomPapersize)x.CustomPapersizeC,
                    CustomOrientationC = (CustomOrientation)x.CustomOrientationC
                }).ToListAsync();
            return result;
        }

        // Agent File
        public async Task<string> AgentSrNoCreation(int cmpid)
        {
            var NewNo = ""; var NewValue = 0; var splitChar = "";
            var result1 = await _applicationDbContext.CompanyDetailTable.Where(x =>  x.Id == cmpid).Select(x => new { x.TransCode }).FirstOrDefaultAsync();
            splitChar = result1.TransCode.Substring(3, 9) + "ANT";
            string[] myzero = { "00", "0" };
            var result = await _applicationDbContext.AgentFileTable
                          .OrderByDescending(x => x.Id)
                          .Where(x => x.CompIdA == cmpid)
                          .Select(x => new { x.Code }).FirstOrDefaultAsync();

            if (result != null)
            {
                string parts1 = result.Code.Substring(12, 3);
                NewValue = Convert.ToInt32(parts1) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 3 ? splitChar + myzero[CurrentIndex] + (NewValue) : splitChar + NewValue.ToString();
            }
            else
            {
                NewNo = splitChar + "001";
            }

            return NewNo;
        }
        public async Task<int> AddNewAgent(AgentFileViewModel models)
        {
            AgentFile newAgent = new AgentFile()
            {
                CompIdA = models.CompIdA,
                Code = models.Code,
                Name = models.Name,
                Address1 = models.Address1,
                City = models.City,
                PinNo = models.PinNo,
                MobileNo = models.MobileNo,
                EmailAddress = models.EmailAddress,
                BankName = models.BankName,
                BankAcNo = models.BankAcNo,
                IFSC = models.IFSC,
                EPFAcNo = models.EPFAcNo,
                BasicPay = models.BasicPay,
                TA = models.TA,
                DA = models.DA,
                HRA = models.HRA,
                CCA = models.CCA,
                ActiveType = models.ActiveType,
                IPAmt1 = models.IPAmt1
            };
            _applicationDbContext.Entry(newAgent).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newAgent.Id;
        }
        public async Task<bool> UpdateAgent(AgentFileViewModel models)
        {
            var result = await _applicationDbContext.AgentFileTable.Where(x => x.Code == models.Code && x.CompIdA == models.CompIdA).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Id = models.Id; result.Code = models.Code; result.CompIdA = models.CompIdA;
                result.Name = models.Name; result.Address1 = models.Address1;
                result.City = models.City; result.PinNo = models.PinNo;
                result.MobileNo = models.MobileNo; result.EmailAddress = models.EmailAddress;
                result.BankName = models.BankName; result.BankAcNo = models.BankAcNo; result.IFSC = models.IFSC;
                result.EPFAcNo = models.EPFAcNo; result.BasicPay = models.BasicPay; result.TA = models.TA;
                result.DA = models.DA; result.HRA = models.HRA; result.CCA = models.CCA;
                result.ActiveType = models.ActiveType;
                result.IPAmt1 = models.IPAmt1;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<AgentFileViewModel>> GetAllAgent(int cmpid)
        {
            var result = await _applicationDbContext.AgentFileTable
                .Where(x => x.CompIdA == cmpid)
                .Select(x => new AgentFileViewModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    NameAddress = x.Name + " " + x.Address1,
                    Name = x.Name,
                    Address1 = x.Address1,
                    City = x.City,
                    PinNo = x.PinNo,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    BankName = x.BankName,
                    BankAcNo = x.BankAcNo,
                    IFSC = x.IFSC,
                    EPFAcNo = x.EPFAcNo,
                    BasicPay = x.BasicPay,
                    TA = x.TA,
                    DA = x.DA,
                    HRA = x.HRA,
                    CCA = x.CCA,
                    ActiveType = x.ActiveType,
                    IPAmt1 = x.IPAmt1,
                    CompIdA = x.CompIdA,
                    AgnetCompanyDetailsViews = new CompanyDetailViewModel()
                    {
                        CompName = x.AgentCompanyDetails.CompName
                    }
                }).ToListAsync();
            return result;
        }
        public async Task<List<AgentFileViewModel>> GetAllAgentBranchWise(int cmpid, string name, string mobileno, string cityx)
        {
            var result = await _applicationDbContext.AgentFileTable
                .OrderBy(x => x.Name)
                .Where(x => x.CompIdA == cmpid
                && ((name != null) ? x.Name.Contains(name) : true)
                && ((mobileno != null) ? x.MobileNo.Contains(mobileno) : true)
                && ((cityx != null) ? x.City.Contains(cityx) : true))
                .Select(x => new AgentFileViewModel()
                {
                    Id = x.Id,
                    CompIdA = x.CompIdA,
                    Code = x.Code,
                    NameAddress = x.Name + " " + x.Address1,
                    Name = x.Name,
                    Address1 = x.Address1,
                    City = x.City,
                    PinNo = x.PinNo,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    BankName = x.BankName,
                    BankAcNo = x.BankAcNo,
                    IFSC = x.IFSC,
                    EPFAcNo = x.EPFAcNo,
                    BasicPay = x.BasicPay,
                    TA = x.TA,
                    DA = x.DA,
                    HRA = x.HRA,
                    CCA = x.CCA,
                    ActiveType = x.ActiveType,
                    IPAmt1 = x.IPAmt1
                }).ToListAsync();
            return result;
        }
        public async Task<AgentFileViewModel> GetAgentById(int id)
        {
            var result = await _applicationDbContext.AgentFileTable.Select(x => new AgentFileViewModel()
            {
                Id = x.Id,
                CompIdA = x.CompIdA,
                Code = x.Code,
                Name = x.Name,
                Address1 = x.Address1,
                City = x.City,
                PinNo = x.PinNo,
                MobileNo = x.MobileNo,
                EmailAddress = x.EmailAddress,
                BankName = x.BankName,
                BankAcNo = x.BankAcNo,
                IFSC = x.IFSC,
                EPFAcNo = x.EPFAcNo,
                BasicPay = x.BasicPay,
                TA = x.TA,
                DA = x.DA,
                HRA = x.HRA,
                CCA = x.CCA,
                ActiveType = x.ActiveType,
                IPAmt1 = x.IPAmt1
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteAgent(int id)
        {
            var result = await _applicationDbContext.AgentFileTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }
        public async Task<AgentFileViewModel> GetAgentByCode(string code)
        {
            var result = await _applicationDbContext.AgentFileTable.Select(x => new AgentFileViewModel()
            {
                Id = x.Id,
                CompIdA = x.CompIdA,
                Code = x.Code,
                Name = x.Name,
                Address1 = x.Address1,
                City = x.City,
                PinNo = x.PinNo,
                MobileNo = x.MobileNo,
                EmailAddress = x.EmailAddress,
                BankName = x.BankName,
                BankAcNo = x.BankAcNo,
                IFSC = x.IFSC,
                EPFAcNo = x.EPFAcNo,
                BasicPay = x.BasicPay,
                TA = x.TA,
                DA = x.DA,
                HRA = x.HRA,
                CCA = x.CCA,
                ActiveType = x.ActiveType,
                IPAmt1 = x.IPAmt1
            }).FirstOrDefaultAsync(x => x.Code == code);
            return result;
        }

        // Client File
        public async Task<string> ClientSrNoCreation(int cmpid)
        {
            var NewNo = ""; var NewValue = 0; var splitChar = "";
            var result1 = await _applicationDbContext.CompanyDetailTable.Where(x => x.Id == cmpid).Select(x => new { x.TransCode }).FirstOrDefaultAsync();
            splitChar = result1.TransCode.Substring(3, 9) + "CL";
            string[] myzero = { "000","00", "0" };
            var result = await _applicationDbContext.ClientFileTable
                          .OrderByDescending(x => x.Id)
                          .Where(x => x.CompIdA == cmpid)
                          .Select(x => new { x.Code }).FirstOrDefaultAsync();

            if (result != null)
            {
                string parts1 = result.Code.Substring(11, 4);
                NewValue = Convert.ToInt32(parts1) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 4 ? splitChar + myzero[CurrentIndex] + (NewValue) : splitChar + NewValue.ToString();
            }
            else
            {
                NewNo = splitChar + "0001";
            }

            return NewNo;
        }
        public async Task<int> AddNewClient(ClientFileViewModel models)
        {
            ClientFile newClient = new ClientFile()
            {
                CompIdA = models.CompIdA,
                Code = models.Code,
                Name = models.Name,
                Address1 = models.Address1,
                City = models.City,
                PinNo = models.PinNo,
                MobileNo = models.MobileNo,
                EmailAddress = models.EmailAddress,
                RegPanel = (int)models.RegPanel,
                ActiveType = models.ActiveType
            };
            _applicationDbContext.Entry(newClient).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newClient.Id;
        }
        public async Task<bool> UpdateClient(ClientFileViewModel models)
        {
            var result = await _applicationDbContext.ClientFileTable.Where(x => x.Code == models.Code && x.CompIdA == models.CompIdA).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Id = models.Id; result.Code = models.Code; result.CompIdA = models.CompIdA;
                result.Name = models.Name; result.Address1 = models.Address1;
                result.City = models.City; result.PinNo = models.PinNo;
                result.MobileNo = models.MobileNo; result.EmailAddress = models.EmailAddress;
                result.RegPanel = (int)models.RegPanel;
                result.ActiveType = models.ActiveType;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<ClientFileViewModel>> GetAllClient(int cmpid)
        {
            var result = await _applicationDbContext.ClientFileTable
                .Where(x => cmpid > 0 ? x.CompIdA == cmpid:true)
                .Select(x => new ClientFileViewModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    NameAddress = x.Name + " " + x.Address1,
                    Name = x.Name,
                    Address1 = x.Address1,
                    City = x.City,
                    PinNo = x.PinNo,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    CompIdA = x.CompIdA,
                    ClientCompanyDetailView = new CompanyDetailViewModel()
                    {
                        CompName = x.ClientCompanyDetail.CompName
                    },
                    ActiveType = x.ActiveType,
                    RegPanel = (PatientPanel)x.RegPanel
                }).ToListAsync();
            return result;
        }
        public async Task<List<ClientFileViewModel>> GetAllClient(int cmpid,int clientid)
        {
            var result = await _applicationDbContext.ClientFileTable
                .Where(x => ( cmpid > 0 ? x.CompIdA == cmpid : true ) && x.Id == clientid)
                .Select(x => new ClientFileViewModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    NameAddress = x.Name + " " + x.Address1,
                    Name = x.Name,
                    Address1 = x.Address1,
                    City = x.City,
                    PinNo = x.PinNo,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    CompIdA = x.CompIdA,
                    ClientCompanyDetailView = new CompanyDetailViewModel()
                    {
                        CompName = x.ClientCompanyDetail.CompName
                    },
                    ActiveType = x.ActiveType,
                    RegPanel = (PatientPanel)x.RegPanel
                }).ToListAsync();
            return result;
        }
        public async Task<List<ClientFileViewModel>> GetAllClientBranchWise(int cmpid, string name)
        {
            var result = await _applicationDbContext.ClientFileTable
                .OrderBy(x => x.Name)
                .Where(x => x.CompIdA == cmpid
                && ((name != null) ? x.Name.Contains(name) : true))
                .Select(x => new ClientFileViewModel()
                {
                    Id = x.Id,
                    CompIdA = x.CompIdA,
                    Code = x.Code,
                    NameAddress = x.Name + " " + x.Address1,
                    Name = x.Name,
                    Address1 = x.Address1,
                    City = x.City,
                    PinNo = x.PinNo,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    ActiveType = x.ActiveType,
                    RegPanel = (PatientPanel)x.RegPanel
                }).ToListAsync();
            return result;
        }
        public async Task<ClientFileViewModel> GetClientById(int id)
        {
            var result = await _applicationDbContext.ClientFileTable.Select(x => new ClientFileViewModel()
            {
                Id = x.Id,
                CompIdA = x.CompIdA,
                Code = x.Code,
                Name = x.Name,
                Address1 = x.Address1,
                City = x.City,
                PinNo = x.PinNo,
                MobileNo = x.MobileNo,
                EmailAddress = x.EmailAddress,
                ActiveType = x.ActiveType,
                RegPanel = (PatientPanel)x.RegPanel
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<ClientFileViewModel> GetClientDefaultValue(int cmpid)
        {
            var result = await _applicationDbContext.ClientFileTable.Select(x => new ClientFileViewModel()
            {
                Id = x.Id,
                CompIdA = x.CompIdA,
                Code = x.Code,
                Name = x.Name,
                Address1 = x.Address1,
                City = x.City,
                PinNo = x.PinNo,
                MobileNo = x.MobileNo,
                EmailAddress = x.EmailAddress,
                ActiveType = x.ActiveType,
                RegPanel = (PatientPanel)x.RegPanel
            }).FirstOrDefaultAsync(x => x.CompIdA == cmpid);
            return result;
        }
        
        public async Task<bool> DeleteClient(int id)
        {
            var result = await _applicationDbContext.ClientFileTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }
        public async Task<ClientFileViewModel> GetClientByCode(string code)
        {
            var result = await _applicationDbContext.ClientFileTable.Select(x => new ClientFileViewModel()
            {
                Id = x.Id,
                CompIdA = x.CompIdA,
                Code = x.Code,
                Name = x.Name,
                Address1 = x.Address1,
                City = x.City,
                PinNo = x.PinNo,
                MobileNo = x.MobileNo,
                EmailAddress = x.EmailAddress,
                ActiveType = x.ActiveType,
                RegPanel = (PatientPanel)x.RegPanel
            }).FirstOrDefaultAsync(x => x.Code == code);
            return result;
        }
     
        // Area Master File
        public async Task<int> AddNewArea(AreaFileViewModel models)
        {
            AreaFile newState = new AreaFile()
            {
                CompIdA = models.CompIdA,
                Name = models.Name,
                DistId = Convert.ToInt32(models.DistId)
            };
            //await _applicationDbContext.CompanyDetailTable.AddAsync(newCompany);
            _applicationDbContext.Entry(newState).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newState.Id;
        }
        public async Task<bool> UpdateArea(AreaFileViewModel models)
        {
            var result = await _applicationDbContext.AreaFileTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.CompIdA = models.CompIdA;
                result.Name = models.Name;
                result.DistId = Convert.ToInt32(models.DistId);
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<AreaFileViewModel>> GetAllArea(int id)
        {
            var result = await _applicationDbContext.AreaFileTable
                .Where(x => ((id > 0) ? x.CompIdA == id : true))
                .Select(x => new AreaFileViewModel()
                {
                    Id = x.Id,
                    CompIdA = x.CompIdA,
                    Name = x.Name,
                    DistId = x.DistId,
                    DistrictDetail = new DistrictViewModel()
                    {
                        DistId = x.DistrictDetail.DistId,
                        DistrictName = x.DistrictDetail.DistrictName,
                        StateViewModel = new StateViewModel()
                        {
                            StateId = x.DistrictDetail.StateDetails.StateId,
                            StateName = x.DistrictDetail.StateDetails.StateName
                        }
                    }
                }).ToListAsync();
            return result;
        }
        public async Task<List<AreaFileViewModel>> GetAllAreaDetails(int id,string name)
        {
            var result = await _applicationDbContext.AreaFileTable
                .Where(x => ((id > 0) ? x.CompIdA == id : true)
                && ((name != null) ? x.Name.Contains(name) : true))
                .Select(x => new AreaFileViewModel()
                {
                    Id = x.Id,
                    CompIdA = x.CompIdA,
                    Name = x.Name,
                    DistId = x.DistId,
                    DistrictDetail = new DistrictViewModel()
                    {
                        DistId = x.DistrictDetail.DistId,
                        DistrictName = x.DistrictDetail.DistrictName,
                        StateViewModel = new StateViewModel()
                        {
                            StateId = x.DistrictDetail.StateDetails.StateId,
                            StateName = x.DistrictDetail.StateDetails.StateName
                        }
                    }
                }).ToListAsync();
            return result;
        }

        public async Task<List<AreaFileViewModel>> GetAllAreaByDistrict(int id)
        {
            var result = await _applicationDbContext.AreaFileTable
                .OrderBy(x => x.DistrictDetail.DistrictName)
                .Where(x => ((id > 0) ? x.DistId == id : true))
                .Select(x => new AreaFileViewModel()
                {
                    Id = x.Id,
                    CompIdA = x.CompIdA,
                    Name = x.Name,
                    DistId = x.DistId,
                    DistrictDetail = new DistrictViewModel()
                    {
                        DistId = x.DistrictDetail.DistId,
                        DistrictName = x.DistrictDetail.DistrictName,
                        StateViewModel = new StateViewModel()
                        {
                            StateId = x.DistrictDetail.StateDetails.StateId,
                            StateName = x.DistrictDetail.StateDetails.StateName
                        }
                    }
                }).ToListAsync();
            return result;
        }
        public async Task<AreaFileViewModel> GetAreaById(int id)
        {
            var result = await _applicationDbContext.AreaFileTable.Select(x => new AreaFileViewModel()
            {
                Id = x.Id,
                CompIdA = x.CompIdA,
                Name = x.Name,
                DistId = x.DistId,
                DistrictDetail = new DistrictViewModel()
                {
                    DistId = x.DistrictDetail.DistId,
                    DistrictName = x.DistrictDetail.DistrictName,
                    StateViewModel = new StateViewModel()
                    {
                        StateId = x.DistrictDetail.StateDetails.StateId,
                        StateName = x.DistrictDetail.StateDetails.StateName
                    }
                }
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteArea(int id)
        {
            var result = await _applicationDbContext.AreaFileTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }

        // Report Group Master File      
        public async Task<int> AddNewReportGroupMasterRecord(ReportGroupViewModel models)
        {
            ReportGroup ReportGroupGroup = new ReportGroup()
            {
                CompId = models.CompId,
                Name = models.Name,
                TempNo = models.TempNo
            };
            _applicationDbContext.Entry(ReportGroupGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return ReportGroupGroup.Id;
        }
        public async Task<bool> UpdateReportGroupMaster(ReportGroupViewModel models)
        {
            var result = await _applicationDbContext.ReportGroupTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.CompId = models.CompId;
                result.Name = models.Name;
                result.TempNo = models.TempNo;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<ReportGroupViewModel> GetReportGroupMasterById(int id)
        {
            var result = await _applicationDbContext.ReportGroupTable
                    .Select(x => new ReportGroupViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        Name = x.Name,
                        TempNo = x.TempNo
                    }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteReportGroupMaster(int id)
        {
            var result2 = await _applicationDbContext.ReportGroupTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<ReportGroupViewModel>> GetAllReportGroupMaster(int cmpid)
        {
            var result = await _applicationDbContext.ReportGroupTable
                    .OrderBy(x => x.Id)
                    .Where(x => ( cmpid > 0 ? x.CompId == cmpid : true))
                    .Select(x => new ReportGroupViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        Name = x.Name,
                        TempNo = x.TempNo
                    }).ToListAsync();
            return result;
        }
        public async Task<int> ReportGroupOrderNo(int cmpid)
        {
            var report = await _applicationDbContext.ReportGroupTable.OrderByDescending(x => x.TempNo)
                        .Where(x => ( cmpid > 0 ? x.CompId == cmpid : true)).Select(x => x.TempNo).FirstOrDefaultAsync();
            return  (report !=null ? report.Value + 1 : 1) ;
        }

        public async Task<bool> UpdateReportSerialNo(TempReportViewFile models)
        {
            int tmpno = 1;
            foreach (var item in models.TempReportDetailViewModels)
            {
                var result1 = await _applicationDbContext.ReportGroupTable.FirstOrDefaultAsync(x => x.CompId == models.CompId && x.Id == item.Id);
                if (result1 != null)
                {
                    //result1.Id = item.Id;
                    result1.TempNo = tmpno;                    
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    tmpno++;
                }                
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        // Test Group Master File
        public async Task<int> AddNewTestGroupMasterRecord(TestGroupMasterViewModel models)
        {
            TestGroupMaster DMaster = new TestGroupMaster()
            {
                CompId = models.CompId,
                Name = models.Name,
                ShortName = models.ShortName,
                IPPer1 = models.IPPer1,
                IPAmt1 = models.IPAmt1
            };
            _applicationDbContext.Entry(DMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            var result = await _applicationDbContext.DoctorTable.Where(x => x.CompId == models.CompId).ToListAsync();
            foreach (var item in result)
            {
                DoctorDetailsMaster order = new DoctorDetailsMaster()
                {
                    Id = 0,
                    DoctorId = item.Id,
                    CompId = models.CompId,
                    TestGId = DMaster.Id,
                    IPPer1 = models.IPPer1,
                    IPAmt1 = models.IPAmt1
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
            }
            return DMaster.Id;
        }
        public async Task<bool> UpdateTestGroupMaster(TestGroupMasterViewModel models)
        {
            var result = await _applicationDbContext.TestGroupTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.CompId = models.CompId;
                result.Name = models.Name;
                result.ShortName = models.ShortName;
                result.IPPer1 = models.IPPer1;
                result.IPAmt1 = models.IPAmt1;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<TestGroupMasterViewModel> GetTestGroupMasterById(int id)
        {
            var result = await _applicationDbContext.TestGroupTable
                .Select(x => new TestGroupMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    Name = x.Name,
                    ShortName = x.ShortName,
                    IPAmt1 = x.IPAmt1,
                    IPPer1 = x.IPPer1
                }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<TestGroupMasterViewModel> GetTestGroupMasterCompany(int cmdid)
        {
            var result = await _applicationDbContext.TestGroupTable
                .Select(x => new TestGroupMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    Name = x.Name,
                    ShortName = x.ShortName,
                    IPAmt1 = x.IPAmt1,
                    IPPer1 = x.IPPer1
                }).FirstOrDefaultAsync(x => x.CompId == cmdid);
            return result;
        }
        public async Task<bool> DeleteTestGroupMaster(int id)
        {
            var result2 = await _applicationDbContext.TestGroupTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<TestGroupMasterViewModel>> GetAllTestGroupMaster(int cmpid)
        {
            var result = await _applicationDbContext.TestGroupTable
                .OrderBy(x => x.Id)
                .Where(x => x.CompId == cmpid)
                .Select(x => new TestGroupMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    Name = x.Name,
                    ShortName = x.ShortName,
                    IPAmt1 = x.IPAmt1,
                    IPPer1 = x.IPPer1
                }).ToListAsync();
            return result;
        }
        public async Task<TestGroupMasterViewModel> GetAllTestGroupMasterName(int cmpid,string shortname)
        {
            var result = await _applicationDbContext.TestGroupTable
                .OrderBy(x => x.Id)
                .Where(x => x.CompId == cmpid && x.ShortName == shortname)
                .Select(x => new TestGroupMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    Name = x.Name,
                    ShortName = x.ShortName,
                    IPAmt1 = x.IPAmt1,
                    IPPer1 = x.IPPer1
                }).FirstOrDefaultAsync();
            return result;
        }

        // Doctor Master File
        public async Task<string> DoctorSrNoCreation(int cmpid)
        {
            var NewNo = ""; var NewValue = 0; var splitChar = "";
            var result1 = await _applicationDbContext.CompanyDetailTable.Where(x => x.Id == cmpid).Select(x => new { x.TransCode }).FirstOrDefaultAsync();
            splitChar = result1.TransCode.Substring(3, 9) + "DOC";
            string[] myzero = { "00", "0" };
            var result = await _applicationDbContext.DoctorTable
                          .OrderByDescending(x => x.Id)
                          .Where(x => x.CompId == cmpid)
                          .Select(x => new { x.Code }).FirstOrDefaultAsync();

            if (result != null)
            {
                string parts1 = result.Code.Substring(12, 3);
                NewValue = Convert.ToInt32(parts1) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 2 ? splitChar +  myzero[CurrentIndex] + (NewValue) : splitChar + NewValue.ToString();
            }
            else
            {
                NewNo = splitChar + "001";
            }

            return NewNo;
        }
        public async Task<int> AddNewDoctorMasterRecord(DoctorViewModel models)
        {
            Doctor platMaster = new Doctor()
            {
                CompId = models.CompId,
                Code = models.Code,
                Name = models.Name,
                Address1 = models.Address1,
                Address2 = models.Address2,
                MobileNo = models.MobileNo,
                Education = models.Eduction
            };
            _applicationDbContext.Entry(platMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.DoctorDetailsMasterViewModel)
            {
                DoctorDetailsMaster order = new DoctorDetailsMaster()
                {
                    Id = item.Id,
                    DoctorId = platMaster.Id,
                    CompId = models.CompId,
                    TestGId = item.TestGId,
                    IPPer1 = item.IPPer1,
                    IPAmt1 = item.IPAmt1
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return platMaster.Id;
        }
        public async Task<bool> UpdateDoctorMaster(DoctorViewModel models)
        {
            var result = await _applicationDbContext.DoctorTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.CompId = models.CompId; result.Name = models.Name;
                result.Address1 = models.Address1; result.Address2 = models.Address2;
                result.MobileNo = models.MobileNo; result.Code = models.Code;
                result.Education = models.Eduction;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.DoctorDetailsMasterViewModel)
            {
                var result1 = await _applicationDbContext.DoctorDetailsMasterTable.FirstOrDefaultAsync(x => x.DoctorId == models.Id && x.CompId == item.CompId && x.TestGId == item.TestGId);
                if (result1 != null)
                {
                    result1.CompId = item.CompId; result1.IPPer1 = item.IPPer1;
                    result1.IPAmt1 = item.IPAmt1; result1.DoctorId = models.Id;
                    result1.TestGId = item.TestGId;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    DoctorDetailsMaster order = new DoctorDetailsMaster()
                    {
                        Id = item.Id,
                        DoctorId = models.Id,
                        CompId = models.CompId,
                        TestGId = item.TestGId,
                        IPPer1 = item.IPPer1,
                        IPAmt1 = (int)item.IPAmt1
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<DoctorViewModel> GetDoctorMasterById(int id)
        {
            var result = await _applicationDbContext.DoctorTable
                     .Select(x => new DoctorViewModel()
                     {
                         Id = x.Id,
                         CompId = x.CompId,
                         Code = x.Code,
                         Name = x.Name,
                         Address1 = x.Address1,
                         Address2 = x.Address2,
                         MobileNo = x.MobileNo,
                         Eduction = x.Education
                     }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<List<int>> GetDetailsDoctorMasterById(int id, int cmdid, int testGroupid)
        {
            List<int> opnValue = new List<int>();
            var result = await _applicationDbContext.DoctorDetailsMasterTable.Where(g => g.DoctorId == id && g.CompId == cmdid && g.TestGId == testGroupid)
                                            .Select(g => new
                                            {
                                                g.IPPer1,
                                                g.IPAmt1
                                            }).FirstOrDefaultAsync();
            opnValue.Add(result != null ? Convert.ToInt32(result.IPPer1) : 0);
            opnValue.Add(result != null ? Convert.ToInt32(result.IPAmt1) : 0);
            return opnValue;
        }
        public async Task<DoctorDetailsMasterViewModel> GetDetailsDoctorMasterTestGroup(string doctorid, int cmdid, int testGroupid)
        {
            var resultx = await _applicationDbContext.DoctorTable.Select(x => new { x.Id, x.Code }).FirstOrDefaultAsync(x => x.Code == doctorid);
            var result = await _applicationDbContext.DoctorDetailsMasterTable
                        .Select(g => new DoctorDetailsMasterViewModel()
                        {
                            Id = g.Id,
                            CompId = g.CompId,
                            DoctorId = g.DoctorId,
                            TestGId = g.TestGId,
                            IPPer1 = g.IPPer1,
                            IPAmt1 = g.IPAmt1
                        }).FirstOrDefaultAsync(g => g.DoctorId == resultx.Id && g.CompId == cmdid && g.TestGId == testGroupid);
            return result;
        }
        public async Task<bool> DeleteDoctorMaster(int id)
        {
            var result1 = await _applicationDbContext.DoctorTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result1 != null)
            {
                var result2 = await _applicationDbContext.DoctorDetailsMasterTable.OrderBy(x => x.Id).Where(x => x.DoctorId == id).ToListAsync();

                foreach (var item in result2)
                {
                    var result3 = await _applicationDbContext.DoctorDetailsMasterTable.FirstOrDefaultAsync(x => x.Id == item.Id);
                    if (result3 != null)
                    {
                        _applicationDbContext.Entry(result3).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                        _applicationDbContext.SaveChanges();
                    }
                }
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<DoctorViewModel>> GetAllDoctorMaster(int cmpid)
        {
            var result = await _applicationDbContext.DoctorTable
                .OrderBy(x => x.Id)
                .Where(x => ( cmpid > 0 ? x.CompId == cmpid : true))
                .Select(x => new DoctorViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    Code = x.Code,
                    Name = x.Name,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    MobileNo = x.MobileNo,
                    Eduction = x.Education
                }).ToListAsync();
            return result;
        }
        public async Task<List<DoctorViewModel>> GetAllDoctorMasterLedger(int cmpid)
        {
            var result = await _applicationDbContext.HeadTable
                .OrderBy(x => x.PartyName)
                .Where(x => x.CompId == cmpid && x.AcGroupId == 29)
                .Select(x => new DoctorViewModel()
                {
                    Id = x.LedgerMasterId,
                    CompId = x.CompId,
                    Code = x.LedCode,
                    Name = x.PartyName,                    
                    Eduction = x.Address3
                }).ToListAsync();
            return result;
        }
        public async Task<string> GetDoctorMasterLedgerId(int id)
        {
            var result = await _applicationDbContext.HeadTable                                
                .Where(x => x.LedgerMasterId == id)
                .Select(x => new DoctorViewModel()
                {
                    Id = x.LedgerMasterId,
                    CompId = x.CompId,
                    Code = x.LedCode,
                    Name = x.PartyName + " " + x.Address3,
                    Eduction = x.Address3
                }).FirstOrDefaultAsync();
            return result.Name;
        }
        public async Task<List<DoctorViewModel>> GetAllDoctorMasterName(int cmpid, string name, string mobileno, string addressx)
        {
            var result = await _applicationDbContext.DoctorTable
                    .OrderBy(x => x.Name)
                    .Where(x => x.CompId == cmpid
                    && ((name != null) ? x.Name.Contains(name) : true)
                    && ((mobileno != null) ? x.MobileNo.Contains(mobileno) : true)
                    && ((addressx != null) ? x.Address1.Contains(addressx) : true))
                .Select(x => new DoctorViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    Code = x.Code,
                    Name = x.Name,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    MobileNo = x.MobileNo,
                    Eduction = x.Education
                }).ToListAsync();
            return result;
        }

        public async Task<int> AddNewDoctorMasterAccountRecord(DoctorViewModel models)
        {
            var statid = await _applicationDbContext.CompanyDetailTable.FirstOrDefaultAsync(x => x.Id == models.CompId);
            LedgerMaster platMaster = new LedgerMaster()
            {
                CompId = models.CompId,
                LedCode = models.Code,
                PartyName = models.Name,
                Address1 = models.Address1,
                Address2 = models.Address2,
                Address3 = models.Eduction,
                MobileNo1 = models.MobileNo,
                LedStateId = Convert.ToInt32(statid.StateId),
                AcGroupId = 29,
                OpnAc =1,
                OpnAmt =0,
                CloseAc = 1,
                CloseAmt = 0,
                Code = "0"
            };
            _applicationDbContext.Entry(platMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return platMaster.LedgerMasterId;
        }
        public async Task<bool> UpdateDoctorMasterAccount(DoctorViewModel models)
        {
            var statid = await _applicationDbContext.CompanyDetailTable.FirstOrDefaultAsync(x => x.Id == models.CompId);
            var result = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.CompId == models.CompId && x.LedCode == models.Code);
            if (result != null)
            {
                result.CompId = models.CompId;
                result.LedCode = models.Code;
                result.PartyName = models.Name;
                result.Address1 = models.Address1;
                result.Address2 = models.Address2;
                result.Address3 = models.Eduction;
                result.MobileNo1 = models.MobileNo;
                result.LedStateId = Convert.ToInt32(statid.StateId);
                result.AcGroupId = 29;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        // Doctor In Lab Details        
        public async Task<int> AddNewDoctorMasterLabRecord(DoctorLabViewModel models)
        {
            DoctorLab platMaster = new DoctorLab()
            {
                CompId = models.CompId,                
                Name = models.Name,
                Address = models.Address,
                MobileNo = models.MobileNo,
                Education = models.Eduction,
                PrintReport = models.PrintReport,
                IPAmt = models.IPAmt
            };
            _applicationDbContext.Entry(platMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return platMaster.Id;
        }
        public async Task<bool> UpdateDoctorMasterLab(DoctorLabViewModel models)
        {
            var result = await _applicationDbContext.DoctorLabTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.CompId = models.CompId; result.Name = models.Name;
                result.Address = models.Address;
                result.MobileNo = models.MobileNo; 
                result.Education = models.Eduction;
                result.PrintReport = models.PrintReport;
                result.IPAmt = models.IPAmt;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();            
            return true;
        }
        public async Task<DoctorLabViewModel> GetDoctorMasterLabById(int id)
        {
            var result = await _applicationDbContext.DoctorLabTable
                     .Select(x => new DoctorLabViewModel()
                     {
                         Id = x.Id,
                         CompId = x.CompId,
                         Name = x.Name,
                         Address = x.Address,
                         MobileNo = x.MobileNo,
                         Eduction = x.Education,
                         PrintReport = x.PrintReport,
                         IPAmt = x.IPAmt
                     }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }        
        public async Task<bool> DeleteDoctorMasterLab(int id)
        {
            var result1 = await _applicationDbContext.DoctorLabTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result1 != null)
            {             
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<DoctorLabViewModel>> GetDoctorMasterLabList(int cmpid)
        {
            var result = await _applicationDbContext.DoctorLabTable
                    .OrderBy(x => x.Name).Where(x => x.CompId == cmpid)
                     .Select(x => new DoctorLabViewModel()
                     {
                         Id = x.Id,
                         CompId = x.CompId,
                         Name = x.Name,
                         Address = x.Address,
                         MobileNo = x.MobileNo,
                         Eduction = x.Education,
                         PrintReport = x.PrintReport,
                         IPAmt = x.IPAmt
                     }).ToListAsync();
            return result;
        }
       
        // Test Document File      
        public async Task<int> AddNewTestDocMasterRecord(TestDocMasterViewModel models)
        {
            TestDocMaster ReportGroupGroup = new TestDocMaster()
            {
                CompId = models.CompId,
                TestCode = models.TestCode,
                TestGroupId = models.TestGroupId,
                documentFile = models.documentFile
            };
            _applicationDbContext.Entry(ReportGroupGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return ReportGroupGroup.Id;
        }
        public async Task<bool> UpdateTestDocMaster(TestDocMasterViewModel models)
        {
            var result = await _applicationDbContext.TestDocMasterTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.CompId = models.CompId;
                result.TestCode = models.TestCode;
                result.TestGroupId = models.TestGroupId;
                result.documentFile = models.documentFile;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<TestDocMasterViewModel> GetTestDocMasterById(int id)
        {
            var result = await _applicationDbContext.TestDocMasterTable
                    .Select(x => new TestDocMasterViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        TestCode = x.TestCode,
                        TestGroupId = x.TestGroupId,
                        documentFile = x.documentFile
                    }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteTestDocMaster(int id)
        {
            var result2 = await _applicationDbContext.TestDocMasterTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<TestDocMasterViewModel>> GetAllTestDocMaster(int cmpid)
        {
            var result = await _applicationDbContext.TestDocMasterTable
                    .OrderBy(x => x.TestGroupMaster.Id)
                    .Where(x => cmpid > 0 ? x.CompId == cmpid : true )
                    .Select(x => new TestDocMasterViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        TestCode = x.TestCode,
                        TestGroupId = x.TestGroupId,
                        TestGroupMasterViewModel = new TestGroupMasterViewModel()
                        {
                            Name = x.TestGroupMaster.Name,
                            ShortName = x.TestGroupMaster.ShortName
                        },
                        documentFile = x.documentFile
                    }).ToListAsync();
            return result;
        }
        public async Task<List<TestDocMasterViewModel>> GetAllTestDocMaster(int cmpid, string testcode, int testgid)
        {
            var result = await _applicationDbContext.TestDocMasterTable
                .OrderBy(x => x.TestCode)
                .Where(x => x.CompId == cmpid
                && (testgid > 0 ? x.TestGroupId == testgid : true)
                && (testcode != null ? x.TestCode.Contains(testcode) : true ))
                .Select(x => new TestDocMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestCode = x.TestCode,
                    TestGroupId = x.TestGroupId,
                    TestGroupMasterViewModel = new TestGroupMasterViewModel()
                    {
                        Name = x.TestGroupMaster.Name,
                        ShortName = x.TestGroupMaster.ShortName
                    },
                    documentFile = x.documentFile
                }).ToListAsync();
            return result;
        }
        public async Task<List<TestDocMasterViewModel>> GetAllTestDocMaster(int cmpid, int testgid)
        {
            var result = await _applicationDbContext.TestDocMasterTable
                .OrderBy(x => x.TestCode)
                .Where(x => x.CompId == cmpid
                && (testgid > 0 ? x.TestGroupId == testgid : true))
                .Select(x => new TestDocMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestCode = x.TestCode,
                    TestGroupId = x.TestGroupId,
                    TestGroupMasterViewModel = new TestGroupMasterViewModel()
                    {
                        Name = x.TestGroupMaster.Name,
                        ShortName = x.TestGroupMaster.ShortName
                    },
                    documentFile = x.documentFile
                }).ToListAsync();
            return result;
        }
         // Test Master Master File     
        public async Task<int> AddNewTestMasterRecord(TestMasterViewModel models)
        {
            TestMaster TestMasterMaster = new TestMaster()
            {
                CompId = models.CompId,
                TestCode = models.TestCode,
                ReportId = models.ReportId,
                TestGroupId = models.TestGroupId,
                Rate = models.Rate,
                IPPer1 = models.IPPer1,
                IPAmt1 = models.IPAmt1,
                documentType = models.documentType,
                ColumnsNo = models.ColumnsNo,
                GraphsType = models.GraphsType,
                PPRate = models.PPRate,
                CCRate = models.CCRate
            };
            _applicationDbContext.Entry(TestMasterMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();            
            foreach (var item in models.TestSubMasterViewModels )
            {
                TestSubMaster order = new TestSubMaster()
                {
                    Id = item.Id,
                    TestDetails = models.documentType == "Reading" ? item.TestDetails : models.TestDocumentain,
                    ColFirst = item.ColFirst,
                    ColSecond = item.ColSecond,
                    ColThird = item.ColThird,
                    ColFourth = item.ColFourth,
                    ColFifth = item.ColFifth,
                    ColSixth = item.ColSixth,
                    VisualTrueFalse = models.documentType == "Reading" ? item.VisualTrueFalse : true,
                    TestLocked = item.TestLocked,
                    Gender = models.documentType == "Reading" ? item.Gender : "A",
                    Units = item.Units,
                    FromRange = item.FromRange,
                    UptoRange = item.UptoRange,
                    RangeSymble = item.RangeSymble,
                    RangeDetails = item.RangeDetails,
                    AgeType = item.AgeType,
                    FromAge = models.documentType == "Reading" ? (int)item.FromAge : 0,
                    UptoAge = models.documentType == "Reading" ? (int)item.UptoAge : 150,
                    DefaultResult = models.documentType == "Reading" ? item.DefaultResult : "-",
                    MiniRange = item.MiniRange,
                    MaxRange = item.MaxRange,
                    TempNo = item.TempNo,
                    CompId = models.CompId,
                    TestId = TestMasterMaster.Id
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return TestMasterMaster.Id;
        }
        public async Task<bool> UpdateTestMaster(TestMasterViewModel models)
        {
            var result = await _applicationDbContext.TestMasterTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.CompId = models.CompId;
                result.TestCode = models.TestCode;
                result.ReportId = models.ReportId;
                result.TestGroupId = models.TestGroupId;
                result.Rate = models.Rate;
                result.IPPer1 = models.IPPer1;
                result.IPAmt1 = models.IPAmt1;
                result.documentType = models.documentType;
                result.ColumnsNo = models.ColumnsNo;
                result.GraphsType = models.GraphsType;
                result.PPRate = models.PPRate;
                result.CCRate = models.CCRate;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.TestSubMasterViewModels)
            {
                var result1 = await _applicationDbContext.TestSubMasterTable.FirstOrDefaultAsync(x => x.TestId == models.Id && x.CompId == models.CompId && x.TempNo == item.TempNo);
                if (result1 != null)
                {
                    //result1.Id = item.Id;
                    result1.TestDetails = models.documentType == "Reading" ? item.TestDetails : models.TestDocumentain;
                    result1.ColFirst = item.ColFirst;
                    result1.ColSecond = item.ColSecond;
                    result1.ColThird = item.ColThird;
                    result1.ColFourth = item.ColFourth;
                    result1.ColFifth = item.ColFifth;
                    result1.ColSixth = item.ColSixth;
                    result1.VisualTrueFalse = models.documentType == "Reading" ? item.VisualTrueFalse : true;
                    result1.TestLocked = item.TestLocked;
                    result1.Gender = models.documentType == "Reading" ? item.Gender : "A";
                    result1.Units = item.Units;
                    result1.FromRange = item.FromRange;
                    result1.UptoRange = item.UptoRange;
                    result1.RangeSymble = item.RangeSymble;
                    result1.RangeDetails = item.RangeDetails;
                    result1.AgeType = item.AgeType;
                    result1.FromAge = models.documentType == "Reading" ? (int)item.FromAge : 0;
                    result1.UptoAge = models.documentType == "Reading" ? (int)item.UptoAge : 150;
                    result1.DefaultResult = models.documentType == "Reading" ? item.DefaultResult : "-";
                    result1.MiniRange = item.MiniRange;
                    result1.MaxRange = item.MaxRange;
                    result1.TempNo = item.TempNo;
                    result1.CompId = models.CompId;
                    result1.TestId = result.Id;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    TestSubMaster order = new TestSubMaster()
                    {
                        //Id = item.Id,
                        TestDetails = models.documentType == "Reading" ? item.TestDetails : models.TestDocumentain,
                        ColFirst = item.ColFirst,
                        ColSecond = item.ColSecond,
                        ColThird = item.ColThird,
                        ColFourth = item.ColFourth,
                        ColFifth = item.ColFifth,
                        ColSixth = item.ColSixth,
                        VisualTrueFalse = models.documentType == "Reading" ? item.VisualTrueFalse : true,
                        TestLocked = item.TestLocked,
                        Gender = models.documentType == "Reading" ? item.Gender : "A",
                        Units = item.Units,
                        FromRange = item.FromRange,
                        UptoRange = item.UptoRange,
                        RangeSymble = item.RangeSymble,
                        RangeDetails = item.RangeDetails,
                        AgeType = item.AgeType,
                        FromAge = models.documentType == "Reading" ? (int)item.FromAge : 0,
                        UptoAge = models.documentType == "Reading" ? (int)item.UptoAge : 150,
                        DefaultResult = models.documentType == "Reading" ? item.DefaultResult : "-",
                        MiniRange = item.MiniRange,
                        MaxRange = item.MaxRange,
                        TempNo = item.TempNo,
                        CompId = models.CompId,
                        TestId = result.Id
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateInsertTestMaster(int testid,int insertno,int totalrows, int compid)
        {
            var No1 = insertno + totalrows + 1;
            var result2 = await _applicationDbContext.TestSubMasterTable.OrderBy(x => x.TempNo).Where(x => x.TestId == testid && x.TempNo > insertno).ToListAsync();
            foreach (var item in result2)
            {
                var result = await _applicationDbContext.TestSubMasterTable.Where(x => x.Id == item.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.TempNo = No1;
                    _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                }
                No1++;
            }
            for (int i = 0; i < totalrows; i++)
            {
                insertno++;
                TestSubMaster order = new TestSubMaster()
                {
                    Id = 0,
                    TestDetails = "-",
                    VisualTrueFalse = true,
                    FromAge = 0,
                    UptoAge = 150,
                    TempNo = insertno,
                    CompId = compid,
                    TestId = testid
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
            }
            return true;
        }
        public async Task<TestMasterViewModel> GetTestMasterById(int id)
        {
            var result1 = await _applicationDbContext.TestSubMasterTable.FirstOrDefaultAsync(a => a.TestId == id && a.TempNo == 1);
            var result = await _applicationDbContext.TestMasterTable
                .Select(x => new TestMasterViewModel()
                {
                    Id = x.Id,
                    TestCode = x.TestCode,
                    ReportId = x.ReportId,
                    TestGroupId = x.TestGroupId,
                    Rate = (decimal)x.Rate,
                    IPPer1 = (decimal)x.IPPer1,
                    IPAmt1 = (decimal)x.IPAmt1,
                    documentType = x.documentType,
                    ColumnsNo = x.ColumnsNo,
                    GraphsType = x.GraphsType,
                    TestDocumentain = result1 != null ? result1.TestDetails : " ",
                    PPRate = (decimal)x.PPRate,
                    CCRate = (decimal)x.CCRate,
                    TestSubMasterViewModels = x.TestSubMasters.Where(a => a.TestId == x.Id)
                    .OrderBy(a => a.TempNo)
                    .Select(n => new TestSubMasterViewModel()
                    {
                        TestId = n.TestId,
                        TestDetails = n.TestDetails,
                        ColFirst = n.ColFirst,
                        ColSecond = n.ColSecond,
                        ColThird = n.ColThird,
                        ColFourth = n.ColFourth,
                        ColFifth = n.ColFifth,
                        ColSixth = n.ColSixth,
                        VisualTrueFalse = n.VisualTrueFalse,
                        TestLocked = n.TestLocked,
                        Gender = n.Gender,
                        Units = n.Units,
                        FromRange = n.FromRange,
                        UptoRange = n.UptoRange,
                        RangeSymble = n.RangeSymble,
                        RangeDetails = n.RangeDetails,
                        AgeType = n.AgeType,
                        FromAge = n.FromAge,
                        UptoAge = n.UptoAge,
                        DefaultResult = n.DefaultResult,
                        MiniRange = n.MiniRange,
                        MaxRange = n.MaxRange,
                        TempNo = (int)n.TempNo,
                        CompId = n.CompId
                    }).ToList()
                }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<List<TestSubMasterViewModel>> GetTestMasterBySubId(int id)
        {
            var result = await _applicationDbContext.TestSubMasterTable
                    .Where(x => x.TestId == id && x.TestDetails != null)
                    .Select(n => new TestSubMasterViewModel()
                    {
                        Id = n.Id,                       
                        TestDetails = n.TestDetails,
                    }).ToListAsync();
            return result;
        }
        public async Task<TestSubMasterViewModel> GetTestMasterBySubDocId(int id)
        {
            var result = await _applicationDbContext.TestSubMasterTable
                    .Select(n => new TestSubMasterViewModel()
                    {
                        Id = n.Id,
                        TestDetails = n.TestDetails,
                        TestId = n.TestId
                    }).FirstOrDefaultAsync(x => x.TestId == id);
            return result;
        }
        public async Task<List<TestSubMasterViewModel>> GetTestMasterSuId(int id)
        {
            var result = await _applicationDbContext.TestSubMasterTable
                    .Where(x => x.TestId == id)
                    .Select(n => new TestSubMasterViewModel()
                    {
                        TestId = n.TestId,
                        TestDetails = n.TestDetails,
                        ColFirst = n.ColFirst,
                        ColSecond = n.ColSecond,
                        ColThird = n.ColThird,
                        ColFourth = n.ColFourth,
                        ColFifth = n.ColFifth,
                        ColSixth = n.ColSixth,
                        VisualTrueFalse = n.VisualTrueFalse,
                        TestLocked = n.TestLocked,
                        Gender = n.Gender,
                        Units = n.Units,
                        FromRange = n.FromRange,
                        UptoRange = n.UptoRange,
                        RangeSymble = n.RangeSymble,
                        RangeDetails = n.RangeDetails,
                        AgeType = n.AgeType,
                        FromAge = n.FromAge,
                        UptoAge = n.UptoAge,
                        DefaultResult = n.DefaultResult,
                        MiniRange = n.MiniRange,
                        MaxRange = n.MaxRange
                    }).ToListAsync();
            return result;
        }
        public async Task<bool> DeleteTestMaster(int id)
        {
            var result2 = await _applicationDbContext.TestMasterTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeleteTestMasterOne(int id, int tno)
        {
            var result1 = await _applicationDbContext.TestSubMasterTable.FirstOrDefaultAsync(x => x.TempNo == tno && x.TestId == id);
            if (result1 != null)
            {
                result1.TestId = id;
                result1.TempNo = tno;
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.TestSubMasterTable.OrderBy(x => x.TempNo).Where(x => x.TestId == id).ToListAsync();
            foreach (var item in result2)
            {
                var result = await _applicationDbContext.TestSubMasterTable.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (result != null)
                {
                    result.TempNo = No1;
                    _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                    No1++;
                }
            }
            return false;
        }
        public async Task<List<TestMasterViewModel>> GetAllTestMaster(int cmpid, int rptid, int testgid,string testname)
        {
            var result = await _applicationDbContext.TestMasterTable
                .OrderBy(x => x.TestCode)
                .Where(x => x.CompId == cmpid
                && (rptid > 0 ? x.ReportId == rptid : true)
                && (testgid > 0 ? x.TestGroupId == testgid : true)
                && (testname != null ? x.TestCode.Contains(testname):true )
                )
                .Select(x => new TestMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestCode = x.TestCode,
                    ReportId = x.ReportId,
                    ReportGroupViewModel = new ReportGroupViewModel()
                    {
                        Name = x.ReportGroup.Name
                    },
                    TestGroupId = x.TestGroupId,
                    TestGroupMasterViewModel = new TestGroupMasterViewModel()
                    {
                        Name = x.TestGroupMaster.Name,
                        ShortName = x.TestGroupMaster.ShortName
                    },
                    Rate = (decimal)x.Rate,
                    IPPer1 = (decimal)x.IPPer1,
                    IPAmt1 = (decimal)x.IPAmt1,
                    documentType = x.documentType,
                    ColumnsNo = x.ColumnsNo,
                    GraphsType = x.GraphsType,
                    PPRate = (decimal)x.PPRate,
                    CCRate = (decimal)x.CCRate
                }).ToListAsync();
            return result;
        }
        public async Task<List<TestMasterViewModel>> GetAllTestMaster(int cmpid, int rptid, int testgid)
        {
            var result = await _applicationDbContext.TestMasterTable
                .OrderBy(x => x.TestCode)
                .Where(x => x.CompId == cmpid
                && (rptid > 0 ? x.ReportId == rptid : true)
                && (testgid > 0 ? x.TestGroupId == testgid : true)
                )
                .Select(x => new TestMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestCode = x.TestCode,
                    ReportId = x.ReportId,
                    ReportGroupViewModel = new ReportGroupViewModel()
                    {
                        Name = x.ReportGroup.Name
                    },
                    TestGroupId = x.TestGroupId,
                    TestGroupMasterViewModel = new TestGroupMasterViewModel()
                    {
                        Name = x.TestGroupMaster.Name,
                        ShortName = x.TestGroupMaster.ShortName
                    },
                    Rate = (decimal)x.Rate,
                    IPPer1 = (decimal)x.IPPer1,
                    IPAmt1 = (decimal)x.IPAmt1,
                    documentType = x.documentType,
                    ColumnsNo = x.ColumnsNo,
                    GraphsType = x.GraphsType,
                    PPRate = (decimal)x.PPRate,
                    CCRate = (decimal)x.CCRate
                }).ToListAsync();
            return result;
        }
        public async Task<List<TestMasterViewModel>> GetAllTestMaster(int cmpid)
        {
            var result = await _applicationDbContext.TestMasterTable
                .OrderBy(x => x.TestCode)
                .Where(x => x.CompId == cmpid)
                .Select(x => new TestMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestCode = x.TestCode,
                    ReportId = x.ReportId,
                    ReportGroupViewModel = new ReportGroupViewModel()
                    {
                        Name = x.ReportGroup.Name
                    },
                    TestGroupId = x.TestGroupId,
                    TestGroupMasterViewModel = new TestGroupMasterViewModel()
                    {
                        Name = x.TestGroupMaster.Name,
                        ShortName = x.TestGroupMaster.ShortName
                    },
                    Rate = (decimal)x.Rate,
                    IPPer1 = (decimal)x.IPPer1,
                    IPAmt1 = (decimal)x.IPAmt1,
                    documentType = x.documentType,
                    ColumnsNo = x.ColumnsNo,
                    GraphsType = x.GraphsType,
                    PPRate = (decimal)x.PPRate,
                    CCRate = (decimal)x.CCRate
                }).ToListAsync();
            return result;
        }
        public async Task<List<TestMasterViewModel>> GetAllTestMasterGroup(int cmpid)
        {
            var result = await _applicationDbContext.TestMasterTable
                .OrderBy(x => x.TestCode)
                .Where(x =>  (cmpid > 0 ? x.CompId == cmpid : true) )
                .Select(x => new TestMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestCode = x.TestCode,
                    ReportId = x.ReportId,
                    ReportGroupViewModel = new ReportGroupViewModel()
                    {
                        Name = x.ReportGroup.Name
                    },
                    TestGroupId = x.TestGroupId,
                    TestGroupMasterViewModel = new TestGroupMasterViewModel()
                    {
                        Name = x.TestGroupMaster.Name,
                        ShortName = x.TestGroupMaster.ShortName
                    },                    
                    Rate = (decimal)x.Rate,
                    IPPer1 = (decimal)x.IPPer1,
                    IPAmt1 = (decimal)x.IPAmt1,
                    documentType = x.documentType,
                    ColumnsNo = x.ColumnsNo,
                    GraphsType = x.GraphsType,
                    PPRate = (decimal)x.PPRate,
                    CCRate = (decimal)x.CCRate
                }).ToListAsync();
            return result;
        }
        public async Task<List<TestMasterViewModel>> GetAllTestMasterGroup(int cmpid,int testid)
        {
            int countgroup = 0;
            var resultx = await _applicationDbContext.TestMasterTable.FirstOrDefaultAsync(x => x.CompId == cmpid && x.Id == testid);
            if (resultx != null)
            {
                var resultxx = await _applicationDbContext.TestMasterTable.Where(x => x.CompId == cmpid && x.TestGroupId == resultx.TestGroupId).ToListAsync();
                countgroup = resultxx.Count();
            }
            var result = await _applicationDbContext.TestMasterTable
                        .OrderBy(x => x.TestCode)
                        .Where(x => (cmpid > 0 ? x.CompId == cmpid : true)
                        && x.TestGroupId == resultx.TestGroupId)
                        .Select(x => new TestMasterViewModel()
                        {
                            Id = x.Id,
                            CompId = x.CompId,
                            TestCode = x.TestCode,
                            ReportId = x.ReportId,
                            ReportGroupViewModel = new ReportGroupViewModel()
                            {
                                Name = x.ReportGroup.Name
                            },
                            TestGroupId = x.TestGroupId,
                            TestGroupMasterViewModel = new TestGroupMasterViewModel()
                            {
                                Name = x.TestGroupMaster.Name,
                                ShortName = x.TestGroupMaster.ShortName
                            },
                            Rate = (decimal)x.Rate,
                            IPPer1 = (decimal)x.IPPer1,
                            IPAmt1 = (decimal)x.IPAmt1,
                            documentType = x.documentType,
                            ColumnsNo = x.ColumnsNo,
                            GraphsType = x.GraphsType,
                            PPRate = (decimal)x.PPRate,
                            CCRate = (decimal)x.CCRate
                        }).ToListAsync();
            var resulttestdoc = await _applicationDbContext.TestDocMasterTable
                        .OrderBy(x => x.TestCode)
                        .Where(x => (cmpid > 0 ? x.CompId == cmpid : true)
                        && x.TestGroupId == resultx.TestGroupId)
                        .Select(x => new TestMasterViewModel()
                        {
                            Id = x.Id,
                            CompId = x.CompId,
                            TestCode = x.TestCode,
                            TestGroupId = x.TestGroupId,
                            TestGroupMasterViewModel = new TestGroupMasterViewModel()
                            {
                                Name = x.TestGroupMaster.Name,
                                ShortName = x.TestGroupMaster.ShortName
                            }
                        }).ToListAsync();
                    return countgroup < 2 ? resulttestdoc : result;
        }
        public async Task<int> GetAllTestMasterGroupTrueFalse(int cmpid, int testid)
        {
            int countgroup = 0;
            var resultx = await _applicationDbContext.TestMasterTable.FirstOrDefaultAsync(x => x.CompId == cmpid && x.Id == testid);
            if (resultx != null)
            {
                var resultxx = await _applicationDbContext.TestMasterTable.Where(x => x.CompId == cmpid && x.TestGroupId == resultx.TestGroupId).ToListAsync();
                countgroup = resultxx.Count();
            }

            return countgroup;
        }
        public async Task<List<TestMasterViewModel>> GetAllTestMasterCompany(int cmpid)
        {
            var result = await _applicationDbContext.TestMasterTable
                .OrderBy(x => x.TestCode)
                .Where(x => x.CompId == cmpid)
                .Select(x => new TestMasterViewModel()
                {
                    Id = x.Id,                  
                    TestCode = x.TestCode
                }).ToListAsync();
            return result;
        }
        public async Task<List<TestMasterViewModel>> GetAllTestMasterName(int cmpid, int rptid, string testname)
        {
            var result = await _applicationDbContext.TestMasterTable
                    .OrderBy(x => x.TestCode).OrderBy(X => X.TestGroupId)
                    .Where(x => x.CompId == cmpid && x.TestGroupId == rptid
                    && ((testname != null) ? x.TestCode.Contains(testname) : true))
                    .Select(x => new TestMasterViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        TestCode = x.TestCode,
                        ReportId = x.ReportId,
                        TestGroupId = x.TestGroupId,
                        Rate = (decimal)x.Rate,
                        IPPer1 = (decimal)x.IPPer1,
                        IPAmt1 = (decimal)x.IPAmt1,
                        documentType = x.documentType,
                        ColumnsNo = x.ColumnsNo,
                        GraphsType = x.GraphsType,
                        PPRate = (decimal)x.PPRate,
                        CCRate = (decimal)x.CCRate
                    }).ToListAsync();
            return result;
        }
        public async Task<List<TestRateDetailViewModel>> GetTestRateList(int cmpid)
        {

            var result = await _applicationDbContext.TestMasterTable
                .OrderBy(x => x.TestCode)
                .Where(x => x.CompId == cmpid)
                .Select(x => new TestRateDetailViewModel()
                {
                    Id = x.Id,
                    CompIdX = x.CompId,
                    TestCode = x.TestCode,
                    Rate = (decimal)x.Rate,
                    PPRate = (decimal)x.PPRate,
                    CCRate = (decimal)x.CCRate

                }).ToListAsync();
            List<TestRateDetailViewModel> list = new List<TestRateDetailViewModel>();
            int tmpno = 1;
            foreach (var item in result)
            {
                list.Add(new TestRateDetailViewModel()
                {
                    Id = item.Id,
                    CompIdX = item.CompIdX,
                    TestCode = item.TestCode,
                    Rate = item.Rate,
                    PPRate = item.PPRate,
                    CCRate = item.CCRate,
                    TempNo = tmpno
                });
                tmpno++;
            }
            return list;
        }
        public async Task<List<TestRateDetailViewModel>> GetTestRateList(int id,int cmpid)
        {
            
            var result = await _applicationDbContext.TestMasterTable
                .OrderBy(x => x.TestCode)
                .Where(x => x.TestGroupId == id && x.CompId == cmpid)
                .Select(x => new TestRateDetailViewModel()
                {
                    Id = x.Id,
                    CompIdX = x.CompId,
                    TestCode = x.TestCode,
                    Rate = (decimal)x.Rate,
                    PPRate = (decimal)x.PPRate,
                    CCRate = (decimal)x.CCRate
                }).ToListAsync();
            List<TestRateDetailViewModel> list = new List<TestRateDetailViewModel>();
            int tmpno = 1;
            foreach (var item in result)
            {
                list.Add(new TestRateDetailViewModel()
                {
                    Id = item.Id,
                    CompIdX = item.CompIdX,
                    TestCode = item.TestCode,
                    Rate = item.Rate,
                    PPRate = item.PPRate,
                    CCRate = item.CCRate,
                    TempNo = tmpno
                });
                tmpno++;
            }
            return list;
        }
        public async Task<bool> UpdateTestRateList(TestRateViewModel models)
        {
            
            foreach (var item in models.TestRateDetailViewModels)
            {
                var result1 = await _applicationDbContext.TestMasterTable.FirstOrDefaultAsync(x => x.Id == item.Id && x.CompId == models.CompId);
                if (result1 != null)
                {
                    //result1.Id = item.Id;                   
                    result1.Rate = item.Rate;
                    result1.PPRate = item.PPRate;
                    result1.CCRate = item.CCRate;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }               
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TestSubMasterTempNo()
        {
            var result = await _applicationDbContext.TestMasterTable.OrderBy(x => x.Id).ToListAsync();
            int tmpno = 1;
            foreach (var item in result)
            {
                tmpno = 1;
                var result1 = await _applicationDbContext.TestSubMasterTable.OrderBy(x => x.TempNo).Where(x => x.TestId == item.Id).ToListAsync();
                foreach (var itemx in result1)
                {
                    var result2 = await _applicationDbContext.TestSubMasterTable.FirstOrDefaultAsync(x => x.Id == itemx.Id && x.TestId == itemx.TestId);
                    if (result2 != null)
                    {
                        //result1.Id = item.Id;                   
                        result2.TempNo = tmpno;
                        _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _applicationDbContext.SaveChangesAsync();
                        tmpno++;
                    }
                }
            }            
            return true;
        }
        // Patient Master File
        public async Task<PatientIIViewModel> GetPatientMasterByMobileNo(string mobileno)
        {
            var result = await _applicationDbContext.PatientIITable
                    .Select(x => new PatientIIViewModel()
                    {
                        Id = x.Id,                        
                        TitleName = x.TitleName,
                        Name = x.Name,
                        Sex = (Gender)x.Sex,
                        Age = Convert.ToInt32(x.Age),
                        AgeType = x.AgeType,
                        Address = x.Address,
                        MobileNo = x.MobileNo,
                        EmailAddress = x.EmailAddress
                    }).FirstOrDefaultAsync(x => x.MobileNo == mobileno);
            return result;
        }
        public async Task<string> PatientSrNoCreation(int CmpId)
        {
            var NewNo = ""; var NewValue = 0; var splitChar = "";
            var result1 = await _applicationDbContext.CompanyDetailTable.Where(x => x.Id == CmpId).Select(x => new { x.TransCode }).FirstOrDefaultAsync();
            splitChar = result1.TransCode.Substring(3, 9) + "Z";
            var result = await _applicationDbContext.PatientTable
                          .OrderByDescending(x => x.Id)
                          .Where(x => x.CompId == CmpId)
                          .Select(x => new { x.VNo }).FirstOrDefaultAsync();

            if (result != null)
            {
                string parts1 = result.VNo.Substring(10, 7);
                NewValue = Convert.ToInt32(parts1) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 7 ? splitChar + myzerovch[CurrentIndex] + (NewValue) : splitChar + NewValue.ToString();
            }
            else
            {
                NewNo = splitChar + "0000001";
            }
            return NewNo;
        }
        public async Task<string> PatientRefCreation(int CmpId, string type, string dt1)
        {
            var NewNo = ""; var NewValue = 0; var splitChar = "";
            string[] MON1 = dt1.Split('/');
            splitChar = type;
            var pageresult = await _applicationDbContext.PageSetupTable.Where(x => x.CompId == CmpId).FirstOrDefaultAsync();
            if (pageresult.PatientRefNo == true && pageresult.PatientRefNoGroupwise == true)
            {
                var result = await _applicationDbContext.PatientTable
                              .OrderByDescending(x => x.Id)
                              .Where(x => x.CompId == CmpId && x.Type == type && x.SDate.Value.Year == Convert.ToInt32(MON1[2])
                              && x.SDate.Value.Month == Convert.ToInt32(MON1[1]) && x.SDate.Value.Day == Convert.ToInt32(MON1[0])
                              )
                              .Select(x => new { x.RefNo }).FirstOrDefaultAsync();


                if (result != null)
                {
                    string[] parts1 = result.RefNo.Split(type);
                    NewValue = Convert.ToInt32(parts1[1]) + 1;
                    CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                    NewNo = CurrentIndex < 4 ? splitChar + myzerothree[CurrentIndex] + (NewValue) : splitChar + NewValue.ToString();
                }
                else
                {
                    NewNo = splitChar + "0001";
                }
            }
            else if (pageresult.PatientRefNo == true && pageresult.PatientRefNoGroupwise != true)
            {
                var result = await _applicationDbContext.PatientTable
                                  .OrderByDescending(x => x.Id)
                                  .Where(x => x.CompId == CmpId)
                                  .Select(x => new { x.RefNo }).FirstOrDefaultAsync();


                if (result != null)
                {
                    string parts1 = result.RefNo;
                    NewValue = Convert.ToInt32(parts1) + 1;
                    CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                    NewNo = CurrentIndex < 8 ? myzerovch[CurrentIndex] + (NewValue) :  NewValue.ToString();
                }
                else
                {
                    NewNo = "0000001";
                }
            }
            return NewNo;
        }
        public async Task<int> PatientHeadDoctorId(string doctcode)
        {
            var result = await _applicationDbContext.HeadTable.Select(x => new { x.LedgerMasterId, x.LedCode }).FirstOrDefaultAsync(x => x.LedCode == doctcode);
            return ( result != null ? result.LedgerMasterId : 0);
        }
        public async Task<string> PatientHeadDoctorCode(int doctid)
        {
            var result = await _applicationDbContext.HeadTable.Select(x => new { x.LedgerMasterId, x.LedCode }).FirstOrDefaultAsync(x => x.LedgerMasterId == doctid);
            return result.LedCode;
        }
        public async Task<int> AddNewPatientMaster(PatientViewModel models)
        {
            var pageresult = await _applicationDbContext.PageSetupTable.Where(x => x.CompId == models.CompId).FirstOrDefaultAsync();
            string resultTest = "";
            foreach (var item in models.PatientDetailsMasterViewModels)
            {
                resultTest = resultTest + item.TestMasterViewModels.TestCode + ",";
            }
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(models.SDate))
            {
                userdt = models.SDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            if (!string.IsNullOrEmpty(models.RDate))
            {
                userdt = models.RDate.Split('/');
                userdt2 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }

            Patient opnitemMaster = new Patient()
            {
                CompId = models.CompId,
                UserCode = models.UserCode,
                VNo =  await PatientSrNoCreation(models.CompId),
                SDate = string.IsNullOrEmpty(models.SDate) ? Date1 : Convert.ToDateTime(userdt1),
                RDate = string.IsNullOrEmpty(models.RDate) ? Date1 : Convert.ToDateTime(userdt2),
                STime = models.STime,
                RTime = models.RTime,
                Type = models.Type,
                RefNo = pageresult.PatientRefNo != true && pageresult.PatientRefNoGroupwise != true ? models.RefNo : await PatientRefCreation(models.CompId,models.Type,models.SDate), //models.RefNo,
                TitleName = models.TitleName,
                Name = models.Name.ToUpper(),
                AdharNo = models.AdharNo,
                Sex = (int)models.Sex,
                Age = Convert.ToInt32(models.Age),
                AgeType = models.AgeType,
                Address = models.Address,
                MobileNo = models.MobileNo,
                EmailAddress = models.EmailAddress,
                EmailAuto = models.EmailAuto,
                PhoneNo = models.PhoneNo,                
                ClientCode = models.ClientCode,
                CollectedIn = models.CollectedIn,
                AgentAcCode = models.AgentAcCode,
                DrName= models.DrName,
                DoctorAcCode = models.DoctorAcCode,
                PaymentType = (int)models.PaymentType,
                TotalAmt = models.TotalAmt,
                TotalIPAmt = models.TotalIPAmt,
                DiscountReasion = models.DiscountReasion,
                ApprovalBy = models.ApprovalBy,
                DiscountType = models.DiscountType,
                DiscPer = models.DiscPer,
                DiscAmt = models.DiscAmt,
                AreaCode = models.AreaCode,
                CollectionCharge = models.CollectionCharge,
                CollectionBoy = models.CollectionBoy,
                DeliveryCharge = models.DeliveryCharge,
                DeliveryBoy = models.DeliveryBoy,
                PaidAmt = models.PaidAmt,
                BalAmt = models.BalAmt,
                TestDetailRecord = resultTest,
                Remark = models.Remark,
                ReportCancel = "False",
                ResultNotDone = "False",
                ResultDone = "False",
                ReportApproved = "False",
                ReportIssue = "False",
                ReportHold = "False",
                ReportRecipt = "False",
                ReportDispatch = "False",
                DispatchColorHold = "False",
                //DrLabId = models.DrLabId,
                EditUserCode = models.UserCode
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            int tmpNo = 1;
            foreach (var item in models.PatientDetailsMasterViewModels)
            {
                PatientDetailsMaster order = new PatientDetailsMaster()
                {
                    Mode = item.Mode,
                    TestId = item.TestId,
                    Rate = item.Rate,
                    StanderRate = item.StanderRate,
                    IPPer1 = item.IPPer1,
                    IPAmt1 = item.IPAmt1,
                    TempSrNo = tmpNo,
                    PtIMId = opnitemMaster.Id,
                    CompIdX = models.CompId,
                    UserCodeX = models.UserCode,
                    VNoX = models.VNo,
                    PrintTest = true
                };
                tmpNo++;
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in models.PatientDiscountMasterViewModels)
            {
                PatientDiscountMaster order = new PatientDiscountMaster()
                {
                    TestGId = item.TestGId,
                    DiscPer1 = item.DiscPer1,
                    DiscAmt1 = item.DiscAmt1,
                    PtIMId = opnitemMaster.Id,
                    CompIdX = models.CompId,
                    UserCodeX = models.UserCode,
                    VNoX = models.VNo
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            // Transfer Investigation Table          
             tmpNo = 1; //List<TestSubMasterViewModel> testSubMasterViewModels = new List<TestSubMasterViewModel>();
            foreach (var item in models.PatientDetailsMasterViewModels)
            {
                    List<TestSubMasterViewModel> detailViewModels = await TransferPatientTestInvestigation(models.SoftwareType == "ALL" ? 1 : models.CompId, item.TestId, models.AgeType, (int)models.Age, (((int)models.Sex) == 0 ? "M" : "F"));
                    foreach (var itemtest in detailViewModels)
                    {
                        PatientInvestigation order = new PatientInvestigation()
                        {
                            TestDetails = itemtest.TestDetails,
                            ColFirst = itemtest.ColFirst,
                            ColSecond = itemtest.ColSecond,
                            ColThird = itemtest.ColThird,
                            ColFourth = itemtest.ColFourth,
                            ColFifth = itemtest.ColFifth,
                            ColSixth = itemtest.ColSixth,
                            VisualTrueFalse = itemtest.VisualTrueFalse,
                            TestLocked = itemtest.TestLocked,
                            Gender = itemtest.Gender,
                            Units = itemtest.Units,
                            FromRange = itemtest.FromRange,
                            UptoRange = itemtest.UptoRange,
                            RangeSymble = itemtest.RangeSymble,
                            RangeDetails = itemtest.RangeDetails,
                            FromAge = (int)itemtest.FromAge,
                            UptoAge = (int)itemtest.UptoAge,
                            DefaultResult = itemtest.DefaultResult,
                            PatResult = itemtest.DefaultResult,
                            MiniRange = itemtest.MiniRange,
                            MaxRange = itemtest.MaxRange,
                            TempNo = tmpNo,
                            CompId = models.CompId,
                            TestIdX = item.TestId,
                            TestSubId = itemtest.Id,
                            PatientId = opnitemMaster.Id
                        };
                        tmpNo++;
                        _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                    await _applicationDbContext.SaveChangesAsync();                
            }
            return opnitemMaster.Id;
        }
        public async Task<bool> UpdatePatientMaster(PatientViewModel models)
        {
            string resultTest = "";
            foreach (var item in models.PatientDetailsMasterViewModels)
            {
                resultTest = resultTest + item.TestMasterViewModels.TestCode + ",";
            }
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(models.SDate))
            {
                userdt = models.SDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            if (!string.IsNullOrEmpty(models.RDate))
            {
                userdt = models.RDate.Split('/');
                userdt2 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.CompId = models.CompId;
                //result.UserCode = models.UserCode;
                result.VNo = models.VNo;
                result.SDate = string.IsNullOrEmpty(models.SDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.RDate = string.IsNullOrEmpty(models.RDate) ? Date1 : Convert.ToDateTime(userdt2);
                result.STime = models.STime;
                result.RTime = models.RTime;
                result.Type = models.Type;
                result.RefNo = models.RefNo;
                result.TitleName = models.TitleName;
                result.Name = models.Name.ToUpper();
                result.AdharNo = models.AdharNo;
                result.Sex = (int)models.Sex;
                result.Age = Convert.ToInt32(models.Age);
                result.AgeType = models.AgeType;
                result.Address = models.Address;
                result.MobileNo = models.MobileNo;
                result.EmailAddress = models.EmailAddress;
                result.EmailAuto = models.EmailAuto;
                result.PhoneNo = models.PhoneNo;
                result.ClientCode = models.ClientCode;
                result.CollectedIn = models.CollectedIn;
                result.AgentAcCode = models.AgentAcCode;
                result.DrName = models.DrName;
                result.DoctorAcCode = models.DoctorAcCode;
                result.PaymentType = (int)models.PaymentType;
                result.TotalAmt = models.TotalAmt;
                result.TotalIPAmt = models.TotalIPAmt;
                result.DiscountReasion = models.DiscountReasion;
                result.ApprovalBy = models.ApprovalBy;
                result.DiscountType = models.DiscountType;
                result.DiscPer = models.DiscPer;
                result.DiscAmt = models.DiscAmt;
                result.AreaCode = models.AreaCode;
                result.CollectionCharge = models.CollectionCharge;
                result.CollectionBoy = models.CollectionBoy;
                result.DeliveryCharge = models.DeliveryCharge;
                result.DeliveryBoy = models.DeliveryBoy;
                result.PaidAmt = models.PaidAmt;
                result.BalAmt = models.BalAmt;
                result.TestDetailRecord = resultTest;
                result.Remark = models.Remark;
                //result.DrLabId = models.DrLabId;
                result.EditUserCode = models.UserCode;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            int tmpNo = 1;
            foreach (var item in models.PatientDetailsMasterViewModels)
            {
                var result1 = await _applicationDbContext.PatientDetailsMasterTable.FirstOrDefaultAsync(x => x.TempSrNo == tmpNo && x.PtIMId == models.Id);
                if (result1 != null)
                {
                    result1.Mode = item.Mode;
                    result1.TestId = item.TestId;
                    result1.Rate = item.Rate;
                    result1.StanderRate = item.StanderRate;
                    result1.IPPer1 = item.IPPer1;
                    result1.IPAmt1 = item.IPAmt1;
                    result1.TempSrNo = tmpNo;
                    result1.PtIMId = models.Id;
                    result1.CompIdX = models.CompId;
                    result1.UserCodeX = models.UserCode;
                    result1.VNoX = models.VNo;
                    result1.PrintTest = true;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    PatientDetailsMaster order = new PatientDetailsMaster()
                    {
                        Mode = item.Mode,
                        TestId = item.TestId,
                        Rate = item.Rate,
                        StanderRate = item.StanderRate,
                        IPPer1 = item.IPPer1,
                        IPAmt1 = item.IPAmt1,
                        TempSrNo = tmpNo,
                        PtIMId = models.Id,
                        CompIdX = models.CompId,
                        UserCodeX = models.UserCode,
                        VNoX = models.VNo,
                        PrintTest =true
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                tmpNo++;
            }
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in models.PatientDiscountMasterViewModels)
            {
                var result1 = await _applicationDbContext.PatientDiscountMasterTable.FirstOrDefaultAsync(x => x.TestGId == item.TestGId && x.PtIMId == models.Id);
                if (result1 != null)
                {
                    result1.TestGId = item.TestGId;
                    result1.DiscPer1 = item.DiscPer1;
                    result1.DiscAmt1 = item.DiscAmt1;
                    result1.PtIMId = models.Id;
                    result1.CompIdX = models.CompId;
                    result1.UserCodeX = models.UserCode;
                    result1.VNoX = models.VNo;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    PatientDiscountMaster order = new PatientDiscountMaster()
                    {
                        TestGId = item.TestGId,
                        DiscPer1 = item.DiscPer1,
                        DiscAmt1 = item.DiscAmt1,
                        PtIMId = models.Id,
                        CompIdX = models.CompId,
                        UserCodeX = models.UserCode,
                        VNoX = models.VNo
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            // Transfer Investigation Table
             tmpNo = 1;
            foreach (var item in models.PatientDetailsMasterViewModels)
            {
                    List<TestSubMasterViewModel> testSubMasterViewModels = await TransferPatientTestInvestigation(models.SoftwareType == "ALL" ? 1 : models.CompId, item.TestId, models.AgeType, (int)models.Age, (((int)models.Sex).ToString() == "0" ? "M" : "F"));
                    foreach (var itemtest in testSubMasterViewModels)
                    {
                        var result3 = await _applicationDbContext.PatientInvestigationTable
                                    .FirstOrDefaultAsync(x => x.PatientId == models.Id && x.CompId == models.CompId
                                    && x.TestIdX == item.TestId && x.TestSubId == itemtest.Id);
                        if (result3 == null)
                        {
                            PatientInvestigation order = new PatientInvestigation()
                            {
                                TestDetails = itemtest.TestDetails,
                                ColFirst = itemtest.ColFirst,
                                ColSecond = itemtest.ColSecond,
                                ColThird = itemtest.ColThird,
                                ColFourth = itemtest.ColFourth,
                                ColFifth = itemtest.ColFifth,
                                ColSixth = itemtest.ColSixth,
                                VisualTrueFalse = itemtest.VisualTrueFalse,
                                TestLocked = itemtest.TestLocked,
                                Gender = itemtest.Gender,
                                Units = itemtest.Units,
                                FromRange = itemtest.FromRange,
                                UptoRange = itemtest.UptoRange,
                                RangeSymble = itemtest.RangeSymble,
                                RangeDetails = itemtest.RangeDetails,
                                FromAge = (int)itemtest.FromAge,
                                UptoAge = (int)itemtest.UptoAge,
                                DefaultResult = itemtest.DefaultResult,
                                PatResult = itemtest.DefaultResult,
                                MiniRange = itemtest.MiniRange,
                                MaxRange = itemtest.MaxRange,
                                TempNo = tmpNo,
                                CompId = models.CompId,
                                TestIdX = item.TestId,
                                TestSubId = itemtest.Id,
                                PatientId = models.Id
                            };
                            _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                        }
                        tmpNo++;
                    }
                    await _applicationDbContext.SaveChangesAsync();                
            }
            return true;
        }
        public async Task<bool> UpdatePatientDrInlabMaster(int id, int drId)
        {
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.DrLabId = drId;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePatientMasterCancel(int id,string canceltrufalse)
        {            
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.ReportCancel = canceltrufalse;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePatientMasterApproved(int id, string canceltrufalse)
        {
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.ReportApproved = canceltrufalse;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PatientMasterApproved(int id,string rptdate)
        {
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.ReportApproved = "True";
                result.ReportDate = rptdate;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePatientMasterIssue(int id, string canceltrufalse)
        {
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.ReportIssue = canceltrufalse;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePatientMasterHold(int id, string canceltrufalse)
        {
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.ReportHold = canceltrufalse;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePatientMasterRecipt(int id, string canceltrufalse)
        {
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.ReportRecipt = canceltrufalse;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePatientMasterDispatch(int id, string canceltrufalse)
        {
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.ReportDispatch = canceltrufalse;
                if (result.DispatchColorHold == "False" || result.DispatchColorHold == null)
                {
                    result.DispatchColorHold = "True";
                }
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<PatientViewModel> GetPatientMasterById(int id)
        {
            var result = await _applicationDbContext.PatientTable
                    .Select(x => new PatientViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        UserCode = x.UserCode,
                        VNo = x.VNo,
                        SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        STime = x.STime,
                        RTime = x.RTime,
                        Type = x.Type,
                        RefNo = x.RefNo,
                        TitleName = x.TitleName,
                        Name = x.Name,
                        AdharNo = x.AdharNo,
                        Sex = (Gender)x.Sex,
                        Age = Convert.ToInt32(x.Age),
                        AgeType = x.AgeType,
                        Address = x.Address,
                        MobileNo = x.MobileNo,
                        EmailAddress = x.EmailAddress,
                        EmailAuto = x.EmailAuto,
                        PhoneNo = x.PhoneNo,
                        ClientCode = x.ClientCode,
                        ClientFileViewModel = new ClientFileViewModel()
                        {
                            Id = x.PatientClientCode.Id,
                            Name = x.PatientClientCode.Name,
                            RegPanel = (PatientPanel)x.PatientClientCode.RegPanel                          
                        },
                        AgentAcCode = x.AgentAcCode,
                        DrName = x.DrName,
                        DoctorAcCode = x.DoctorAcCode,
                        LedgerMasterViewModel = new LedgerMasterViewModel()
                        {
                            LedCode = x.PatientDoctorAcCode.LedCode,
                            PartyName = x.PatientDoctorAcCode.PartyName + ' ' + x.PatientDoctorAcCode.Address3
                        },
                        PaymentType = (PayMode) x.PaymentType,
                        TotalAmt = x.TotalAmt,
                        TotalIPAmt = x.TotalIPAmt,
                        DiscountReasion = x.DiscountReasion,
                        ApprovalBy = x.ApprovalBy,
                        DiscountType = x.DiscountType,
                        DiscPer = Convert.ToDecimal(x.DiscPer),
                        DiscAmt = Convert.ToDecimal(x.DiscAmt),
                        AreaCode = x.AreaCode,
                        CollectionCharge = Convert.ToDecimal(x.CollectionCharge),
                        CollectionBoy = x.CollectionBoy,
                        DeliveryCharge = Convert.ToDecimal(x.DeliveryCharge),
                        DeliveryBoy = x.DeliveryBoy,
                        PaidAmt = x.PaidAmt,
                        BalAmt = x.BalAmt,
                        TestDetailRecord = x.TestDetailRecord,
                        Remark = x.Remark,
                        ReportDate = x.ReportDate,
                        ReportCancel = x.ReportCancel,
                        ResultNotDone = x.ResultNotDone,
                        ResultDone = x.ResultDone,
                        ReportApproved = x.ReportApproved,
                        ReportIssue = x.ReportIssue,
                        ReportHold = x.ReportHold,
                        ReportRecipt = x.ReportRecipt,
                        ReportDispatch = x.ReportDispatch,
                        DrLabId = x.DrLabId,
                        DoctorLabViewModel = new DoctorLabViewModel()
                        {
                            //Id = x.DoctorLab.Id,
                            //CompId = x.DoctorLab.CompId,
                            Name = x.DoctorLab.Name,
                            Address = x.DoctorLab.Address,
                            MobileNo = x.DoctorLab.MobileNo,
                            Eduction = x.DoctorLab.Education,
                            PrintReport = x.DoctorLab.PrintReport
                        },
                        PatientDetailsMasterViewModels = x.PatientDetailsMasters.Where(a => a.PtIMId == x.Id)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new PatientDetailsMasterViewModel()
                        {
                            Mode = n.Mode,
                            TestId = n.TestId,
                            TestMasterViewModels = new TestMasterViewModel()
                            {
                                TestCode = n.TestMaster.TestCode,
                                documentType = n.TestMaster.documentType
                            },
                            Rate = n.Rate,
                            StanderRate = n.StanderRate,
                            IPPer1 = n.IPPer1,
                            IPAmt1 = n.IPAmt1,
                            TempSrNo = (int)n.TempSrNo
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<PatientViewModel> GetPatientMasterByReportNo(string voucherno)
        {
            var result = await _applicationDbContext.PatientTable
                    .Select(x => new PatientViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        UserCode = x.UserCode,
                        VNo = x.VNo,
                        SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        STime = x.STime,
                        RTime = x.RTime,
                        Type = x.Type,
                        RefNo = x.RefNo,
                        TitleName = x.TitleName,
                        Name = x.Name,
                        Sex = (Gender)x.Sex,
                        Age = Convert.ToInt32(x.Age),
                        AgeType = x.AgeType,
                        Address = x.Address,
                        MobileNo = x.MobileNo,
                        EmailAddress = x.EmailAddress,
                        EmailAuto = x.EmailAuto,
                        PhoneNo = x.PhoneNo,
                        ClientCode = x.ClientCode,
                        AgentAcCode = x.AgentAcCode,
                        DrName = x.DrName,
                        DoctorAcCode = x.DoctorAcCode,
                        LedgerMasterViewModel = new LedgerMasterViewModel()
                        {
                            LedCode = x.PatientDoctorAcCode.LedCode,
                            PartyName = x.PatientDoctorAcCode.PartyName + ' ' + x.PatientDoctorAcCode.Address3
                        },
                        PaymentType = (PayMode)x.PaymentType,
                        TotalAmt = x.TotalAmt,
                        TotalIPAmt = x.TotalIPAmt,
                        DiscountReasion = x.DiscountReasion,
                        ApprovalBy = x.ApprovalBy,
                        DiscountType = x.DiscountType,
                        DiscPer = Convert.ToDecimal(x.DiscPer),
                        DiscAmt = Convert.ToDecimal(x.DiscAmt),
                        AreaCode = x.AreaCode,
                        CollectionCharge = Convert.ToDecimal(x.CollectionCharge),
                        CollectionBoy = x.CollectionBoy,
                        DeliveryCharge = Convert.ToDecimal(x.DeliveryCharge),
                        DeliveryBoy = x.DeliveryBoy,
                        PaidAmt = x.PaidAmt,
                        BalAmt = x.BalAmt,
                        TestDetailRecord = x.TestDetailRecord,
                        Remark = x.Remark,
                        ReportDate = x.ReportDate,
                        ReportCancel = x.ReportCancel,
                        ResultNotDone = x.ResultNotDone,
                        ResultDone = x.ResultDone,
                        ReportApproved = x.ReportApproved,
                        ReportIssue = x.ReportIssue,
                        ReportHold = x.ReportHold,
                        ReportRecipt = x.ReportRecipt,
                        ReportDispatch = x.ReportDispatch,
                        DrLabId = x.DrLabId,
                        PatientDetailsMasterViewModels = x.PatientDetailsMasters.Where(a => a.PtIMId == x.Id)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new PatientDetailsMasterViewModel()
                        {
                            Mode = n.Mode,
                            TestId = n.TestId,
                            TestMasterViewModels = new TestMasterViewModel()
                            {
                                TestCode = n.TestMaster.TestCode,
                                documentType = n.TestMaster.documentType
                            },
                            Rate = n.Rate,
                            StanderRate = n.StanderRate,
                            IPPer1 = n.IPPer1,
                            IPAmt1 = n.IPAmt1,
                            TempSrNo = (int)n.TempSrNo
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.VNo == voucherno);
            return result;
        }
        public async Task<bool> GetPatientMasterValidByReportNo(string voucherno)
        {
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(x => x.VNo == voucherno);
            return result != null ? true :false ;
        }
        public async Task<PatientViewModel> GetPatientMasterByVoucherNo(string id)
        {
            var result = await _applicationDbContext.PatientTable
                    .Select(x => new PatientViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        UserCode = x.UserCode,
                        VNo = x.VNo,
                        SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        STime = x.STime,
                        RTime = x.RTime,
                        Type = x.Type,
                        RefNo = x.RefNo,
                        TitleName = x.TitleName,
                        Name = x.Name,
                        AdharNo = x.AdharNo,
                        Sex = (Gender)x.Sex,
                        Age = Convert.ToInt32(x.Age),
                        AgeType = x.AgeType,
                        Address = x.Address,
                        MobileNo = x.MobileNo,
                        EmailAddress = x.EmailAddress,
                        EmailAuto = x.EmailAuto,
                        PhoneNo = x.PhoneNo,
                        ClientCode = x.ClientCode,
                        AgentAcCode = x.AgentAcCode,
                        DrName = x.DrName,
                        DoctorAcCode = x.DoctorAcCode,
                        LedgerMasterViewModel = new LedgerMasterViewModel()
                        {
                            LedCode = x.PatientDoctorAcCode.LedCode,
                            PartyName = x.PatientDoctorAcCode.PartyName + ' ' + x.PatientDoctorAcCode.Address3
                        },
                        PaymentType = (PayMode)x.PaymentType,
                        TotalAmt = x.TotalAmt,
                        TotalIPAmt = x.TotalIPAmt,
                        DiscountReasion = x.DiscountReasion,
                        ApprovalBy = x.ApprovalBy,
                        DiscountType = x.DiscountType,
                        DiscPer = Convert.ToDecimal(x.DiscPer),
                        DiscAmt = Convert.ToDecimal(x.DiscAmt),
                        AreaCode = x.AreaCode,
                        CollectionCharge = Convert.ToDecimal(x.CollectionCharge),
                        CollectionBoy = x.CollectionBoy,
                        DeliveryCharge = Convert.ToDecimal(x.DeliveryCharge),
                        DeliveryBoy = x.DeliveryBoy,
                        PaidAmt = x.PaidAmt,
                        BalAmt = x.BalAmt,
                        TestDetailRecord = x.TestDetailRecord,
                        Remark = x.Remark,
                        ReportDate = x.ReportDate,
                        ReportCancel = x.ReportCancel,
                        ResultNotDone = x.ResultNotDone,
                        ResultDone = x.ResultDone,
                        ReportApproved = x.ReportApproved,
                        ReportIssue = x.ReportIssue,
                        ReportHold = x.ReportHold,
                        ReportRecipt = x.ReportRecipt,
                        ReportDispatch = x.ReportDispatch,
                        DrLabId = x.DrLabId,
                        PatientDetailsMasterViewModels = x.PatientDetailsMasters.Where(a => a.PtIMId == x.Id)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new PatientDetailsMasterViewModel()
                        {
                            Mode = n.Mode,
                            TestId = n.TestId,
                            TestMasterViewModels = new TestMasterViewModel()
                            {
                                TestCode = n.TestMaster.TestCode
                            },
                            Rate = n.Rate,
                            StanderRate = n.StanderRate,
                            IPPer1 = n.IPPer1,
                            IPAmt1 = n.IPAmt1,
                            TempSrNo = (int)n.TempSrNo
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.VNo == id);
            return result;
        }
        public async Task<List<PatientDetailsMasterViewModel>> GetPatientDetailsById(int id)
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable
                    .OrderBy(x => x.TempSrNo).Where(x => x.PtIMId == id)
                    .Select(n => new PatientDetailsMasterViewModel()
                    {
                        Mode = n.Mode,
                        TestId = n.TestId,
                        TestMasterViewModels = new TestMasterViewModel()
                        {
                            TestCode = n.TestMaster.TestCode
                        },
                        Rate = n.Rate,
                        StanderRate = n.StanderRate,
                        IPPer1 = n.IPPer1,
                        IPAmt1 = n.IPAmt1,
                        TempSrNo = (int)n.TempSrNo
                    }).ToListAsync();
            return result;
        }
        public async Task<List<int>> GetPatientDetailsDiscountMasterById(int id, int cmdid, int testGroupid, string userid)
        {
            List<int> opnValue = new List<int>();
            var result = await _applicationDbContext.PatientDiscountMasterTable.Where(g => g.Id == id && g.CompIdX == cmdid && g.TestGId == testGroupid && g.UserCodeX == userid)
                                            .Select(g => new
                                            {
                                                g.DiscPer1,
                                                g.DiscAmt1
                                            }).FirstOrDefaultAsync();
            opnValue.Add(result != null ? Convert.ToInt32(result.DiscPer1) : 0);
            opnValue.Add(result != null ? Convert.ToInt32(result.DiscAmt1) : 0);
            return opnValue;
        }
        public async Task<bool> DeletePatientMaster(int id)
        {
            // await DeletePatientDetails(models.VNo, models.UserCode, models.CompId);
            var result2 = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeletePatientMasterOne(int id, int tno)
        {
            var result1 = await _applicationDbContext.PatientDetailsMasterTable.FirstOrDefaultAsync(x => x.TempSrNo == tno && x.PtIMId == id);
            if (result1.TestId > 0)
            {
                bool delingestigation = await DeletePatientInvesstigation(id, (int)result1.TestId);
            }
            if (result1 != null)
            {
                result1.PtIMId = id;
                result1.TempSrNo = tno;
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.PatientDetailsMasterTable.OrderBy(x => x.TempSrNo).Where(x => x.PtIMId == id).ToListAsync();
            foreach (var item in result2)
            {
                var result = await _applicationDbContext.PatientDetailsMasterTable.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (result != null)
                {
                    item.TempSrNo = No1;
                    _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                    No1++;
                }
            }
            return false;
        }
        public async Task<bool> DeletePatientDetails(string VchNo, string Userid, int? cmpid)
        {
            var result1 = await _applicationDbContext.PatientDetailsMasterTable.Where(x => x.VNoX == VchNo && x.UserCodeX == Userid && x.CompIdX == cmpid).OrderBy(x => x.Id).ToListAsync();
            foreach (var item in result1)
            {
                var result2 = await _applicationDbContext.PatientDetailsMasterTable.FirstOrDefaultAsync(x => x.VNoX == item.VNoX && x.UserCodeX == item.UserCodeX && x.CompIdX == item.CompIdX && x.TempSrNo == item.TempSrNo);
                if (result2 != null)
                {
                    result2.VNoX = item.VNoX;
                    result2.UserCodeX = item.UserCodeX;
                    result2.CompIdX = item.CompIdX;
                    _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _applicationDbContext.SaveChanges();
                }
            }
            return false;
        }
        public async Task<List<PatientViewModel>> PatientDoctorIPDateWise(int CmpId,int doctId, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.PatientTable
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                  && x.DoctorAcCode != null
                  && ( doctId > 0 ? x.DoctorAcCode == doctId : true )
                  && x.SDate >= dt1 && x.SDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.SDate).ThenBy(x => x.VNo)
                 .Select(x => new PatientViewModel()
                 {
                     Id = x.Id,
                     CompId = x.CompId,
                     UserCode = x.UserCode,
                     VNo = x.VNo,
                     SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     STime = x.STime,
                     RTime = x.RTime,
                     Type = x.Type,
                     RefNo = x.RefNo,
                     TitleName = x.TitleName,
                     Name = x.Name,
                     AdharNo = x.AdharNo,
                     Sex = (Gender)x.Sex,
                     Age = Convert.ToInt32(x.Age),
                     AgeType = x.AgeType,
                     Address = x.Address,
                     MobileNo = x.MobileNo,
                     EmailAddress = x.EmailAddress,
                     EmailAuto = x.EmailAuto,
                     PhoneNo = x.PhoneNo,
                     ClientCode = x.ClientCode,
                     AgentAcCode = x.AgentAcCode,
                     AgentFileViewModel = new AgentFileViewModel()
                     {
                         Name = x.PatientAgentAcCode.Name
                     },
                     DrName = x.DrName,
                     DoctorAcCode = x.DoctorAcCode,
                     LedgerMasterViewModel = new LedgerMasterViewModel()
                     {
                         PartyName = x.PatientDoctorAcCode.PartyName,
                         Address1 = x.PatientDoctorAcCode.Address1,
                         Address2 = x.PatientDoctorAcCode.Address2,
                         Address3 = x.PatientDoctorAcCode.Address3,
                     },
                     PaymentType = (PayMode)x.PaymentType,
                     TotalAmt = x.TotalAmt,
                     TotalIPAmt = x.TotalIPAmt,
                     DiscountReasion = x.DiscountReasion,
                     ApprovalBy = x.ApprovalBy,
                     DiscountType = x.DiscountType,
                     DiscPer = Convert.ToDecimal(x.DiscPer),
                     DiscAmt = Convert.ToDecimal(x.DiscAmt),
                     AreaCode = x.AreaCode,
                     CollectionCharge = x.CollectionCharge,
                     CollectionBoy = x.CollectionBoy,
                     DeliveryCharge = x.DeliveryCharge,
                     DeliveryBoy = x.DeliveryBoy,
                     PaidAmt = x.PaidAmt,
                     BalAmt = x.BalAmt,
                     TestDetailRecord = x.TestDetailRecord,
                     Remark = x.Remark,
                     ReportDate = x.ReportDate,
                     ReportCancel = x.ReportCancel,
                     ResultNotDone = x.ResultNotDone,
                     ResultDone = x.ResultDone,
                     ReportApproved = x.ReportApproved,
                     ReportIssue = x.ReportIssue,
                     ReportHold = x.ReportHold,
                     ReportRecipt = x.ReportRecipt,
                     ReportDispatch = x.ReportDispatch,
                     DrLabId = x.DrLabId,
                     DoctorLabViewModel = new DoctorLabViewModel()
                     {
                         //Id = x.DoctorLab.Id,
                         //CompId = x.DoctorLab.CompId,
                         Name = x.DoctorLab.Name,
                         Address = x.DoctorLab.Address,
                         MobileNo = x.DoctorLab.MobileNo,
                         Eduction = x.DoctorLab.Education,
                         PrintReport = x.DoctorLab.PrintReport
                     }
                 }).ToListAsync();
            return result;
        }
        public async Task<List<PatientViewModel>> SearchPatientMasterDateWise(int CmpId, string UCode,string patienttype, DateTime dt1, DateTime dt2)
        {          
            var result = await _applicationDbContext.PatientTable
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                  && (UCode != "0" && UCode != null ? x.UserCode == UCode : true)
                  &&(patienttype !="0" && patienttype != null ? x.Type == patienttype : true)
                  && x.SDate >= dt1 && x.SDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.SDate).ThenBy(x => x.VNo)
                 .Select(x => new PatientViewModel()
                 {
                     Id = x.Id,
                     CompId = x.CompId,
                     UserCode = x.UserCode,
                     VNo = x.VNo,
                     SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     STime = x.STime,
                     RTime = x.RTime,
                     Type = x.Type,
                     RefNo = x.RefNo,
                     TitleName = x.TitleName,
                     Name = x.Name,
                     AdharNo = x.AdharNo,
                     Sex = (Gender)x.Sex,
                     Age = Convert.ToInt32(x.Age),
                     AgeType = x.AgeType,
                     Address = x.Address,
                     MobileNo = x.MobileNo,
                     EmailAddress = x.EmailAddress,
                     EmailAuto = x.EmailAuto,
                     PhoneNo = x.PhoneNo,
                     ClientCode = x.ClientCode,
                     AgentAcCode = x.AgentAcCode,
                     AgentFileViewModel = new AgentFileViewModel()
                     {
                         Name = x.PatientAgentAcCode.Name
                     },
                     DrName = x.DrName,
                     DoctorAcCode = x.DoctorAcCode,
                     LedgerMasterViewModel = new LedgerMasterViewModel()
                     {
                         PartyName = x.PatientDoctorAcCode.PartyName,
                         Address1 = x.PatientDoctorAcCode.Address1,
                         Address2 = x.PatientDoctorAcCode.Address2,
                         Address3 = x.PatientDoctorAcCode.Address3,
                     },
                     PaymentType = (PayMode)x.PaymentType,
                     TotalAmt = x.TotalAmt,
                     TotalIPAmt = x.TotalIPAmt,
                     DiscountReasion = x.DiscountReasion,
                     ApprovalBy = x.ApprovalBy,
                     DiscountType = x.DiscountType,
                     DiscPer = Convert.ToDecimal(x.DiscPer),
                     DiscAmt = Convert.ToDecimal(x.DiscAmt),
                     AreaCode = x.AreaCode,
                     CollectionCharge = x.CollectionCharge,
                     CollectionBoy = x.CollectionBoy,
                     DeliveryCharge = x.DeliveryCharge,
                     DeliveryBoy = x.DeliveryBoy,
                     PaidAmt = x.PaidAmt,
                     BalAmt = x.BalAmt,
                     TestDetailRecord = x.TestDetailRecord,
                     Remark = x.Remark,
                     ReportDate = x.ReportDate,
                     ReportCancel = x.ReportCancel,
                     ResultNotDone = x.ResultNotDone,
                     ResultDone = x.ResultDone,
                     ReportApproved = x.ReportApproved,
                     ReportIssue = x.ReportIssue,
                     ReportHold = x.ReportHold,
                     ReportRecipt = x.ReportRecipt,
                     ReportDispatch = x.ReportDispatch,
                     DrLabId = x.DrLabId,
                     DoctorLabViewModel = new DoctorLabViewModel()
                     {
                         //Id = x.DoctorLab.Id,
                         //CompId = x.DoctorLab.CompId,
                         Name = x.DoctorLab.Name,
                         Address = x.DoctorLab.Address,
                         MobileNo = x.DoctorLab.MobileNo,
                         Eduction = x.DoctorLab.Education,
                         PrintReport = x.DoctorLab.PrintReport
                     }
                 }).ToListAsync();
            return result;
        }
        public async Task<List<PatientViewModel>> GetAllPatientMasterName(int cmpid, string UCode, string mobileno, int sexid,string type, string name,int age,string address, string emailaddress,int doctorid, DateTime FromDt, DateTime UptoDt,string paymentype,string paymentmode,int testdrId, bool datetrue, int clntId)
        {
            int paymode = 0;
            Boolean xx = int.TryParse(paymentmode, out paymode);
            var result = await _applicationDbContext.PatientTable
                    .OrderBy(x => x.SDate).ThenBy(x => x.RefNo)
                    .Where(x => (cmpid > 0 ? x.CompId == cmpid : true)
                    && ( UCode != "0" && UCode != null ? x.UserCode == UCode : true)
                    && ((mobileno != null) ? x.MobileNo.Contains(mobileno) : true)
                    && (sexid < 3 ? (x.Sex == Convert.ToInt32(sexid)) : true)
                    && (type != "ALL" ? x.TestDetailRecord.Contains(type) : true)
                    && ((name != null) ? x.Name.Contains(name) : true)
                    && (age > 0 ? x.Age == age :true)
                    && ((address != null) ? x.Address.Contains(address) : true)
                    && ((emailaddress != null) ? x.RefNo.Contains(emailaddress) : true)
                    && ( doctorid > 0 ? x.DoctorAcCode == doctorid :true )
                    && (datetrue == true ? (x.SDate >= FromDt && x.SDate <= UptoDt) : true)
                    && (paymentype == "C" ? x.ReportCancel == "True" : paymentype == "A" ? true : paymentype == "F" ? x.BalAmt == 0 : paymentype == "P" ? x.PaidAmt > 0 && x.BalAmt > 0 : paymentype == "U" ? x.PaidAmt == 0 : true)
                    && (paymentmode != "ALL"  ? x.PaymentType == paymode : true)
                    && (testdrId > 0 ? x.DrLabId == testdrId : true)
                    && (clntId > 0 ? x.ClientCode == clntId : true))
                .Select(x => new PatientViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    UserCode = x.UserCode,
                    VNo = x.VNo,
                    SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    STime = x.STime,
                    RTime = x.RTime,
                    Type = x.Type,
                    RefNo = x.RefNo,
                    TitleName = x.TitleName,
                    Name = x.Name,
                    AdharNo = x.AdharNo,
                    Sex = (Gender)x.Sex,
                    Age = Convert.ToInt32(x.Age),
                    AgeType = x.AgeType,
                    Address = x.Address,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    EmailAuto = x.EmailAuto,
                    PhoneNo = x.PhoneNo,
                    ClientCode = x.ClientCode,
                    AgentAcCode = x.AgentAcCode,
                    AgentFileViewModel = new AgentFileViewModel()
                    {
                        Name = x.PatientAgentAcCode.Name
                    },
                    DoctorAcCode = x.DoctorAcCode,
                    DrName = x.DrName,
                    LedgerMasterViewModel = new LedgerMasterViewModel()
                    {
                        PartyName = x.PatientDoctorAcCode.PartyName,
                        Address1 = x.PatientDoctorAcCode.Address1,
                        Address2 = x.PatientDoctorAcCode.Address2,
                        Address3 = x.PatientDoctorAcCode.Address3,
                    },
                    PaymentType = (PayMode)x.PaymentType,
                    TotalAmt = x.TotalAmt,
                    TotalIPAmt = x.TotalIPAmt,
                    DiscountReasion = x.DiscountReasion,
                    ApprovalBy = x.ApprovalBy,
                    DiscountType = x.DiscountType,
                    DiscPer = Convert.ToDecimal(x.DiscPer),
                    DiscAmt = Convert.ToDecimal(x.DiscAmt),
                    AreaCode = x.AreaCode,
                    CollectionCharge = x.CollectionCharge,
                    CollectionBoy = x.CollectionBoy,
                    DeliveryCharge = x.DeliveryCharge,
                    DeliveryBoy = x.DeliveryBoy,
                    PaidAmt = x.PaidAmt,
                    BalAmt = x.BalAmt,
                    TestDetailRecord = x.TestDetailRecord,
                    Remark = x.Remark,
                    ReportDate = x.ReportDate,
                    ReportCancel = x.ReportCancel,
                    ResultNotDone = x.ResultNotDone,
                    ResultDone = x.ResultDone,
                    ReportApproved = x.ReportApproved,
                    ReportIssue = x.ReportIssue,
                    ReportHold = x.ReportHold,
                    ReportRecipt = x.ReportRecipt,
                    ReportDispatch = x.ReportDispatch,
                    DrLabId = x.DrLabId,
                    DoctorLabViewModel = new DoctorLabViewModel()
                    {
                        //Id = x.DoctorLab.Id,
                        //CompId = x.DoctorLab.CompId,
                        Name = x.DoctorLab.Name,
                        Address = x.DoctorLab.Address,
                        MobileNo = x.DoctorLab.MobileNo,
                        Eduction = x.DoctorLab.Education,
                        PrintReport = x.DoctorLab.PrintReport
                    }
                }).ToListAsync();
            return result;
        }
        public async Task<List<PatientViewModel>> GetAllPatientMasterResultSearch(int cmpid, string UCode, string mobileno, int sexid, string type, string name, int age, string address, string emailaddress, int doctorid, DateTime FromDt, DateTime UptoDt, string paymentype, string paymentmode, int testdrId,bool datetrue,int clntId,string searchfilder)
        {
                    //&& (paymentype == "RND" ? x.ResultNotDone == true : true)
                    //&& (paymentype == "RD" ? x.ResultDone == true : true)
                    //&& (paymentype == "AP" ? x.ReportApproved == true : true)
                    //&& (paymentype == "IS" ? x.ReportIssue == true : true)
                    //&& (paymentype == "HO" ? x.ReportHold == true : true)
                    //&& (paymentype == "RE" ? x.ReportRecipt == true : true)
                    //&& (paymentype == "DI" ? x.ReportDispatch == true : true)

                    //&& (paymentype != "ALL" ? (paymentype == "RD" ? x.ResultDone == "True" : true) : true)
                    //&& (paymentype != "ALL" ? (paymentype == "AP" ? x.ReportApproved == "True" : true) : true)
                    //&& (paymentype != "ALL" ? (paymentype == "IS" ? x.ReportIssue == "True" : true) : true)
                    //&& (paymentype != "ALL" ? (paymentype == "HO" ? x.ReportHold == "True" : true) : true)
                    //&& (paymentype != "ALL" ? (paymentype == "RE" ? x.ReportRecipt == "True" : true) : true)
                    //&& (paymentype != "ALL" ? (paymentype == "DI" ? x.ReportDispatch == "True" : true) : true)

            int paymode = 0;             
            Boolean xx = int.TryParse(paymentmode, out paymode);
            var result = await _applicationDbContext.PatientTable
                    .OrderBy(x => x.SDate).ThenBy(x => x.RefNo)
                    .Where(x => (cmpid > 0 ? x.CompId == cmpid : true)
                    && (UCode != "ALL" && UCode != null ? x.UserCode == UCode : true)                    
                    && (mobileno != null ? x.MobileNo.Contains(mobileno) : true)
                    && (sexid < 3 ? x.Sex == Convert.ToInt32(sexid) : true)
                    && (type != "ALL" && searchfilder == "Yes" ? x.TestDetailRecord.Contains(type) : (searchfilder == "Yes" && type == "ALL" ? true : x.TestDetailRecord.Contains("00")))
                    && (name != null ? x.Name.Contains(name) : true)
                    && (age > 0 ? x.Age == age : true)
                    && (address != null ? x.Address.Contains(address) : true)
                    && (emailaddress != null ? x.RefNo.Contains(emailaddress) : true)
                    && (doctorid > 0 ? x.DoctorAcCode == doctorid : true)
                    && (datetrue == true ? (x.SDate >= FromDt && x.SDate <= UptoDt) : true)
                    && (paymentype != "ALL" && paymentype != null ? (paymentype == "RND" ? x.ResultNotDone != "True" : (paymentype == "RD" ? x.ResultDone == "True" && x.ReportApproved != "True" : (paymentype == "AP" ? x.ReportApproved == "True" : (paymentype == "IS" ? x.ReportIssue == "True" : (paymentype == "HO" ? x.ReportHold == "True" : (paymentype == "RE" ? x.ReportRecipt == "True" : (paymentype == "DI" ? x.DispatchColorHold == "True" : true))))))) : true)
                    && (paymentmode != "ALL" ?   x.PaymentType == Convert.ToInt32(paymentmode) : true)                    
                    && (testdrId > 0 ? x.DrLabId == testdrId : true)
                    && (clntId > 0 ? x.ClientCode == clntId : true))                    
                .Select(x => new PatientViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    UserCode = x.UserCode,
                    VNo = x.VNo,
                    SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    STime = x.STime,
                    RTime = x.RTime,
                    Type = x.Type,
                    RefNo = x.RefNo,
                    TitleName = x.TitleName,
                    Name = x.Name,
                    AdharNo = x.AdharNo,
                    Sex = (Gender)x.Sex,
                    Age = Convert.ToInt32(x.Age),
                    AgeType = x.AgeType,
                    Address = x.Address,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    EmailAuto = x.EmailAuto,
                    PhoneNo = x.PhoneNo,
                    ClientCode = x.ClientCode,
                    AgentAcCode = x.AgentAcCode,
                    AgentFileViewModel = new AgentFileViewModel()
                    {
                        Name = x.PatientAgentAcCode.Name
                    },
                    DrName = x.DrName,
                    DoctorAcCode = x.DoctorAcCode,
                    LedgerMasterViewModel = new LedgerMasterViewModel()
                    {
                        PartyName = x.PatientDoctorAcCode.PartyName,
                        Address1 = x.PatientDoctorAcCode.Address1,
                        Address2 = x.PatientDoctorAcCode.Address2,
                        Address3 = x.PatientDoctorAcCode.Address3,
                    },
                    PaymentType = (PayMode)x.PaymentType,
                    TotalAmt = x.TotalAmt,
                    TotalIPAmt = x.TotalIPAmt,
                    DiscountReasion = x.DiscountReasion,
                    ApprovalBy = x.ApprovalBy,
                    DiscountType = x.DiscountType,
                    DiscPer = Convert.ToDecimal(x.DiscPer),
                    DiscAmt = Convert.ToDecimal(x.DiscAmt),
                    AreaCode = x.AreaCode,
                    CollectionCharge = x.CollectionCharge,
                    CollectionBoy = x.CollectionBoy,
                    DeliveryCharge = x.DeliveryCharge,
                    DeliveryBoy = x.DeliveryBoy,
                    PaidAmt = x.PaidAmt,
                    BalAmt = x.BalAmt,
                    TestDetailRecord = x.TestDetailRecord,
                    Remark = x.Remark,
                    ReportDate = x.ReportDate,
                    ReportCancel = x.ReportCancel,
                    ResultNotDone = x.ResultNotDone,
                    ResultDone = x.ResultDone,
                    ReportApproved = x.ReportApproved,
                    ReportIssue = x.ReportIssue,
                    ReportHold = x.ReportHold,
                    ReportRecipt = x.ReportRecipt,
                    ReportDispatch = x.ReportDispatch,
                    DispatchColorHold = x.DispatchColorHold,
                    DrLabId = x.DrLabId,
                    DoctorLabViewModel = new DoctorLabViewModel()
                    {
                        //Id = x.DoctorLab.Id,
                        //CompId = x.DoctorLab.CompId,
                        Name = x.DoctorLab.Name,
                        Address = x.DoctorLab.Address,
                        MobileNo = x.DoctorLab.MobileNo,
                        Eduction = x.DoctorLab.Education,
                        PrintReport = x.DoctorLab.PrintReport
                    }
                }).ToListAsync();
            return result;
        }
        public async Task<List<PatientViewModel>> GetAllPatientMasterResultSearchDispatch(int cmpid)
        {
            var result = await _applicationDbContext.PatientTable
                    .OrderBy(x => x.SDate).ThenBy(x => x.RefNo)
                    .Where(x => (cmpid > 0 ? x.CompId == cmpid : true)
                    && ( x.ResultDone == "True")
                    && ( x.ReportApproved == "True")
                    && ( x.ReportDispatch == "True"))
                .Select(x => new PatientViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    UserCode = x.UserCode,
                    VNo = x.VNo,
                    SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    STime = x.STime,
                    RTime = x.RTime,
                    Type = x.Type,
                    RefNo = x.RefNo,
                    TitleName = x.TitleName,
                    Name = x.Name,
                    AdharNo = x.AdharNo,
                    Sex = (Gender)x.Sex,
                    Age = Convert.ToInt32(x.Age),
                    AgeType = x.AgeType,
                    Address = x.Address,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    EmailAuto = x.EmailAuto,
                    PhoneNo = x.PhoneNo,
                    ClientCode = x.ClientCode,
                    AgentAcCode = x.AgentAcCode,
                    AgentFileViewModel = new AgentFileViewModel()
                    {
                        Name = x.PatientAgentAcCode.Name
                    },
                    DrName = x.DrName,
                    DoctorAcCode = x.DoctorAcCode,
                    LedgerMasterViewModel = new LedgerMasterViewModel()
                    {
                        PartyName = x.PatientDoctorAcCode.PartyName,
                        Address1 = x.PatientDoctorAcCode.Address1,
                        Address2 = x.PatientDoctorAcCode.Address2,
                        Address3 = x.PatientDoctorAcCode.Address3,
                    },
                    PaymentType = (PayMode)x.PaymentType,
                    TotalAmt = x.TotalAmt,
                    TotalIPAmt = x.TotalIPAmt,
                    DiscountReasion = x.DiscountReasion,
                    ApprovalBy = x.ApprovalBy,
                    DiscountType = x.DiscountType,
                    DiscPer = Convert.ToDecimal(x.DiscPer),
                    DiscAmt = Convert.ToDecimal(x.DiscAmt),
                    AreaCode = x.AreaCode,
                    CollectionCharge = x.CollectionCharge,
                    CollectionBoy = x.CollectionBoy,
                    DeliveryCharge = x.DeliveryCharge,
                    DeliveryBoy = x.DeliveryBoy,
                    PaidAmt = x.PaidAmt,
                    BalAmt = x.BalAmt,
                    TestDetailRecord = x.TestDetailRecord,
                    Remark = x.Remark,
                    ReportDate = x.ReportDate,
                    ReportCancel = x.ReportCancel,
                    ResultNotDone = x.ResultNotDone,
                    ResultDone = x.ResultDone,
                    ReportApproved = x.ReportApproved,
                    ReportIssue = x.ReportIssue,
                    ReportHold = x.ReportHold,
                    ReportRecipt = x.ReportRecipt,
                    ReportDispatch = x.ReportDispatch,
                    DrLabId = x.DrLabId,
                    DoctorLabViewModel = new DoctorLabViewModel()
                    {
                        //Id = x.DoctorLab.Id,
                        //CompId = x.DoctorLab.CompId,
                        Name = x.DoctorLab.Name,
                        Address = x.DoctorLab.Address,
                        MobileNo = x.DoctorLab.MobileNo,
                        Eduction = x.DoctorLab.Education,
                        PrintReport = x.DoctorLab.PrintReport
                    },
                    PatientDetailsMasterViewModels = x.PatientDetailsMasters.Where(a => a.PtIMId == x.Id)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new PatientDetailsMasterViewModel()
                        {
                            Mode = n.Mode,
                            TestId = n.TestId,
                            TestMasterViewModels = new TestMasterViewModel()
                            {
                                TestCode = n.TestMaster.TestCode,
                                documentType = n.TestMaster.documentType
                            },
                            Rate = n.Rate,
                            StanderRate = n.StanderRate,
                            IPPer1 = n.IPPer1,
                            IPAmt1 = n.IPAmt1,
                            TempSrNo = (int)n.TempSrNo
                        }).ToList()
                }).ToListAsync();
            var resut1 = result.Select(x => x.Id).ToList();
            foreach (var item in resut1)
            {
                var result2 = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(x => x.Id == Convert.ToInt32(item));
                if (result2 != null)
                {
                    result2.DispatchColorHold = "True";
                    result2.ReportDispatch = "False";
                    _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _applicationDbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        public async Task<bool> UpdateAllPatientMasterResultApproved(int cmpid, string UCode, string mobileno, int sexid, string name, int age, string address, string emailaddress, int doctorid, DateTime FromDt, DateTime UptoDt)
        {
            var result = await _applicationDbContext.PatientTable
                    .OrderBy(x => x.SDate).ThenBy(x => x.RefNo)
                    .Where(x => (cmpid > 0 ? x.CompId == cmpid : true)
                    && (UCode != "0" && UCode != null ? x.UserCode == UCode : true)
                    && ((mobileno != null) ? x.MobileNo.Contains(mobileno) : true)
                    && (sexid < 3 ? (x.Sex == Convert.ToInt32(sexid)) : true)
                    && ((name != null) ? x.Name.Contains(name) : true)
                    && (age > 0 ? x.Age == age : true)
                    && ((address != null) ? x.Address.Contains(address) : true)
                    && ((emailaddress != null) ? x.EmailAddress.Contains(emailaddress) : true)
                    && (doctorid > 0 ? x.DoctorAcCode == doctorid : true)
                    && (x.SDate >= FromDt && x.SDate <= UptoDt))
                .Select(x => new PatientViewModel()
                {
                    Id = x.Id,                    
                }).ToListAsync();
            foreach (var item in result)
            {
                var result1 = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(n => n.Id == item.Id);
                if (result1 != null)
                {
                    result1.Id = item.Id;
                    result1.ReportApproved = "True";
                };
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _applicationDbContext.SaveChangesAsync();
            }
            return true;
        }
        public async Task<List<PatientViewModel>> GetPatientDateWise(int cmpid, string UCode, string patienttype, int AgentId, int DoctorId, DateTime FromDt, DateTime UptoDt, string paymentmode, int testdrId)
        {
            int paymode = 0;
            Boolean xx = int.TryParse(paymentmode, out paymode);
            var result = await _applicationDbContext.PatientTable
                    .OrderBy(x => x.SDate).ThenBy(x => x.RefNo)
                    .Where(x => (cmpid > 0 ? x.CompId == cmpid : true )
                    && (UCode != "ALL"   ? x.UserCode == UCode : true )
                    && (patienttype != "0" && patienttype != null ? x.Type == patienttype : true)
                    && x.SDate >= FromDt && x.SDate <= UptoDt
                    && ((AgentId  > 0) ? x.AgentAcCode == AgentId : true)
                    && ((DoctorId > 0 ) ? x.DoctorAcCode == DoctorId : true)
                    && (paymentmode != "ALL" ? x.PaymentType == paymode : true)
                    && (testdrId > 0 ? x.DrLabId == testdrId : true))
                .Select(x => new PatientViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    UserCode = x.UserCode,
                    VNo = x.VNo,
                    SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    STime = x.STime,
                    RTime = x.RTime,
                    Type = x.Type,
                    RefNo = x.RefNo,
                    TitleName = x.TitleName,
                    Name = x.Name,
                    AdharNo = x.AdharNo,
                    Sex = (Gender)x.Sex,
                    Age = Convert.ToInt32(x.Age),
                    AgeType = x.AgeType,
                    Address = x.Address,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    EmailAuto = x.EmailAuto,
                    PhoneNo = x.PhoneNo,
                    ClientCode = x.ClientCode,
                    AgentAcCode = x.AgentAcCode,
                    AgentFileViewModel = new AgentFileViewModel()
                    {
                        Name = x.PatientAgentAcCode.Name,
                        Address1 = x.PatientAgentAcCode.Address1,
                        City = x.PatientAgentAcCode.City,
                        PinNo = x.PatientAgentAcCode.PinNo,
                        MobileNo = x.PatientAgentAcCode.MobileNo,
                        EmailAddress = x.PatientAgentAcCode.EmailAddress,
                        IPAmt1 = x.PatientAgentAcCode.IPAmt1
                    },
                    DrName = x.DrName,
                    DoctorAcCode = x.DoctorAcCode,
                    LedgerMasterViewModel = new LedgerMasterViewModel()
                    {
                        PartyName = x.PatientDoctorAcCode.PartyName,
                        Address1 = x.PatientDoctorAcCode.Address1,
                        Address2 = x.PatientDoctorAcCode.Address2,
                        Address3 = x.PatientDoctorAcCode.Address3,
                        MobileNo1 = x.PatientDoctorAcCode.MobileNo1
                    },
                    PaymentType = (PayMode)x.PaymentType,
                    TotalAmt = x.TotalAmt,
                    TotalIPAmt = x.TotalIPAmt,
                    DiscountReasion = x.DiscountReasion,
                    ApprovalBy = x.ApprovalBy,
                    DiscountType = x.DiscountType,
                    DiscPer = Convert.ToDecimal(x.DiscPer),
                    DiscAmt = Convert.ToDecimal(x.DiscAmt),
                    AreaCode = x.AreaCode,
                    CollectionCharge = x.CollectionCharge,
                    CollectionBoy = x.CollectionBoy,
                    DeliveryCharge = x.DeliveryCharge,
                    DeliveryBoy = x.DeliveryBoy,
                    PaidAmt = x.PaidAmt,
                    BalAmt = x.BalAmt,
                    TestDetailRecord = x.TestDetailRecord,
                    Remark = x.Remark,
                    ReportDate = x.ReportDate,
                    ReportCancel = x.ReportCancel,
                    ResultNotDone = x.ResultNotDone,
                    ResultDone = x.ResultDone,
                    ReportApproved = x.ReportApproved,
                    ReportIssue = x.ReportIssue,
                    ReportHold = x.ReportHold,
                    ReportRecipt = x.ReportRecipt,
                    ReportDispatch = x.ReportDispatch,
                    DrLabId = x.DrLabId,
                    DoctorLabViewModel = new DoctorLabViewModel()
                    {
                        //Id = x.DoctorLab.Id,
                        //CompId = x.DoctorLab.CompId,
                        Name = x.DoctorLab.Name,
                        Address = x.DoctorLab.Address,
                        MobileNo = x.DoctorLab.MobileNo,
                        Eduction = x.DoctorLab.Education,
                        PrintReport = x.DoctorLab.PrintReport
                    }
                }).ToListAsync();
            return result;
        }
        public async Task<List<PatientViewModel>> GetPatientDateTestWise(int cmpid, string UCode, DateTime FromDt, DateTime UptoDt)
        {            
            var result = await _applicationDbContext.PatientTable
                    .OrderBy(x => x.SDate).ThenBy(x => x.RefNo)
                    .Where(x => (cmpid > 0 ? x.CompId == cmpid : true)
                    && (UCode != "ALL" ? x.UserCode == UCode : true)
                    && x.SDate >= FromDt && x.SDate <= UptoDt)
                .Select(x => new PatientViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    UserCode = x.UserCode,
                    VNo = x.VNo,
                    SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null)
                }).ToListAsync();
            return result;
        }
        public async Task<List<PatientDetailsMasterViewModel>> GetPatientDateTestGroup(int mainId,int TestGroupId, int TestId)
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable.OrderBy(a => a.TempSrNo)
                        .Where(a => (TestGroupId > 0 ? a.TestMaster.TestGroupId == TestGroupId : true)
                        && (TestId > 0 ? a.TestId == TestId : true)
                        && a.PtIMId == mainId)
                        .Select(n => new PatientDetailsMasterViewModel()
                        {
                            Mode = n.Mode,
                            TestGId = Convert.ToInt32(n.TestMaster.TestGroupId),
                            TestId = n.TestId,
                            TestMasterViewModels = new TestMasterViewModel()
                            {
                                TestCode = n.TestMaster.TestCode
                            },
                            Rate = n.Rate,
                            StanderRate = n.StanderRate,
                            IPPer1 = n.IPPer1,
                            IPAmt1 = n.IPAmt1,
                            TempSrNo = (int)n.TempSrNo
                        }).ToListAsync();
            return result;
        }
        public async Task<List<int>> GetDetailsPatientDiscountMasterById(int id, int cmdid, int testGroupid)
        {
            List<int> opnValue = new List<int>();
            var result = await _applicationDbContext.PatientDiscountMasterTable.Where(g => g.PtIMId == id && g.CompIdX == cmdid && g.TestGId == testGroupid)
                                            .Select(g => new
                                            {
                                                g.DiscPer1,
                                                g.DiscAmt1
                                            }).FirstOrDefaultAsync();
            opnValue.Add(result != null ? Convert.ToInt32(result.DiscPer1) : 0);
            opnValue.Add(result != null ? Convert.ToInt32(result.DiscAmt1) : 0);
            return opnValue;
        }
        public async Task<List<TestSubMasterViewModel>> TransferPatientTestInvestigation(int cmpid, int testid, string ageType, int patAge, string sexa)
        {
            var result = await _applicationDbContext.TestSubMasterTable.OrderBy(x => x.TempNo)
                          .Where(x => x.CompId == cmpid && x.TestId == testid && (x.AgeType == "A" || x.AgeType == ageType)
                          && x.FromAge <= patAge && x.UptoAge >= patAge && (x.Gender == "A" || x.Gender == sexa))
                          .Select(n => new TestSubMasterViewModel()
                          {
                              Id = n.Id,
                              TestId = n.TestId,
                              TestDetails = n.TestDetails,
                              ColFirst = n.ColFirst,
                              ColSecond = n.ColSecond,
                              ColThird = n.ColThird,
                              ColFourth = n.ColFourth,
                              ColFifth = n.ColFifth,
                              ColSixth = n.ColSixth,
                              VisualTrueFalse = n.VisualTrueFalse,
                              TestLocked = n.TestLocked,
                              Gender = n.Gender,
                              Units = n.Units,
                              FromRange = n.FromRange,
                              UptoRange = n.UptoRange,
                              RangeSymble = n.RangeSymble,
                              RangeDetails = n.RangeDetails,
                              FromAge = n.FromAge,
                              UptoAge = n.UptoAge,
                              DefaultResult = n.DefaultResult,
                              MiniRange = n.MiniRange,
                              MaxRange = n.MaxRange,
                              TempNo = (int)n.TempNo,
                              CompId = n.CompId
                          }).ToListAsync();
            return result;
        }
        public async Task<bool> DeletePatientInvesstigation(int id, int testid)
        {
            // await DeletePatientDetails(models.VNo, models.UserCode, models.CompId);
            var result = await _applicationDbContext.PatientInvestigationTable.Where(x => x.PatientId == id && x.TestIdX == testid).ToListAsync();
            foreach (var item in result)
            {
                var result2 = await _applicationDbContext.PatientInvestigationTable.FirstOrDefaultAsync(x => x.PatientId == id && x.TestIdX == testid && x.TempNo == item.TempNo);
                if (result2 != null)
                {
                    _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _applicationDbContext.SaveChanges();
                }
            }
            return false;
        }
        public async Task<List<PatientInvestigationViewModel>> GetPatientTestInvestigation(int PatId, int testid)
        {
            //  .Where(x => x.PatientId == PatId && x.TestIdX == testid && x.VisualTrueFalse == true)
            var result = await _applicationDbContext.PatientInvestigationTable.OrderBy(x => x.TestMaster.ReportGroup.TempNo).ThenBy(x => x.TempNo) .ThenBy(x => x.Id) // Before kiya tha order by x.testsubid
                          .Where(x => x.PatientId == PatId && x.TestMaster.TestGroupMaster.Id == testid && x.VisualTrueFalse == true)
                          .Select(n => new PatientInvestigationViewModel()
                          {
                              TestSubId = n.TestSubId,
                              TestIdX = n.TestIdX,
                              TestDetails = n.TestDetails,
                              TestDetailsF = n.TestDetails.ToUpper(),
                              ColFirst = n.ColFirst,
                              ColSecond = n.ColSecond,
                              ColThird = n.ColThird,
                              ColFourth = n.ColFourth,
                              ColFifth = n.ColFifth,
                              ColSixth = n.ColSixth,
                              VisualTrueFalse = n.VisualTrueFalse,
                              TestLocked = n.TestLocked,
                              Gender = n.Gender,
                              Units = n.Units,
                              FromRange = n.FromRange,
                              UptoRange = n.UptoRange,
                              RangeSymble = n.RangeSymble,
                              RangeDetails = n.RangeDetails,
                              FromAge = n.FromAge,
                              UptoAge = n.UptoAge,
                              PatResult = n.PatResult,
                              DefaultResult = n.DefaultResult,
                              MiniRange = n.MiniRange,
                              MaxRange = n.MaxRange,
                              TempNo = (int)n.TempNo,
                              TempDigitPlace = (n.UptoRange != null ? n.UptoRange.Contains('.')  ? (n.UptoRange.Substring(n.UptoRange.LastIndexOf('.') + 1)).Count().ToString() : "1" : "1" ),
                              CompId = n.CompId,
                              TestMasterViewModels = new TestMasterViewModel()
                              {
                                  TestCode = n.TestMaster.TestCode
                              }
                          }).ToListAsync();

            //  n.UptoRange.Substring(n.UptoRange.LastIndexOf('.') + 1)
            return result;
        }
        public async Task<bool> UpdatePatientInvestigation(TempResultViewFile model)
        {
            foreach (var item in model.PatientInvestigationViewModels)
            {
                var result = await _applicationDbContext.PatientInvestigationTable.FirstOrDefaultAsync(x => x.PatientId == model.PatientId && x.TestIdX == item.TestIdX && x.TestSubId == item.TestSubId);
                if (result != null)
                {
                    result.TestDetails = model.DocType == "Reading" ? item.TestDetails : model.TestDocumentain;
                    result.PatResult = item.PatResult;
                }
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<PatientDetailsMasterViewModel>> GetPatientTestDetails(int PatId, int compid, string rpttype) // RptType Reading/Document
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable.OrderBy(x => x.Id)
                          .Where(x => x.PtIMId == PatId && x.CompIdX == compid && x.TestMaster.documentType == rpttype)
                          .Select(n => new PatientDetailsMasterViewModel()
                          {
                              Id = n.Id,
                              TestId = n.TestId,
                              TestMasterViewModels = new TestMasterViewModel()
                              {
                                  TestCode = n.TestMaster.TestCode
                              },
                              isSelected = n.PrintTest,
                              TempSrNo = n.TempSrNo
                          }).ToListAsync();
            return result;
        }
        public async Task<List<PatientDetailsMasterViewModel>> GetPatientTestGroupDetails(int PatId, int compid,string rpttype) // RptType Reading/Document
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable.OrderBy(x => x.Id)
                          .Where(x => x.PtIMId == PatId && x.CompIdX == compid && x.TestMaster.documentType == rpttype)
                          .Select(n => new PatientDetailsMasterViewModel()
                          {
                              Id = n.Id,
                              TestId = n.TestId,
                              TestMasterViewModels = new TestMasterViewModel()
                              {
                                  TestCode = n.TestMaster.TestCode,
                                  TestGroupId = n.TestMaster.TestGroupId,
                                  TestGroupMasterViewModel = new TestGroupMasterViewModel()
                                  {
                                      Id = n.TestMaster.TestGroupMaster.Id,
                                      Name = n.TestMaster.TestGroupMaster.Name
                                  }
                              },
                              isSelected = n.PrintTest,
                              TempSrNo = n.TempSrNo
                          }).ToListAsync();
            var groupbyundertest = result.GroupBy(x => new { x.TestMasterViewModels.TestGroupMasterViewModel.Id,x.TestMasterViewModels.TestGroupMasterViewModel.Name });
            List<PatientDetailsMasterViewModel> itemlist = new List<PatientDetailsMasterViewModel>();
            int tmpno = 1;
            foreach (var item in groupbyundertest)
            {
                itemlist.Add(new PatientDetailsMasterViewModel()
                {
                    Id = item.Key.Id,
                    TestMasterViewModels = new TestMasterViewModel()
                    {
                        TestCode = item.Key.Name
                    },
                   TempSrNo = tmpno
                });
                tmpno++;
            }
            return itemlist;
        }

        public async Task<List<PatientDetailsMasterViewModel>> GetPatientTestDetails(int PatId, int compid, string rpttype,string rpttype2) // RptType Reading/Document
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable.OrderBy(x => x.Id)
                          .Where(x => x.PtIMId == PatId && x.CompIdX == compid && ( x.TestMaster.documentType == rpttype || x.TestMaster.documentType == rpttype2))
                          .Select(n => new PatientDetailsMasterViewModel()
                          {
                              Id = n.Id,
                              TestId = n.TestId,
                              TestMasterViewModels = new TestMasterViewModel()
                              {
                                  TestCode = n.TestMaster.TestCode
                              },
                              isSelected = n.PrintTest,
                              TempSrNo = n.TempSrNo
                          }).ToListAsync();
            return result;
        }
        public async Task<List<PatientDetailsMasterViewModel>> GetPatientTestGroupDetails(int PatId, int compid, string rpttype, string rpttype2) // RptType Reading/Document
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable.OrderBy(x => x.Id)
                          .Where(x => x.PtIMId == PatId && x.CompIdX == compid && ( x.TestMaster.documentType == rpttype || x.TestMaster.documentType == rpttype2))
                          .Select(n => new PatientDetailsMasterViewModel()
                          {
                              Id = n.Id,
                              TestId = n.TestId,
                              TestMasterViewModels = new TestMasterViewModel()
                              {
                                  TestCode = n.TestMaster.TestCode,
                                  TestGroupId = n.TestMaster.TestGroupId,
                                  TestGroupMasterViewModel = new TestGroupMasterViewModel()
                                  {
                                      Id = n.TestMaster.TestGroupMaster.Id,
                                      Name = n.TestMaster.TestGroupMaster.Name
                                  }
                              },
                              isSelected = n.PrintTest,
                              TempSrNo = n.TempSrNo
                          }).ToListAsync();
            var groupbyundertest = result.GroupBy(x => new { x.TestMasterViewModels.TestGroupMasterViewModel.Id, x.TestMasterViewModels.TestGroupMasterViewModel.Name });
            List<PatientDetailsMasterViewModel> itemlist = new List<PatientDetailsMasterViewModel>();
            int tmpno = 1;
            foreach (var item in groupbyundertest)
            {
                itemlist.Add(new PatientDetailsMasterViewModel()
                {
                    Id = item.Key.Id,
                    TestMasterViewModels = new TestMasterViewModel()
                    {
                        TestCode = item.Key.Name
                    },
                    TempSrNo = tmpno
                });
                tmpno++;
            }
            return itemlist;
        }
        public async Task<List<ReportGroupViewModel>> GetPatientReportGroup(int PatId, string rpttype) // RptType Reading/Document
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable
                          .OrderBy(x => x.TestMaster.ReportGroup.TempNo)  
                          .Where(x => x.PtIMId == PatId && ( rpttype !="ALL" ? x.PrintTest == true : true )  
                          && (rpttype !="ALL" ? x.TestMaster.documentType == rpttype : true))
                          .Select(n => new ReportGroupViewModel()
                          {
                              Id = n.TestMaster.ReportGroup.Id,
                              TempNo = n.TestMaster.ReportGroup.TempNo,
                              Name = n.TestMaster.ReportGroup.Name,
                              DocReading = n.TestMaster.documentType,
                              TempTestId = (int)n.TestId
                          }).ToListAsync();
            return result;
        }
        public async Task<List<ReportGroupViewModel>> GetPatientReportGroup(int PatId, string rpttype,string rpttype2) // RptType Reading/Document
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable
                          .OrderBy(x => x.TestMaster.ReportGroup.TempNo)
                          .Where(x => x.PtIMId == PatId && (rpttype != "ALL" ? x.PrintTest == true : true)
                          && (rpttype != "ALL" ? ( x.TestMaster.documentType == rpttype || x.TestMaster.documentType == rpttype2) : true))
                          .Select(n => new ReportGroupViewModel()
                          {
                              Id = n.TestMaster.ReportGroup.Id,
                              TempNo = n.TestMaster.ReportGroup.TempNo,
                              Name = n.TestMaster.ReportGroup.Name,
                              DocReading = n.TestMaster.documentType,
                              TempTestId = (int)n.TestId
                          }).ToListAsync();
            return result;
        }
        public async Task<int> GetPatientReportGroupDocRecord(int PatId,string rpttype, int testgid) // RptType Reading/Document
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable
                          .OrderBy(x => x.TestMaster.ReportGroup.Id)
                          .Where(x => x.PtIMId == PatId && x.TestMaster.TestGroupMaster.Id == testgid && x.TestMaster.documentType == rpttype)
                          .Select(n => new ReportGroupViewModel()
                          {
                              Id = n.TestMaster.ReportGroup.Id,
                              Name = n.TestMaster.ReportGroup.Name,
                              DocReading = n.TestMaster.documentType,
                              TempTestId = (int)n.TestId
                          }).ToListAsync();
            return result.Count;
        }
        public async Task<bool> GetPatientTestGroupCovid(int PatId)
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable
                          .Where(x => x.PtIMId == PatId && x.TestMaster.TestGroupMaster.Name == "Covid-19")
                          .ToListAsync();                          
            return result.Count > 0 ? true : false;
        }
        public async Task<List<PatientInvestigationViewModel>> GetPatientTestReport(int PatId, int rptid,int testid)
        {
            var result = await _applicationDbContext.PatientInvestigationTable.OrderBy(x => x.TestMaster.Id).ThenBy(x => x.TempNo)
                          .Where(x => x.PatientId == PatId && x.TestMaster.ReportId == rptid && x.TestIdX == testid && x.PatResult != null)
                          .Select(n => new PatientInvestigationViewModel()
                          {
                              TestSubId = n.TestSubId,
                              TestIdX = n.TestIdX,
                              TestMasterViewModels = new TestMasterViewModel()
                              {
                                  documentType = n.TestMaster.documentType,
                                  ReportGroupViewModel = new ReportGroupViewModel()
                                  {
                                      Id = n.TestMaster.ReportGroup.Id,
                                      Name = n.TestMaster.ReportGroup.Name
                                  }
                              },
                              TestDetails = n.TestDetails,
                              ColFirst = n.ColFirst,
                              ColSecond = n.ColSecond,
                              ColThird = n.ColThird,
                              ColFourth = n.ColFourth,
                              ColFifth = n.ColFifth,
                              ColSixth = n.ColSixth,
                              VisualTrueFalse = n.VisualTrueFalse,
                              TestLocked = n.TestLocked,
                              Gender = n.Gender,
                              Units = n.Units,
                              FromRange = n.FromRange,
                              UptoRange = n.UptoRange,
                              RangeSymble = n.RangeSymble,
                              RangeDetails = n.RangeDetails,
                              FromAge = n.FromAge,
                              UptoAge = n.UptoAge,
                              PatResult = n.PatResult,
                              DefaultResult = n.DefaultResult,
                              MiniRange = n.MiniRange,
                              MaxRange = n.MaxRange,
                              TempNo = (int)n.TempNo,
                              CompId = n.CompId
                          }).ToListAsync();
            return result;
        }
        public async Task<List<PatientInvestigationViewModel>> GetPatientTestReport(int PatId, int rptid)
        {
            var result = await _applicationDbContext.PatientInvestigationTable.OrderBy(x => x.TestMaster.Id).ThenBy(x => x.TempNo)
                          .Where(x => x.PatientId == PatId && x.TestMaster.ReportId == rptid && x.PatResult != null)
                          .Select(n => new PatientInvestigationViewModel()
                          {
                              TestSubId = n.TestSubId,
                              TestIdX = n.TestIdX,
                              TestMasterViewModels = new TestMasterViewModel()
                              {
                                  documentType = n.TestMaster.documentType,
                                  ReportGroupViewModel = new ReportGroupViewModel()
                                  {
                                      Id = n.TestMaster.ReportGroup.Id,
                                      Name = n.TestMaster.ReportGroup.Name
                                  }
                              },
                              TestDetails = n.TestDetails,
                              ColFirst = n.ColFirst,
                              ColSecond = n.ColSecond,
                              ColThird = n.ColThird,
                              ColFourth = n.ColFourth,
                              ColFifth = n.ColFifth,
                              ColSixth = n.ColSixth,
                              VisualTrueFalse = n.VisualTrueFalse,
                              TestLocked = n.TestLocked,
                              Gender = n.Gender,
                              Units = n.Units,
                              FromRange = n.FromRange,
                              UptoRange = n.UptoRange,
                              RangeSymble = n.RangeSymble,
                              RangeDetails = n.RangeDetails,
                              FromAge = n.FromAge,
                              UptoAge = n.UptoAge,
                              PatResult = n.PatResult,
                              DefaultResult = n.DefaultResult,
                              MiniRange = n.MiniRange,
                              MaxRange = n.MaxRange,
                              TempNo = (int)n.TempNo,
                              CompId = n.CompId
                          }).ToListAsync();
            return result;
        }
        public async Task<bool> UpdatePatientPrintOption(int patid,int testid, bool truefalse)
        {           
                var result = await _applicationDbContext.PatientDetailsMasterTable.FirstOrDefaultAsync(x => x.PtIMId == patid && x.TestId == testid);
            if (result != null)
            {
                result.PrintTest = truefalse;                
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePatientReportingDate(int patid,string dtvalue)
        {
            var result = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(x => x.Id == patid);
            if (result != null )
            {
                result.ResultNotDone = "True";
                result.ResultDone = "True";
                result.ReportDate = dtvalue;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<PatientViewModel>> GetAllPatientMasterNameByBranchWise(int cmpid, DateTime UptoDt)
        {
                        
            var result = await _applicationDbContext.PatientTable
                    .OrderBy(x => x.SDate).ThenBy(x => x.RefNo)
                    .Where(x => (cmpid > 0 ? x.CompId == cmpid : true)
                    && x.SDate <= UptoDt)
                .Select(x => new PatientViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    UserCode = x.UserCode,
                    VNo = x.VNo,
                    SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    STime = x.STime,
                    RTime = x.RTime,
                    Type = x.Type,
                    RefNo = x.RefNo,
                    TitleName = x.TitleName,
                    Name = x.Name,
                    AdharNo = x.AdharNo,
                    Sex = (Gender)x.Sex,
                    Age = Convert.ToInt32(x.Age),
                    AgeType = x.AgeType,
                    Address = x.Address,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    EmailAuto = x.EmailAuto,
                    PhoneNo = x.PhoneNo,
                    ClientCode = x.ClientCode,
                    AgentAcCode = x.AgentAcCode,
                    AgentFileViewModel = new AgentFileViewModel()
                    {
                        Name = x.PatientAgentAcCode.Name
                    },
                    DoctorAcCode = x.DoctorAcCode,
                    DrName = x.DrName,
                    LedgerMasterViewModel = new LedgerMasterViewModel()
                    {
                        PartyName = x.PatientDoctorAcCode.PartyName,
                        Address1 = x.PatientDoctorAcCode.Address1,
                        Address2 = x.PatientDoctorAcCode.Address2,
                        Address3 = x.PatientDoctorAcCode.Address3,
                    },
                    PaymentType = (PayMode)x.PaymentType,
                    TotalAmt = x.TotalAmt,
                    TotalIPAmt = x.TotalIPAmt,
                    DiscountReasion = x.DiscountReasion,
                    ApprovalBy = x.ApprovalBy,
                    DiscountType = x.DiscountType,
                    DiscPer = Convert.ToDecimal(x.DiscPer),
                    DiscAmt = Convert.ToDecimal(x.DiscAmt),
                    AreaCode = x.AreaCode,
                    CollectionCharge = x.CollectionCharge,
                    CollectionBoy = x.CollectionBoy,
                    DeliveryCharge = x.DeliveryCharge,
                    DeliveryBoy = x.DeliveryBoy,
                    PaidAmt = x.PaidAmt,
                    BalAmt = x.BalAmt,
                    TestDetailRecord = x.TestDetailRecord,
                    Remark = x.Remark,
                    ReportDate = x.ReportDate,
                    ReportCancel = x.ReportCancel,
                    ResultNotDone = x.ResultNotDone,
                    ResultDone = x.ResultDone,
                    ReportApproved = x.ReportApproved,
                    ReportIssue = x.ReportIssue,
                    ReportHold = x.ReportHold,
                    ReportRecipt = x.ReportRecipt,
                    ReportDispatch = x.ReportDispatch,
                    DrLabId = x.DrLabId,
                    DoctorLabViewModel = new DoctorLabViewModel()
                    {
                        //Id = x.DoctorLab.Id,
                        //CompId = x.DoctorLab.CompId,
                        Name = x.DoctorLab.Name,
                        Address = x.DoctorLab.Address,
                        MobileNo = x.DoctorLab.MobileNo,
                        Eduction = x.DoctorLab.Education,
                        PrintReport = x.DoctorLab.PrintReport
                    }
                }).ToListAsync();
            return result;
        }
        // Patient Document File
        public async Task<bool> UpdatePatientInvestigationDoctype(int patid,string doctype)
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable
                .FirstOrDefaultAsync(x => x.PtIMId == patid && x.TestMaster.documentType == doctype);            
            return result != null ? true : false;
        }
        public async Task<bool> UpdatePatientInvestigationDoc(TempResultViewFile model)
        {
          
                var result = await _applicationDbContext.PatientInvestigationTable.FirstOrDefaultAsync(x => x.PatientId == model.PatientId && x.TestIdX == model.TestListId);
                if (result != null)
                {
                    result.TestDetails = model.TestDocumentain;
                    result.PatResult = "-";
                }
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<PatientInvestigationViewModel> GetPatientTestInvestigationDoc(int PatId, int testid)
        {
            var result = await _applicationDbContext.PatientInvestigationTable
                          .Select(n => new PatientInvestigationViewModel()
                          {
                              TestSubId = n.TestSubId,
                              TestIdX = n.TestIdX,
                              TestDetails = n.TestDetails,
                              PatientId = n.PatientId,
                              TestMasterViewModels = new TestMasterViewModel()
                              {
                                  TestCode = n.TestMaster.TestCode,
                                  TestGroupId = n.TestMaster.TestGroupId
                              }
                          }).FirstOrDefaultAsync(x => x.PatientId == PatId && x.TestIdX == testid);
            return result;
        }
        
        // Audit Table Details
        public async Task<List<PatientAuditViewModel>> SearchPatientAudit(int patid)
        {
            var result = await _applicationDbContext.PatientAuditTable
                 .Where(x => x.PatId == patid )
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.SDate).ThenBy(x => x.VNo)
                 .Select(x => new PatientAuditViewModel()
                 {
                     Id = x.Id,
                     PatId = x.PatId,
                     CompId = x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         NameAddress = x.CompanyDetail.TransCode.Substring(3, 9) + x.CompanyDetail.Address1
                     },
                     UserCode = x.UserCode,
                     SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     ModifDate = Convert.ToDateTime(x.ModifDate).ToString(),
                     VNo = x.VNo,
                     RefNo = x.RefNo,
                     PatientInformation = x.PatientInformation,
                     PaidPreInformation = x.PaidPreInformation,
                     PaidPostInformation = x.PaidPostInformation,
                     UpdateType = x.UpdateType,
                     SelectDeleted = x.SelectDeleted,
                     EditUserCode = x.EditUserCode
                 }).ToListAsync();
            return result;
        }
        public async Task<List<PatientAuditViewModel>> SearchPatientAuditDateWise(int CmpId, string UCode, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.PatientAuditTable
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                 && (UCode != "0" && UCode != null ? x.UserCode == UCode : true)
                 && x.SDate >= dt1 && x.SDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.SDate).ThenBy(x => x.VNo)
                 .Select(x => new PatientAuditViewModel()
                 {
                     Id = x.Id,
                     PatId = x.PatId,
                     CompId = x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         NameAddress = x.CompanyDetail.TransCode.Substring(3,9) + x.CompanyDetail.Address1
                     },
                     UserCode = x.UserCode,                    
                     SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     ModifDate = Convert.ToDateTime(x.ModifDate).ToString(),
                     VNo = x.VNo,
                     RefNo = x.RefNo,
                     PatientInformation = x.PatientInformation,
                     PaidPreInformation = x.PaidPreInformation,
                     PaidPostInformation = x.PaidPostInformation,
                     UpdateType = x.UpdateType,
                     SelectDeleted = x.SelectDeleted,
                     EditUserCode = x.EditUserCode
                 }).ToListAsync();
            return result;
        }
        public async Task<bool> DeletePatientAuditDetails(int CmpId, string UCode, DateTime dt1, DateTime dt2)
        {
            var result1 = await _applicationDbContext.PatientAuditTable
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                 && (UCode != "0" && UCode != null ? x.UserCode == UCode : true)
                 && x.SDate >= dt1 && x.SDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.SDate).ThenBy(x => x.VNo).ToListAsync();
            foreach (var item in result1)
            {
                var result2 = await _applicationDbContext.PatientAuditTable.FirstOrDefaultAsync(x => x.Id == item.Id && item.SelectDeleted == true);
                if (result2 != null)
                {
                    result2.Id = item.Id;
                    _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _applicationDbContext.SaveChanges();
                }
            }
            return false;
        }
        public async Task<bool> UpdateAuditFileForDelete(int id, bool canceltrufalse)
        {
            var result = await _applicationDbContext.PatientAuditTable.FirstOrDefaultAsync(n => n.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.SelectDeleted = canceltrufalse;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateALLAuditFileForDelete(int CmpId, string UCode, DateTime dt1, DateTime dt2,bool chvalues)
        {
            var result1 = await _applicationDbContext.PatientAuditTable
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                 && (UCode != "0" && UCode != null ? x.UserCode == UCode : true)
                 && x.SDate >= dt1 && x.SDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.SDate).ThenBy(x => x.VNo).ToListAsync();
            foreach (var item in result1)
            {
                var result2 = await _applicationDbContext.PatientAuditTable.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (result2 != null)
                {
                    result2.Id = item.Id;
                    result2.SelectDeleted = chvalues;
                    _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                }
            }
          
            return true;
        }
        public async Task<bool> AuditFileForValid(int patid)
        {
            var result = await _applicationDbContext.PatientAuditTable.FirstOrDefaultAsync(n => n.PatId == patid);            
            return result != null ? true : false;
        }
       
        // Patient Due Recipt File
        public async Task<int> AddNewPatientDueReciptMaster(PatientDueReciptViewModel models)
        {           
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(models.VDate))
            {
                userdt = models.VDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            PatientDueRecipt opnitemMaster = new PatientDueRecipt()
            {                
                UserCode = models.UserCode,
                PatId = models.PatId,
                VNo = models.VNo,
                VDate = string.IsNullOrEmpty(models.VDate) ? Date1 : Convert.ToDateTime(userdt1),
                TotalAmt = models.TotalAmt,
                DiscAmt = models.DiscAmt,
                PaidAmt = models.PaidAmt,
                Remark = models.Remark,
                PaymentType = (int)models.PaymentType
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();          
            return opnitemMaster.Id;
        }
        public async Task<bool> UpdatePatientDueReciptMaster(PatientDueReciptViewModel models)
        {
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(models.VDate))
            {
                userdt = models.VDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result = await _applicationDbContext.PatientDueReciptTable.FirstOrDefaultAsync(n => n.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;                
                result.UserCode = models.UserCode;
                result.PatId = models.PatId;
                result.VNo = models.VNo;
                result.VDate = string.IsNullOrEmpty(models.VDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.TotalAmt = models.TotalAmt;
                result.DiscAmt = models.DiscAmt;
                result.PaidAmt = models.PaidAmt;
                result.Remark = models.Remark;
                result.PaymentType = (int)models.PaymentType;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<PatientDueReciptViewModel> GetPatientDueReciptMasterById(int id)
        {
            var result = await _applicationDbContext.PatientDueReciptTable
                    .Select(x => new PatientDueReciptViewModel()
                    {
                        Id = x.Id,
                        UserCode = x.UserCode,
                        VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        VNo = x.VNo,
                        PatId = x.PatId,
                        PatientViewModel = new PatientViewModel()
                        {
                            Id = x.Patient.Id,
                            CompId = x.Patient.CompId,
                            UserCode = x.Patient.UserCode,
                            VNo = x.Patient.VNo,
                            SDate = (x.Patient.SDate != null ? Convert.ToDateTime(x.Patient.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            RDate = (x.Patient.RDate != null ? Convert.ToDateTime(x.Patient.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            STime = x.Patient.STime,
                            RTime = x.Patient.RTime,
                            Type = x.Patient.Type,
                            RefNo = x.Patient.RefNo,
                            TitleName = x.Patient.TitleName,
                            Name = x.Patient.Name,
                            Sex = (Gender)x.Patient.Sex,
                            Age = Convert.ToInt32(x.Patient.Age),
                            AgeType = x.Patient.AgeType,
                            Address = x.Patient.Address,
                            MobileNo = x.Patient.MobileNo,
                            EmailAddress = x.Patient.EmailAddress
                        },
                        TotalAmt = x.TotalAmt,
                        DiscAmt = Convert.ToDecimal(x.DiscAmt),
                        PaidAmt = x.PaidAmt,
                        Remark = x.Remark,
                        PaymentType = (PayMode)x.PaymentType
                    }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> GetPatientDueReciptValidedByVoucherNo(string voucherno)
        {
            var result = await _applicationDbContext.PatientDueReciptTable.FirstOrDefaultAsync(x => x.VNo == voucherno);
            return result != null ? true : false;
        }
        public async Task<bool> DeletePatientDueReciptMaster(int id)
        {
            var result2 = await _applicationDbContext.PatientDueReciptTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<PatientDueReciptViewModel>> GetPatientDueReciptDateWise(string UCode,DateTime FromDt, DateTime UptoDt, string paymentmode)
        {
            int paymode = 0;
            Boolean xx = int.TryParse(paymentmode, out paymode);
            var result = await _applicationDbContext.PatientDueReciptTable
                    .OrderBy(x => x.VDate).ThenBy(x => x.VNo)
                    .Where(x => (UCode != "ALL" && UCode != null ? x.UserCode == UCode : true)
                    && x.VDate >= FromDt && x.VDate <= UptoDt
                    && (paymentmode != "ALL" ? x.PaymentType == paymode : true))
                .Select(x => new PatientDueReciptViewModel()
                {
                    Id = x.Id,
                    UserCode = x.UserCode,
                    VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    VNo = x.VNo,
                    PatId = x.PatId,
                    PatientViewModel = new PatientViewModel()
                    {
                        Id = x.Patient.Id,                        
                        CompId = x.Patient.CompId,
                        CompanyDetailViewModel = new CompanyDetailViewModel()
                        {
                            NameAddress = x.Patient.PatientCompanyDetails.Address1
                        },
                        UserCode = x.Patient.UserCode,
                        VNo = x.Patient.VNo,
                        SDate = (x.Patient.SDate != null ? Convert.ToDateTime(x.Patient.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        RDate = (x.Patient.RDate != null ? Convert.ToDateTime(x.Patient.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        STime = x.Patient.STime,
                        RTime = x.Patient.RTime,
                        Type = x.Patient.Type,
                        RefNo = x.Patient.RefNo,
                        TitleName = x.Patient.TitleName,
                        Name = x.Patient.Name,
                        Sex = (Gender)x.Patient.Sex,
                        Age = Convert.ToInt32(x.Patient.Age),
                        AgeType = x.Patient.AgeType,
                        Address = x.Patient.Address,
                        MobileNo = x.Patient.MobileNo,
                        EmailAddress = x.Patient.EmailAddress,
                        DrName = x.Patient.DrName,
                        TestDetailRecord = x.Patient.TestDetailRecord
                    },
                    TotalAmt = x.TotalAmt,
                    DiscAmt = Convert.ToDecimal(x.DiscAmt),
                    PaidAmt = x.PaidAmt,
                    Remark = x.Remark,
                    PaymentType = (PayMode)x.PaymentType
                }).ToListAsync();
            return result;
        }
        public async Task<List<PatientViewModel>> GetAllPatientMasterDueAnalysis(int cmpid, string UCode, string mobileno, int sexid, string name, int age, string address, string emailaddress, int doctorid, DateTime FromDt, DateTime UptoDt, string paymentmode)
        {
            int paymode = 0;
            Boolean xx = int.TryParse(paymentmode, out paymode);
            var result = await _applicationDbContext.PatientTable
                    .OrderBy(x => x.SDate).ThenBy(x => x.RefNo)
                    .Where(x => (cmpid > 0 ? x.CompId == cmpid : true)
                    && (UCode != "0" && UCode != null ? x.UserCode == UCode : true)
                    && ((mobileno != null) ? x.MobileNo.Contains(mobileno) : true)
                    && (sexid < 3 ? (x.Sex == Convert.ToInt32(sexid)) : true)
                    && ((name != null) ? x.Name.Contains(name) : true)
                    && (age > 0 ? x.Age == age : true)
                    && ((address != null) ? x.Address.Contains(address) : true)
                    && ((emailaddress != null) ? x.EmailAddress.Contains(emailaddress) : true)
                    && (doctorid > 0 ? x.DoctorAcCode == doctorid : true)
                    && (x.SDate >= FromDt && x.SDate <= UptoDt)
                    && ( x.ReportCancel != "True" && x.BalAmt > 0 )
                    && (paymentmode != "ALL" ? x.PaymentType == paymode : true))
                .Select(x => new PatientViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    UserCode = x.UserCode,
                    VNo = x.VNo,
                    SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    RDate = (x.RDate != null ? Convert.ToDateTime(x.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    STime = x.STime,
                    RTime = x.RTime,
                    Type = x.Type,
                    RefNo = x.RefNo,
                    TitleName = x.TitleName,
                    Name = x.Name,
                    Sex = (Gender)x.Sex,
                    Age = Convert.ToInt32(x.Age),
                    AgeType = x.AgeType,
                    Address = x.Address,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    AgentAcCode = x.AgentAcCode,
                    AgentFileViewModel = new AgentFileViewModel()
                    {
                        Name = x.PatientAgentAcCode.Name
                    },
                    DoctorAcCode = x.DoctorAcCode,
                    LedgerMasterViewModel = new LedgerMasterViewModel()
                    {
                        PartyName = x.PatientDoctorAcCode.PartyName,
                        Address1 = x.PatientDoctorAcCode.Address1,
                        Address2 = x.PatientDoctorAcCode.Address2,
                        Address3 = x.PatientDoctorAcCode.Address3,
                    },
                    PaymentType = (PayMode)x.PaymentType,
                    TotalAmt = x.TotalAmt,
                    TotalIPAmt = x.TotalIPAmt,
                    DiscountType = x.DiscountType,
                    DiscPer = Convert.ToDecimal(x.DiscPer),
                    DiscAmt = Convert.ToDecimal(x.DiscAmt),
                    PaidAmt = x.PaidAmt,
                    BalAmt = x.BalAmt,
                    TestDetailRecord = x.TestDetailRecord,
                    Remark = x.Remark,
                    ReportDate = (x.ReportDate != null ? Convert.ToDateTime(x.ReportDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    ReportCancel = x.ReportCancel,
                    ResultNotDone = x.ResultNotDone,
                    ResultDone = x.ResultDone,
                    ReportApproved = x.ReportApproved,
                    ReportIssue = x.ReportIssue,
                    ReportHold = x.ReportHold,
                    ReportRecipt = x.ReportRecipt,
                    ReportDispatch = x.ReportDispatch
                }).ToListAsync();
            return result;
        }
        // Test Result View Model
        public async Task<List<TestResultDetailViewModel>> GetTestResultHelp(int testid, string testDetailName)
        {

            var result = await _applicationDbContext.TestResultTable.OrderBy(x => x.Id)
                        .Where(x => x.TestIdX == testid && x.TestDetailName == testDetailName)
                        .Select(x => new TestResultViewModel()
                        {
                            Id = x.Id,
                            CompId = x.CompId,
                            TestIdX = x.TestIdX,
                            TestDetailName = x.TestDetailName
                        }).FirstOrDefaultAsync();
            var result1 = await _applicationDbContext.TestResultDetailTable.Where(x => x.TestResultId == result.Id)
                          .Select(x => new TestResultDetailViewModel()
                          {
                              TempNo = x.TempNo,
                              PatientValue = x.PatientValue,
                              TestResultId = x.TestResultId
                          }).ToListAsync();
            return result1;
        }
        public async Task<int> GetTestResultFindId(int testid, string testDetailName)
        {

            var result = await _applicationDbContext.TestResultTable.OrderBy(x => x.Id)
                        .Where(x => x.TestIdX == testid && x.TestDetailName == testDetailName)
                        .Select(x => new TestResultViewModel()
                        {
                            Id = x.Id,
                            CompId = x.CompId,
                            TestIdX = x.TestIdX,
                            TestDetailName = x.TestDetailName
                        }).FirstOrDefaultAsync();
            return result == null ? 0 : result.Id;
        }
        public async Task<int> GetTestResultIdByCompTestIdTestSubId(int compid, int testid, string testDetailName)
        {

            var result = await _applicationDbContext.TestResultTable.OrderBy(x => x.Id)
                        .Where(x => x.CompId == compid && x.TestIdX == testid && x.TestDetailName == testDetailName)
                        .Select(x => x.Id).FirstOrDefaultAsync();
            return result;
        }
        public async Task<int> AddNewTestResult(TestResultViewModel models)
        {
            TestResult newCate = new TestResult()
            {
                CompId = models.CompId,
                TestIdX = models.TestIdX,
                TestDetailName = models.TestDetailName
            };
            _applicationDbContext.Entry(newCate).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.TestResultDetailViewModels)
            {
                TestResultDetail order = new TestResultDetail()
                {
                    Id = item.Id,
                    PatientValue = item.PatientValue,
                    TempNo = item.TempNo,
                    TestResultId = newCate.Id,

                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return newCate.Id;
        }
        public async Task<bool> UpdateTestResult(TestResultViewModel models)
        {
            var result = await _applicationDbContext.TestResultTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.CompId = models.CompId;
                result.TestIdX = models.TestIdX;
                result.TestDetailName = models.TestDetailName;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.TestResultDetailViewModels)
            {
                var result1 = await _applicationDbContext.TestResultDetailTable.FirstOrDefaultAsync(x => x.TempNo == item.TempNo && x.TestResultId == models.Id);
                if (result1 != null)
                {
                    result1.PatientValue = item.PatientValue;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    TestResultDetail order = new TestResultDetail()
                    {
                        PatientValue = item.PatientValue,
                        TempNo = item.TempNo,
                        TestResultId = models.Id,
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<TestResultViewModel> GetTestResultById(int id)
        {
            var result = await _applicationDbContext.TestResultTable.Select(x => new TestResultViewModel()
            {
                Id = x.Id,
                CompId = x.CompId,
                TestIdX = x.TestIdX,
                TestDetailName = x.TestDetailName,
                TestResultDetailViewModels = x.TestResultDetails.Where(n => n.TestResultId == x.Id).OrderBy(n => n.TempNo)
                                             .Select(n => new TestResultDetailViewModel()
                                             {
                                                 Id = n.Id,
                                                 PatientValue = n.PatientValue,
                                                 TempNo = n.TempNo
                                             }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<List<TestResultViewModel>> GetTestResultList(int cmpid)
        {
            var result = await _applicationDbContext.TestResultTable
                .Where(x => x.CompId == cmpid)
                .Select(x => new TestResultViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestIdX = x.TestIdX,
                    TestDetailName = x.TestDetailName
                }).ToListAsync();
            return result;
        }
        public async Task<List<TestResultViewModel>> GetTestResultListTestId(int testid, string testDetailName)
        {
            var result = await _applicationDbContext.TestResultTable
                .Where(x => x.TestIdX == testid && x.TestDetailName == testDetailName)
                .Select(x => new TestResultViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestIdX = x.TestIdX,
                    TestDetailName = x.TestDetailName
                }).ToListAsync();
            return result;
        }
        public async Task<bool> DeleteTestResult(int id)
        {
            var result2 = await _applicationDbContext.TestResultTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeleteTestResultOne(int id, int tno)
        {
            var result1 = await _applicationDbContext.TestResultDetailTable.FirstOrDefaultAsync(x => x.TempNo == tno && x.Id == id);
            if (result1 != null)
            {
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.TestResultDetailTable.OrderBy(x => x.TempNo).Where(x => x.Id == id).ToListAsync();
            foreach (var item in result2)
            {
                var result3 = await _applicationDbContext.TestResultDetailTable.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (result3 != null)
                {
                    item.TempNo = No1;
                    _applicationDbContext.Entry(result3).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                    No1++;
                }
            }
            return false;
        }
      
        public async Task<int> TransferTestOneUserToAnotherUser(int fromcompId, int uptocompid)
        {
            var compmodel = await _applicationDbContext.CompanyDetailTable.Where(x => x.Id == uptocompid).FirstOrDefaultAsync();
            AreaFile areaFile  = new AreaFile()
            {                
                CompIdA   = uptocompid,
                Name = "NA",
                DistId = (int) compmodel.DistId
            };
            _applicationDbContext.Entry(areaFile).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();

            ClientFile clientFile = new ClientFile()
            {
                CompIdA = uptocompid,
                Code = await ClientSrNoCreation(uptocompid),
                Name = compmodel.CompName.Substring(0,10) + " Collection Center",  
                Address1 ="-", City ="-",  PinNo ="-",  MobileNo ="-",EmailAddress = "g@gmail.com",
                RegPanel = 0, ActiveType =true
            };
            _applicationDbContext.Entry(clientFile).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();

            DoctorLab doctorinFile = new DoctorLab()
            {
                CompId = uptocompid,                
                Name = "SELF",
                Address = "-",
                MobileNo = "-",
                Education ="-",
                PrintReport ="-",
                IPAmt = 0
            };
            _applicationDbContext.Entry(doctorinFile).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();

            AgentFile agentFile = new AgentFile()
            {
                CompIdA = uptocompid,
                Code = await AgentSrNoCreation(uptocompid),
                Name = "SELF",
                Address1 = "-",City ="-",PinNo ="-",EmailAddress ="gg@gmail.com",
                MobileNo = "-",IPAmt1 =0,
               BankName = "-", BankAcNo = "-",IFSC = "-",EPFAcNo ="-",
               BasicPay = 0, TA = 0, DA = 0, HRA = 0, CCA = 0 , TransferStatus = false, ActiveType = true
            };
            _applicationDbContext.Entry(agentFile).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();

            var result1x = await _applicationDbContext.MedMasterTable.Where(x => x.CompId == fromcompId).ToListAsync();
            foreach (var item in result1x)
            {
                MedMaster DMasterX = new MedMaster()
                {
                    CompId = uptocompid,
                    TestDetailsA = item.TestDetailsA,
                    PatResultA = item.PatResultA,
                    RangeDetailsA = item.RangeDetailsA,
                    TestLineA = item.TestLineA,
                    TestDetailsB = item.TestDetailsB,
                    PatResultB = item.PatResultB,
                    RangeDetailsB = item.RangeDetailsB,
                   TestLineB = item.TestLineB
                };
                _applicationDbContext.Entry(DMasterX).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
            }

            var result1 = await _applicationDbContext.TestGroupTable.Where(x => x.CompId == fromcompId ).ToListAsync();
            foreach (var item in result1)
            {
                TestGroupMaster DMaster = new TestGroupMaster()
                {
                    CompId = uptocompid,
                    Name = item.Name,
                    ShortName = item.ShortName,
                    IPPer1 = item.IPPer1,
                    IPAmt1 = item.IPAmt1
                };
                _applicationDbContext.Entry(DMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
            }
            var result2 = await _applicationDbContext.ReportGroupTable.Where(x => x.CompId == fromcompId).ToListAsync();
            foreach (var item in result2)
            {
                ReportGroup ReportGroupGroup = new ReportGroup()
                {
                    CompId = uptocompid,
                    Name = item.Name,
                    TempNo = item.TempNo
                };
                _applicationDbContext.Entry(ReportGroupGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
            }
            var result3 = await _applicationDbContext.TestMasterTable.Where(x => x.CompId == fromcompId).ToListAsync();
            foreach (var item in result3)
            {
                TestMaster TestMasterMaster = new TestMaster()
                {
                    CompId = uptocompid,
                    TestCode = item.TestCode,
                    ReportId = await _applicationDbContext.ReportGroupTable.Where(x => x.CompId == uptocompid && x.Name == item.ReportGroup.Name).Select(x => x.Id).FirstOrDefaultAsync(),
                    TestGroupId = await _applicationDbContext.TestGroupTable.Where(x => x.CompId == uptocompid && x.Name == item.TestGroupMaster.Name).Select(x => x.Id).FirstOrDefaultAsync(),
                    Rate = item.Rate,
                    PPRate = item.PPRate,
                    CCRate = item.CCRate,
                    IPPer1 = item.IPPer1,
                    IPAmt1 = item.IPAmt1,
                    documentType = item.documentType,
                    ColumnsNo = item.ColumnsNo,
                    GraphsType = item.GraphsType
                };
                _applicationDbContext.Entry(TestMasterMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
                var result4 = await _applicationDbContext.TestSubMasterTable.Where(x => x.CompId == fromcompId && x.TestId == item.Id).ToListAsync();
                foreach (var itemx in result4)
                {
                    TestSubMaster order = new TestSubMaster()
                    {
                        //Id = itemx.Id,
                        TestDetails = item.documentType == "Reading" ? itemx.TestDetails : "XXX",
                        ColFirst = itemx.ColFirst != null ? itemx.ColFirst : null,
                        ColSecond = itemx.ColSecond != null ? itemx.ColSecond : null,
                        ColThird = itemx.ColThird != null ? itemx.ColThird : null,
                        ColFourth = itemx.ColFourth != null ? itemx.ColFourth : null,
                        ColFifth = itemx.ColFifth != null ? itemx.ColFifth : null,
                        ColSixth = itemx.ColSixth != null ? itemx.ColSixth : null,
                        VisualTrueFalse = itemx.VisualTrueFalse,
                        TestLocked = itemx.TestLocked,
                        Gender = item.documentType == "Reading" ? itemx.Gender : "A",
                        Units = itemx.Units != null ? itemx.Units : null,
                        FromRange = itemx.FromRange != null ? itemx.FromRange : null,
                        UptoRange = itemx.UptoRange != null ? itemx.UptoRange : null,
                        RangeSymble = itemx.RangeSymble != null ? itemx.RangeSymble : null,
                        RangeDetails = itemx.RangeDetails != null ? itemx.RangeDetails : null,
                        AgeType = itemx.AgeType != null ? itemx.AgeType : null,
                        FromAge = item.documentType == "Reading" ? (int)itemx.FromAge : 0,
                        UptoAge = item.documentType == "Reading" ? (int)itemx.UptoAge : 150,
                        DefaultResult = itemx.DefaultResult != null ? itemx.DefaultResult : null,
                        MiniRange = itemx.MiniRange != null ? itemx.MiniRange : null,
                        MaxRange = itemx.MaxRange != null ? itemx.MaxRange : null,
                        TempNo = itemx.TempNo,
                        CompId = uptocompid,
                        TestId = TestMasterMaster.Id
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                await _applicationDbContext.SaveChangesAsync();
            }

            var result3doc = await _applicationDbContext.TestDocMasterTable.Where(x => x.CompId == fromcompId).ToListAsync();
            foreach (var item in result3doc)
            {
                TestDocMaster TestdocMaster = new TestDocMaster()
                {
                    CompId = uptocompid,
                    TestCode = item.TestCode,                    
                    TestGroupId = await _applicationDbContext.TestGroupTable.Where(x => x.CompId == uptocompid && x.Name == item.TestGroupMaster.Name).Select(x => x.Id).FirstOrDefaultAsync(),
                    documentFile = item.documentFile
                };
                _applicationDbContext.Entry(TestdocMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();                
            }

            var result5 = await _applicationDbContext.PageSetupTable.Where(x => x.CompId == fromcompId).FirstOrDefaultAsync();
            PageSetup newCate = new PageSetup()
            {
                LeftA = result5.LeftA,
                RightA = result5.RightA,
                TopA = result5.TopA,
                BottomA = result5.BottomA,
                CustomPapersizeA = Convert.ToInt32(result5.CustomPapersizeA),
                CustomOrientationA = Convert.ToInt32(result5.CustomOrientationA),
                LeftB = result5.LeftB,
                RightB = result5.RightB,
                TopB = result5.TopB,
                BottomB = result5.BottomB,
                CustomPapersizeB = Convert.ToInt32(result5.CustomPapersizeB),
                CustomOrientationB = Convert.ToInt32(result5.CustomOrientationB),
                PageHeaderB = result5.PageHeaderB,
                PageFooterB = result5.PageFooterB,
                CompId =uptocompid,

                PrintHeaderB = result5.PrintHeaderB,
                PrintFooterB = result5.PrintFooterB,
                HeaderPhotoFile = "-",//result5.HeaderPhotoFile,
                ReportHeaderPrint = result5.ReportHeaderPrint,
                FooterPhotoFile = "-", // result5.FooterPhotoFile,
                ReportFooterPrintA = result5.ReportFooterPrintA,
                ReportFooterB = result5.ReportFooterB,
                ReportFooterPrintB = result5.ReportFooterPrintB,
                LeftR = result5.LeftR,
                RightR = result5.RightR,
                TopR = result5.TopR,
                BottomR = result5.BottomR,
                CustomPapersizeR = result5.CustomPapersizeR,
                CustomOrientationR = result5.CustomOrientationR,
                LeftC = result5.LeftC,
                RightC = result5.RightC,
                TopC = result5.TopC,
                BottomC = result5.BottomC,
                CustomPapersizeC = result5.CustomPapersizeC,
                CustomOrientationC = result5.CustomOrientationC,
                HeaderFont = result5.HeaderFont,
                HeaderSize = result5.HeaderSize,
                HeaderStyle = result5.HeaderStyle,
                HeaderWeight = result5.HeaderWeight,
                HeaderColor = result5.HeaderColor,
                HeaderDecorate = result5.HeaderDecorate,
                HeaderDetails = result5.HeaderDetails,
                HeaderSecondFont = result5.HeaderSecondFont,
                HeaderSecondSize = result5.HeaderSecondSize,
                HeaderSecondStyle = result5.HeaderSecondStyle,
                HeaderSecondWeight = result5.HeaderSecondWeight,
                HeaderSecondColor = result5.HeaderSecondColor,
                HeaderSecondDecorate = result5.HeaderSecondDecorate,
                HeaderSecondDetails = result5.HeaderSecondDetails,
                ReportHeaderFont = result5.ReportHeaderFont,
                ReportHeaderSize = result5.ReportHeaderSize,
                ReportHeaderStyle = result5.ReportHeaderStyle,
                ReportHeaderWeight = result5.ReportHeaderWeight,
                ReportHeaderLineHeight = result5.ReportHeaderLineHeight,
                ReportHeaderColor = result5.ReportHeaderColor,
                ReportHeaderDecorate = result5.ReportHeaderDecorate,
                ReportHeaderDetails = result5.ReportHeaderDetails,
                TestLockTypeNFont = result5.TestLockTypeNFont,
                TestLockTypeNSize = result5.TestLockTypeNSize,
                TestLockTypeNStyle = result5.TestLockTypeNStyle,
                TestLockTypeNWeight = result5.TestLockTypeNWeight,
                TestLockTypeNLineHeight = result5.TestLockTypeNLineHeight,
                TestLockTypeNColor = result5.TestLockTypeNColor,
                TestLockTypeNDecorate = result5.TestLockTypeNDecorate,
                TestLockTypeNDetails = result5.TestLockTypeNDetails,
                TestLockTypeLFont = result5.TestLockTypeLFont,
                TestLockTypeLSize = result5.TestLockTypeLSize,
                TestLockTypeLStyle = result5.TestLockTypeLStyle,
                TestLockTypeLWeight = result5.TestLockTypeLWeight,
                TestLockTypeLLineHeight = result5.TestLockTypeLLineHeight,
                TestLockTypeLColor = result5.TestLockTypeLColor,
                TestLockTypeLDecorate = result5.TestLockTypeLDecorate,
                TestLockTypeLDetails = result5.TestLockTypeLDetails,
                TestLockTypeMFont = result5.TestLockTypeMFont,
                TestLockTypeMSize = result5.TestLockTypeMSize,
                TestLockTypeMStyle = result5.TestLockTypeMStyle,
                TestLockTypeMWeight = result5.TestLockTypeMWeight,
                TestLockTypeMLineHeight = result5.TestLockTypeMLineHeight,
                TestLockTypeMColor = result5.TestLockTypeMColor,
                TestLockTypeMDecorate = result5.TestLockTypeMDecorate,
                TestLockTypeMDetails = result5.TestLockTypeMDetails,
                TestLockTypeYFont = result5.TestLockTypeYFont,
                TestLockTypeYSize = result5.TestLockTypeYSize,
                TestLockTypeYStyle = result5.TestLockTypeYStyle,
                TestLockTypeYWeight = result5.TestLockTypeYWeight,
                TestLockTypeYLineHeight = result5.TestLockTypeYLineHeight,
                TestLockTypeYColor = result5.TestLockTypeYColor,
                TestLockTypeYDecorate = result5.TestLockTypeYDecorate,
                TestLockTypeYDetails = result5.TestLockTypeYDetails,
                TestLockTypeSFont = result5.TestLockTypeSFont,
                TestLockTypeSSize = result5.TestLockTypeSSize,
                TestLockTypeSStyle = result5.TestLockTypeSStyle,
                TestLockTypeSWeight = result5.TestLockTypeSWeight,
                TestLockTypeSLineHeight = result5.TestLockTypeSLineHeight,
                TestLockTypeSColor = result5.TestLockTypeSColor,
                TestLockTypeSDecorate = result5.TestLockTypeSDecorate,
                TestLockTypeSDetails = result5.TestLockTypeSDetails,
                TestLockTypeBFont = result5.TestLockTypeBFont,
                TestLockTypeBSize = result5.TestLockTypeBSize,
                TestLockTypeBStyle = result5.TestLockTypeBStyle,
                TestLockTypeBWeight = result5.TestLockTypeBWeight,
                TestLockTypeBLineHeight = result5.TestLockTypeBLineHeight,
                TestLockTypeBColor = result5.TestLockTypeBColor,
                TestLockTypeBDecorate = result5.TestLockTypeBDecorate,
                TestLockTypeBDetails = result5.TestLockTypeBDetails,
                TestLockTypeNormalFont = result5.TestLockTypeNormalFont,
                TestLockTypeNormalSize = result5.TestLockTypeNormalSize,
                TestLockTypeNormalStyle = result5.TestLockTypeNormalStyle,
                TestLockTypeNormalWeight = result5.TestLockTypeNormalWeight,
                TestLockTypeNormalLineHeight = result5.TestLockTypeNormalLineHeight,
                TestLockTypeNormalColor = result5.TestLockTypeNormalColor,
                TestLockTypeNormalDecorate = result5.TestLockTypeNormalDecorate,
                TestLockTypeNormalDetails = result5.TestLockTypeNormalDetails,
                TestLockTypeUnnormalFont = result5.TestLockTypeUnnormalFont,
                TestLockTypeUnnormalSize = result5.TestLockTypeUnnormalSize,
                TestLockTypeUnnormalStyle = result5.TestLockTypeUnnormalStyle,
                TestLockTypeUnnormalWeight = result5.TestLockTypeUnnormalWeight,
                TestLockTypeUnnormalLineHeight = result5.TestLockTypeUnnormalLineHeight,
                TestLockTypeUnnormalColor = result5.TestLockTypeUnnormalColor,
                TestLockTypeUnnormalDecorate = result5.TestLockTypeUnnormalDecorate,
                TestLockTypeUnnormalDetails = result5.TestLockTypeUnnormalDetails,
                TestLockTypeRangeFont = result5.TestLockTypeRangeFont,
                TestLockTypeRangeSize = result5.TestLockTypeRangeSize,
                TestLockTypeRangeStyle = result5.TestLockTypeRangeStyle,
                TestLockTypeRangeWeight = result5.TestLockTypeRangeWeight,
                TestLockTypeRangeLineHeight = result5.TestLockTypeRangeLineHeight,
                TestLockTypeRangeColor = result5.TestLockTypeRangeColor,
                TestLockTypeRangeDecorate = result5.TestLockTypeRangeDecorate,
                TestLockTypeRangeDetails = result5.TestLockTypeRangeDetails,
                PrintMedReport = result5.PrintMedReport,
                MedReportType = result5.MedReportType,
                BarcodeTop = result5.BarcodeTop,
                TestHeaderTop = result5.TestHeaderTop,
                PatientRefNo = result5.PatientRefNo,
                PatientRefNoGroupwise = result5.PatientRefNoGroupwise,
                PagePrintLine = result5.PagePrintLine,
                OnePrintChart = result5.OnePrintChart,
                QRCodePrint = result5.QRCodePrint,
                BarCodePrint = result5.BarCodePrint,
                TestFormulaApply = result5.TestFormulaApply,
                FormulaDecimalPlace = result5.FormulaDecimalPlace,
                PrintBillOneTwo = result5.PrintBillOneTwo
            };
            _applicationDbContext.Entry(newCate).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            

            var resultx1 = await _applicationDbContext.CompanyDetailTable.Where(x => x.Id == uptocompid).Select(x => new { x.TransCode }).FirstOrDefaultAsync();         
            var result8 = await _applicationDbContext.HeadTable.Where(x => x.CompId == fromcompId).Take(21).ToListAsync();
            int ledNo = 1;
            foreach (var headfile in result8)
            {
                LedgerMaster ledgerMaster = new LedgerMaster()
                {
                    CompId = uptocompid,
                    PartyName = headfile.PartyName,
                    Address1 = headfile.Address1,
                    Address2 = headfile.Address2,
                    Address3 = headfile.Address3,
                    City =  headfile.City,
                    PinNo = headfile.PinNo,
                    LedStateId = Convert.ToInt32(headfile.LedStateId),
                    EmailAddress = headfile.EmailAddress,
                    PhoneNo = headfile.PhoneNo,
                    MobileNo1 = headfile.MobileNo1,
                    MobileNo2 = headfile.MobileNo2,
                    PanNo = headfile.PanNo,
                    AdharNo = headfile.AdharNo,
                    AcGroupId = headfile.AcGroupId,
                    DateOfBirth = headfile.DateOfBirth,
                    DateOfAnversary = headfile.DateOfAnversary,
                    OpnAmt = headfile.OpnAmt,
                    OpnAc = (int)headfile.OpnAc,
                    LedCode = resultx1.TransCode.Substring(3, 9) + "A" + ((ledNo > 1 && ledNo < 10) ? "0000" + ledNo :  "000" + ledNo)
                };
                ledNo++;
            _applicationDbContext.Entry(ledgerMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return 0;
        }
        public async Task<int> TransferTestOneUserToAnotherUser(int fromcompId, int uptocompid, int fromTestId)
        {
            int tempno = await ReportGroupOrderNo(uptocompid);
            var resultx = await _applicationDbContext.TestMasterTable
                                .Select(x => new TestMasterViewModel()
                                {
                                    Id = x.Id,
                                    CompId = x.CompId,
                                    TestCode = x.TestCode,
                                    ReportId = x.ReportId,
                                    ReportGroupViewModel = new ReportGroupViewModel()
                                    {
                                        Id = x.ReportGroup.Id,
                                        Name = x.ReportGroup.Name,
                                        TempNo = tempno
                                    },
                                    TestGroupId = x.TestGroupId,
                                    TestGroupMasterViewModel = new TestGroupMasterViewModel()
                                    {
                                        Id = x.TestGroupMaster.Id,
                                        Name = x.TestGroupMaster.Name,
                                        ShortName = x.TestGroupMaster.ShortName,
                                        IPAmt1 = x.TestGroupMaster.IPAmt1,
                                        IPPer1 = x.TestGroupMaster.IPPer1,
                                    },
                                    Rate = (decimal)x.Rate,
                                    IPPer1 = (decimal)x.IPPer1,
                                    IPAmt1 = (decimal)x.IPAmt1,
                                    documentType = x.documentType,
                                    ColumnsNo = x.ColumnsNo,
                                    GraphsType = x.GraphsType,
                                    TestDocumentain = x.documentType,
                                    TestSubMasterViewModels = x.TestSubMasters.Where(a => a.TestId == x.Id)
                                                .OrderBy(a => a.TempNo)
                                                .Select(n => new TestSubMasterViewModel()
                                                {
                                                    TestId = n.TestId,
                                                    TestDetails = n.TestDetails,
                                                    ColFirst = n.ColFirst,
                                                    ColSecond = n.ColSecond,
                                                    ColThird = n.ColThird,
                                                    ColFourth = n.ColFourth,
                                                    ColFifth = n.ColFifth,
                                                    ColSixth = n.ColSixth,
                                                    VisualTrueFalse = n.VisualTrueFalse,
                                                    TestLocked = n.TestLocked,
                                                    Gender = n.Gender,
                                                    Units = n.Units,
                                                    FromRange = n.FromRange,
                                                    UptoRange = n.UptoRange,
                                                    RangeSymble = n.RangeSymble,
                                                    RangeDetails = n.RangeDetails,
                                                    AgeType = n.AgeType,
                                                    FromAge = n.FromAge,
                                                    UptoAge = n.UptoAge,
                                                    DefaultResult = n.DefaultResult,
                                                    MiniRange = n.MiniRange,
                                                    MaxRange = n.MaxRange,
                                                    TempNo = (int)n.TempNo,
                                                    CompId = n.CompId
                                                }).ToList()
                                }).FirstOrDefaultAsync(x => x.CompId == fromcompId && x.Id == fromTestId);

            var result1 = await _applicationDbContext.TestGroupTable.Where(x => x.CompId == uptocompid && x.Name.Trim() == resultx.TestGroupMasterViewModel.Name.Trim()).FirstOrDefaultAsync();
            if (result1 == null)
            {
                TestGroupMaster DMaster = new TestGroupMaster()
                {
                    CompId = uptocompid,
                    Name = resultx.TestGroupMasterViewModel.Name,
                    ShortName = resultx.TestGroupMasterViewModel.ShortName,
                    IPPer1 = resultx.TestGroupMasterViewModel.IPPer1,
                    IPAmt1 = resultx.TestGroupMasterViewModel.IPAmt1
                };
                _applicationDbContext.Entry(DMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
            }
            var result2 = await _applicationDbContext.ReportGroupTable.Where(x => x.CompId == uptocompid && x.Name.Trim() == resultx.ReportGroupViewModel.Name.Trim()).FirstOrDefaultAsync();
            if (result2 == null)
            {
                ReportGroup ReportGroupGroup = new ReportGroup()
                {
                    CompId = uptocompid,
                    Name = resultx.ReportGroupViewModel.Name,
                    TempNo = resultx.ReportGroupViewModel.TempNo
                };
                _applicationDbContext.Entry(ReportGroupGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
            }
            var result3 = await _applicationDbContext.TestMasterTable.Where(x => x.CompId == uptocompid && x.TestCode.Trim() == resultx.TestCode.Trim()).FirstOrDefaultAsync();
            if (result3 == null)
            {
                TestMaster TestMasterMaster = new TestMaster()
                {
                    CompId = uptocompid,
                    TestCode = resultx.TestCode,
                    ReportId = await _applicationDbContext.ReportGroupTable.Where(x => x.CompId == uptocompid && x.Name == resultx.ReportGroupViewModel.Name).Select(x => x.Id).FirstOrDefaultAsync(),
                    TestGroupId = await _applicationDbContext.TestGroupTable.Where(x => x.CompId == uptocompid && x.Name == resultx.TestGroupMasterViewModel.Name).Select(x => x.Id).FirstOrDefaultAsync(),
                    Rate = resultx.Rate,
                    PPRate = resultx.PPRate,
                    CCRate = resultx.CCRate,
                    IPPer1 = resultx.IPPer1,
                    IPAmt1 = resultx.IPAmt1,
                    documentType = resultx.documentType,
                    ColumnsNo = resultx.ColumnsNo,
                    GraphsType = resultx.GraphsType
                };
                _applicationDbContext.Entry(TestMasterMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
                foreach (var itemx in resultx.TestSubMasterViewModels)
                {
                    TestSubMaster order = new TestSubMaster()
                    {
                        //Id = itemx.Id,
                        TestDetails = itemx.TestDetails,
                        ColFirst = itemx.ColFirst != null ? itemx.ColFirst : null,
                        ColSecond = itemx.ColSecond != null ? itemx.ColSecond : null,
                        ColThird = itemx.ColThird != null ? itemx.ColThird : null,
                        ColFourth = itemx.ColFourth != null ? itemx.ColFourth : null,
                        ColFifth = itemx.ColFifth != null ? itemx.ColFifth : null,
                        ColSixth = itemx.ColSixth != null ? itemx.ColSixth : null,
                        VisualTrueFalse = itemx.VisualTrueFalse,
                        TestLocked = itemx.TestLocked,
                        Gender = itemx.Gender,
                        Units = itemx.Units != null ? itemx.Units : null,
                        FromRange = itemx.FromRange != null ? itemx.FromRange : null,
                        UptoRange = itemx.UptoRange != null ? itemx.UptoRange : null,
                        RangeSymble = itemx.RangeSymble != null ? itemx.RangeSymble : null,
                        RangeDetails = itemx.RangeDetails != null ? itemx.RangeDetails : null,
                        AgeType = itemx.AgeType != null ? itemx.AgeType : null,
                        FromAge = (int)itemx.FromAge,
                        UptoAge = (int)itemx.UptoAge,
                        DefaultResult = itemx.DefaultResult != null ? itemx.DefaultResult : null,
                        MiniRange = itemx.MiniRange != null ? itemx.MiniRange : null,
                        MaxRange = itemx.MaxRange != null ? itemx.MaxRange : null,
                        TempNo = itemx.TempNo,
                        CompId = uptocompid,
                        TestId = TestMasterMaster.Id
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                var result5 = await _applicationDbContext.TestSubMasterTable.OrderBy(x => x.TempNo).Where(x => x.TestId == result3.Id).ToListAsync();
                int tmpno = (int)result5.OrderByDescending(x => x.TempNo).Select(x => x.TempNo).FirstOrDefault();
                tmpno++;
                foreach (var itemx in result5)
                {
                    var result6 = await _applicationDbContext.TestSubMasterTable.Where(x => x.TestId == result3.Id && x.TempNo == tmpno).FirstOrDefaultAsync();
                    if (result6 == null)
                    {
                        TestSubMaster order = new TestSubMaster()
                        {
                            //Id = itemx.Id,
                            TestDetails = itemx.TestDetails,
                            ColFirst = itemx.ColFirst != null ? itemx.ColFirst : null,
                            ColSecond = itemx.ColSecond != null ? itemx.ColSecond : null,
                            ColThird = itemx.ColThird != null ? itemx.ColThird : null,
                            ColFourth = itemx.ColFourth != null ? itemx.ColFourth : null,
                            ColFifth = itemx.ColFifth != null ? itemx.ColFifth : null,
                            ColSixth = itemx.ColSixth != null ? itemx.ColSixth : null,
                            VisualTrueFalse = itemx.VisualTrueFalse,
                            TestLocked = itemx.TestLocked,
                            Gender = itemx.Gender,
                            Units = itemx.Units != null ? itemx.Units : null,
                            FromRange = itemx.FromRange != null ? itemx.FromRange : null,
                            UptoRange = itemx.UptoRange != null ? itemx.UptoRange : null,
                            RangeSymble = itemx.RangeSymble != null ? itemx.RangeSymble : null,
                            RangeDetails = itemx.RangeDetails != null ? itemx.RangeDetails : null,
                            AgeType = itemx.AgeType != null ? itemx.AgeType : null,
                            FromAge = (int)itemx.FromAge,
                            UptoAge = (int)itemx.UptoAge,
                            DefaultResult = itemx.DefaultResult != null ? itemx.DefaultResult : null,
                            MiniRange = itemx.MiniRange != null ? itemx.MiniRange : null,
                            MaxRange = itemx.MaxRange != null ? itemx.MaxRange : null,
                            TempNo = itemx.TempNo,
                            CompId = uptocompid,
                            TestId = result3.Id
                        };
                        _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                    else
                    {
                        result6.TestDetails = itemx.TestDetails;
                        result6.ColFirst = itemx.ColFirst != null ? itemx.ColFirst : null;
                        result6.ColSecond = itemx.ColSecond != null ? itemx.ColSecond : null;
                        result6.ColThird = itemx.ColThird != null ? itemx.ColThird : null;
                        result6.ColFourth = itemx.ColFourth != null ? itemx.ColFourth : null;
                        result6.ColFifth = itemx.ColFifth != null ? itemx.ColFifth : null;
                        result6.ColSixth = itemx.ColSixth != null ? itemx.ColSixth : null;
                        result6.VisualTrueFalse = itemx.VisualTrueFalse;
                        result6.TestLocked = itemx.TestLocked;
                        result6.Gender = itemx.Gender;
                        result6.Units = itemx.Units != null ? itemx.Units : null;
                        result6.FromRange = itemx.FromRange != null ? itemx.FromRange : null;
                        result6.UptoRange = itemx.UptoRange != null ? itemx.UptoRange : null;
                        result6.RangeSymble = itemx.RangeSymble != null ? itemx.RangeSymble : null;
                        result6.RangeDetails = itemx.RangeDetails != null ? itemx.RangeDetails : null;
                        result6.AgeType = itemx.AgeType != null ? itemx.AgeType : null;
                        result6.FromAge = (int)itemx.FromAge;
                        result6.UptoAge = (int)itemx.UptoAge;
                        result6.DefaultResult = itemx.DefaultResult != null ? itemx.DefaultResult : null;
                        result6.MiniRange = itemx.MiniRange != null ? itemx.MiniRange : null;
                        result6.MaxRange = itemx.MaxRange != null ? itemx.MaxRange : null;
                        _applicationDbContext.Entry(result6).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                }
                await _applicationDbContext.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<List<PatientViewModel>> GetALLPatientCompanyWiseWeekly(DateTime dateTime)
        {
            dateTime = dateTime.ToString() == "01/01/0001 00:00:00" ? DateTime.Today : dateTime;
            var result1 = await _applicationDbContext.DoctorTable.ToListAsync();
            var result = await _applicationDbContext.PatientTable.Where(x => x.RDate.Value.Year == dateTime.Year).ToListAsync();
            List<PatientViewModel> customer = new List<PatientViewModel>();
            foreach (var item in result1)
            {
                PatientViewModel customerViewModels = new PatientViewModel()
                {
                    EmailAddress = item.Code,
                    PaidAmt = result.Where(x => x.Id == item.Id).Count()
                };
                customer.Add(customerViewModels);
            }
            return customer;
        }
        public async Task<List<PatientViewModel>> GetALLPatientCompanyWiseMonthly(DateTime dateTime)
        {
            dateTime = dateTime.ToString() == "01/01/0001 00:00:00" ? DateTime.Today : dateTime;
            var result1 = await _applicationDbContext.DoctorTable.ToListAsync();
            var result = await _applicationDbContext.PatientTable
                        .Where(x => x.RDate.Value.Month == dateTime.Month &&
                            x.RDate.Value.Year == dateTime.Year
                        ).ToListAsync();
            List<PatientViewModel> customer = new List<PatientViewModel>();
            foreach (var item in result1)
            {
                PatientViewModel customerViewModels = new PatientViewModel()
                {
                    EmailAddress = item.Code,
                    PaidAmt = result.Where(x => x.Id == item.Id).Count()
                };
                customer.Add(customerViewModels);
            }
            return customer;
        }       
        public async Task<List<PatientViewModel>> GetALLPatientRecord(DateTime dateTime,int BranchId)
        {
             dateTime = dateTime.ToString() == "01/01/0001 00:00:00" ? DateTime.Today : dateTime;
            int nox = 0;
            var result = await _applicationDbContext.TestGroupTable
                      .Where(x => x.CompId == BranchId).ToListAsync();
            var result1 = await _applicationDbContext.PatientTable
                    .Where(x => x.RDate.Value.Date == dateTime && x.CompId == BranchId)
                  .Select(x => new PatientViewModel()
                  {
                      Id = x.Id
                  }).ToListAsync();
            
            List<PatientViewModel> customer = new List<PatientViewModel>();
            foreach (var item in result)
            {
                nox = 0;
                foreach (var item1 in result1)
                {
                   nox += await CountPatientDetailReportWise(item1.Id, item.Id);
                }
                PatientViewModel customerViewModels = new PatientViewModel()
                {
                    Id = item.Id,
                    EmailAddress = item.Name,
                    PaidAmt =nox
                };
                customer.Add(customerViewModels);
            }
            return customer;
        }
        private async Task<int> CountPatientDetailReportWise(int patientId,int rptId)
        {
            var result = await _applicationDbContext.PatientDetailsMasterTable
                   .Where(x => x.PtIMId == patientId && x.TestMaster.TestGroupMaster.Id == rptId).ToListAsync();                 
                    
            return result !=null ? result.Count : 0;
        }

        // Med Test Master File
        public async Task<int> AddNewMedMasterRecord(MedMasterViewModel models)
        {
            MedMaster DMaster = new MedMaster()
            {
                CompId = models.CompId,
                TestDetailsA = models.TestDetailsA,
                PatResultA = models.PatResultA,
                RangeDetailsA = models.RangeDetailsA,
                TestLineA = models.TestLineA,
                TestDetailsB = models.TestDetailsB,
                PatResultB = models.PatResultB,
                RangeDetailsB = models.RangeDetailsB,
                TestLineB = models.TestLineB
            };
            _applicationDbContext.Entry(DMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();            
            return DMaster.Id;
        }
        public async Task<bool> UpdateMedMaster(MedMasterViewModel models)
        {
            var result = await _applicationDbContext.MedMasterTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.CompId = models.CompId;
                result.TestDetailsA = models.TestDetailsA;
                result.PatResultA = models.PatResultA;
                result.RangeDetailsA = models.RangeDetailsA;
                result.TestLineA = models.TestLineA;
                result.TestDetailsB = models.TestDetailsB;
                result.PatResultB = models.PatResultB;
                result.RangeDetailsB = models.RangeDetailsB;
                result.TestLineB = models.TestLineB;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<MedMasterViewModel> GetMedMasterById(int id)
        {
            var result = await _applicationDbContext.MedMasterTable
                .Select(x => new MedMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestDetailsA = x.TestDetailsA,
                    PatResultA = x.PatResultA,
                    RangeDetailsA = x.RangeDetailsA,
                    TestLineA = x.TestLineA,
                    TestDetailsB = x.TestDetailsB,
                    PatResultB = x.PatResultB,
                    RangeDetailsB = x.RangeDetailsB,
                    TestLineB = x.TestLineB
                }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        
        public async Task<bool> DeleteMedMaster(int id)
        {
            var result2 = await _applicationDbContext.MedMasterTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<MedMasterViewModel>> GetAllMedMaster(int cmpid)
        {
            var result = await _applicationDbContext.MedMasterTable
                .OrderBy(x => x.Id)
                .Where(x => x.CompId == cmpid)
                .Select(x => new MedMasterViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    TestDetailsA = x.TestDetailsA,
                    PatResultA = x.PatResultA,
                    RangeDetailsA = x.RangeDetailsA,
                    TestLineA = x.TestLineA,
                    TestDetailsB = x.TestDetailsB,
                    PatResultB = x.PatResultB,
                    RangeDetailsB = x.RangeDetailsB,
                    TestLineB = x.TestLineB
                }).ToListAsync();
            return result;
        }

        // Med Patient File
        public async Task<int> AddNewMedFile(MedTestViewModel models)
        {            
            MedTest opnitemMaster = new MedTest()
            {                
                CompId = models.CompId,
                PtId = models.PtId,                
                PassportNo = models.PassportNo,
                DateOfIssue = models.DateOfIssue,
                Nationality = models.Nationality,
                DateOfBirth = models.DateOfBirth,
                Trade = models.Trade,
                ExamDate = models.ExamDate,
                ExpiryDate = models.ExpiryDate,
                VisaNoDate = models.VisaNoDate,
                PhotoPath = models.ExitPhotoPath,
                MedRemarks = models.MedRemarks,
                MedPatientType = (int) models.MedPatientType,
                PatHeight = models.PatHeight,
                PatWeight = models.PatWeight,
                PatientMarried = (int)models.PatientMarried,
                PatientReligion = (int) models.PatientReligion,
                PlaceIssue = models.PlaceIssue,
                RecrutingAgency = models.RecrutingAgency,
                AllergyIssue = models.AllergyIssue,
                OtherIssue = models.OtherIssue
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.MedTestDetailViewModels)
            {                
                MedTestDetail order = new MedTestDetail()
                {
                    Id = item.Id,
                    MedId = opnitemMaster.Id,
                    TestDetailsA = item.TestDetailsA,
                    PatResultA = item.PatResultA,                    
                    RangeDetailsA = item.RangeDetailsA,
                    TestLineA = item.TestLineA,
                    TestDetailsB = item.TestDetailsB,
                    PatResultB = item.PatResultB,
                    RangeDetailsB = item.RangeDetailsB,
                    TestLineB = item.TestLineB,
                    TempSrNo = (int)item.TempSrNo,
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return opnitemMaster.Id;
        }
        public async Task<bool> UpdateMedFile(MedTestViewModel models)
        {
            
            var result = await _applicationDbContext.MedTestTable.FirstOrDefaultAsync(n => n.Id == models.Id);
            if (result != null)
            {                
                result.CompId = result.CompId;
                result.PtId = models.PtId;                
                result.PassportNo = models.PassportNo;
                result.DateOfIssue = models.DateOfIssue;
                result.Nationality = models.Nationality;
                result.DateOfBirth = models.DateOfBirth;
                result.Trade = models.Trade;
                result.ExamDate = models.ExamDate;
                result.ExpiryDate = models.ExpiryDate;
                result.VisaNoDate = models.VisaNoDate;
                result.PhotoPath = models.ExitPhotoPath;
                result.MedRemarks = models.MedRemarks;
                result.MedPatientType = (int) models.MedPatientType;
                result.PatHeight = models.PatHeight;
                result.PatWeight = models.PatWeight;
                result.PatientMarried = (int)models.PatientMarried;
                result.PatientReligion = (int)models.PatientReligion;
                result.PlaceIssue = models.PlaceIssue;
                result.RecrutingAgency = models.RecrutingAgency;
                result.AllergyIssue = models.AllergyIssue;
                result.OtherIssue = models.OtherIssue;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in models.MedTestDetailViewModels)
            {
                
                var result1 = await _applicationDbContext.MedTestDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == item.TempSrNo && x.MedId == models.Id);
                if (result1 != null)
                {
                    result1.MedId = result.Id;
                    result1.TestDetailsA = item.TestDetailsA;
                    result1.PatResultA = item.PatResultA;
                    result1.RangeDetailsA = item.RangeDetailsA;
                    result1.TestLineA = item.TestLineA;
                    result1.TestDetailsB = item.TestDetailsB;
                    result1.PatResultB = item.PatResultB;
                    result1.RangeDetailsB = item.RangeDetailsB;
                    result1.TestLineB = item.TestLineB;
                    result1.TempSrNo = (int)item.TempSrNo;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }                
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<MedTestViewModel> GetMedFileById(int id)
        {
            var result = await _applicationDbContext.MedTestTable
                    .Select(x => new MedTestViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        PtId = x.PtId,
                        PassportNo = x.PassportNo,
                        DateOfIssue = x.DateOfIssue,
                        Nationality = x.Nationality,
                        DateOfBirth = x.DateOfBirth,
                        Trade = x.Trade,
                        ExamDate = x.ExamDate,
                        ExpiryDate = x.ExpiryDate,
                        VisaNoDate = x.VisaNoDate,
                        ExitPhotoPath = x.PhotoPath,
                        MedRemarks = x.MedRemarks,
                        MedPatientType = (PatientFitType)x.MedPatientType,
                        PatHeight = x.PatHeight,
                        PatWeight = x.PatWeight,
                        PatientMarried = (PatientMarriedType)x.PatientMarried,
                        PatientReligion = (PatientReligionType)x.PatientReligion,
                        PlaceIssue = x.PlaceIssue,
                        RecrutingAgency = x.RecrutingAgency,
                        AllergyIssue = x.AllergyIssue,
                        OtherIssue = x.OtherIssue,
                        MedTestDetailViewModels = x.MedTestDetails.Where(a => a.MedId == x.Id)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new MedTestDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            MedId = n.MedId,
                            TestDetailsA = n.TestDetailsA,
                            PatResultA = n.PatResultA,
                            RangeDetailsA = n.RangeDetailsA,
                            TestLineA = n.TestLineA,
                            TestDetailsB = n.TestDetailsB,
                            PatResultB = n.PatResultB,
                            RangeDetailsB = n.RangeDetailsB,
                            TestLineB = n.TestLineB
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<MedTestViewModel> GetMedFileByPtId(int id)
        {
            var result = await _applicationDbContext.MedTestTable
                    .Select(x => new MedTestViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        PtId = x.PtId,
                        PassportNo = x.PassportNo,
                        DateOfIssue = x.DateOfIssue,
                        Nationality = x.Nationality,
                        DateOfBirth = x.DateOfBirth,
                        Trade = x.Trade,
                        ExamDate = x.ExamDate,
                        ExpiryDate = x.ExpiryDate,
                        VisaNoDate = x.VisaNoDate,
                        ExitPhotoPath = x.PhotoPath,
                        MedRemarks = x.MedRemarks,
                        MedPatientType = (PatientFitType)x.MedPatientType,
                        PatHeight = x.PatHeight,
                        PatWeight = x.PatWeight,
                        PatientMarried = (PatientMarriedType)x.PatientMarried,
                        PatientReligion = (PatientReligionType)x.PatientReligion,
                        PlaceIssue = x.PlaceIssue,
                        RecrutingAgency = x.RecrutingAgency,
                        AllergyIssue = x.AllergyIssue,
                        OtherIssue = x.OtherIssue
                    }).FirstOrDefaultAsync(x => x.PtId == id);
            return result;
        }
        public async Task<MedTestViewModel> GetMedFileByIdReport(int id)
        {
            var result = await _applicationDbContext.MedTestTable
                    .Select(x => new MedTestViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        DoctorCompanyDetailsViews = new CompanyDetailViewModel()
                        {
                            CompName = x.DoctorCompanyDetails.CompName,
                            Address1 = x.DoctorCompanyDetails.Address1,
                            Address2 = x.DoctorCompanyDetails.Address2,
                            Address3 = x.DoctorCompanyDetails.Address3,
                            City = x.DoctorCompanyDetails.City,
                            PinNo = x.DoctorCompanyDetails.PinNo,
                            StateId = x.DoctorCompanyDetails.StateId,
                            StateInCompany = new StateViewModel()
                            {
                                StateName = x.DoctorCompanyDetails.State.StateName
                            },
                            DistId = x.DoctorCompanyDetails.DistId,
                            DistrictInCompany = new DistrictViewModel()
                            {
                                DistrictName = x.DoctorCompanyDetails.District.DistrictName
                            },
                            PhoneNo = x.DoctorCompanyDetails.PhoneNo,
                            MobileNo = x.DoctorCompanyDetails.MobileNo,
                            EmailAddress = x.DoctorCompanyDetails.EmailAddress,
                            GSTNo = x.DoctorCompanyDetails.GSTNo,
                            Jurisdiction = x.DoctorCompanyDetails.Jurisdiction,
                            TransCode = x.DoctorCompanyDetails.TransCode,
                            FromDate = (x.DoctorCompanyDetails.FromDate != null ? Convert.ToDateTime(x.DoctorCompanyDetails.FromDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            UptoDate = (x.DoctorCompanyDetails.UptoDate != null ? Convert.ToDateTime(x.DoctorCompanyDetails.UptoDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            ExitPhotoPath = x.DoctorCompanyDetails.PhotoPath,
                            ExitSignaturePhotoPath = x.DoctorCompanyDetails.SignaturePhotoPath,
                            ExitSignaturePhotoPathLeft = x.DoctorCompanyDetails.SignaturePhotoPathLeft,
                            PhotoPathPrint = x.DoctorCompanyDetails.PhotoPathPrint,
                            SignaturePrint = x.DoctorCompanyDetails.SignaturePrint,
                            SignaturePrintLeft = x.DoctorCompanyDetails.SignaturePrintLeft
                        },
                        PtId = x.PtId,
                        PatientViewModel = new PatientViewModel()
                        {
                            Id = x.Id,                            
                            VNo = x.Patient.VNo,
                            SDate = (x.Patient.SDate != null ? Convert.ToDateTime(x.Patient.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            RDate = (x.Patient.RDate != null ? Convert.ToDateTime(x.Patient.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            STime = x.Patient.STime,
                            RTime = x.Patient.RTime,
                            Type = x.Patient.Type,
                            RefNo = x.Patient.RefNo,
                            TitleName = x.Patient.TitleName,
                            Name = x.Patient.Name,
                            AdharNo = x.Patient.AdharNo,
                            Sex = (Gender)x.Patient.Sex,
                            Age = Convert.ToInt32(x.Patient.Age),
                            AgeType = x.Patient.AgeType,
                            Address = x.Patient.Address,
                            MobileNo = x.Patient.MobileNo,
                            EmailAddress = x.Patient.EmailAddress,
                            AgentAcCode = x.Patient.AgentAcCode,
                            DrName = x.Patient.DrName,
                            DoctorAcCode = x.Patient.DoctorAcCode,
                            LedgerMasterViewModel = new LedgerMasterViewModel()
                            {
                                LedCode = x.Patient.PatientDoctorAcCode.LedCode,
                                PartyName = x.Patient.PatientDoctorAcCode.PartyName + ' ' + x.Patient.PatientDoctorAcCode.Address3
                            },                            
                            TestDetailRecord = x.Patient.TestDetailRecord,
                            Remark = x.Patient.Remark,
                            ReportDate = x.Patient.ReportDate,
                            ReportCancel = x.Patient.ReportCancel,
                            ResultNotDone = x.Patient.ResultNotDone,
                            ResultDone = x.Patient.ResultDone,
                            ReportApproved = x.Patient.ReportApproved,
                            ReportIssue = x.Patient.ReportIssue,
                            ReportHold = x.Patient.ReportHold,
                            ReportRecipt = x.Patient.ReportRecipt,
                            ReportDispatch = x.Patient.ReportDispatch
                        },
                        PassportNo = x.PassportNo,
                        DateOfIssue = x.DateOfIssue,
                        Nationality = x.Nationality,
                        DateOfBirth = x.DateOfBirth,
                        Trade = x.Trade,
                        ExamDate = x.ExamDate,
                        ExpiryDate = x.ExpiryDate,
                        VisaNoDate = x.VisaNoDate,
                        ExitPhotoPath = x.PhotoPath,
                        MedRemarks = x.MedRemarks,
                        MedPatientType = (PatientFitType)x.MedPatientType,
                        PatHeight = x.PatHeight,
                        PatWeight = x.PatWeight,
                        PatientMarried = (PatientMarriedType)x.PatientMarried,
                        PatientReligion = (PatientReligionType)x.PatientReligion,
                        PlaceIssue = x.PlaceIssue,
                        RecrutingAgency = x.RecrutingAgency,
                        AllergyIssue = x.AllergyIssue,
                        OtherIssue = x.OtherIssue,
                        MedTestDetailViewModels = x.MedTestDetails.Where(a => a.MedId == x.Id)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new MedTestDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            MedId = n.MedId,
                            TestDetailsA = n.TestDetailsA,
                            PatResultA = n.PatResultA,
                            RangeDetailsA = n.RangeDetailsA,
                            TestLineA = n.TestLineA,
                            TestDetailsB = n.TestDetailsB,
                            PatResultB = n.PatResultB,
                            RangeDetailsB = n.RangeDetailsB,
                            TestLineB = n.TestLineB
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<MedTestViewModel> GetMedFileByIdNo(string id)
        {
            var result1 = await _applicationDbContext.PatientTable.FirstOrDefaultAsync(x => x.VNo == id);
            var result = await _applicationDbContext.MedTestTable
                    .Select(x => new MedTestViewModel()
                    {
                        Id = x.Id,
                        CompId = x.CompId,
                        DoctorCompanyDetailsViews = new CompanyDetailViewModel()
                        {
                            CompName = x.DoctorCompanyDetails.CompName,
                            Address1 = x.DoctorCompanyDetails.Address1,
                            Address2 = x.DoctorCompanyDetails.Address2,
                            Address3 = x.DoctorCompanyDetails.Address3,
                            City = x.DoctorCompanyDetails.City,
                            PinNo = x.DoctorCompanyDetails.PinNo,
                            StateId = x.DoctorCompanyDetails.StateId,
                            StateInCompany = new StateViewModel()
                            {
                                StateName = x.DoctorCompanyDetails.State.StateName
                            },
                            DistId = x.DoctorCompanyDetails.DistId,
                            DistrictInCompany = new DistrictViewModel()
                            {
                                DistrictName = x.DoctorCompanyDetails.District.DistrictName
                            },
                            PhoneNo = x.DoctorCompanyDetails.PhoneNo,
                            MobileNo = x.DoctorCompanyDetails.MobileNo,
                            EmailAddress = x.DoctorCompanyDetails.EmailAddress,
                            GSTNo = x.DoctorCompanyDetails.GSTNo,
                            Jurisdiction = x.DoctorCompanyDetails.Jurisdiction,
                            TransCode = x.DoctorCompanyDetails.TransCode,
                            FromDate = (x.DoctorCompanyDetails.FromDate != null ? Convert.ToDateTime(x.DoctorCompanyDetails.FromDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            UptoDate = (x.DoctorCompanyDetails.UptoDate != null ? Convert.ToDateTime(x.DoctorCompanyDetails.UptoDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            ExitPhotoPath = x.DoctorCompanyDetails.PhotoPath,
                            ExitSignaturePhotoPath = x.DoctorCompanyDetails.SignaturePhotoPath,
                            ExitSignaturePhotoPathLeft = x.DoctorCompanyDetails.SignaturePhotoPathLeft,
                            PhotoPathPrint = x.DoctorCompanyDetails.PhotoPathPrint,
                            SignaturePrint = x.DoctorCompanyDetails.SignaturePrint,
                            SignaturePrintLeft = x.DoctorCompanyDetails.SignaturePrintLeft,
                            ValidedDate = x.DoctorCompanyDetails.UptoDate
                        },
                        PtId = x.PtId,
                        PatientViewModel = new PatientViewModel()
                        {
                            Id = x.Id,
                            VNo = x.Patient.VNo,
                            SDate = (x.Patient.SDate != null ? Convert.ToDateTime(x.Patient.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            RDate = (x.Patient.RDate != null ? Convert.ToDateTime(x.Patient.RDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            STime = x.Patient.STime,
                            RTime = x.Patient.RTime,
                            Type = x.Patient.Type,
                            RefNo = x.Patient.RefNo,
                            TitleName = x.Patient.TitleName,
                            Name = x.Patient.Name,
                            AdharNo = x.Patient.AdharNo,
                            Sex = (Gender)x.Patient.Sex,
                            Age = Convert.ToInt32(x.Patient.Age),
                            AgeType = x.Patient.AgeType,
                            Address = x.Patient.Address,
                            MobileNo = x.Patient.MobileNo,
                            EmailAddress = x.Patient.EmailAddress,
                            AgentAcCode = x.Patient.AgentAcCode,
                            DrName = x.Patient.DrName,
                            DoctorAcCode = x.Patient.DoctorAcCode,
                            LedgerMasterViewModel = new LedgerMasterViewModel()
                            {
                                LedCode = x.Patient.PatientDoctorAcCode.LedCode,
                                PartyName = x.Patient.PatientDoctorAcCode.PartyName + ' ' + x.Patient.PatientDoctorAcCode.Address3
                            },
                            TestDetailRecord = x.Patient.TestDetailRecord,
                            Remark = x.Patient.Remark,
                            ReportDate = x.Patient.ReportDate,
                            ReportCancel = x.Patient.ReportCancel,
                            ResultNotDone = x.Patient.ResultNotDone,
                            ResultDone = x.Patient.ResultDone,
                            ReportApproved = x.Patient.ReportApproved,
                            ReportIssue = x.Patient.ReportIssue,
                            ReportHold = x.Patient.ReportHold,
                            ReportRecipt = x.Patient.ReportRecipt,
                            ReportDispatch = x.Patient.ReportDispatch
                        },
                        PassportNo = x.PassportNo,
                        DateOfIssue = x.DateOfIssue,
                        Nationality = x.Nationality,
                        DateOfBirth = x.DateOfBirth,
                        Trade = x.Trade,
                        ExamDate = x.ExamDate,
                        ExpiryDate = x.ExpiryDate,
                        VisaNoDate = x.VisaNoDate,
                        ExitPhotoPath = x.PhotoPath,
                        MedRemarks = x.MedRemarks,
                        MedPatientType = (PatientFitType)x.MedPatientType,
                        PatHeight = x.PatHeight,
                        PatWeight = x.PatWeight,
                        PatientMarried = (PatientMarriedType)x.PatientMarried,
                        PatientReligion = (PatientReligionType)x.PatientReligion,
                        PlaceIssue = x.PlaceIssue,
                        RecrutingAgency = x.RecrutingAgency,
                        AllergyIssue = x.AllergyIssue,
                        OtherIssue = x.OtherIssue,
                        MedTestDetailViewModels = x.MedTestDetails.Where(a => a.MedId == x.Id)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new MedTestDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            MedId = n.MedId,
                            TestDetailsA = n.TestDetailsA,
                            PatResultA = n.PatResultA,
                            RangeDetailsA = n.RangeDetailsA,
                            TestLineA = n.TestLineA,
                            TestDetailsB = n.TestDetailsB,
                            PatResultB = n.PatResultB,
                            RangeDetailsB = n.RangeDetailsB,
                            TestLineB = n.TestLineB
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.PtId == result1.Id);
            return result;
        }
        public async Task<int> GetMedFileByPatientId(int id)
        {
            var result = await _applicationDbContext.MedTestTable.FirstOrDefaultAsync(x => x.PtId == id);
            return result != null ? result.Id: 0;
        }
        public async Task<bool> DeleteMedFile(MedTestViewModel models)
        {
            var result2 = await _applicationDbContext.MedTestTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeleteMedTestFile(int id)
        {
            var result2 = await _applicationDbContext.MedTestTable.FirstOrDefaultAsync(x => x.PtId == id);
            if (result2 != null)
            {
                var result3 = await _applicationDbContext.MedTestDetailTable.Where(x => x.MedId == result2.Id).ToListAsync();
                foreach (var item in result3)
                {
                    var result4 = await _applicationDbContext.MedTestDetailTable.FirstOrDefaultAsync(x => x.Id == item.Id && item.MedId == result2.Id);
                    if (result4 != null)
                    {
                        result4.Id = item.Id;
                        _applicationDbContext.Entry(result4).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                        _applicationDbContext.SaveChanges();
                    }
                }
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
    }
}