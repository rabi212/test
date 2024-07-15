using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace ITCGKP.Data.ViewModels.Setting
{
    public class UploadPhotoFrontViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Title Field Required..")]
        [Display(Name ="Title :")]
        [StringLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Descriptions Field Required..")]
        [Display(Name = "Descriptions :")]
        public string Descriptions { get; set; }
        [Required(ErrorMessage = "Product Group Name Field Required..")]
        [Display(Name = "Product Group :")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "MRP Field Required..")]
        [Display(Name = "MRP :")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rate { get; set; }       
        public IFormFile Photo { get; set; }
        public string ExitPhotoPath { get; set; }
    }
}
