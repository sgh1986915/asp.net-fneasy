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

public partial class ScheduledMessages : FrontPage
{
    public campaign mycampaign;
    public common mycommon;
    private string userIDstr;

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
        this.Title = "Schedule Messages";
        mycampaign = new campaign();
        mycommon = new common();


        if (Session["userID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            userIDstr = Session["userID"].ToString();
            if (this.IsPostBack)
            {

            }
            else
            {
                GridView1.DataSource = mycampaign.GetSendMessagesFilter_by_UserID(Session["userID"].ToString());
                GridView1.DataBind();

                AgeDropDownList.DataSource = mycampaign.GetVisitorsAgeList_by_UserID(Session["userID"].ToString());
                AgeDropDownList.DataValueField = "Age";
                AgeDropDownList.DataTextField = "Age";
                AgeDropDownList.DataBind();


                PostcodeDropDownList.DataSource = mycampaign.GetVisitorsPostcodeList_by_UserID(Session["userID"].ToString());
                PostcodeDropDownList.DataValueField = "Postcode";
                PostcodeDropDownList.DataTextField = "Postcode";
                PostcodeDropDownList.DataBind();


                StateDropDownList.DataSource = mycampaign.GetVisitorsStateList_by_UserID(Session["userID"].ToString());
                StateDropDownList.DataValueField = "State";
                StateDropDownList.DataTextField = "State";
                StateDropDownList.DataBind();

                CampaignDropDownList.DataSource = mycampaign.GetVisitorsCampaignList_by_UserID(Session["userID"].ToString());
                CampaignDropDownList.DataValueField = "CampaignID";
                CampaignDropDownList.DataTextField = "Title";
                CampaignDropDownList.DataBind();

                ShowDropDownList.DataSource = mycampaign.GetVisitorsCampaignList_by_UserID(Session["userID"].ToString());
                ShowDropDownList.DataValueField = "CampaignID";
                ShowDropDownList.DataTextField = "Show";
                ShowDropDownList.DataBind();
            }
        }
    }
    
    
    protected void GridViewPageIndexChange(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridViewMessage_Click(object sender, EventArgs e)   
    {   
        Button    btn    =    sender    as    Button;   
        GridViewRow    row    =    btn.Parent.Parent    as    GridViewRow;   
           
        string    ID_val    =    this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();//获得DataKeys的值

        

        DataTable temptable;
        temptable = mycampaign.GetSendMessagesFilter_by_ID(ID_val);

        IDHiddenField.Value = ID_val;

        for (int k = 0; k < SetMessageTypeRadioButtonList.Items.Count; k++)
        {
            if (SetMessageTypeRadioButtonList.Items[k].Value == temptable.Rows[0]["SendType"].ToString())
            {
                SetMessageTypeRadioButtonList.Items[k].Selected = true;
            }
            else
            {
                SetMessageTypeRadioButtonList.Items[k].Selected = false;
            }


        }
        EmailSubjectTextBox.Text = temptable.Rows[0]["Subject"].ToString();
        MessageTextBox.Text = temptable.Rows[0]["Message"].ToString();


        DateTime dbTime = Convert.ToDateTime(temptable.Rows[0]["SendTime"].ToString());
        
        DateText.Text = dbTime.Month.ToString() +"/" + dbTime.Day.ToString() + "/" + dbTime.Year.ToString();
        TimeText.Text = dbTime.Hour.ToString() + ":" + dbTime.Minute.ToString();

        if (temptable.Rows[0]["SendAttachment"].ToString() == "")
        {
            currentFilePanel.Visible = false;
        }
        else
        {
            currentFilePanel.Visible = true;
            currentFileHyperLink.Text = temptable.Rows[0]["SendAttachment"].ToString();
            currentFileHyperLink.NavigateUrl = common.GetUrl().ToString().Replace("ScheduledMessages.aspx", "").Replace("https","http") + "Uploads/Mail/" + temptable.Rows[0]["AttachmentID"].ToString() + "/" + temptable.Rows[0]["SendAttachment"].ToString();
        }

        //currentLogoHyperLink.NavigateUrl = common.GetUrl().ToString().Replace("ScheduleMessages.aspx", "") + "Uploads/Mail/" + userIDstr + "/" + temp_table.Rows[0]["LogoFile"].ToString();

        SetMessageModalPopupExtender.Show();

           
   }
    protected void GridViewFilter_Click(object sender, EventArgs e)   
    {
        Button btn = sender as Button;
        GridViewRow row = btn.Parent.Parent as GridViewRow;

        string ID_val = this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();//获得DataKeys的值

        DataTable temptable;
        temptable = mycampaign.GetSendMessagesFilter_by_ID(ID_val);
        FilterIDHiddenField.Value=ID_val;
        int k = 0;
        if (temptable.Rows[0]["FilterAge"].ToString() == "")
        {
            AgeCheckBox.Checked = false;

        }
        else
        {
            AgeCheckBox.Checked = true;
            for (k = 0; k < AgeDropDownList.Items.Count; k++)
            {
                if (AgeDropDownList.Items[k].Value == temptable.Rows[0]["FilterAge"].ToString())
                {
                    AgeDropDownList.Items[k].Selected = true;
                }
                else
                {
                    AgeDropDownList.Items[k].Selected = false;
                }
            }
        }

        if (temptable.Rows[0]["FilterPostcode"].ToString() == "")
        {
            PostcodeCheckBox.Checked = false;

        }
        else
        {
            PostcodeCheckBox.Checked = true;
            for (k = 0; k < AgeDropDownList.Items.Count; k++)
            {
                if (PostcodeDropDownList.Items[k].Value == temptable.Rows[0]["FilterPostcode"].ToString())
                {
                    PostcodeDropDownList.Items[k].Selected = true;
                }
                else
                {
                    PostcodeDropDownList.Items[k].Selected = false;
                }
            }
        }


        if (temptable.Rows[0]["FilterState"].ToString() == "")
        {
            StateCheckBox.Checked = false;

        }
        else
        {
            for (k = 0; k < StateDropDownList.Items.Count; k++)
            {
                if (StateDropDownList.Items[k].Value == temptable.Rows[0]["FilterState"].ToString())
                {
                    StateDropDownList.Items[k].Selected = true;
                }
                else
                {
                    StateDropDownList.Items[k].Selected = false;
                }
            }
            StateCheckBox.Checked = true;
        }


        if (temptable.Rows[0]["FilterCampaignID"].ToString() == "")
        {
            CampaignCheckBox.Checked = false;

        }
        else
        {
            CampaignCheckBox.Checked = true;
            for (k = 0; k < CampaignDropDownList.Items.Count; k++)
            {
                if (CampaignDropDownList.Items[k].Value == temptable.Rows[0]["FilterCampaignID"].ToString())
                {
                    CampaignDropDownList.Items[k].Selected = true;
                }
                else
                {
                    CampaignDropDownList.Items[k].Selected = false;
                }
            }
        }


        if (temptable.Rows[0]["FilterShow"].ToString() == "")
        {
            ShowCheckBox.Checked = false;

        }
        else
        {
            ShowCheckBox.Checked = true;
            for (k = 0; k < ShowDropDownList.Items.Count; k++)
            {
                if (ShowDropDownList.Items[k].Value == temptable.Rows[0]["FilterShow"].ToString())
                {
                    ShowDropDownList.Items[k].Selected = true;
                }
                else
                {
                    ShowDropDownList.Items[k].Selected = false;
                }
            }
        }


        

        FilterModalPopupExtender.Show();
     
    }

    protected void GridViewDelete_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.Parent.Parent as GridViewRow;

        string ID_val = this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();//获得DataKeys的值

        mycampaign.DeleteMessageFilter_by_ID(ID_val);
        GridView1.DataSource = mycampaign.GetSendMessagesFilter_by_UserID(Session["userID"].ToString());
        GridView1.DataBind();
        
    }

