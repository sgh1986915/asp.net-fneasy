using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text == "" || txtUsername.Text == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type username'); ", true);
        }
        else if (txtPassword.Text == "" || txtPassword.Text == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type password'); ", true);
        }
        else
        {
            //verify login info

            //admin ID
            Session["admin"] = "1";
            Response.Redirect("Default.aspx");
        }
    }
}