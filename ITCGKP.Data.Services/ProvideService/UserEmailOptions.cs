using System;
using System.Collections.Generic;
using System.Text;

namespace ITCGKP.Data.Services.ProvideService
{
    public class UserEmailOptions
    {
        public List<string> ToEmails { get; set; }
        public string Subjet { get; set; }
        public string Body { get; set; }
        public List<KeyValuePair<string, string>> PlaceHolders { get; set; }
    }
}
