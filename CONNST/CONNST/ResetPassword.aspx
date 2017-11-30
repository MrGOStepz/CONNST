<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="CONNST.ResetPassword" %>
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
          <div id="login-overlay" class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div class="row"> 
                    <div class="col-xl-12">
                        <p style="text-align: center;" class="h4">NewPassword</p>
                        <div class="jumbotron login-padding">
                            <div class="form-group">
                                <label for="password" class="control-label">Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" title="Please enter your password" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">Confirm Password</label>
                                <asp:TextBox ID="txtCMPassword" runat="server" CssClass="form-control" title="Please enter your Confirm password" TextMode="Password"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnChangePW" runat="server" Text="Change Password" class="btn btn-info btn-block"/> <br />
                            <asp:Label ID="lbAlerts" runat="server" CssClass="alert alert-danger" Visible="False"></asp:Label>
                       </div>
                   </div>
               </div>
           </div>
       </div>
    </div>
    </div>
      </div>
</asp:Content>
