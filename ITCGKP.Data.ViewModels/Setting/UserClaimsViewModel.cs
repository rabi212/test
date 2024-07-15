using System;
using System.Collections.Generic;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public class UserClaimsViewModel
    {
        public UserClaimsViewModel()
        {
            Claims = new List<UserClaim>();
        }
        public string UserId { get; set; }
        public List<UserClaim> Claims { get; set; }
    }
}
