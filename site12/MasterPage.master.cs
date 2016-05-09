using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Touchdevice.Common;
using Touchdevice.Web;

public partial class Masterpage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            //mydiv.Visible = false;
            headerPanel1.Visible = true;
            headerPanel2.Visible = false;

            //Email_username_txt.Visible = true;
            //Password_txt.Visible = true;


        }
        else
        {
            //mydiv.Visible = true;
            headerPanel1.Visible = false;
            headerPanel2.Visible = true;
            //Email_username_txt.Visible = false;
            //Password_txt.Visible = false;
        }
    }
    public EventHandler<LoginEventArgs> OnLogin;
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        OnLogin(sender,new LoginEventArgs(Email_username_txt.Text, Password_txt.Text));
    }

}

