using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CONNST
{
    public partial class NavUserControl : System.Web.UI.UserControl
    {
        public TextBox TextBoxPassword
        {
            get { return txtPassword; }
            set { txtPassword = value; }
        }

        public TextBox TextBoxUserName
        {
            get { return txtUserName; }
            set { txtUserName = value; }
        }

        public Button ButtonLogin
        {
            get { return btnLogin; }
            set { btnLogin = value; }
        }
                

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}