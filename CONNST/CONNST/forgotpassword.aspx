<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="CONNST.forgotpassword" %>
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
        <div id="login-overlay" class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div class="row"> 
                    <div class="col-xl-12">
                        <p style="text-align: center;" class="h4">Your Email</p>
                        <div class="jumbotron login-padding">
                            <div class="form-group">
                                <label for="email" class="control-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" title="Email"></asp:TextBox>  

                            </div>
                            <asp:Button ID="btnSumbit" runat="server" Text="Submit" class="btn btn-info btn-block" /> <br />
                            <asp:Label ID="lbAlerts" runat="server" CssClass="alert alert-danger" Visible="False"></asp:Label>
                       </div>
                   </div>
               </div>
           </div>
       </div>
    </div>
</asp:Content>
