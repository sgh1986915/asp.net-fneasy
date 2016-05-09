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

public partial class createaccount_two : FrontPage
{
    public string BusinessName_val = "";
    public string Address_val = "";
    public string PhoneNumber_val = "";
    public string Email_val = "";
    public string Username_val = "";
    public string Tradingname_val = "";
    public string ContactPerson_val = "";
    public string Password_val = "";
    public string ActivationCode_val = "";


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
        this.Title = "Create account";
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

        if (Request["package_id"] == null)
        {
        }
        else
        {
            package_id.Value = Request["package_id"].ToString();
        }

        if (Request["buy_type"] == null)
        {
        }
        else
        {
            buy_type.Value = Request["buy_type"].ToString();
        }
    }

    protected void nocode_Click(object sender, EventArgs e)
    {
        
        string sendurl = "createaccountdo.aspx?BusinessName=" + BusinessName_val + "&Address=" + Address_val + "&PhoneNumber=" + PhoneNumber_val + "&Email=" + Email_val + "&Username=" + Username_val + "&Tradingname=" + Tradingname_val + "&ContactPerson=" + ContactPerson_val + "&Password=" + Password_val + "&ActivationCode=" + ActivationCode_txt.Text + "&package_id=" + package_id.Value.ToString() + "&buy_type=" + buy_type.Value.ToString();
        
        Server.Transfer(sendurl);

    }
    protected void submit_btn_Click(object sender, EventArgs e)
    {


        if (ActivationCode_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('please type Activation Code '); ", true);
        }
        else
        {
            string sendurl = "createaccountdo.aspx?BusinessName=" + BusinessName_val + "&Address=" + Address_val + "&PhoneNumber=" + PhoneNumber_val + "&Email=" + Email_val + "&Username=" + Username_val + "&Tradingname=" + Tradingname_val + "&ContactPerson=" + ContactPerson_val + "&Password=" + Password_val + "&ActivationCode=" + ActivationCode_txt.Text + "&package_id=" + package_id.Value.ToString() + "&buy_type=" + buy_type.Value.ToString();
            //Server.Transfer("createaccountdo.aspx");
            Server.Transfer(sendurl);
        }

    }
}