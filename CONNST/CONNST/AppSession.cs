using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CONNST
{
    public static class AppSession
    {
        /// <summary>
        /// Set User Id when user login.
        /// </summary>
        /// <param name="userID"></param>
        public static void SetUserID(UserLoginProfile userLoginProfile)
        {
            HttpContext.Current.Session["UserProfile"] = userLoginProfile;
        }

        /// <summary>
        /// Set User Id when user login.
        /// </summary>
        /// <param name="userID"></param>
        public static UserLoginProfile GetUserProfile()
        {
            if (HttpContext.Current.Session["UserProfile"] == null)
            {
                return null;
            }
            else
            {
                return (UserLoginProfile)(HttpContext.Current.Session["UserProfile"]);
            }
            
        }

        /// <summary>
        /// Clear Session When User Logout
        /// </summary>
        public static void ClearSession()
        {
            HttpContext.Current.Session["UserProfile"] = null;
        }
    }
}