using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CONNST
{
    public partial class SiteMain : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO Make a Session Login
            //NavUserControl navUserControl = (NavUserControl)LoadControl("UserControl\\NavUserLoginControl.ascx");
            //phNavUserLogin.Controls.Add(navUserControl);

            //NavUserControl navUserControl = (NavUserControl)LoadControl("UserControl\\NavUserControl.ascx");
            //phNavUserLogin.Controls.Add(navUserControl);
        }
    }
}