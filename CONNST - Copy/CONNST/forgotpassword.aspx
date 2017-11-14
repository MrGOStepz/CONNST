<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMain.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="CONNST.forgotpassword" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div id="login-overlay" class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div class="row"> 
                    <div class="col-xl-12">
                        <p style="text-align: center;" class="h4">Change Password</p>
                        <div class="jumbotron padding-bottom20">
                            <div class="form-group">
                                <label for="email" class="control-label">New Password</label>
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" title="New Password"></asp:TextBox>  
                                <label for="email" class="control-label">Confirm Password</label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" title="Confirm Password"></asp:TextBox>  

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
