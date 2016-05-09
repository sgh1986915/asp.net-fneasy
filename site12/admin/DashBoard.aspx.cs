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
    public owner ownerobj;

    public string sortingOrder
    {
        get
        {
            if (ViewState["sortingOrder"].ToString() == "desc")
                ViewState["sortingOrder"] = "asc";
            else
                ViewState["sortingOrder"] = "desc";

            return ViewState["sortingOrder"].ToString();
        }
        set
        {
            ViewState["sortingOrder"] = value;
        }
    }

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
        
        ownerobj = new owner();
        
        if (this.IsPostBack) {

        } else {
            ViewState["sortingOrder"] = string.Empty;
    	    DataBindGrid("", "");
        }
    }

    protected void DataBindGrid(string sortExpr, string sortOrder)
    {
        DataTable dt = ownerobj.GetOwnerList();

        if (dt != null)
        {
            DataView dv = dt.DefaultView;

            if (sortExpr != string.Empty)
                dv.Sort = sortExpr + " " + sortOrder;

            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void GridViewDeleteOwner_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.Parent.Parent as GridViewRow;

        string ID_val = this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();

        ownerobj.DeleteOwner(ID_val);
        GridView1.DataSource = ownerobj.GetOwnerList();
        GridView1.DataBind();
    }

    protected void GridViewEditOwner_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.Parent.Parent as GridViewRow;

        string ID_val = this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();

        Response.Redirect("OwnerEdit.aspx?ownerID=" + ID_val);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataBindGrid(e.SortExpression, sortingOrder);
    }

    protected void ExportCSV_Click(object sender, EventArgs e)
    {
        DataTable temptable;
        
        temptable = ownerobj.GetOwnerList();

        StringWriter sw = new StringWriter();
        sw.WriteLine("Email,Business Name,Address,Phone Number,UserName,NameToDisplay,Contact Person,Activation Code");
        for (int j = 0; j < temptable.Rows.Count; j++)
        {
            sw.WriteLine(temptable.Rows[j]["Email"].ToString() + "," 
                + temptable.Rows[j]["BusinessName"].ToString() + "," 
                + temptable.Rows[j]["Address"].ToString() + "," 
                + temptable.Rows[j]["PhoneNumber"].ToString() + ","
                + temptable.Rows[j]["NameToDisplay"].ToString() + "," 
                + temptable.Rows[j]["Username"].ToString() + "," 
                + temptable.Rows[j]["ContactPerson"].ToString() + "," 
                + temptable.Rows[j]["ActivationCode"].ToString());
        }

        Response.AddHeader("Content-Disposition", "attachment; filename=ClientInfoList.csv");
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.Write(sw);
        Response.End();
    }
}