using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITCGKP.Data.ViewModels.Setting;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TestMasterViewModel
    {
        [Key]       
        [Display(Name = "Id :")]
        public int Id { get; set; }
        public int? CompId { get; set; }
        public virtual CompanyDetailViewModel TestMasterCompanyDetailsViews { get; set; }
        [Required(ErrorMessage ="Test Code Field Rquired")]
        [Display(Name = "Test Code :")]
        [StringLength(100)]
        public string TestCode { get; set; }
        [Display(Name = "Report's Name :")]
        public int? ReportId { get; set; }       
        public virtual ReportGroupViewModel ReportGroupViewModel { get; set; }
        [Display(Name = "Under Group :")]
        public int? TestGroupId { get; set; }       
        public virtual TestGroupMasterViewModel TestGroupMasterViewModel { get; set; }
        [Display(Name = "Standard Rate :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal Rate { get; set; }
        [Display(Name = "IP % :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal IPPer1 { get; set; }
        [Display(Name = "IP Amt :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal IPAmt1 { get; set; }
        //[Required(ErrorMessage = "Test Reading Or Document Field Rquired")]
        [StringLength(15)]
        [Display(Name = "Document :")]
        public string documentType { get; set; } // Reading or ducument
        //[Required(ErrorMessage = "The Columns No Field Rquired")]
        [Display(Name = "Columns :")]
        public int ColumnsNo { get; set; }  // reading time columns
        //[Required(ErrorMessage = "The Graphs Field Rquired")]
        [StringLength(5)]
        [Display(Name = "Graphs :")]
        public string GraphsType { get; set; }  // reading time Fixed 3 columns Yes/No
        public TestMasterViewModel()
        {
            TestSubMasterViewModels = new List<TestSubMasterViewModel>();
        }
        public virtual List<TestSubMasterViewModel> TestSubMasterViewModels { get; set; }        
        public int CurrentNo { get => TestSubMasterViewModels.Count + 1; }
        public int RowId { get; set; }
        public string TestDocumentain { get; set; }
        [Display(Name = "Add Rows")]
        public decimal? AddNo { get; set; }
        [Display(Name = "Add Down Rows")]
        public decimal? FromNo { get; set; }
        public decimal? UptoNo { get; set; }
        [Display(Name = "Test Code")]
        public decimal? TempTestIdAdd { get; set; }
        [Display(Name = "PP Rate :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal PPRate { get; set; }
        [Display(Name = "CC Rate :")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal CCRate { get; set; }
    }
}