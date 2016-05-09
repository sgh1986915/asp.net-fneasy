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



public partial class CampaignEdit : FrontPage
{

    public campaign mycampaign;

    private DataTable campaignTable;

    private string strCamID;


    private string userIDstr;
    private string guidstr;

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
        this.Title = "Campaign Edit ";
        mycampaign = new campaign();
        if(Request["camID"]==null)
        {
            
        }else{
            strCamID = Request["camID"].ToString();
            Session["CamID"] = Request["camID"].ToString() ;

        }
        if (Session["userID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else if (Session["CamID"] == null)
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

                campaignTable = mycampaign.GetCampaignInfo_by_CamID(strCamID);

                txtCampaignName.Text = campaignTable.Rows[0]["Title"].ToString();
                txtCampainShow.Text = campaignTable.Rows[0]["Show"].ToString();
                txtCampainVenue.Text = campaignTable.Rows[0]["Venue"].ToString();

                //DateTime mytoday = DateTime.Today;
                Calendar1.TodaysDate = Convert.ToDateTime(campaignTable.Rows[0]["Date"].ToString());

                Calendar1.SelectedDate = Convert.ToDateTime(campaignTable.Rows[0]["Date"].ToString());
                txtCampainDate.Text = Calendar1.SelectedDate.ToShortDateString();
                txtLogo.Text = campaignTable.Rows[0]["Logo"].ToString();


                SiteDropDownList.DataSource = mycampaign.Site_by_order();
                SiteDropDownList.SelectedValue = campaignTable.Rows[0]["SiteID"].ToString();
                SiteDropDownList.DataTextField = "Website";
                SiteDropDownList.DataValueField = "ID";
                SiteDropDownList.DataBind();


                //SiteDropDownList.SelectedValue
                FieldCheckBoxList.DataSource = mycampaign.Get_Campaignfieldc_by_SiteID(SiteDropDownList.SelectedValue.ToString());
                FieldCheckBoxList.DataTextField = "FieldText";
                FieldCheckBoxList.DataValueField = "FieldID";
                FieldCheckBoxList.DataBind();

                BgColorDropDownList.DataSource = mycampaign.Get_CampainColor();
                BgColorDropDownList.DataTextField = "ColorText";
                BgColorDropDownList.DataValueField = "ColorValue";
                BgColorDropDownList.DataBind();

                for (int k = 0; k < BgColorDropDownList.Items.Count; k++)
                {
                    if (BgColorDropDownList.Items[k].Value == campaignTable.Rows[0]["BgColor"].ToString())
                    {
                        BgColorDropDownList.Items[k].Selected = true;
                    }
                    else
                    {
                        BgColorDropDownList.Items[k].Selected = false;
                    }
                    

                }

                for (int j = 0; j < FieldCheckBoxList.Items.Count; j++)
                {
                    if (mycampaign.isIncludeCampaignField(strCamID, FieldCheckBoxList.Items[j].Value) == true)
                    {
                        FieldCheckBoxList.Items[j].Selected = true;

                    }
                    else
                    {
                        FieldCheckBoxList.Items[j].Selected = false;
                    }
                }

                MainFieldCheckBoxList.DataSource = mycampaign.campaignfield_by_SiteID(SiteDropDownList.SelectedValue.ToString());
                MainFieldCheckBoxList.DataTextField = "FieldText";
                MainFieldCheckBoxList.DataValueField = "FieldID";
                MainFieldCheckBoxList.DataBind();

                for (int i = 0; i < MainFieldCheckBoxList.Items.Count; i++)
                {

                    MainFieldCheckBoxList.Items[i].Selected = true;

                }


               

               

                

            }
        }




    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        string[] fieldsID;


        List<string> listArr = new List<string>();

