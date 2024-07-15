using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.ViewModels.Master
{
    public class TestResultDetailViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="The Value field must be required")]
        public string PatientValue { get; set; }
        public int? TempNo { get; set; }
        public int TestResultId { get; set; }
        public virtual TestResultViewModel TestResultViewModel { get; set; }
    }
}
