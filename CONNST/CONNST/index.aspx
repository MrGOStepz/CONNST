<%@ Page Title="Home" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CONNST.index" %>
<%--<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI"
    TagPrefix="BotDetect" %>--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <style type="text/css">
body { background-image:url("../images/bg-index.jpg");
       background-size: cover;
    background-repeat: repeat;
}

.login-padding{
    padding: 2rem 1rem;
}
.vertical-center {
  min-height: 100%;  /* Fallback for browsers do NOT support vh unit */
  min-height: 100vh; /* These two lines are counted as one :-)       */

  display: flex;
  align-items: center;
}
</style>
    
    <div class="container-fluid">
  <div class="row">
    <div class="col">
      <div class="jumbotron jumbotron-fluid">
          <div class="container">
            <h1 class="display-3">Hello</h1>
            <p class="lead">Welcome to CONNST</p>
          </div>
        </div>
    </div>
    <div class="col justify-content-center">
          <div id="login-overlay" class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div class="row"> 
                    <div class="col-xl-12">
                        <p style="text-align: center;" class="h4">Create an Account</p>
                        <div class="jumbotron login-padding">
                            <div class="form-group">
                                <label for="username" class="control-label">Username</label>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" title="Please enter your Username"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Fill Up User Name" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>--%>                                          
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" title="Please enter your password" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">Confirm Password</label>
                                <asp:TextBox ID="txtCMPassword" runat="server" CssClass="form-control" title="Please enter your Confirm password" TextMode="Password"></asp:TextBox>
                            </div>
<%--                            <BotDetect:Captcha ID="ExampleCaptcha" runat="server" />
                            <asp:TextBox ID="CaptchaCodeTextBox" runat="server" />--%>

                            <asp:Button ID="btnRegister" runat="server" Text="Login" class="btn btn-info btn-block" OnClick="btnRegister_Click"/> <br />
                            <asp:Label ID="lbAlerts" runat="server" CssClass="alert alert-danger" Visible="False"></asp:Label>
                       </div>
                   </div>
               </div>
           </div>
       </div>
    </div>
    </div>
  </div>
   </div>
</asp:Content>