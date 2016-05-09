using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

using Touchdevice.Common;
using Touchdevice.Web;


public partial class LaunchCampaign : FrontPage
{
    public DataTable temp_table;
    public DataTable temp_table2;
    public campaign mycampaign;

    public common mycommon;

    private string myCamID;
    private string myUserID;


    private string str_EmailAddress;
    private string str_MobileNumber;
    private string str_FirstName;
    private string str_LastName;
    private string str_DrivingLicenceNumber;
    private string str_Address;
    private string str_State;
    private string str_Postcode;
    private string str_Age;

    private bool isAge = false;


    public string mybgcolor;

 
       

    protected void Page_Load(object sender, EventArgs e)
    {

        UserLoginPanel.Visible = false;
        ShowInfoPanel.Visible = false;
        if (this.IsPostBack)
        {

        }
        else
        {
            Timer1.Enabled = false;

        }
        

        mycampaign = new campaign();
        if (Session["CamID"] == null)
        {
            Labelshow.Text = "null";
            mybgcolor = "#000000";
            
        }
        else
        {
            myCamID = Session["CamID"].ToString();
            myUserID = Session["userID"].ToString();


            string camID_str = Session["CamID"].ToString();
            Labelshow.Text = camID_str;

            temp_table = mycampaign.GetCampaignfields_by_CamID(camID_str);
            temp_table2 = mycampaign.GetCampaignInfo_by_CamID(camID_str);


            //fneasypromos.com

            string mysite = temp_table2.Rows[0]["Website"].ToString();
            mybgcolor = temp_table2.Rows[0]["BgColor"].ToString();


            if (this.IsPostBack)
            {

            }
            else
            {

                EmailAddressPanel.Visible = false;
                MobilePhoneNumberPanel.Visible = false;
                FirstNamePanel.Visible = false;
                LastNamePanel.Visible = false;
                DrivingLicenceNumberPanel.Visible = false;
                AddressPanel.Visible = false;
                StatePanel.Visible = false;
                PostcodePanel.Visible = false;
                AgePanel.Visible = false;

                if (mysite == "fneasypromos.com")
                {
                    remove1_btn.Visible = true;
                    remove2_btn.Visible = true;

                }
                else
                {
                    remove1_btn.Visible = false;
                    remove2_btn.Visible = false;


                }
                string myurl = campaign.GetUrl();

                myurl = myurl.ToLower();
                myurl = myurl.Replace("launchcampaign.aspx", "");

                if (temp_table2.Rows[0]["Logo"].ToString() == null || temp_table2.Rows[0]["Logo"].ToString() == "")
                {
                    mycommon = new common();
                    if (mycommon.Get_User_by_UserID(myUserID).Rows[0]["LogoFile"].ToString() == null || mycommon.Get_User_by_UserID(myUserID).Rows[0]["LogoFile"].ToString() == "")
                    {
                        LogoImage.ImageUrl = "";
                        LogoImage.Visible = false;

                    }
                    else
                    {
                        LogoImage.ImageUrl = myurl + "Uploads/" + myUserID + "/" + mycommon.Get_User_by_UserID(myUserID).Rows[0]["LogoFile"].ToString();

                        LogoImage.Visible = true;
                    }


                }
                else
                {


                    LogoImage.ImageUrl = myurl + "Uploads/" + myUserID + "/Campaign/" + temp_table2.Rows[0]["Logo"].ToString();
                    LogoImage.Visible = true;

                }

                for (int j = 0; j < temp_table.Rows.Count; j++)
                {
                    string FieldNameStr = temp_table.Rows[j]["FieldName"].ToString();
                    //this.FindControl("camFieldlist") as GridView
                    //this.FindControl(FieldNameStr
                    if (FieldNameStr == "Age")
                    {
                        isAge = true;
                    }
                    if (this.FindControl(FieldNameStr + "Panel") == null)
                    {

                    }
                    else
                    {
                        Panel myPanel = this.FindControl(FieldNameStr + "Panel") as Panel;
                        myPanel.Visible = true;

                    }
                }
            }
           
        }

        
    }
    protected void autoShowInfo()
    {
        ShowInfoPanel.Visible = true;
        ShowInfoLabel.Text = "Thank you,  please  check your  inbox and junk mail ";
        inputAreaPanel.Visible = false;

        Timer1.Enabled = true;
        
        
        

    }

