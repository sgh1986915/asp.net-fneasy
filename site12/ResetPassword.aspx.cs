using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using Touchdevice.Common;
using Touchdevice.Web;



public partial class ResetPassword : FrontPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        Master.OnLogin += new EventHandler<LoginEventArgs>(OnPageLogin);
        //Master.Master.OnLogin
        //Master.OnLogin += new EventHandler<LoginEventArgs>(OnPageLogin);
    }
    protected void OnPageLogin(object sender, LoginEventArgs e)
    {
        string UserName = e.username;
        string PassWord = e.password;
        this.goPageLogin(UserName, PassWord);

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Reset Password";
    }
    protected void submit_btn_Click(object sender, EventArgs e)
    {
        if (Oldpassword_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type old password'); ", true);
        }
        else if (Password_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type new password'); ", true);
        }
        else if (VerifyPassword_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type verify  password'); ", true);
        }
        else if (Password_txt.Text != VerifyPassword_txt.Text)
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('New password and Verify password do not match'); ", true);
        }
        else
        {
            string userid_val;

            if (Session["userID"] == null)
            {
                Server.Transfer("index.aspx");
            }
            else
            {
                userid_val = Session["userID"].ToString();
                if (mymembership.restorePassword_by_ID(userid_val, Oldpassword_txt.Text, Password_txt.Text))
                {
                    ClientScript.RegisterStartupScript(GetType(), "Success_Scr2", "javascript: alert('Your already successfully changed your password'); ", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Success_Scr2", "javascript: alert('Your failed to  change your password'); ", true);
                }
            }


        }
    }
}