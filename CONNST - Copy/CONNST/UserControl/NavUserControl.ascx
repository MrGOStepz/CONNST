<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavUserControl.ascx.cs" Inherits="CONNST.NavUserControl" %>

            <div class="form-inline my-2 my-lg-0">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>  
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>  
                <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-outline-login my-2 my-sm-0" type="submit"/>
            </div>
