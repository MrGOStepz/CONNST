using CONNST.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CONNST
{
    public partial class index : System.Web.UI.Page
    {

        WebServiceClient wb = new WebServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (AppSession.GetUserProfile() != null)
            {
                //TODO change form login to Account Profile
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Please fill up username";
            }
            else if (txtPassword.Text == "")
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Please fill up password";
            }
            else if (txtCMPassword.Text == "")
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Please fill up Confirm password";
            }
            else if (txtPassword.Text != txtCMPassword.Text)
            {
                lbAlerts.Visible = true;
                lbAlerts.Text = "Password doesn't match";
            }
            else
            {
                //TODO Insert Member into Database
                // Go to the chat page
                // Get userID from Database
                // Setting Session
                //if (IsPostBack)
                //{
                //    // validate the Captcha to check we're not dealing with a bot

                //    bool isHuman = ExampleCaptcha.Validate(CaptchaCodeTextBox.Text);

                //    CaptchaCodeTextBox.Text = null; // clear previous user input

                //    if (!isHuman)
                //    {
                //        if (wb.RegisterUser(txtUserName.Text, txtPassword.Text) > 0)
                //        {
                //            UserLoginProfile userLoginProfile = new UserLoginProfile();
                //            int userID = wb.GetUserIDbyUserName(txtUserName.Text);
                //            userLoginProfile.UserID = userID;
                //            userLoginProfile.UserName = txtUserName.Text;
                //            AppSession.SetUserID(userLoginProfile);
                //            //Response.Redirect("chat.aspx");
                //            lbAlerts.Visible = true;
                //            lbAlerts.Text = "Register Success userID is " + userID;
                //        }
                //        else
                //        {
                //            lbAlerts.Visible = true;
                //            lbAlerts.Text = "There are something wrong.";
                //        }
                //    }
                //    else
                //    {
                //        lbAlerts.Visible = true;
                //        lbAlerts.Text = "There are something wrong.";
                //    }
                //}

                if (wb.RegisterUser(txtUserName.Text, txtPassword.Text) > 0)
                {
                    UserLoginProfile userLoginProfile = new UserLoginProfile();
                    int userID = wb.GetUserIDbyUserName(txtUserName.Text);
                    userLoginProfile.UserID = userID;
                    userLoginProfile.UserName = txtUserName.Text;
                    AppSession.SetUserID(userLoginProfile);
                    //Response.Redirect("chat.aspx");
                    lbAlerts.Visible = true;
                    lbAlerts.Text = "Register Success userID is " + userID;
                }
                else
                {
                    lbAlerts.Visible = true;
                    lbAlerts.Text = "There are something wrong.";
                }


            }
        }
    }
}