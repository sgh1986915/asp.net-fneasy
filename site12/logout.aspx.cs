using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Touchdevice.Common;
using Touchdevice.Web;

public partial class logout : FrontPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
         Session["userID"] = null;

         Response.Redirect("index.aspx");
           
           
    }
}