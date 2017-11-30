﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CONNST.WebServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WebServiceReference.IWebService")]
    public interface IWebService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/DoWork", ReplyAction="http://tempuri.org/IWebService/DoWorkResponse")]
        string DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/DoWork", ReplyAction="http://tempuri.org/IWebService/DoWorkResponse")]
        System.Threading.Tasks.Task<string> DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/RegisterUser", ReplyAction="http://tempuri.org/IWebService/RegisterUserResponse")]
        int RegisterUser(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/RegisterUser", ReplyAction="http://tempuri.org/IWebService/RegisterUserResponse")]
        System.Threading.Tasks.Task<int> RegisterUserAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/GetUserIDbyUserName", ReplyAction="http://tempuri.org/IWebService/GetUserIDbyUserNameResponse")]
        int GetUserIDbyUserName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/GetUserIDbyUserName", ReplyAction="http://tempuri.org/IWebService/GetUserIDbyUserNameResponse")]
        System.Threading.Tasks.Task<int> GetUserIDbyUserNameAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/GetUserIDbyUserAndPW", ReplyAction="http://tempuri.org/IWebService/GetUserIDbyUserAndPWResponse")]
        int GetUserIDbyUserAndPW(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWebService/GetUserIDbyUserAndPW", ReplyAction="http://tempuri.org/IWebService/GetUserIDbyUserAndPWResponse")]
        System.Threading.Tasks.Task<int> GetUserIDbyUserAndPWAsync(string userName, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWebServiceChannel : CONNST.WebServiceReference.IWebService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceClient : System.ServiceModel.ClientBase<CONNST.WebServiceReference.IWebService>, CONNST.WebServiceReference.IWebService {
        
        public WebServiceClient() {
        }
        
        public WebServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoWork() {
            return base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task<string> DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public int RegisterUser(string userName, string password) {
            return base.Channel.RegisterUser(userName, password);
        }
        
        public System.Threading.Tasks.Task<int> RegisterUserAsync(string userName, string password) {
            return base.Channel.RegisterUserAsync(userName, password);
        }
        
        public int GetUserIDbyUserName(string userName) {
            return base.Channel.GetUserIDbyUserName(userName);
        }
        
        public System.Threading.Tasks.Task<int> GetUserIDbyUserNameAsync(string userName) {
            return base.Channel.GetUserIDbyUserNameAsync(userName);
        }
        
        public int GetUserIDbyUserAndPW(string userName, string password) {
            return base.Channel.GetUserIDbyUserAndPW(userName, password);
        }
        
        public System.Threading.Tasks.Task<int> GetUserIDbyUserAndPWAsync(string userName, string password) {
            return base.Channel.GetUserIDbyUserAndPWAsync(userName, password);
        }
    }
}