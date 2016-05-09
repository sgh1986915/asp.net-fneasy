using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            headerPanel.Visible = false;
        }
        else
        {
            headerPanel.Visible = true;
        }
    }
    public EventHandler<LoginEventArgs> OnLogin;
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //OnLogin(sender, new LoginEventArgs(Email_username_txt.Text, Password_txt.Text));
    }
}
