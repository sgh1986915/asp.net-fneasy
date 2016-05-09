using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

using Touchdevice.Common;
using Touchdevice.Web;

public partial class OwnerEdit : System.Web.UI.Page
{
    public owner ownerobj;
    private DataTable ownerTable;

    private string strOwnerID;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Owner Edit ";

        ownerobj = new owner();

        if (Request["ownerID"] == null)
        {

        }
        else
        {
            strOwnerID = Request["ownerID"].ToString();
            Session["ownerID"] = Request["ownerID"].ToString();
        }

        if (Session["admin"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            if (this.IsPostBack)
            {

            }
            else
            {
                ownerTable = ownerobj.GetOwnerList(strOwnerID);

                txtEmail.Text = ownerTable.Rows[0]["Email"].ToString();
                txtBusinessName.Text = ownerTable.Rows[0]["BusinessName"].ToString();
                txtAddress.Text = ownerTable.Rows[0]["Address"].ToString();
                txtPhoneNumber.Text = ownerTable.Rows[0]["PhoneNumber"].ToString();
                txtNameToDisplay.Text = ownerTable.Rows[0]["NameToDisplay"].ToString();
                txtContactPerson.Text = ownerTable.Rows[0]["ContactPerson"].ToString();
                txtActivationCode.Text = ownerTable.Rows[0]["ActivationCode"].ToString();
            }
        }
    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {

        }
        else
        {
            if (txtEmail.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please input Email Address'); ", true);
            }
            else if (txtAddress.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please input Address'); ", true);
            }
            else if (txtNameToDisplay.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please input Trading Name'); ", true);
            }
            else if (txtActivationCode.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please input Activation Code'); ", true);
            }
            else
            {
                ownerobj.UpdateOwner(strOwnerID, txtEmail.Text, txtBusinessName.Text, txtAddress.Text, txtPhoneNumber.Text, txtNameToDisplay.Text, txtContactPerson.Text, txtActivationCode.Text);
                
                Response.Redirect("DashBoard.aspx");
            }
        }
    }
}