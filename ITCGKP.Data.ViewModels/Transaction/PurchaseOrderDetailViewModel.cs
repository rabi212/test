using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ITCGKP.Data.ViewModels.Transaction
{
    public class PurchaseOrderDetailViewModel
    {
        [Key]
        public int SOMDId { get; set; }
        [Required(ErrorMessage ="The Item name field must be required")]
        [Remote(action: "IsItemCodeValidation", controller: "DateCheck")]
        public int ItemCode { get; set; }       
        public virtual ItemMasterViewModel ItemMasterViewModel { get; set; }
        [Required(ErrorMessage = "The Item name field must be required")]
        [Display(Name = "Item Name")]
        [StringLength(100)]
        public string SSItemName { get; set; }
        [Required(ErrorMessage = "The Unit Case field must be required")]
        [Display(Name = "Unit")]
        public decimal? CasePcs { get; set; }
        [Required(ErrorMessage = "The Rate field must be required")]
        [Display(Name = "Rate")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? Rate { get; set; }
        [Display(Name = "Unit Name")]        
        [StringLength(100)]
        public string UnitName { get; set; }
        [Display(Name = "GST %")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? GSTPer { get; set; }
        //[Required]
        public int TempSrNo { get; set; }
        //[Required]
        public int CompIdSOItemMD { get; set; }
        //[Required]
        [StringLength(128)]
        public string UserCodeSOItemMD { get; set; }
        //[Required]
        [StringLength(6)]
        public string SOVNoD { get; set; }
        public int SOIMId { get; set; }
        public string RecordType { get; set; }
        public virtual PurchaseOrderViewModel PurchaseOrderViewModel { get; set; }
    }
}