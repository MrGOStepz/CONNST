using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CONNST.WebServiceReference;

namespace CONNST
{
    public partial class SiteMain : System.Web.UI.MasterPage
    {
        WebServiceClient wb = new WebServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (AppSession.GetUserProfile() != null)
            {
                //Response.Redirect("chat.aspx");
            }
            //TODO Make a Session Login
            //NavUserControl navUserControl = (NavUserControl)LoadControl("UserControl\\NavUserLoginControl.ascx");
            //phNavUserLogin.Controls.Add(navUserControl);

            //NavUserControl navUserControl = (NavUserControl)LoadControl("UserControl\\NavUserControl.ascx");
            //phNavUserLogin.Controls.Add(navUserControl);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //TODO Connect to service and Check User in Database
            //If it doesn't have do go any where and know the error
            //If there is, go to Chat Page and set Session.

            if (wb.GetUserIDbyUserAndPW(txtLoginUserName.Text, txtLoginPassword.Text) > 0)
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Login Success";
            }
            else
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Incorrect Id or Password";
            }
            
        }
    }
}