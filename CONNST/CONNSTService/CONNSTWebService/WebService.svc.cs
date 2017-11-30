using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CONNSTService;
using DataAccessLayer;

namespace CONNSTWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WebService.svc or WebService.svc.cs at the Solution Explorer and start debugging.
    public class WebService : IWebService
    {
        UserLogic userLogic = new UserLogic();

        public string DoWork()
        {
            return "I am very Handsome";
        }

        public int GetUserIDbyUserName(string userName)
        {
            return userLogic.GetUserIDbyUserName(userName);
        }

        public int GetUserIDbyUserAndPW(string userName, string password)
        {
            return userLogic.GetUserIDbyUserAndPW(userName, password);
        }

        public int RegisterUser(string userName, string password)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.UserName = userName;
            userProfile.Password = password;
            return userLogic.AddNewUser(userProfile);
        }

        
    }
}
