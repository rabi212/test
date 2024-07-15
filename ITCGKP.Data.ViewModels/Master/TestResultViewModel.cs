using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TestResultViewModel
    {       
        [Key]
        public int Id { get; set; }
        public int? CompId { get; set; }
        [Required(ErrorMessage = "The Code field must be required")]
        [Display(Name = "Code")]
        public int? TestIdX { get; set; }
        [Required(ErrorMessage = "The Test Details field must be required")]
        [Display(Name = "Test Details")]
        public string TestDetailName { get; set; }
        public virtual List<TestResultDetailViewModel> TestResultDetailViewModels { get; set; }
        public TestResultViewModel()
        {
            TestResultDetailViewModels = new List<TestResultDetailViewModel>();
        }
        public int CurrentNo { get => TestResultDetailViewModels.Count + 1; }
        public int RowId { get; set; }

    }
}
