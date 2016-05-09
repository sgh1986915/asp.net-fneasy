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

public partial class CampaignManage : FrontPage
{
    public campaign mycampaign;

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
        this.Title = "Campaign Management ";
         mycampaign = new campaign();

        if (Session["userID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            if (this.IsPostBack)
            {

            }
            else
            {
                GridView1.DataSource = mycampaign.GetCampaignList_by_UserID(Session["userID"].ToString());
                GridView1.DataBind();
            }
            

        }

    }

    protected void GridViewPageIndexChange(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void CampaignAddBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("CampaignAdd.aspx");
    }



    protected void GridRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string camID = this.GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView gdvFields = e.Row.FindControl("camFieldlist") as GridView;

           

            Session["CamID"] = camID;
            //LinkButton myLinkButton = e.Row.FindControl("LinkButton1") as LinkButton;
            //myLinkButton.PostBackUrl = "CampaignEdit.aspx?camID=" + camID;

            gdvFields.DataSource = mycampaign.GetCampaignfields_by_CamID(camID);
            gdvFields.DataBind();

        }
    }


    protected void GridViewDeleteCampaign_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.Parent.Parent as GridViewRow;

        string ID_val = this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();//获得DataKeys的值

        mycampaign.DeleteCampaign_by_ID(ID_val);
        GridView1.DataSource = mycampaign.GetCampaignList_by_UserID(Session["userID"].ToString());
        GridView1.DataBind();

    }
    protected void GridViewLauchCampaign_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.Parent.Parent as GridViewRow;

        string ID_val = this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();//获得DataKeys的值
        string jsfunstr = "window.open('LaunchCampaign.aspx', 'newwindow', 'fullscreen=3, top=0, left=0, height=1200, width=1600,toolbar=no, menubar=no, scrollbars=no, location=no,   status=no,resizable=no,location=no');";
        //string jsfunstr = "var slideWin = openDialog('LaunchCampaign.aspx', 'name', 'fullscreen=yes, resize=no');";
        String CamID = ID_val;

        Session["CamID"] = CamID;

        ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript:  " + jsfunstr, true);


    }

    protected void GridViewEditCampaign_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.Parent.Parent as GridViewRow;

        string ID_val = this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();//获得DataKeys的值

        //string jsfunstr = "window.open('CampaignEdit.aspx?camID=" + ID_val + "', 'newwindow', 'fullscreen=no, top=0, left=0, height=600, width=800,toolbar=no, menubar=ews, scrollbars=no, location=no,   status=no,resizable=yes,location=no');";
        //string jsfunstr = "var slideWin = openDialog('LaunchCampaign.aspx', 'name', 'fullscreen=yes, resize=no');";
        String CamID = ID_val;

        //Session["CamID"] = CamID;

        //ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript:  " + jsfunstr, true);

        Response.Redirect("CampaignEdit.aspx?camID=" + ID_val);


    }


    protected void ShowAutoRespond(string ID_val)
    {
        CampaignIDHiddenField.Value = ID_val;
        DataTable temptable;
        temptable = mycampaign.GetAutoRespond_by_CampaignID(ID_val);
        if (temptable.Rows.Count <= 0)
        {
            currentFilePanel.Visible = false;
            IDHiddenField.Value = "";

            EmailSubjectTextBox.Text = "";
            MessageTextBox.Text = "";

            for (int k = 0; k < SetAutoTypeRadioButtonList.Items.Count; k++)
            {

                if (k == 0)
                {
                    SetAutoTypeRadioButtonList.Items[k].Selected = true;
                }
                else
                {
                    SetAutoTypeRadioButtonList.Items[k].Selected = false;
                }


            }
        }
        else
        {

            currentFilePanel.Visible = false;
            for (int k = 0; k < SetAutoTypeRadioButtonList.Items.Count; k++)
            {
                if (SetAutoTypeRadioButtonList.Items[k].Value == temptable.Rows[0]["SendType"].ToString())
                {
                    SetAutoTypeRadioButtonList.Items[k].Selected = true;
                }
                else
                {
                    SetAutoTypeRadioButtonList.Items[k].Selected = false;
                }


            }
            IDHiddenField.Value = temptable.Rows[0]["ID"].ToString();
            EmailSubjectTextBox.Text = temptable.Rows[0]["Subject"].ToString();
            MessageTextBox.Text = temptable.Rows[0]["Message"].ToString();

            if (temptable.Rows[0]["SendAttachment"].ToString() != "" && temptable.Rows[0]["SendAttachment"].ToString() != "null")
            {
                currentFilePanel.Visible = true;
                currentFileHyperLink.Text = temptable.Rows[0]["SendAttachment"].ToString();
                currentFileHyperLink.NavigateUrl = common.GetUrl().ToString().Replace("CampaignManage.aspx", "").Replace("https", "http") + "Uploads/Mail/" + temptable.Rows[0]["AttachmentID"].ToString() + "/" + temptable.Rows[0]["SendAttachment"].ToString();
            }
        }
        SetAutoModalPopupExtender.Show();
    }
    protected void GridViewAutoRespondCampaign_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.Parent.Parent as GridViewRow;

        string ID_val = this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();//获得DataKeys的值

        ShowAutoRespond(ID_val);


    }

    protected void currentFileDelButton_Click(object sender, EventArgs e)
    {

        mycampaign.DeleteFileForAutoRespond(IDHiddenField.Value.ToString());

        ShowAutoRespond(CampaignIDHiddenField.Value.ToString());
        //mycampaign.UpdateAttachmentToDB_by_FilterID(IDHiddenField.Value.ToString(), "");
    }
    protected void SetAuto_btn_Click(object sender, EventArgs e)
    {
        Boolean fileOkExtenen = false;
        System.Guid guid = new Guid();
        guid = Guid.NewGuid();
        string AttachmentGuidstr = "";
        string sendAttachmentPath = "";

        if (FileUpload1.HasFile)
        {
            AttachmentGuidstr = guid.ToString();
            string path = Server.MapPath("~/Uploads/Mail/" + AttachmentGuidstr + "/");
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpeg", ".jpg", ".pdf", ".doc", ".swf", ".txt" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOkExtenen = true;

                }


            }
            sendAttachmentPath = FileUpload1.FileName;
            if (fileOkExtenen)
            {
                if (FileUpload1.PostedFile.ContentLength <= 1000 * 1024)
                {
                    try
                    {
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);

                    }
                    catch (Exception ex)
                    {

                        ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the attachment file  didn't successfully uploaded , the reason :" + ex.Message + "' ); ", true);

                    }


                }
                else
                {

                    ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the attachment file size can't exceeds 1000KB  '); ", true);
                }
            }
            else
            {

                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the  file  formats are not accepted   '); ", true);
            }
        }


        mycampaign.UpdateAutoRespond(IDHiddenField.Value.ToString(), CampaignIDHiddenField.Value.ToString(), SetAutoTypeRadioButtonList.SelectedValue.ToString(), EmailSubjectTextBox.Text, MessageTextBox.Text, AttachmentGuidstr, sendAttachmentPath);
        //mycampaign.UpdateSendMessage_by_FilterID(IDHiddenField.Value.ToString(), SetMessageTypeRadioButtonList.SelectedValue.ToString(), EmailSubjectTextBox.Text.ToString(), MessageTextBox.Text.ToString(), mySendTime, AttachmentGuidstr, sendAttachmentPath);
        //GridView1.DataSource = mycampaign.GetSendMessagesFilter_by_UserID(Session["userID"].ToString());
        //GridView1.DataBind();
    }

}