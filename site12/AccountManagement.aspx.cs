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

public partial class AccountManagement  : FrontPage
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
        this.Title = "Account Management ";

        if (this.IsPostBack)
        {
            
            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }
        else
        {
            //ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('this is not callback'); ", true);


            if (Session["userID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                userid_val = Session["userID"].ToString();

                if (userid_val == "")
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    //ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('user id " + userid_val + "'); ", true);

                    DataTable mytable = mymembership.Get_User_by_UserID(userid_val);
                    if (mytable == null)
                    {

                    }
                    else
                    {
                        if (mytable.Rows.Count == 0)
                        {

                        }
                        else
                        {
                            BusinessName_txt.Text = mytable.Rows[0]["BusinessName"].ToString();
                            Address_txt.Text = mytable.Rows[0]["Address"].ToString();
                            PhoneNumber_txt.Text = mytable.Rows[0]["PhoneNumber"].ToString();
                            Email_txt.Text = mytable.Rows[0]["Email"].ToString();
                            Tradingname_txt.Text = mytable.Rows[0]["NameToDisplay"].ToString();
                            ContactPerson_txt.Text = mytable.Rows[0]["ContactPerson"].ToString();
                        }



                    }
                }

            }
        }

    }
    protected void submit_btn_Click(object sender, EventArgs e)
    {

        if (Email_txt.Text.ToString().Contains("@"))
        {
            userid_val = Session["userID"].ToString();
            //ClientScript.RegisterStartupScript(GetType(), "Success_Scr2", "javascript: alert('Address_txt " + Address_txt.Text + "'); ", true);
            mymembership.Set_User_by_UserID(userid_val, Email_txt.Text, BusinessName_txt.Text, Address_txt.Text, PhoneNumber_txt.Text, Tradingname_txt.Text, ContactPerson_txt.Text);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('You must enter correct email'); ", true);
        }
       
    }
}