    protected void Timer_Tick(object sender, EventArgs e)
    {
        if (Timer1.Enabled == true)
        {
            //
        }
        
        ShowInfoPanel.Visible = false;

        inputAreaPanel.Visible = true;
        Timer1.Enabled = false;
    } 
    protected void sendInfo()
    {
        
        
       


        EmailAddress.Disabled = true;
        MobileNumber.Disabled = true;
        FirstName.Disabled = true;
        LastName.Disabled = true;
        DrivingLicenceNumber.Disabled = true;
        Address.Disabled = true;
        State.Disabled = true;
        Postcode.Disabled = true;
        Age.Disabled = true;
        submit_btn.Enabled = false;



        if (EmailAddressPanel.Visible == true)
        {
            if (EmailAddress.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your Email address'); ", true);
                return;

            }
            else
            {
                if (EmailAddress.Value.ToString().Contains("@"))
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your Email address'); ", true);
                    return;
                }

            }
        }

        if (MobilePhoneNumberPanel.Visible == true)
        {
            if (MobileNumber.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your mobile phone number'); ", true);
                return;
            }
        }

        if (FirstNamePanel.Visible == true)
        {
            if (FirstName.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your first name'); ", true);
                return;
            }
        }


        if (LastNamePanel.Visible == true)
        {
            if (LastName.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your first name'); ", true);
                return;
            }
        }

        if (DrivingLicenceNumberPanel.Visible == true)
        {
            if (DrivingLicenceNumber.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your driving licence number'); ", true);
                return;
            }
        }

        if (AddressPanel.Visible == true)
        {
            if (Address.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your address '); ", true);
                return;
            }
        }

        if (StatePanel.Visible == true)
        {
            if (State.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your state '); ", true);
                return;
            }
        }

        if (PostcodePanel.Visible == true)
        {
            if (Postcode.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your postcode '); ", true);
                return;
            }
        }

        if (AgePanel.Visible == true)
        {
            if (Age.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your age '); ", true);
                return;
            }
        }

        str_EmailAddress = EmailAddress.Value;
        str_MobileNumber = MobileNumber.Value;
        str_FirstName = FirstName.Value;

        str_LastName = LastName.Value;
        str_DrivingLicenceNumber = DrivingLicenceNumber.Value;
        str_Address = Address.Value;
        str_State = State.Value;


        str_Postcode = Postcode.Value;

        string camID_str = Session["CamID"].ToString();
        temp_table = mycampaign.GetCampaignfields_by_CamID(camID_str);
        for (int j = 0; j < temp_table.Rows.Count; j++)
        {
            string FieldNameStr = temp_table.Rows[j]["FieldName"].ToString();

            if (FieldNameStr == "Age")
            {
                isAge = true;
            }

        }


        if (isAge == true)
        {
            str_Age = Age.Value;
        }
        else
        {
            str_Age = "";
        }
        





        EmailAddress.Value = "";
        MobileNumber.Value = "";
        FirstName.Value = "";
        LastName.Value = "";
        DrivingLicenceNumber.Value = "";
        Address.Value = "";
        State.Value = "";
        Postcode.Value = "";
        Age.Value = "";

        myCamID = Session["CamID"].ToString();
        myUserID = Session["userID"].ToString();
        
        //ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Thank you for submitting your details '); ", true);
        mycampaign.CollectInfo(myUserID, myCamID, str_EmailAddress, str_MobileNumber, str_FirstName, str_LastName, str_DrivingLicenceNumber, str_Address, str_State, str_Postcode, str_Age);

