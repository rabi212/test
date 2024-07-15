using System;
using System.Collections.Generic;
using System.Text;

namespace ITCGKP.Data.ViewModels
{
    public class FooterViewModel
    {
        public string SigLeft { get; set; }
        public string SigCenter { get; set; }
        public string SigRight { get; set; }
        public bool SigLeftTrueFalse { get; set; }
        public bool SigCenterTrueFalse { get; set; }
        public bool SigRightTrueFalse { get; set; }
        public string QrCodeValue { get; set; }
        public string BarCodeValue { get; set; }
        public bool BarCodeTopTrue { get; set; }
        public string FooterImages { get; set; }
        public bool FooterImagesTrueFalse { get; set; }
        public string VNo { get; set; }
        public bool QRCodePrint { get; set; }
        public bool BarCodePrint { get; set; }
    }
}
