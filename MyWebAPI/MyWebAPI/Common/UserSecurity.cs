using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebAPI.Models;

namespace MyWebAPI.Common
{
    public class UserSecurity
    {
        static SECURITY_DBEntities context = new SECURITY_DBEntities();
        public static bool Login(string uname, string pass)
        {
            return context.UserMasters.Any(user => user.UserName.Equals(uname, StringComparison.OrdinalIgnoreCase) && user.UserPassword == pass);
        }
    }
}