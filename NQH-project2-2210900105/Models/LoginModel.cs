using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NQH_project2_2210900105.Models
{
    public class LoginModel
    {
        public string member_username { get; set; }
        public string member_pass { get; set; }
        public byte admin_status { get; set; }
        public string admin_username { get; set; }
        public string admin_pass { get; set; }

    }
}