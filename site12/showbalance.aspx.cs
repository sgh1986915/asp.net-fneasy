using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using System.Data;
using Touchdevice.Dal;
using Touchdevice.Common;
using Touchdevice.Web;

public partial class showbalance : FrontPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Balance";

        if (Session["userID"] == null)
        {
            //Response.Redirect("index.aspx");


        }
        else
        {
            DataTable mytable;
            mytable = mymembership.Get_PackageDetail_by_UserID(Session["userID"].ToString());


            if (mytable.Rows.Count == 0)
            {

            }
            else
            {
                total_sms_txt.Text = mytable.Rows[0]["SmsNumber"].ToString();
                used_sms_txt.Text = mytable.Rows[0]["UsedSmsNumber"].ToString();
                total_valume_txt.Text = mytable.Rows[0]["Volume"].ToString();
                used_valume_txt.Text = mytable.Rows[0]["UsedVolume"].ToString();

            }

        }
    }
}