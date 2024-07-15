using ITCGKP.Data.Models.Setting;
using ITCGKP.Data.Models.Master;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITCGKP.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string City { get; set; }
        public int? CompanyDetailId { get; set; }
        [ForeignKey("CompanyDetailId")]
        public CompanyDetail CompanyDetail { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public ClientFile ClientFile { get; set; }
    }
}
