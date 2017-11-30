﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CONNSTWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebService" in both code and config file together.
    [ServiceContract]
    public interface IWebService
    {
        [OperationContract]
        string DoWork();

        [OperationContract]
        int RegisterUser(string userName, string password);

        [OperationContract]
        int GetUserIDbyUserName(string userName);

        [OperationContract]
        int GetUserIDbyUserAndPW(string userName, string password);
    }
}
