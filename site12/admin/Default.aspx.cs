using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.IO;

using Touchdevice.Common;
using Touchdevice.Web;

public partial class AdminDashBoard : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Administrator DashBoard ";
    }
}