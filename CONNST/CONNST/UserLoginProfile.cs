using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CONNST
{
    public class UserLoginProfile
    {
        public int UserID { get; set; }
        public int UserType { get { return UserType; } set { UserType = 3; } }
        public string UserName { get; set ; }

    }
}