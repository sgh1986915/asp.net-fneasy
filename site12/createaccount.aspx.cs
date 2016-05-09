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

public partial class createaccount : FrontPage
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
        //this.Title = "Sign up";
        this.Title = "Create account";

        if (Request["Package_ID"] == null)
        {

        }
        else
        {
            package_id.Value = Request["Package_ID"].ToString();

        }

        if (Request["Buy_Type"] == null)
        {
            //buy_type.Value = "null";
        }
        else
        {
            buy_type.Value = Request["Buy_Type"].ToString();
            //ClientScript.RegisterStartupScript(GetType(), "Success_Scr3", "javascript: alert('buy_type: is not null  '); ", true);
        }
    }
    protected void submit_btn_Click(object sender, EventArgs e)
    {
        if (Address_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type address'); ", true);
        }
        else if (Email_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type Email Address'); ", true);
        }
        else if (Username_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type User Name'); ", true);
        }
        else if (Tradingname_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type Trading name to display'); ", true);
        }
        else if (Password_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type password'); ", true);
        }
        else if (VerifyPassword_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type verify password'); ", true);
        }
        else if (Password_txt.Text.ToString().Length < 6)
        {


            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Password and Verify password should be at least 6 characters'); ", true);
        }
        else if (Password_txt.Text != VerifyPassword_txt.Text)
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('New password and Verify passwords do not match'); ", true);
        }
        else if (Username_txt.Text.ToString().Contains("@"))
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Username can not include the @ symbol '); ", true);
        }
        else
        {

            if (mymembership.Get_User_by_Email(Email_txt.Text).Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Your email address is already registered.  Please Login or go to Forgotten Password'); ", true);
            }
            else if (mymembership.Get_User_by_Username(Username_txt.Text).Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Your username is already registered.  Please Login or go to Forgotten Password'); ", true);
            }
            else
            {
                if (ActivationCode_txt.Text == "")
                {
                    
                    string sendurl = "createaccount_two.aspx?BusinessName=" + BusinessName_txt.Text + "&Address=" + Address_txt.Text + "&PhoneNumber=" + PhoneNumber_txt.Text + "&Email=" + Email_txt.Text + "&Username=" + Username_txt.Text + "&Tradingname=" + Tradingname_txt.Text + "&ContactPerson=" + ContactPerson_txt.Text + "&Password=" + Password_txt.Text + "&ActivationCode=" + ActivationCode_txt.Text + "&package_id=" + package_id.Value.ToString() + "&buy_type=" + buy_type.Value.ToString();
                    Server.Transfer(sendurl);
                }
                else
                {
                    string sendurl = "createaccountdo.aspx?BusinessName=" + BusinessName_txt.Text + "&Address=" + Address_txt.Text + "&PhoneNumber=" + PhoneNumber_txt.Text + "&Email=" + Email_txt.Text + "&Username=" + Username_txt.Text + "&Tradingname=" + Tradingname_txt.Text + "&ContactPerson=" + ContactPerson_txt.Text + "&Password=" + Password_txt.Text + "&ActivationCode=" + ActivationCode_txt.Text + "&package_id=" + package_id.Value.ToString() + "&buy_type=" + buy_type.Value.ToString();
                    Server.Transfer(sendurl);

                }

            }



        }
    }
}