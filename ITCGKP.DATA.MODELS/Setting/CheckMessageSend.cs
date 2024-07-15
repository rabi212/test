using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models.Setting
{
    [Table("CheckMessageSendTable")]
    public class CheckMessageSend
    {
        [Key]
        public int Id { get; set; }       
        public int? CustCode { get; set; }
       // [ForeignKey("CustCode")]
        //public virtual Customer Customer { get; set; }        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:dd/mm/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? CurrentDate { get; set; }       
        public bool TodayMessageSend { get; set; }
        [StringLength(20)]
        public string MessageType { get; set; }
    }
}
