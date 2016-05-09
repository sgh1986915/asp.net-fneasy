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

public partial class Maillist : FrontPage
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
        this.Title = "Mailing List ";
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

                MessageTextBox.Text = "Please find attached our company brochure.";
                GridView1.DataSource = mycampaign.GetVisitorsList_by_UserID(Session["userID"].ToString());
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


                SendMassDateText.Text = DateTime.Now.Month.ToString() +"/" + DateTime.Today.Day.ToString() + "/" + DateTime.Now.Year.ToString();
                SendMassTimeText.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            }
            
        }
    }
    protected void VisitorAddBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("VisitorAdd.aspx?ID=");
    }

    protected void GridViewPageIndexChange(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void CustomersGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("VisitorEdit.aspx?ID=" + GridView1.DataKeys[GridView1.SelectedRow.RowIndex]["ID"].ToString());
        
    }

    protected void visitor_RowDelete(object sender, GridViewDeleteEventArgs e)
    {

       mycampaign.DeleteVisitor_by_ID(GridView1.DataKeys[e.RowIndex]["ID"].ToString());

       GridView1.DataSource = mycampaign.GetVisitorsList_by_UserID(Session["userID"].ToString());
       GridView1.DataBind();
    }




    protected void Filter_btn_Click(object sender, EventArgs e)
    {
        string Age_val="";
        string Postcode_val = "";
        string State_val = "";
        string Campaign_val = "";
        string Show_val = "";


        if (AgeCheckBox.Checked == true)
        {
            Age_val = AgeDropDownList.SelectedValue;
        }
        else
        {
            Age_val = "";
        }

        if (PostcodeCheckBox.Checked == true)
        {
            Postcode_val = PostcodeDropDownList.SelectedValue;
        }
        else
        {
            Postcode_val = "";
        }

        if (StateCheckBox.Checked == true)
        {
            State_val = StateDropDownList.SelectedValue;
        }
        else
        {
            State_val = "";
        }
        if (CampaignCheckBox.Checked == true)
        {
            Campaign_val = CampaignDropDownList.SelectedValue;
        }
        else
        {
            Campaign_val = "";
        }

        if (ShowCheckBox.Checked == true)
        {
            Show_val = ShowDropDownList.Items[ShowDropDownList.SelectedIndex].Text.ToString();

        }
        else
        {
            Show_val = "";
        }

        
        GridView1.DataSource = mycampaign.GetVisitorsPamaList_by_UserID(Session["userID"].ToString(), Age_val, Postcode_val, State_val, Campaign_val, Show_val);
        GridView1.DataBind();
        
    }

    protected void ShowAll_btn_Click(object sender, EventArgs e)
    {

        GridView1.DataSource = mycampaign.GetVisitorsList_by_UserID(Session["userID"].ToString());
        GridView1.DataBind();
    }


    protected void SendMassMessage_btn_Click(object sender, EventArgs e)
    {
        //this.PopupControlExtender1.;
        /*
        if (SendTypeRadioButtonList.SelectedValue == "now")
        {
            this.NowModalPopupExtender.Show();
        }
        else
        {
            this.LaterModalPopupExtender.Show();
        }
        */

        SendMassModalPopupExtender.Show();
        

    }

    protected void ExportCSV_Click(object sender, EventArgs e)
    {
        DataTable temptable;

        string MyAge_val = "";
        string MyPostcode_val = "";
        string MyState_val = "";
        string MyCampaign_val = "";

        string MyShow_val = "";



        if (AgeCheckBox.Checked == true)
        {
            MyAge_val = AgeDropDownList.SelectedValue;
        }
        else
        {
            MyAge_val = "";
        }

        if (PostcodeCheckBox.Checked == true)
        {
            MyPostcode_val = PostcodeDropDownList.SelectedValue;
        }
        else
        {
            MyPostcode_val = "";
        }

        if (StateCheckBox.Checked == true)
        {
            MyState_val = StateDropDownList.SelectedValue;
        }
        else
        {
            MyState_val = "";
        }
        if (CampaignCheckBox.Checked == true)
        {
            MyCampaign_val = CampaignDropDownList.SelectedValue;
        }
        else
        {
            MyCampaign_val = "";
        }


        if (ShowCheckBox.Checked == true)
        {
            MyShow_val = ShowDropDownList.Items[ShowDropDownList.SelectedIndex].Text.ToString();

        }
        else
        {
            MyShow_val = "";
        }

        temptable = mycampaign.GetVisitorsPamaList_by_UserID(Session["userID"].ToString(), MyAge_val, MyPostcode_val, MyState_val, MyCampaign_val, MyShow_val);


        StringWriter sw = new StringWriter();
        sw.WriteLine("Email,Mobile Number,First Name,Last Name,Driving Licence Number,Address,State,Postcode,Age");
        for (int j = 0; j < temptable.Rows.Count; j++)
        {
            sw.WriteLine(temptable.Rows[j]["Email"].ToString() + "," + temptable.Rows[j]["MobileNumber"].ToString() + "," + temptable.Rows[j]["FirstName"].ToString() + "," + temptable.Rows[j]["LastName"].ToString() + "," + temptable.Rows[j]["DrivingLicenceNumber"].ToString() + "," + temptable.Rows[j]["Address"].ToString() + "," + temptable.Rows[j]["State"].ToString() + "," + temptable.Rows[j]["Postcode"].ToString() + "," + temptable.Rows[j]["Age"].ToString() ); 
        }

        Response.AddHeader("Content-Disposition", "attachment; filename=ClientInfoList.csv");
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.Write(sw);
        Response.End(); 
    }


    protected void SendMassButton_Click(object sender, EventArgs e)
    {
        Boolean fileOkExtenen = false;
        System.Guid guid = new Guid();
        guid = Guid.NewGuid();
        string guidstr = guid.ToString();
        string path = Server.MapPath("~/Uploads/Mail/" + guidstr + "/");
        if (FileUpload1.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            string[] allowedExtensions = { ".png", ".jpeg", ".jpg",".pdf",".doc",".swf",".txt" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOkExtenen = true;

                }


            }


            if (fileOkExtenen)
            {
                if (FileUpload1.PostedFile.ContentLength <= 1000 * 1024)
                {
                    try
                    {
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);


                        FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                        //mycommon.UpdateLogoToDB_by_UserID(userIDstr, FileUpload1.FileName);

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
        


       
        string sendtime = "";

        if(SendMassLaterRadioButtonList.SelectedValue.ToString()=="now")
        {
            sendtime = "";

            DataTable temptable;
            temptable = GetVisitorsTable();

            string send_title = " ";
            string send_content = " ";

            send_title = EmailSubjectTextBox.Text;


            for (int j = 0; j < temptable.Rows.Count; j++)
            {
                string Email_val = temptable.Rows[j]["Email"].ToString();
                string MobileNumber_val = temptable.Rows[j]["MobileNumber"].ToString();

                string FirstName_val = temptable.Rows[j]["FirstName"].ToString();
                string LastName_val = temptable.Rows[j]["LastName"].ToString();
                string DrivingLicenceNumber_val = temptable.Rows[j]["DrivingLicenceNumber"].ToString();
                string Address_val = temptable.Rows[j]["Address"].ToString();
                string State_val = temptable.Rows[j]["State"].ToString();
                string Postcode_val = temptable.Rows[j]["Postcode"].ToString();
                string Age_val = temptable.Rows[j]["Age"].ToString();


                send_content = " ";
                if (FirstName_val == "")
                {

                }
                else
                {
                    send_content = send_content + " Hello " + FirstName_val + " \n    Your First Name : " + FirstName_val;
                }

                if (LastName_val == "")
                {

                }
                else
                {
                    send_content = send_content + "   \n   Your Last  Name : " + LastName_val;
                }

                if (Email_val == null || Email_val == "")
                {

                }
                else
                {
                    send_content = send_content + "    \n  Your Email : " + Email_val;
                }

                if (MobileNumber_val == null || MobileNumber_val == "")
                {

                }
                else
                {

                    send_content = send_content + "   \n   Your Mobile Number : " + MobileNumber_val;
                }



                if (LastName_val == "")
                {

                }
                else
                {
                    send_content = send_content + "   \n   Your Last  Name : " + LastName_val;
                }

                if (DrivingLicenceNumber_val == "")
                {

                }
                else
                {
                    send_content = send_content + "   \n   Your Driving Licence Number : " + DrivingLicenceNumber_val;
                }

                if (Address_val == "")
                {

                }
                else
                {
                    send_content = send_content + "    \n  Your Address  : " + Address_val;
                }

                if (State_val == "")
                {

                }
                else
                {
                    send_content = send_content + "  \n   Your State : " + State_val;
                }

                if (Postcode_val == "")
                {

                }
                else
                {

                    send_content = send_content + "   \n  Your Post code : " + Postcode_val;
                }

                if (Age_val == "")
                {

                }
                else
                {

                    send_content = send_content + "  \n   Your Age : " + Age_val;
                }


                send_content = send_content + System.Environment.NewLine + MessageTextBox.Text;


                if (SendMassTypeRadioButtonList.SelectedValue.ToString() == "emailsms")
                {
                    if (Email_val == null || Email_val == "")
                    {

                    }
                    else
                    {

                        mycampaign.AddSendEmailMobile(Email_val, send_title, send_content, guidstr, FileUpload1.FileName, "email", SendMassLaterRadioButtonList.SelectedValue, sendtime, "n");
                    }
                    if (MobileNumber_val == null || MobileNumber_val == "")
                    {

                    }
                    else
                    {

                        mycampaign.AddSendEmailMobile(MobileNumber_val, "", send_content, "", "", "mobile", SendMassLaterRadioButtonList.SelectedValue, sendtime, "n");
                    }

                }
                else if (SendMassTypeRadioButtonList.SelectedValue.ToString() == "email")
                {
                    if (Email_val == null || Email_val == "")
                    {

                    }
                    else
                    {
                        mycampaign.AddSendEmailMobile(Email_val, send_title, send_content, guidstr, FileUpload1.FileName, "email", SendMassLaterRadioButtonList.SelectedValue, sendtime, "n");
                    }
                }
                else
                {
                    if (MobileNumber_val == null || MobileNumber_val == "")
                    {

                    }
                    else
                    {

                        mycampaign.AddSendEmailMobile(MobileNumber_val, "", send_content, "", "", "mobile", SendMassLaterRadioButtonList.SelectedValue, sendtime, "n");
                    }
                }

            }
        }else{
            sendtime = SendMassDateText.Text.ToString() +" "+ SendMassTimeText.Text.ToString();
            //如果是随后发送，这里就不发送，仅仅把filter数据保存在数据库里，以便以后产生发送消息
            string MyAge_val = "";
            string MyPostcode_val = "";
            string MyState_val = "";
            string MyCampaign_val = "";

            if (AgeCheckBox.Checked == true)
            {
                MyAge_val = AgeDropDownList.SelectedValue;
            }
            else
            {
                MyAge_val = "";
            }

            if (PostcodeCheckBox.Checked == true)
            {
                MyPostcode_val = PostcodeDropDownList.SelectedValue;
            }
            else
            {
                MyPostcode_val = "";
            }

            if (StateCheckBox.Checked == true)
            {
                MyState_val = StateDropDownList.SelectedValue;
            }
            else
            {
                MyState_val = "";
            }
            if (CampaignCheckBox.Checked == true)
            {
                MyCampaign_val = CampaignDropDownList.SelectedValue;
            }
            else
            {
                MyCampaign_val = "";
            }
            mycampaign.AddSendMessagesFilter(userIDstr, SendMassTypeRadioButtonList.SelectedValue.ToString(), MyAge_val, MyPostcode_val, MyState_val, MyCampaign_val, "", sendtime, guidstr, FileUpload1.FileName, EmailSubjectTextBox.Text,MessageTextBox.Text, "n");

        }

        


    }


    private DataTable GetVisitorsTable()
    {
        DataTable temptable;

        string MyAge_val = "";
        string MyPostcode_val = "";
        string MyState_val = "";
        string MyCampaign_val = "";
        string MyShow_val = "";

        if (AgeCheckBox.Checked == true)
        {
            MyAge_val = AgeDropDownList.SelectedValue;
        }
        else
        {
            MyAge_val = "";
        }

        if (PostcodeCheckBox.Checked == true)
        {
            MyPostcode_val = PostcodeDropDownList.SelectedValue;
        }
        else
        {
            MyPostcode_val = "";
        }

        if (StateCheckBox.Checked == true)
        {
            MyState_val = StateDropDownList.SelectedValue;
        }
        else
        {
            MyState_val = "";
        }
        if (CampaignCheckBox.Checked == true)
        {
            MyCampaign_val = CampaignDropDownList.SelectedValue;
        }
        else
        {
            MyCampaign_val = "";
        }

        if (ShowCheckBox.Checked == true)
        {
            MyShow_val = ShowDropDownList.Items[ShowDropDownList.SelectedIndex].Text.ToString();

        }
        else
        {
            MyShow_val = "";
        }



        temptable = mycampaign.GetVisitorsPamaList_by_UserID(Session["userID"].ToString(), MyAge_val, MyPostcode_val, MyState_val, MyCampaign_val, MyShow_val);


        return temptable;

    }

 

    protected void mySelectedIndexChanged(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('mySelectedIndexChanged  '); ", true);
        if (SendMassLaterRadioButtonList.SelectedIndex == 0)
        {
            DatePanel.Visible = false;
        }
        else
        {
            DatePanel.Visible = true;
        }
        
        SendMassModalPopupExtender.Show();

    }
}