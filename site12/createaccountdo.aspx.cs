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

public partial class createaccountdo : FrontPage
{
    public DataTable temp_table;

    public string BusinessName_val = "";
    public string Address_val = "";
    public string PhoneNumber_val = "";
    public string Email_val = "";
    public string Username_val = "";
    public string Tradingname_val = "";
    public string ContactPerson_val = "";
    public string Password_val = "";
    public string ActivationCode_val = "";

    public string package_id_val = "";
    public string buy_type_val = "";

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
       // pagetitle = "Sign-up Complete";
        this.Title = "Sign-up Complete";

        if (Request["BusinessName"] == null)
        {
        }
        else
        {
            BusinessName_val = Request["BusinessName"].ToString();
        }

        if (Request["Address"] == null)
        {
        }
        else
        {
            Address_val = Request["Address"].ToString();
        }

        if (Request["PhoneNumber"] == null)
        {
        }
        else
        {
            PhoneNumber_val = Request["PhoneNumber"].ToString();
        }

        if (Request["Email"] == null)
        {
        }
        else
        {
            Email_val = Request["Email"].ToString();
        }

        if (Request["Username"] == null)
        {
        }
        else
        {
            Username_val = Request["Username"].ToString();
        }

        if (Request["Tradingname"] == null)
        {
        }
        else
        {
            Tradingname_val = Request["Tradingname"].ToString();
        }

        if (Request["ContactPerson"] == null)
        {
        }
        else
        {
            ContactPerson_val = Request["ContactPerson"].ToString();
        }

        if (Request["Password"] == null)
        {
        }
        else
        {
            Password_val = Request["Password"].ToString();
        }

        if (Request["ActivationCode"] == null)
        {
        }
        else
        {
            ActivationCode_val = Request["ActivationCode"].ToString();
        }


        if (Request["package_id"] == null)
        {
        }
        else
        {
            package_id_val = Request["package_id"].ToString();
        }

        if (Request["buy_type"] == null)
        {
        }
        else
        {
            buy_type_val = Request["buy_type"].ToString();
        }



        if (mymembership.Createuser(Email_val, BusinessName_val, Address_val, PhoneNumber_val, Username_val, Tradingname_val, Password_val, ContactPerson_val, ActivationCode_val) == true)
        {
            //mymembership.update_packageuser(
            string userID = mymembership.Get_UserID_by_Email(Email_val);
            mymembership.update_packageuser(package_id_val, userID, buy_type_val);


            showinfo.Text = "You have successfully signed-up for your new account. Thank you for using our service";
        }
        else
        {
            showinfo.Text = " There are system error , you didn't create your account, please contact administrator";
        }
    }
}