<%@ Page Title="Login" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CONNST.login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-xl-12">
            <p style="text-align: center;""><asp:Label ID="lbLoginError" runat="server" Text="Incorrect Username or Password!" CssClass="alert alert-danger" Visible="False"></asp:Label></p>
    
        </div>
    </div>

    <div id="login-overlay" class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div class="row"> 
                    <div class="col-xl-12">
                        <p style="text-align: center;" class="h4">Register</p>
                        <div class="jumbotron">
                            <div class="form-group">
                                <label for="username" class="control-label">Username</label>
                                <asp:TextBox ID="txtUserNameStaff" runat="server" CssClass="form-control" title="Please enter your Username"></asp:TextBox>                                          
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">Password</label>
                                <asp:TextBox ID="txtPasswordStaff" runat="server" CssClass="form-control" title="Please enter your password" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" class="control-label">Confirm Password</label>
                                <asp:TextBox ID="txtConfirmPW" runat="server" CssClass="form-control" title="Please confirm your Username" TextMode="Password"></asp:TextBox>
                            </div> 
                            <asp:Button ID="btnStaffRegister" runat="server" Text="Register" class="btn btn-danger btn-block" /> <br />
                            <asp:Label ID="lbAlerts" runat="server" CssClass="alert alert-danger" Visible="False"></asp:Label>
                       </div>
                   </div>
               </div>
           </div>
       </div>
    </div>

</asp:Content>