        if (Session["userID"] == null)
        {

        }
        else
        {
            if (txtCampaignName.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please input Campaign Name'); ", true);
            }
            else if (txtCampainShow.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please input Campain Show'); ", true);
            }
            else if (txtCampainVenue.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please input Campain Venue'); ", true);
            }
            else if (txtCampaignName.Text == "")
            {

            }
            else
            {

                if (LogoFileUpload1.FileName == null || LogoFileUpload1.FileName=="")
                {

                }
                else
                {
                    Boolean fileOkExtenen = false;
                    string path = Server.MapPath("~/Uploads/" + userIDstr + "/Campaign/");
                    if (LogoFileUpload1.HasFile)
                    {
                        string fileExtension = System.IO.Path.GetExtension(LogoFileUpload1.FileName).ToLower();
                        string[] allowedExtensions = { ".png", ".jpeg", ".jpg" };
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i])
                            {
                                fileOkExtenen = true;

                            }


                        }
                    }
                    if (fileOkExtenen)
                    {
                        if (LogoFileUpload1.PostedFile.ContentLength <= 500 * 1024)
                        {
                            try
                            {
                                if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);

                                System.Guid guid = new Guid();
                                guid = Guid.NewGuid();
                                guidstr = guid.ToString();
                                LogoFileUpload1.PostedFile.SaveAs(path + guidstr + LogoFileUpload1.FileName);
                                //mycommon.UpdateLogoToDB_by_UserID(userIDstr, LogoFileUpload1.FileName);

                            }
                            catch (Exception ex)
                            {

                                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the logo file  didn't successfully uploaded , the reason :" + ex.Message + "' ); ", true);
                                // showinfo.Text = "The logo file  didn't successfully uploaded , the reason :" + ex.Message;

                            }


                        }
                        else
                        {
                            //showinfo.Text = "The file size can't exceeds 500KB.";
                            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the file size can not exceeds 500KB  '); ", true);
                            return;
                        }
                    }
                    else
                    {
                        //showinfo.Text = "The logo file  only accept JPG and PNG  formats .";
                        ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the logo file  only accept JPG and PNG  formats  '); ", true);
                        return;
                    }

                }
                


                for (int i = 0; i < FieldCheckBoxList.Items.Count; i++)
                {

                    if (FieldCheckBoxList.Items[i].Selected == true)
                    {
                        //fieldsID.
                        listArr.Add(FieldCheckBoxList.Items[i].Value);
                        //listArr.add(FieldCheckBoxList.Items[i].Value);
                    }
                }

                fieldsID = listArr.ToArray();

                if (LogoFileUpload1.FileName == null || LogoFileUpload1.FileName == "")
                {
                    mycampaign.UpdateCampaignInfoByCamID(strCamID, txtCampaignName.Text.ToString(), txtCampainShow.Text.ToString(), txtCampainVenue.Text.ToString(), txtCampainDate.Text.ToString(), "", SiteDropDownList.SelectedValue.ToString(), fieldsID, MainFieldCheckBoxList.Items[0].Value, BgColorDropDownList.SelectedValue.ToString());
                }
                else
                {
                    mycampaign.UpdateCampaignInfoByCamID(strCamID, txtCampaignName.Text.ToString(), txtCampainShow.Text.ToString(), txtCampainVenue.Text.ToString(), txtCampainDate.Text.ToString(), guidstr + LogoFileUpload1.FileName, SiteDropDownList.SelectedValue.ToString(), fieldsID, MainFieldCheckBoxList.Items[0].Value, BgColorDropDownList.SelectedValue.ToString());
                }
                

                Response.Redirect("CampaignManage.aspx");
            }


        }

    }
    protected void SiteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FieldCheckBoxList.DataSource = mycampaign.Get_Campaignfieldc_by_SiteID(SiteDropDownList.SelectedValue.ToString());
        //FieldCheckBoxList.DataTextField = "FieldName";
        //FieldCheckBoxList.DataValueField = "ID";
        FieldCheckBoxList.DataBind();

        MainFieldCheckBoxList.DataSource = mycampaign.campaignfield_by_SiteID(SiteDropDownList.SelectedValue.ToString());

        MainFieldCheckBoxList.DataBind();

        for (int i = 0; i < MainFieldCheckBoxList.Items.Count; i++)
        {

            MainFieldCheckBoxList.Items[i].Selected = true;

        }
    }

    protected void Calendar1_SelectionChanged(object ender, EventArgs e)
    {
        txtCampainDate.Text = Calendar1.SelectedDate.ToShortDateString();
    }
}