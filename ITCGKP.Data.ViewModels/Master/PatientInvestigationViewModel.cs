using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class PatientInvestigationViewModel
    {
        [Key]
        public int Id { get; set; }      
        public string TestDetails { get; set; }

        public string TestDetailsF { get; set; }
        [StringLength(100)]
        public string ColFirst { get; set; }
        [StringLength(100)]
        public string ColSecond { get; set; }
        [StringLength(100)]
        public string ColThird { get; set; }
        [StringLength(100)]
        public string ColFourth { get; set; }
        [StringLength(100)]
        public string ColFifth { get; set; }
        [StringLength(100)]
        public string ColSixth { get; set; }        
        public string PatResult { get; set; }
        public bool VisualTrueFalse { get; set; }
        [StringLength(5)]
        public string TestLocked { get; set; }
        [StringLength(2)]
        public string Gender { get; set; }
        [StringLength(20)]
        public string Units { get; set; }
        [StringLength(20)]
        public string FromRange { get; set; }
        [StringLength(20)]
        public string UptoRange { get; set; }
        [StringLength(5)]
        public string RangeSymble { get; set; }
        public string RangeDetails { get; set; }
        public int FromAge { get; set; }
        public int UptoAge { get; set; }
        public string DefaultResult { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MiniRange { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxRange { get; set; }
        public bool PrintTrueFalse { get; set; }
        public int? TempNo { get; set; }
        public string TempDigitPlace { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel CompanyDetailViewModel { get; set; }
        public int? TestIdX { get; set; }       
        public virtual TestMasterViewModel TestMasterViewModels { get; set; }
        public int? TestSubId { get; set; }
        public virtual TestSubMasterViewModel TestSubMasterViewModel { get; set; }
        public int PatientId { get; set; }
        public virtual PatientViewModel PatientViewModel { get; set; }
    }
}