        EmailAddress.Disabled = false;
        MobileNumber.Disabled = false;
        FirstName.Disabled = false;
        LastName.Disabled = false;
        DrivingLicenceNumber.Disabled = false;
        Address.Disabled = false;
        State.Disabled = false;
        Postcode.Disabled = false;
        Age.Disabled = false;
        submit_btn.Enabled = true;

    }
    
    protected void submit_btn_Click(object sender, EventArgs e)
    {
        autoShowInfo();


        EmailAddress.Disabled = true;
        MobileNumber.Disabled = true;
        FirstName.Disabled = true;
        LastName.Disabled = true;
        DrivingLicenceNumber.Disabled = true;
        Address.Disabled = true;
        State.Disabled = true;
        Postcode.Disabled = true;
        Age.Disabled = true;
        submit_btn.Enabled = false;



        if (EmailAddressPanel.Visible == true)
        {
            if (EmailAddress.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your Email address'); ", true);
                return;

            }
            else
            {
                if (EmailAddress.Value.ToString().Contains("@"))
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your Email address'); ", true);
                    return;
                }

            }
        }

        if (MobilePhoneNumberPanel.Visible == true)
        {
            if (MobileNumber.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your mobile phone number'); ", true);
                return;
            }
        }

        if (FirstNamePanel.Visible == true)
        {
            if (FirstName.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your first name'); ", true);
                return;
            }
        }


        if (LastNamePanel.Visible == true)
        {
            if (LastName.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your first name'); ", true);
                return;
            }
        }

        if (DrivingLicenceNumberPanel.Visible == true)
        {
            if (DrivingLicenceNumber.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your driving licence number'); ", true);
                return;
            }
        }

        if (AddressPanel.Visible == true)
        {
            if (Address.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your address '); ", true);
                return;
            }
        }

        if (StatePanel.Visible == true)
        {
            if (State.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your state '); ", true);
                return;
            }
        }

        if (PostcodePanel.Visible == true)
        {
            if (Postcode.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your postcode '); ", true);
                return;
            }
        }

        if (AgePanel.Visible == true)
        {
            if (Age.Value == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type your age '); ", true);
                return;
            }
        }

        str_EmailAddress = EmailAddress.Value;
        str_MobileNumber = MobileNumber.Value;
        str_FirstName = FirstName.Value;

        str_LastName = LastName.Value;
        str_DrivingLicenceNumber = DrivingLicenceNumber.Value;
        str_Address = Address.Value;
        str_State = State.Value;

        str_Postcode = Postcode.Value;

        string camID_str = Session["CamID"].ToString();
        temp_table = mycampaign.GetCampaignfields_by_CamID(camID_str);
        for (int j = 0; j < temp_table.Rows.Count; j++)
        {
            string FieldNameStr = temp_table.Rows[j]["FieldName"].ToString();

            if (FieldNameStr == "Age")
            {
                isAge = true;
            }

        }
        if (isAge == true)
        {
            str_Age = Age.Value;
        }
        else
        {
            str_Age = "";
        }



        EmailAddress.Value = "";
        MobileNumber.Value = "";
        FirstName.Value = "";
        LastName.Value = "";
        DrivingLicenceNumber.Value = "";
        Address.Value = "";
        State.Value = "";
        Postcode.Value = "";
        Age.Value = "";

        myCamID = Session["CamID"].ToString();
        myUserID = Session["userID"].ToString();

        //ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Thank you for submitting your details '); ", true);
        mycampaign.CollectInfo(myUserID, myCamID, str_EmailAddress, str_MobileNumber, str_FirstName, str_LastName, str_DrivingLicenceNumber, str_Address, str_State, str_Postcode, str_Age);

        EmailAddress.Disabled = false;
        MobileNumber.Disabled = false;
        FirstName.Disabled = false;
        LastName.Disabled = false;
        DrivingLicenceNumber.Disabled = false;
        Address.Disabled = false;
        State.Disabled = false;
        Postcode.Disabled = false;
        Age.Disabled = false;
        submit_btn.Enabled = true;

        //mycampaign.SendEmailAndSMS(myUserID, myCamID, str_EmailAddress, str_MobileNumber, str_FirstName, str_LastName, str_DrivingLicenceNumber, str_Address, str_State, str_Postcode, str_Age);


    }
    protected void ExitButton_Click(object sender, EventArgs e)
    {
        UserLoginPanel.Visible = true;
        
    }
    protected void LoginCancel_Click(object sender, EventArgs e)
    {
        UserLoginPanel.Visible = false;

    }
    protected void LoginSubmit_Click(object sender, EventArgs e)
    {
        if (this.goCampaignLogin(txtUsername.Text.ToString(), txtPassword.Text.ToString()))
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Thank you , you already successfully  exit capture screen '); ", true);
            ClientScript.RegisterStartupScript(GetType(), "Close_Scr", "javascript: window.close(); ", true);
            
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Your email or password is wrong, you failed to exit capture screen  '); ", true);
        };
    }
    protected void remove1_btn_Click(object sender, EventArgs e)
    {
        sendInfo();
    }
    protected void remove2_btn_Click(object sender, EventArgs e)
    {
        sendInfo();
    }
}