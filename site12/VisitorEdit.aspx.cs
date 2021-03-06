﻿using System;
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



public partial class VisitorEdit : FrontPage
{
    public campaign mycampaign;

    private DataTable visitorTable;
    private string ID_val;



    protected void Page_Init(object sender, EventArgs e)
    {
        Master.OnLogin += new EventHandler<LoginEventArgs>(OnPageLogin);
        
    }
    protected void OnPageLogin(object sender, LoginEventArgs e)
    {

        string UserName = e.username;
        string PassWord = e.password;
        this.goPageLogin(UserName, PassWord);

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Visitor Edit ";
        mycampaign = new campaign();
        if (Request["ID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            ID_val = Request["ID"].ToString();

            CampaignDropDownList.DataSource = mycampaign.GetCampaignInfo_by_UserID(Session["userID"].ToString());
            CampaignDropDownList.DataTextField = "Title";
            CampaignDropDownList.DataValueField = "ID";
            CampaignDropDownList.DataBind();


            


            if (this.IsPostBack)
            {
            }
            else
            {


                visitorTable = mycampaign.GetVisitorInfo_by_ID(Request["ID"].ToString());
                txtEmail.Text = visitorTable.Rows[0]["Email"].ToString();
                txtMobileNumber.Text = visitorTable.Rows[0]["MobileNumber"].ToString();
                txtFirstName.Text = visitorTable.Rows[0]["FirstName"].ToString();
                txtLastName.Text = visitorTable.Rows[0]["LastName"].ToString();
                txtDrivingLicenceNumber.Text = visitorTable.Rows[0]["DrivingLicenceNumber"].ToString();
                txtAddress.Text = visitorTable.Rows[0]["Address"].ToString();
                txtState.Text = visitorTable.Rows[0]["State"].ToString();
                txtPostcode.Text = visitorTable.Rows[0]["Postcode"].ToString();


                for (int k = 0; k < CampaignDropDownList.Items.Count; k++)
                {
                    if (CampaignDropDownList.Items[k].Value == visitorTable.Rows[0]["CampaignID"].ToString())
                    {
                        CampaignDropDownList.Items[k].Selected = true;
                    }
                    else
                    {
                        CampaignDropDownList.Items[k].Selected = false;
                    }


                }

                AgeDropDownList.DataSource=mycampaign.Get_CampaignAge();
                AgeDropDownList.DataTextField = "AgeText";
                AgeDropDownList.DataValueField = "AgeText";
                AgeDropDownList.DataBind();
                for (int j = 0; j < AgeDropDownList.Items.Count; j++)
                {
                    if (AgeDropDownList.Items[j].Text == visitorTable.Rows[0]["Age"].ToString())
                    {
                        AgeDropDownList.Items[j].Selected = true;

                    }
                    else
                    {
                        AgeDropDownList.Items[j].Selected = false;
                    }
                }

            }
        }
    }
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text == "")
        {

        }
        else
        {
            if (txtEmail.Text.ToString().Contains("@"))
            {

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type volid  email address'); ", true);
                return;
            }

        }

        if (txtEmail.Text.ToString() == "" && txtMobileNumber.Text.ToString() == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type  email address or Mobible Number at least '); ", true);
            return;
        }

        mycampaign.UpdateVisitorInfo(ID_val, CampaignDropDownList.SelectedValue.ToString(), txtEmail.Text.ToString(), txtMobileNumber.Text.ToString(), txtFirstName.Text.ToString(), txtLastName.Text.ToString(), txtDrivingLicenceNumber.Text.ToString(), txtAddress.Text.ToString(), txtState.Text.ToString(), txtPostcode.Text.ToString(), AgeDropDownList.SelectedValue.ToString());
        Response.Redirect("Maillist.aspx");
    }
}