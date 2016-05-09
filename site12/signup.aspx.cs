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


public partial class signup :  FrontPage
{
    public DataTable package_table;


    public DataTable temp_table;


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
        this.Title = "Sign up";
        string packageID = "null";

        if (Request["package"] == null)
        {

        }
        else
        {
            packageID = Request["package"].ToString();

            package_id.Value = packageID;

            package_table = mymembership.Package_by_ID(packageID);


            package_name.Text = package_table.Rows[0]["PackageName"].ToString();
            sitename.Text = package_table.Rows[0]["Website"].ToString();
            headertxt.Text = "Select Package";
        }
    }

    protected void nowbuy_btn_Click(object sender, EventArgs e)
    {
        // string buytypestr = "buy";
        // Context.Items.Add("Package_ID", package_id.Value);
        // Context.Items.Add("Buy_Type", buytypestr);
        //Server.Transfer("createaccount.aspx");
        string sendurl = "createaccount.aspx?Package_ID" + package_id.Value + "&Buy_Type=buy";
        Response.Redirect(sendurl);
    }
}