    protected void currentFileDelButton_Click(object sender, EventArgs e)
    {
        //mycommon.UpdateLogoToDB_by_UserID(userIDstr, "");
        //currentLogoHyperLink.Text = temp_table.Rows[0]["LogoFile"].ToString();

        //currentLogoHyperLink.NavigateUrl = common.GetUrl().ToString().Replace("ScheduleMessages.aspx", "") + "Uploads/" + userIDstr + "/" + temp_table.Rows[0]["LogoFile"].ToString();

        mycampaign.UpdateAttachmentToDB_by_FilterID(IDHiddenField.Value.ToString(), "");
    }

    protected void Filter_btn_Click(object sender, EventArgs e)
    {

        //FilterIDHiddenField.Value

        string myFilterID = "";
        string myFilterAge = "";
        string myFilterPostcode = "";
        string myFilterState = "";
        string myFilterCampaignID = "";
        string myFilterShow = "";

        myFilterID = FilterIDHiddenField.Value.ToString();
        if (AgeCheckBox.Checked)
        {
            
            myFilterAge = AgeDropDownList.SelectedValue.ToString();
        }
        else
        {
            myFilterAge = "";
        }

        if (PostcodeCheckBox.Checked)
        {
            
            myFilterPostcode = PostcodeDropDownList.SelectedValue.ToString();
        }
        else
        {
            myFilterPostcode = "";
        }

        if (StateCheckBox.Checked)
        {
            myFilterState = StateDropDownList.SelectedValue.ToString();
        }
        else
        {
            

            myFilterState = "";
        }

        if (CampaignCheckBox.Checked)
        {
            
            myFilterCampaignID = CampaignDropDownList.SelectedValue.ToString();
        }
        else
        {
            myFilterCampaignID = "";
        }

        if (ShowCheckBox.Checked)
        {
            myFilterShow = ShowDropDownList.SelectedValue.ToString();
        }
        else
        {
            myFilterShow = "";
            
        }

        mycampaign.UpdateSendFilter_by_FilterID(myFilterID, myFilterAge, myFilterPostcode, myFilterState, myFilterCampaignID, myFilterShow);

        GridView1.DataSource = mycampaign.GetSendMessagesFilter_by_UserID(Session["userID"].ToString());
        GridView1.DataBind();
    }
    protected void SetMessage_btn_Click(object sender, EventArgs e)
    {
        Boolean fileOkExtenen = false;
        System.Guid guid = new Guid();
        guid = Guid.NewGuid();
        string AttachmentGuidstr = "";
        string sendAttachmentPath="";
       
        if (FileUpload1.HasFile)
        {
            AttachmentGuidstr= guid.ToString();
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
            sendAttachmentPath=FileUpload1.FileName;
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

        string mySendTime = "";
        mySendTime= DateText.Text.ToString() +" "+ TimeText.Text.ToString();
        mycampaign.UpdateSendMessage_by_FilterID(IDHiddenField.Value.ToString(), SetMessageTypeRadioButtonList.SelectedValue.ToString(), EmailSubjectTextBox.Text.ToString(), MessageTextBox.Text.ToString(),mySendTime,AttachmentGuidstr,sendAttachmentPath);
        GridView1.DataSource = mycampaign.GetSendMessagesFilter_by_UserID(Session["userID"].ToString());
        GridView1.DataBind();
    }
}