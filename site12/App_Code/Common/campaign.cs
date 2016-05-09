using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using Touchdevice.Dal;
using System.Data;

using au.com.messagenet.www;

using System.Net;
using System.Net.Mail;


namespace Touchdevice.Common
{
    public class campaign
    {
        private DalLayer objDalLayer = new DalLayer();
        private baseclass new_base = new baseclass();

        private MailMessage mail;

        public campaign()
        {
            //new_base.init_connection(true);
             mail = new MailMessage();
        }

        public static string GetUrl()
        {
            //  2009年12月15日 11:45:24
            //  B哥 kuibono@163.com
            string strTemp = "";
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTPS"] == "off")
            {
                strTemp = "http://";
            }
            else
            {
                strTemp = "http://";
            }

            strTemp = strTemp + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"];

            if (System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"] != "80")
            {
                strTemp = strTemp + ":" + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            }

            strTemp = strTemp + System.Web.HttpContext.Current.Request.ServerVariables["URL"];

            if (System.Web.HttpContext.Current.Request.QueryString.AllKeys.Length > 0)
            {
                strTemp = strTemp + "?" + System.Web.HttpContext.Current.Request.QueryString;
            }

            return strTemp;
        }


        public bool isIncludeCampaignField(string CamID, string FieldID)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, CampaignID, FieldID FROM  CampaignDetails  where CampaignID=@CampaignID and FieldID=@FieldID ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(CamID);
                cmd.Parameters.Add("@FieldID", SqlDbType.UniqueIdentifier).Value = new Guid(FieldID);

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
                new_base.init_connection(false);
            }
            catch (Exception exception)
            {
                throw exception;
                

            }
            if (table.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            


        }
        public DataTable Get_CampainColor()
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, ColorValue, ColorText FROM  CampainColor  ";
                SqlCommand cmd = new SqlCommand(queryTxt);

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            new_base.init_connection(false);
            return table;
        }


        public DataTable Get_CampaignAge()
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, AgeValue, AgeText FROM  CampaignAge  ";
                SqlCommand cmd = new SqlCommand(queryTxt);

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            new_base.init_connection(false);
            return table;

        }


        public DataTable Site_by_order()
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, Website, Url, Price, Sorder FROM  Site where Enable='y' order by Sorder ";
                SqlCommand cmd = new SqlCommand(queryTxt);

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            new_base.init_connection(false);
            return table;
        }

        public void LoopCreateSendByFilter()
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT * FROM  SendMessagesFilter where IsSend='n'    ";
                SqlCommand cmd = new SqlCommand(queryTxt);


                table = objDalLayer.ReturnDataset(cmd).Tables[0];
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    DateTime todayTime = DateTime.Now.AddMinutes(-2);
                    DateTime dbTime = Convert.ToDateTime(table.Rows[j]["SendTime"].ToString());
                    if (DateTime.Compare(todayTime, dbTime) > 0)
                    {

                        CreateSendsByFilter(table.Rows[j]["ID"].ToString());
                    }

                }

            }
            catch (Exception exception)
            {
                throw exception;

            }
        }

        public void CreateSendsByFilter(string FilterID)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT * FROM  SendMessagesFilter where ID=@ID and IsSend='n'    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterID);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];

                string MyID_val = "";
                if (table != null)
                {
                    new_base.init_connection(false);
                    new_base.init_connection(true);


                    
                    string MyUserID_val = "";
                    string MyAge_val = "";
                    string MyPostcode_val = "";
                    string MyState_val = "";
                    string MyCampaign_val = "";
                    string MyShow_val = "";

                    string MySendType_val = "";
                    string MyAttachmentID_val = "";
                    string MySendAttachment_val = "";
                    string MySubject_val = "";
                    string MyMessage_val = "";

                    MyID_val = table.Rows[0]["ID"].ToString();

                    if (table.Rows[0]["UserID"].ToString() == "")
                    {
                    }
                    else
                    {
                        MyUserID_val = table.Rows[0]["UserID"].ToString();
                    }

                    if (table.Rows[0]["FilterAge"].ToString() == "")
                    {
                    }
                    else
                    {
                        MyAge_val = table.Rows[0]["FilterAge"].ToString();
                    }

                    if (table.Rows[0]["FilterPostcode"].ToString() == "")
                    {

                    }
                    else
                    {
                        MyPostcode_val = table.Rows[0]["FilterPostcode"].ToString();

                    }

                    if (table.Rows[0]["FilterState"].ToString() == "")
                    {

                    }
                    else
                    {
                        MyState_val = table.Rows[0]["FilterState"].ToString();

                    }

                    if (table.Rows[0]["FilterCampaignID"].ToString() == "" || table.Rows[0]["FilterCampaignID"]==null)
                    {

                    }
                    else
                    {
                        MyCampaign_val = table.Rows[0]["FilterCampaignID"].ToString();

                    }

                    if (table.Rows[0]["FilterShow"].ToString() == "")
                    {

                    }
                    else
                    {
                        MyShow_val = table.Rows[0]["FilterShow"].ToString();
                    }


                    MySendType_val=table.Rows[0]["SendType"].ToString();
                    MyAttachmentID_val = table.Rows[0]["AttachmentID"].ToString();
                    MySendAttachment_val = table.Rows[0]["SendAttachment"].ToString();
                    MySubject_val = table.Rows[0]["Subject"].ToString();
                    MyMessage_val = table.Rows[0]["Message"].ToString();

                    DataTable temptable;
                    temptable = GetVisitorsPamaList_by_UserID(MyUserID_val, MyAge_val, MyPostcode_val, MyState_val, MyCampaign_val, MyShow_val);
                    string send_content = "";

                    string updateCMD;
                    new_base.init_connection(true);
                    updateCMD = "UPDATE SendMessagesFilter set IsSend='y' where ID=@ID";
                    try
                    {
                        SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                        base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(MyID_val);

                        base_command.ExecuteNonQuery();
                        new_base.init_connection(false);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


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


                        send_content = send_content + System.Environment.NewLine + MyMessage_val;
                        if(MySendType_val=="emailsms")
                        {
                            if(MobileNumber_val!="")
                            {
                                AddSendEmailMobile(MobileNumber_val, "", send_content,MyAttachmentID_val, MySendAttachment_val, "mobile", "now", DateTime.Now.AddMinutes(-2).ToShortDateString(), "n");
                            }
                            if(Email_val!="")
                            {
                                AddSendEmailMobile(Email_val, MySubject_val, send_content,MyAttachmentID_val, MySendAttachment_val, "email", "now", DateTime.Now.AddMinutes(-2).ToShortDateString(), "n");
                            }

                        }else if(MySendType_val=="email")
                        {
                            if(Email_val!="")
                            {
                                AddSendEmailMobile(Email_val, MySubject_val, send_content,MyAttachmentID_val, MySendAttachment_val, "email", "now", DateTime.Now.AddMinutes(-2).ToShortDateString(), "n");
                            }
                        }else if(MySendType_val=="sms")
                        {
                             if(MobileNumber_val!="")
                            {
                                AddSendEmailMobile(MobileNumber_val, "", send_content,MyAttachmentID_val, MySendAttachment_val, "mobile", "now", DateTime.Now.AddMinutes(-2).ToShortDateString(), "n");
                            }
                        }else{

                        }

                        
                    }

                }

                new_base.init_connection(false);

                


            }
            catch (Exception exception)
            {
                throw exception;

            }
        }
        public void LoopSendLaterEmailSMS()
        {
            
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, EmailMobile, SendTitle, SendContent ,AttachmentID,SendAttachment,SendType,SendFlag,SendTime,IsSend FROM  SendEmailMobile where IsSend='n' and SendFlag='later'    ";
                SqlCommand cmd = new SqlCommand(queryTxt);


                table = objDalLayer.ReturnDataset(cmd).Tables[0];
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    DateTime todayTime = DateTime.Now;
                    DateTime dbTime = Convert.ToDateTime(table.Rows[j]["SendTime"].ToString());

                    if (DateTime.Compare(todayTime, dbTime) > 0)
                    {
                        UpdateIsSendSendEmailMobileDB_by_ID("y", table.Rows[j]["ID"].ToString());
                        if (table.Rows[j]["SendType"].ToString() == "email")
                        {
                            SendEmail("Welcome to fneasy", table.Rows[j]["SendContent"].ToString().Replace("\n", "<br>"), table.Rows[j]["EmailMobile"].ToString());
                        }
                        else
                        {
                            SendSMSMessageByNumber("Welcome to fneasy ," + table.Rows[j]["SendContent"].ToString(), table.Rows[j]["EmailMobile"].ToString());
                        }
                        //cmd.Connection.Close();
                        new_base.init_connection(false);
                        return;
                    }
                    else
                    {

                    }
                    


                }
            }
            catch (Exception exception)
            {
                throw exception;


            }
        }
        public void LoopSendNow_EmailSMS(string pagepath)
        {
            
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, EmailMobile, SendTitle, SendContent ,AttachmentID,SendAttachment,SendType,SendFlag,SendTime,IsSend FROM  SendEmailMobile where IsSend='n' and SendFlag='now'    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
                if (table != null &&table.Rows.Count >0 && table.Rows[0]["ID"].ToString()!="")
                {
                    UpdateIsSendSendEmailMobileDB_by_ID("y", table.Rows[0]["ID"].ToString());
                    if (table.Rows[0]["SendType"].ToString() == "email")
                    {
                        string attachmentpath = "";
                        if (table.Rows[0]["SendAttachment"].ToString() == "")
                        {
                            SendEmail("Welcome to fneasy", table.Rows[0]["SendContent"].ToString().Replace("\n", "<br>"), table.Rows[0]["EmailMobile"].ToString());
                        }
                        else
                        {
                            attachmentpath = pagepath + "\\Uploads\\Mail\\" + table.Rows[0]["AttachmentID"].ToString() + "\\" + table.Rows[0]["SendAttachment"].ToString();
                            SendEmailAttachment("Welcome to fneasy", table.Rows[0]["SendContent"].ToString().Replace("\n", "<br>"), table.Rows[0]["EmailMobile"].ToString(), attachmentpath);
                        }
                    }
                    else
                    {
                        SendSMSMessageByNumber("Welcome to fneasy ," + table.Rows[0]["SendContent"].ToString(), table.Rows[0]["EmailMobile"].ToString());
                    }
                    //table.Clear();
                    new_base.init_connection(false);
                    // cmd.Connection.Close();
                    return;
                }
                
            }
            catch (Exception exception)
            {
                throw exception;


            }
            
        }
        public DataTable Get_Campaignfield_by_SiteID(string SiteID_val)
        {
            new_base.init_connection(true);
            DataTable table;

            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT SiteFields.ID, SiteFields.SiteID, SiteFields.FieldID, SystemFields.FieldName ,SystemFields.FieldText FROM  SiteFields ,SystemFields where SystemFields.ID=SiteFields.FieldID  and SiteFields.SiteID= @SiteID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@SiteID", SqlDbType.UniqueIdentifier).Value = new Guid(SiteID_val);

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }
        public DataTable Get_Campaignfieldc_by_SiteID(string SiteID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT SiteFields.ID, SiteFields.SiteID, SiteFields.FieldID, SystemFields.FieldName,SystemFields.FieldText FROM  SiteFields ,SystemFields where SystemFields.ID=SiteFields.FieldID and SiteFields.Type='c'   and SiteFields.SiteID= @SiteID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@SiteID", SqlDbType.UniqueIdentifier).Value = new Guid(SiteID_val);

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }
        public DataTable GetCampaignList_by_UserID(string UserID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT CampaignInfo.ID, CampaignInfo.UserID, CampaignInfo.Title, CampaignInfo.SiteID ,CampaignInfo.Show, CampaignInfo.Venue, CampaignInfo.Date,CampaignInfo.Logo, Site.Website FROM  CampaignInfo,Site  where Site.ID=CampaignInfo.SiteID and   CampaignInfo.UserID= @UserID  order by CampaignInfo.GetTime   ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable GetVisitorsStateList_by_UserID(string UserID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT distinct ClientInfoCollect.State FROM  ClientInfoCollect  where    ClientInfoCollect.UserID= @UserID and ClientInfoCollect.State<>''    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }


        public DataTable GetVisitorsPamaList_by_UserID(string UserID_val,string Age_val, string Postcode_val, string State_val, string CampaignID_val,string Show_val)
        {
            new_base.init_connection(true);
            DataTable table;
            string queryTxt = "";
            string insertSQL = "";

            if (Age_val == "")
            {
                
            }
            else
            {
                insertSQL = insertSQL + " and ClientInfoCollect.Age='" + Age_val + "'";
            }

            if (State_val == "")
            {
                
            }
            else
            {
                insertSQL = insertSQL + " and ClientInfoCollect.State='" + State_val + "'";
            }
            if (Postcode_val == "")
            {
                
            }
            else
            {
                insertSQL = insertSQL + " and ClientInfoCollect.Postcode='" + Postcode_val + "'";
            }

            if (Show_val == "")
            {

            }
            else
            {
                insertSQL = insertSQL + " and  CampaignInfo.ID in ( select ID  from CampaignInfo where Show='" + Show_val + "' )";
            }
            try
            {
                if (CampaignID_val == "")
                {
                    queryTxt = "SELECT ClientInfoCollect.ID, ClientInfoCollect.UserID, ClientInfoCollect.Email, ClientInfoCollect.MobileNumber,ClientInfoCollect.FirstName, ClientInfoCollect.LastName, ClientInfoCollect.DrivingLicenceNumber,ClientInfoCollect.Address,ClientInfoCollect.State,ClientInfoCollect.Postcode,ClientInfoCollect.Age,CampaignInfo.Title, CampaignInfo.Show FROM  ClientInfoCollect,CampaignInfo  where CampaignInfo.ID= ClientInfoCollect.CampaignID and   ClientInfoCollect.UserID= @UserID     " + insertSQL;
                    SqlCommand cmd = new SqlCommand(queryTxt);
                    cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                    table = objDalLayer.ReturnDataset(cmd).Tables[0];
                }
                else
                {
                    queryTxt = "SELECT ClientInfoCollect.ID, ClientInfoCollect.UserID, ClientInfoCollect.Email, ClientInfoCollect.MobileNumber,ClientInfoCollect.FirstName, ClientInfoCollect.LastName, ClientInfoCollect.DrivingLicenceNumber,ClientInfoCollect.Address,ClientInfoCollect.State,ClientInfoCollect.Postcode,ClientInfoCollect.Age,CampaignInfo.Title, CampaignInfo.Show  FROM  ClientInfoCollect,CampaignInfo  where  CampaignInfo.ID= ClientInfoCollect.CampaignID and  ClientInfoCollect.UserID= @UserID  and  ClientInfoCollect.CampaignID= @CampaignID   " + insertSQL;
                    SqlCommand cmd = new SqlCommand(queryTxt);
                    cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                    cmd.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(CampaignID_val);
                    table = objDalLayer.ReturnDataset(cmd).Tables[0];
                }
            
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable GetVisitorsCampaignList_by_UserID(string UserID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT distinct ClientInfoCollect.CampaignID,CampaignInfo.Title ,CampaignInfo.Show  FROM  ClientInfoCollect,CampaignInfo  where    ClientInfoCollect.UserID= @UserID and  CampaignInfo.ID=ClientInfoCollect.CampaignID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }
        

        public DataTable GetVisitorsPostcodeList_by_UserID(string UserID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT distinct ClientInfoCollect.Postcode FROM  ClientInfoCollect  where    ClientInfoCollect.UserID= @UserID and ClientInfoCollect.Postcode<>''    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }



        public DataTable GetVisitorsAgeList_by_UserID(string UserID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT distinct ClientInfoCollect.Age FROM  ClientInfoCollect  where    ClientInfoCollect.UserID= @UserID  and ClientInfoCollect.Age<>''   ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable GetSendMessagesFilter_by_ID(string ID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT * FROM  SendMessagesFilter  where    SendMessagesFilter.ID= @ID     ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(ID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable GetAutoRespond_by_CampaignID(string CampaignID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT * FROM  AutoRespondRole  where    CampaignID= @CampaignID     ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(CampaignID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }


        public DataTable GetSendMessagesFilter_by_UserID(string UserID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT * FROM  SendMessagesFilter  where    SendMessagesFilter.UserID= @UserID     ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }
        public DataTable GetVisitorsList_by_UserID(string UserID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT CampaignInfo.Title, CampaignInfo.Show, ClientInfoCollect.ID, ClientInfoCollect.UserID, ClientInfoCollect.Email, ClientInfoCollect.MobileNumber,ClientInfoCollect.FirstName, ClientInfoCollect.LastName, ClientInfoCollect.DrivingLicenceNumber,ClientInfoCollect.Address,ClientInfoCollect.State,ClientInfoCollect.Postcode,ClientInfoCollect.Age FROM  ClientInfoCollect,CampaignInfo  where  ClientInfoCollect.CampaignID=CampaignInfo.ID  and   ClientInfoCollect.UserID= @UserID     ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable GetVisitorInfo_by_ID(string ID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT ClientInfoCollect.ID, ClientInfoCollect.UserID, ClientInfoCollect.CampaignID, ClientInfoCollect.Email ,ClientInfoCollect.MobileNumber, ClientInfoCollect.FirstName, ClientInfoCollect.LastName,ClientInfoCollect.DrivingLicenceNumber,ClientInfoCollect.Address,ClientInfoCollect.State,ClientInfoCollect.Postcode,ClientInfoCollect.Age FROM  ClientInfoCollect  where   ClientInfoCollect.ID= @ID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(ID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;

        }

        public DataTable GetCampaignInfo_by_UserID(string UserID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT CampaignInfo.ID, CampaignInfo.UserID, CampaignInfo.Title, CampaignInfo.SiteID ,CampaignInfo.Show, CampaignInfo.Venue, CampaignInfo.Date,CampaignInfo.Logo, CampaignInfo.BgColor, Site.Website FROM  CampaignInfo,Site  where Site.ID=CampaignInfo.SiteID and   CampaignInfo.UserID= @UserID  order by CampaignInfo.GetTime   ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }


        public DataTable GetCampaignInfo_by_CamID(string CamID_val)
        {
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT CampaignInfo.ID, CampaignInfo.UserID, CampaignInfo.Title, CampaignInfo.SiteID ,CampaignInfo.Show, CampaignInfo.Venue, CampaignInfo.Date,CampaignInfo.Logo, CampaignInfo.BgColor, Site.Website FROM  CampaignInfo,Site  where Site.ID=CampaignInfo.SiteID and   CampaignInfo.ID= @ID  order by CampaignInfo.GetTime   ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(CamID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable campaignfield_by_SiteID(string SiteID_val)
        {
            // string scalarValue = null;
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT SiteFields.ID, SiteFields.SiteID, SiteFields.FieldID, SystemFields.FieldName,SystemFields.FieldText FROM  SiteFields ,SystemFields where SystemFields.ID=SiteFields.FieldID and SiteFields.Type='m'   and SiteFields.SiteID= @SiteID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@SiteID", SqlDbType.UniqueIdentifier).Value = new Guid(SiteID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable GetCampaignfields_by_CamID(string CampaignID_val)
        {
            // string scalarValue = null;
            new_base.init_connection(true);
            DataTable table;
            try
            {
                string queryTxt = "";
                queryTxt = "SELECT SystemFields.ID, SystemFields.FieldName,SystemFields.FieldText FROM  SystemFields,CampaignDetails where CampaignDetails.FieldID=SystemFields.ID and  CampaignDetails.CampaignID= @CampaignID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(CampaignID_val);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }


        public bool UpdateSendFilter_by_FilterID(string FilterID, string FilterAge_val, string FilterPostcode_val, string FilterState_val, string FilterCampaignID_val, string FilterShow_val)
        {
            string updateCMD;
            
            
            updateCMD = "UPDATE SendMessagesFilter set FilterAge=@FilterAge  where ID=@ID";
            try
            {
                new_base.init_connection(true);
                SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterID);
                base_command.Parameters.Add("@FilterAge", SqlDbType.NVarChar).Value = FilterAge_val;
                base_command.ExecuteNonQuery();
                new_base.init_connection(false);

            }
            catch (Exception ex)
            {
                return false;
            }
            
            updateCMD = "UPDATE SendMessagesFilter set FilterPostcode=@FilterPostcode  where ID=@ID";
            try
            {
                new_base.init_connection(true);
                SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterID);
                base_command.Parameters.Add("@FilterPostcode", SqlDbType.NVarChar).Value = FilterPostcode_val;
                base_command.ExecuteNonQuery();
                new_base.init_connection(false);

            }
            catch (Exception ex)
            {
                return false;
            }


            updateCMD = "UPDATE SendMessagesFilter set FilterState=@FilterState  where ID=@ID";
            try
            {
                new_base.init_connection(true);
                SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterID);
                base_command.Parameters.Add("@FilterState", SqlDbType.NVarChar).Value = FilterState_val;
                base_command.ExecuteNonQuery();
                new_base.init_connection(false);

            }
            catch (Exception ex)
            {
                return false;
            }

            if (FilterCampaignID_val == "")
            {
                updateCMD = "UPDATE SendMessagesFilter set FilterCampaignID=@FilterCampaignID  where ID=@ID";
                try
                {
                    new_base.init_connection(true);
                    SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                    base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterID);
                    base_command.Parameters.Add("@FilterCampaignID", SqlDbType.NVarChar).Value = "";
                    base_command.ExecuteNonQuery();
                    new_base.init_connection(false);

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                updateCMD = "UPDATE SendMessagesFilter set FilterCampaignID=@FilterCampaignID  where ID=@ID";
                try
                {
                    new_base.init_connection(true);
                    SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                    base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterID);
                    base_command.Parameters.Add("@FilterCampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterCampaignID_val);
                    base_command.ExecuteNonQuery();
                    new_base.init_connection(false);

                }
                catch (Exception ex)
                {
                    return false;
                }
            }


            
            updateCMD = "UPDATE SendMessagesFilter set FilterShow=@FilterShow  where ID=@ID";
            try
            {
                new_base.init_connection(true);
                SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterID);
                base_command.Parameters.Add("@FilterShow", SqlDbType.NVarChar).Value = FilterShow_val;
                base_command.ExecuteNonQuery();
                new_base.init_connection(false);

            }
            catch (Exception ex)
            {
                return false;
            }


            return true;
        }


        public bool UpdateSendMessage_by_FilterID(string FilterID,string SendType_val, string subject_val, string Message_val,string SendTime_val,string attachmentID, string SendAttachment)
        {
            string updateCMD;
            new_base.init_connection(true);
            if (SendAttachment == "")
            {
                if (SendTime_val == "")
                {
                    updateCMD = "UPDATE SendMessagesFilter set SendType=@SendType, Subject=@Subject, Message=@Message where ID=@ID";
                }
                else
                {
                    updateCMD = "UPDATE SendMessagesFilter set SendType=@SendType, Subject=@Subject, Message=@Message,SendTime=@SendTime where ID=@ID";
                }
                
            }
            else
            {
                if (SendTime_val == "")
                {
                    updateCMD = "UPDATE SendMessagesFilter set SendType=@SendType, Subject=@Subject, Message=@Message,AttachmentID=@AttachmentID, SendAttachment=@SendAttachment where ID=@ID";
                }
                else
                {
                    updateCMD = "UPDATE SendMessagesFilter set SendType=@SendType, Subject=@Subject, Message=@Message,SendTime=@SendTime,AttachmentID=@AttachmentID, SendAttachment=@SendAttachment where ID=@ID";
                }
                
            }
            
            try
            {
                SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterID);
                base_command.Parameters.Add("@SendType", SqlDbType.NVarChar).Value = SendType_val;
                base_command.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = subject_val;
                base_command.Parameters.Add("@Message", SqlDbType.NText).Value = Message_val;
                if (SendTime_val == "")
                {
                    
                }
                else
                {

                    base_command.Parameters.Add("@SendTime", SqlDbType.DateTime).Value = Convert.ToDateTime(SendTime_val);
                }
                if (SendAttachment == "")
                {

                }
                else
                {
                    base_command.Parameters.Add("@AttachmentID", SqlDbType.NVarChar).Value = attachmentID;
                    base_command.Parameters.Add("@SendAttachment", SqlDbType.NVarChar).Value = SendAttachment;
                }
                base_command.ExecuteNonQuery();
                new_base.init_connection(false);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public bool UpdateAttachmentToDB_by_FilterID(string FilterID, string attachment_val)
        {
            string updateCMD;
            new_base.init_connection(true);
            updateCMD = "UPDATE SendMessagesFilter set SendAttachment=@SendAttachment where ID=@ID";
            try
            {
                SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterID);
                base_command.Parameters.Add("@SendAttachment", SqlDbType.NVarChar).Value = attachment_val;
                base_command.ExecuteNonQuery();
                new_base.init_connection(false);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public bool UpdateIsSendSendEmailMobileDB_by_ID(string IsSend_val, string ID_val)
        {
            string updateCMD;
            new_base.init_connection(true);
            updateCMD = "UPDATE SendEmailMobile set IsSend=@IsSend where ID=@ID";
            try
            {
                SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(ID_val);
                base_command.Parameters.Add("@IsSend", SqlDbType.NVarChar).Value = IsSend_val;
                base_command.ExecuteNonQuery();
                new_base.init_connection(false);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public bool UpdateCampaignInfoByCamID(string camID, string CampaignName_val, string CampainShow_val, string CampainVenue_val, string CampainDate_val, string LogoFile_val, string SiteID_val, string[] Fields, string MainFieldID ,string BgColor_val)
        {
            new_base.init_connection(true);
            string updateCMD;
            updateCMD = "UPDATE CampaignInfo set Title=@Title ,SiteID=@SiteID, Show=@Show,Venue=@Venue, Date=@Date,Logo=@Logo , BgColor=@BgColor where ID=@ID";
            try{
                SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(camID);
                base_command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = CampaignName_val;
                base_command.Parameters.Add("@SiteID", SqlDbType.UniqueIdentifier).Value = new Guid(SiteID_val);
                base_command.Parameters.Add("@Show", SqlDbType.NVarChar).Value = CampainShow_val;
                base_command.Parameters.Add("@Venue", SqlDbType.NVarChar).Value = CampainVenue_val;
                base_command.Parameters.Add("@Date", SqlDbType.NVarChar).Value = CampainDate_val;
                base_command.Parameters.Add("@Logo", SqlDbType.NVarChar).Value = LogoFile_val;
                base_command.Parameters.Add("@BgColor", SqlDbType.NVarChar).Value = BgColor_val;

                base_command.ExecuteNonQuery();
                //return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            updateCMD = @"delete from  CampaignDetails where CampaignID = @CampaignID   ";


            SqlCommand cmd = new SqlCommand(updateCMD, new_base.conn);
            cmd.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(camID);
            cmd.ExecuteNonQuery();

            string tempSQLforMain;


            try
            {
                tempSQLforMain = "INSERT INTO CampaignDetails (CampaignID,FieldID) Values  (@CampaignID,@FieldID)";

                SqlCommand cmdnew = new SqlCommand(tempSQLforMain, new_base.conn);

                cmdnew.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(camID);
                cmdnew.Parameters.Add("@FieldID", SqlDbType.UniqueIdentifier).Value = new Guid(MainFieldID);
                cmdnew.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }


            for (int i = 0; i < Fields.Length; i++)
            {
                string tempFieldID = Fields[i];
                string tempSQL;


                try
                {
                    tempSQL = "INSERT INTO CampaignDetails (CampaignID,FieldID) Values  (@CampaignID,@FieldID)";

                    SqlCommand cmdnew = new SqlCommand(tempSQL, new_base.conn);

                    cmdnew.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(camID);
                    cmdnew.Parameters.Add("@FieldID", SqlDbType.UniqueIdentifier).Value = new Guid(tempFieldID);
                    cmdnew.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                    return false;
                }
            }
            new_base.init_connection(false);
            return true;
        }

        public bool DeleteFileForAutoRespond(string ID_val)
        {
            new_base.init_connection(true);
            string updateCMD;
            updateCMD = "UPDATE AutoRespondRole set AttachmentID=@AttachmentID,SendAttachment=@SendAttachment where ID=@ID";
            try
            {
                SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);

                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(ID_val);
                base_command.Parameters.Add("@AttachmentID", SqlDbType.NVarChar).Value = "";
                base_command.Parameters.Add("@SendAttachment", SqlDbType.NVarChar).Value = "";

                base_command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            new_base.init_connection(false);
            return true;
        }
        public bool UpdateAutoRespond(string ID_val, string CampaignID_val, string SendType_val, string Subject_val, string Message_val, string AttachmentID_val, string SendAttachment_val)
        {
            if (ID_val == "")
            {
                //insert data into database
                new_base.init_connection(true);
                string InsertCMD;

                if (SendAttachment_val == "")
                {
                    InsertCMD = "INSERT INTO AutoRespondRole(CampaignID, SendType, Subject, Message) Values (@CampaignID, @SendType, @Subject, @Message)";
                }
                else
                {
                    InsertCMD = "INSERT INTO AutoRespondRole(CampaignID, SendType, Subject, Message,AttachmentID, SendAttachment) Values (@CampaignID, @SendType, @Subject, @Message,@AttachmentID, @SendAttachment)";
                }
                


                try
                {
                    //open connection
                    SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);
                    cmd.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(CampaignID_val);
                    cmd.Parameters.Add("@SendType", SqlDbType.NVarChar).Value = SendType_val;
                    cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = Subject_val;
                    cmd.Parameters.Add("@Message", SqlDbType.NText).Value = Message_val;
                    if (SendAttachment_val == "")
                    {

                    }
                    else
                    {
                        cmd.Parameters.Add("@AttachmentID", SqlDbType.NVarChar).Value = AttachmentID_val;
                        cmd.Parameters.Add("@SendAttachment", SqlDbType.NVarChar).Value = SendAttachment_val;

                    }
                    
                    cmd.ExecuteNonQuery();

                }catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                    return false;
                }
                new_base.init_connection(false);
                return true;
            }
            else
            {
                // update data of database by ID
                string updateCMD;
                new_base.init_connection(true);
                if (SendAttachment_val == "")
                {
                    updateCMD = "UPDATE AutoRespondRole set SendType=@SendType,Subject=@Subject,Message=@Message where ID=@ID";
                }
                else
                {
                    updateCMD = "UPDATE AutoRespondRole set SendType=@SendType,Subject=@Subject,Message=@Message,AttachmentID=@AttachmentID,SendAttachment=@SendAttachment where ID=@ID";
                }
                
                try
                {
                    SqlCommand base_command = new SqlCommand(updateCMD, new_base.conn);


                    if (SendAttachment_val == "")
                    {
                        base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(ID_val);
                        base_command.Parameters.Add("@SendType", SqlDbType.NVarChar).Value = SendType_val;
                        base_command.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = Subject_val;
                        base_command.Parameters.Add("@Message", SqlDbType.NText).Value = Message_val;
                       
                    }
                    else
                    {
                        base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(ID_val);
                        base_command.Parameters.Add("@SendType", SqlDbType.NVarChar).Value = SendType_val;
                        base_command.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = Subject_val;
                        base_command.Parameters.Add("@Message", SqlDbType.NText).Value = Message_val;
                        base_command.Parameters.Add("@AttachmentID", SqlDbType.NVarChar).Value = AttachmentID_val;
                        base_command.Parameters.Add("@SendAttachment", SqlDbType.NVarChar).Value = SendAttachment_val;
                    }
                    base_command.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    return false;
                }
                new_base.init_connection(false);
                return true;

                
            }

        }
        
        public bool AddSendMessagesFilter(string UserID_val, string SendType_val, string FilterAge_val, string FilterPostcode_val, string FilterState_val, string FilterCampaignID_val, string FilterShow_val, string SendTime_val,string AttachmentID_val, string SendAttachment_val, string Subject_val, string Message_val,string IsSend_val)
        {
            new_base.init_connection(true);
            string InsertCMD;
            if (FilterCampaignID_val == "")
            {
                InsertCMD = "INSERT INTO SendMessagesFilter(UserID, SendType, FilterAge, FilterPostcode,FilterState, FilterShow,SendTime,AttachmentID,SendAttachment,Subject, Message,IsSend) Values (@UserID, @SendType, @FilterAge, @FilterPostcode,@FilterState, @FilterShow,@SendTime,@AttachmentID,@SendAttachment,@Subject,@Message,@IsSend)";
            }
            else
            {
                InsertCMD = "INSERT INTO SendMessagesFilter(UserID, SendType, FilterAge, FilterPostcode,FilterState, FilterCampaignID,FilterShow,SendTime,AttachmentID,SendAttachment,Subject, Message,IsSend) Values (@UserID, @SendType, @FilterAge, @FilterPostcode,@FilterState, @FilterCampaignID,@FilterShow,@SendTime,@AttachmentID,@SendAttachment,@Subject,@Message,@IsSend)";
            }
            
            try
            {
                //open connection

                SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);


                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                cmd.Parameters.Add("@SendType", SqlDbType.NVarChar).Value = SendType_val;
                cmd.Parameters.Add("@FilterAge", SqlDbType.NVarChar).Value = FilterAge_val;
                cmd.Parameters.Add("@FilterPostcode", SqlDbType.NVarChar).Value = FilterPostcode_val;
                cmd.Parameters.Add("@FilterState", SqlDbType.NVarChar).Value = FilterState_val;
                if (FilterCampaignID_val == "")
                {

                }
                else
                {
                    cmd.Parameters.Add("@FilterCampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(FilterCampaignID_val);
                }

                
                cmd.Parameters.Add("@FilterShow", SqlDbType.NVarChar).Value = FilterShow_val;

                if (SendTime_val == "")
                {
                    cmd.Parameters.Add("@SendTime", SqlDbType.DateTime).Value = DateTime.Today;
                }
                else
                {

                    cmd.Parameters.Add("@SendTime", SqlDbType.DateTime).Value = Convert.ToDateTime(SendTime_val);
                }

                cmd.Parameters.Add("@AttachmentID", SqlDbType.NVarChar).Value = AttachmentID_val;
                cmd.Parameters.Add("@SendAttachment", SqlDbType.NVarChar).Value = SendAttachment_val;

                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = Subject_val;
                cmd.Parameters.Add("@Message", SqlDbType.NText).Value = Message_val;
                cmd.Parameters.Add("@IsSend", SqlDbType.NVarChar).Value = IsSend_val;

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            new_base.init_connection(false);
            return true;
        }

        public bool AddSendEmailMobile(string EmailMobile_val, string SendTitle_val, string SendContent_val, string AttachmentID_val, string SendAttachment_val, string SendType_val, string SendFlag_val, string SendTime_val, string IsSend_val)
        {
            
            new_base.init_connection(true);
             string InsertCMD;

             if (SendTime_val == "")
             {
                 InsertCMD = "INSERT INTO SendEmailMobile(EmailMobile,SendTitle,SendContent,AttachmentID,SendAttachment,SendType,SendFlag,IsSend) Values  (@EmailMobile,@SendTitle,@SendContent,@AttachmentID,@SendAttachment,@SendType,@SendFlag,@IsSend)";
             }
             else
             {
                 InsertCMD = "INSERT INTO SendEmailMobile(EmailMobile,SendTitle,SendContent,AttachmentID,SendAttachment,SendType,SendFlag,SendTime,IsSend) Values  (@EmailMobile,@SendTitle,@SendContent,@AttachmentID,@SendAttachment,@SendType,@SendFlag,@SendTime,@IsSend)";
             }
             

            try
            {
                //open connection

                SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);



                //System.Guid guid = new Guid();
                //guid = Guid.NewGuid();
                //string guidstr = guid.ToString();

                //cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(guidstr);
                cmd.Parameters.Add("@EmailMobile", SqlDbType.NVarChar).Value = EmailMobile_val;
                cmd.Parameters.Add("@SendTitle", SqlDbType.NVarChar).Value = SendTitle_val;
                cmd.Parameters.Add("@SendContent", SqlDbType.NText).Value = SendContent_val;
                cmd.Parameters.Add("@AttachmentID", SqlDbType.NVarChar).Value = AttachmentID_val;
                cmd.Parameters.Add("@SendAttachment", SqlDbType.NVarChar).Value = SendAttachment_val;
                cmd.Parameters.Add("@SendType", SqlDbType.NVarChar).Value = SendType_val;
                cmd.Parameters.Add("@SendFlag", SqlDbType.NVarChar).Value = SendFlag_val;
                if (SendTime_val == "")
                {
                    cmd.Parameters.Add("@SendTime", SqlDbType.DateTime).Value = DateTime.Today;
                }
                else
                {

                    cmd.Parameters.Add("@SendTime", SqlDbType.DateTime).Value = Convert.ToDateTime(SendTime_val);
                }
                
                cmd.Parameters.Add("@IsSend", SqlDbType.NVarChar).Value = IsSend_val;

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            new_base.init_connection(false);
            return true;
        }

        public bool AddVisitorInfo(string UserID_val, string CampaignID_val,string Email_val, string MobileNumber_val, string FirstName_val, string LastName_val, string DrivingLicenceNumber_val, string Address_val, string State_val, string Postcode_val, string Age_val)
        {
            new_base.init_connection(true);
            string InsertCMD;
            InsertCMD = "INSERT INTO  ClientInfoCollect(ID,UserID,CampaignID,Email, MobileNumber, FirstName, LastName, DrivingLicenceNumber,Address,State,Postcode,Age) Values(@ID,@UserID,@CampaignID,@Email, @MobileNumber, @FirstName, @LastName, @DrivingLicenceNumber,@Address,@State,@Postcode,@Age)";

            try
            {
                //open connection

                SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);

                System.Guid guid = new Guid();
                guid = Guid.NewGuid();
                string guidstr = guid.ToString();

                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(guidstr);


                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                cmd.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(CampaignID_val);
                
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email_val;
                cmd.Parameters.Add("@MobileNumber", SqlDbType.NVarChar).Value = MobileNumber_val;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName_val;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName_val;
                cmd.Parameters.Add("@DrivingLicenceNumber", SqlDbType.NVarChar).Value = DrivingLicenceNumber_val;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address_val;
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = State_val;
                cmd.Parameters.Add("@Postcode", SqlDbType.NVarChar).Value = Postcode_val;
                cmd.Parameters.Add("@Age", SqlDbType.NVarChar).Value = Age_val;

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }
            finally
            {
               
                new_base.init_connection(false);

            }

            return true;
        }


        public bool UpdateVisitorInfo(string ID_val, string CampaignID_val, string Email_val, string MobileNumber_val, string FirstName_val, string LastName_val, string DrivingLicenceNumber_val, string Address_val, string State_val, string Postcode_val, string Age_val)
        {
            
            new_base.init_connection(true);
            string updateCMD;
            updateCMD = "UPDATE   ClientInfoCollect  set  CampaignID=@CampaignID,Email=@Email, MobileNumber=@MobileNumber, FirstName=@FirstName, LastName=@LastName, DrivingLicenceNumber=@DrivingLicenceNumber,Address=@Address,State=@State,Postcode=@Postcode,Age=@Age  where ID=@ID";

            try
            {
                //open connection

                SqlCommand cmd = new SqlCommand(updateCMD, new_base.conn);



                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(ID_val);

                cmd.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(CampaignID_val);

                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email_val;
                cmd.Parameters.Add("@MobileNumber", SqlDbType.NVarChar).Value = MobileNumber_val;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName_val;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName_val;
                cmd.Parameters.Add("@DrivingLicenceNumber", SqlDbType.NVarChar).Value = DrivingLicenceNumber_val;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address_val;
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = State_val;
                cmd.Parameters.Add("@Postcode", SqlDbType.NVarChar).Value = Postcode_val;
                cmd.Parameters.Add("@Age", SqlDbType.NVarChar).Value = Age_val;

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }
            finally
            {

                new_base.init_connection(false);

            }

            return true;
        }
        //
        public bool AddCampaignInfo(string CampaignName_val, string CampainShow_val, string CampainVenue_val, string CampainDate_val, string LogoFile_val, string SiteID_val, string[] Fields, string MainFieldID, string UserID_val, string BgColor_val)
        {

            //SqlDataReader reader = null;
            
            new_base.init_connection(true);
            string InsertCMD;

            InsertCMD = "INSERT INTO CampaignInfo (ID,UserID,Title,SiteID,Show,Venue,Date,Logo,BgColor) Values  (@ID,@UserID,@Title,@SiteID,@Show,@Venue,@Date,@Logo,@BgColor)";

            try
            {
                //open connection

                SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);

  

                System.Guid guid = new Guid();
                guid = Guid.NewGuid();
                string guidstr = guid.ToString();

                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(guidstr);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = CampaignName_val;
                cmd.Parameters.Add("@SiteID", SqlDbType.UniqueIdentifier).Value = new Guid(SiteID_val);
                cmd.Parameters.Add("@Show", SqlDbType.NVarChar).Value = CampainShow_val;
                cmd.Parameters.Add("@Venue", SqlDbType.NVarChar).Value = CampainVenue_val;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value =Convert.ToDateTime(CampainDate_val);
                cmd.Parameters.Add("@Logo", SqlDbType.NVarChar).Value = LogoFile_val;
                cmd.Parameters.Add("@BgColor", SqlDbType.NVarChar).Value = BgColor_val;
                


                
                cmd.ExecuteNonQuery();

                string tempSQLforMain;


                try
                {
                    tempSQLforMain = "INSERT INTO CampaignDetails (CampaignID,FieldID) Values  (@CampaignID,@FieldID)";

                    SqlCommand cmdnew = new SqlCommand(tempSQLforMain, new_base.conn);

                    cmdnew.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(guidstr);
                    cmdnew.Parameters.Add("@FieldID", SqlDbType.UniqueIdentifier).Value = new Guid(MainFieldID);
                    cmdnew.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                    return false;
                }


                for (int i = 0; i < Fields.Length; i++)
                {
                    string tempFieldID = Fields[i];
                    string tempSQL;
                   
                   
                    try
                    {
                        tempSQL = "INSERT INTO CampaignDetails (CampaignID,FieldID) Values  (@CampaignID,@FieldID)";

                        SqlCommand cmdnew = new SqlCommand(tempSQL, new_base.conn);

                        cmdnew.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(guidstr);
                        cmdnew.Parameters.Add("@FieldID", SqlDbType.UniqueIdentifier).Value = new Guid(tempFieldID);
                        cmdnew.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex);
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            finally
            {
                //close connection
               // new_base.conn.Close();
                new_base.init_connection(false);

            }

            return true;
        }

        public bool DeleteMessageFilter_by_ID(string ID_val)
        {

            new_base.init_connection(true);
            string updateSQL;

            updateSQL = @"delete from  SendMessagesFilter where ID =@ID ";

            try
            {
                SqlCommand cmdnew = new SqlCommand(updateSQL, new_base.conn);
                cmdnew.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(ID_val);

                cmdnew.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            finally
            {
                new_base.init_connection(false);
            }
            return true;
        }



        public bool DeleteVisitor_by_ID(string VisitorID)
        {
            
            new_base.init_connection(true);
            //SqlDataReader reader = null;

            string updateSQL;

            updateSQL = @"delete from  ClientInfoCollect where ID =@VisitorID ";

            try
            {
                SqlCommand cmdnew = new SqlCommand(updateSQL, new_base.conn);

                cmdnew.Parameters.Add("@VisitorID", SqlDbType.UniqueIdentifier).Value = new Guid(VisitorID);
                
                cmdnew.ExecuteNonQuery();

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            finally
            {
                //reader.Close();
                new_base.init_connection(false);
            }
            return true;
        }


        public bool DeleteCampaign_by_ID(string CampaignID)
        {

            
            new_base.init_connection(true);
            SqlDataReader reader = null;
            SqlDataReader reader2 = null;



            string updateSQL;

            updateSQL = @"delete from  CampaignInfo where ID = "
                       + "'" + CampaignID + "'";

            try
            {

                SqlCommand cmd = new SqlCommand(updateSQL, new_base.conn);
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            finally
            {
                reader.Close();

            }

            updateSQL = @"delete from  CampaignDetails where CampaignID = "
                      + "'" + CampaignID + "'";

            try
            {

                SqlCommand cmd = new SqlCommand(updateSQL, new_base.conn);
                reader2 = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            finally
            {
                reader2.Close();
            }



            new_base.init_connection(false);
            return true;
        }

        public void SendEmailAttachment(string subject_val, string body_val, string toEmail_val, string attachment_val)
        {
            //add the email address we will be sending the message to
            mail.To.Add(toEmail_val);
            //add our email here
            mail.From = new MailAddress("touchsms666@gmail.com");
            //email's subject
            mail.Subject = subject_val;
            //email's body, this is going to be html. note that we attach the image as using cid
            mail.Body = body_val;
            //set email's body to html
            mail.IsBodyHtml = true;
            //mail.Attachments.Add(

            //Attachment myAttachment = new Attachment("./Uploads/Mail/
            Attachment myAttachment = new Attachment(attachment_val);
            if (attachment_val == "")
            {

            }
            else
            {
                mail.Attachments.Add(myAttachment);
            }
           


            //setup our smtp client, these are Gmail specific settings
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true; //ssl must be enabled for Gmail
            //our Gmail account credentials
            NetworkCredential credentials = new NetworkCredential("touchsms666@gmail.com", "touchsmspass");
            //add credentials to our smtp client
            client.Credentials = credentials;

            try
            {
                //try to send the mail message
                client.Send(mail);
                //return true;

            }
            catch
            {
                //some feedback if it does not work
                //return false;

            }
        }
        public void SendEmail(string subject_val, string body_val, string toEmail_val)
        {

            //add the email address we will be sending the message to
            mail.To.Add(toEmail_val);
            //add our email here
            mail.From = new MailAddress("touchsms666@gmail.com");
            //email's subject
            mail.Subject = subject_val;
            //email's body, this is going to be html. note that we attach the image as using cid
            mail.Body = body_val;
            //set email's body to html
            mail.IsBodyHtml = true;


            //setup our smtp client, these are Gmail specific settings
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true; //ssl must be enabled for Gmail
            //our Gmail account credentials
            NetworkCredential credentials = new NetworkCredential("touchsms666@gmail.com", "touchsmspass");
            //add credentials to our smtp client
            client.Credentials = credentials;

            try
            {
                //try to send the mail message
                client.Send(mail);
                //return true;

            }
            catch
            {
                //some feedback if it does not work
                //return false;

            }
        }

        public void SendSMSMessageByNumber(string msg,string telephonenumber)
        {
            string returnstr;
            Lodge oWS = new Lodge();
            returnstr = oWS.LodgeSMSMessage("Cyberplex.Software", "431531", telephonenumber, msg);
        }

        public void SendEmailAndSMS(string userid_val, string campaignid_val, string email_val, string phonenumber_val, string firstname_val, string lastname_val, string drivinglicencenumber_val, string address_val, string state_val, string postcode_val, string age_val)
        {
            string content_val = "";


            if (firstname_val == "")
            {

            }
            else
            {
                content_val = content_val + "     Your First Name : " + firstname_val;

            }
            if (lastname_val == "")
            {

            }
            else
            {
                content_val = content_val + "     Your  Last Name : " + lastname_val;

            }

            if (drivinglicencenumber_val == "")
            {

            }
            else
            {
                content_val = content_val + "      Your Driving Licence Number : " + drivinglicencenumber_val;

            }

            if (address_val == "")
            {

            }
            else
            {
                content_val = content_val + "     Your Address : " + address_val;

            }

            if (state_val == "")
            {

            }
            else
            {
                content_val = content_val + "     Your State : " + state_val;

            }

            if (postcode_val == "")
            {

            }
            else
            {
                content_val = content_val + "     Your Postcode : " + postcode_val;

            }

            if (age_val == "")
            {

            }
            else
            {
                content_val = content_val + "       Your Age : " + age_val;

            }

            if (phonenumber_val == "")
            {

            }
            else
            {
                content_val = content_val + "       Your Mobile Phone Number : " + phonenumber_val;


            }


            if (email_val == "")
            {

            }
            else
            {
                content_val = content_val + "       Your Email : " + email_val;

                //SendEmail("Welcome to fneasy", content_val, email_val);
                AddSendEmailMobile(email_val, "Welcome to fneasy", content_val,"", "", "email", "now", "", "n");
            }

            if (phonenumber_val == "")
            {

            }
            else
            {

                //SendSMSMessageByNumber("Welcome to fneasy ," + content_val, phonenumber_val);
                AddSendEmailMobile(phonenumber_val, "Welcome to fneasy", "Welcome to fneasy  "+content_val, "","", "mobile", "now", "", "n");

            }
        }


        public void CollectInfo(string userid_val, string campaignid_val,string email_val, string phonenumber_val, string firstname_val, string lastname_val, string drivinglicencenumber_val, string address_val, string state_val, string postcode_val, string age_val)
        {

            string content_val = "";


            if (firstname_val == "")
            {

            }
            else
            {
                content_val = content_val + "  <br>   Your First Name : " + firstname_val;

            }
            if (lastname_val == "")
            {

            }
            else
            {
                content_val = content_val + "  <br>   Your  Last Name : " + lastname_val;

            }

            if (drivinglicencenumber_val == "")
            {

            }
            else
            {
                content_val = content_val + " <br>     Your Driving Licence Number : " + drivinglicencenumber_val;

            }

            if (address_val == "")
            {

            }
            else
            {
                content_val = content_val + "  <br>   Your Address : " + address_val;

            }

            if (state_val == "")
            {

            }
            else
            {
                content_val = content_val + "  <br>   Your State : " + state_val;

            }

            if (postcode_val == "")
            {

            }
            else
            {
                content_val = content_val + "  <br>   Your Postcode : " + postcode_val;

            }

            if (age_val == "")
            {

            }
            else
            {
                content_val = content_val + "   <br>    Your Age : " + age_val;

            }

            if (phonenumber_val == "")
            {

            }
            else
            {
                content_val = content_val + "  <br>     Your Mobile Phone Number : " + phonenumber_val;
                

            }


            if (email_val == "")
            {
               
            }
            else
            {
                content_val = content_val + "  <br>     Your Email : " + email_val;

               // SendEmail("Welcome to fneasy", content_val, email_val);

                ////AddSendEmailMobile(email_val, "Welcome to fneasy", content_val, "","", "email", "now", "", "n");
            }

            if (phonenumber_val == "")
            {

            }
            else
            {
                content_val = content_val + "   <br>   Your Mobile Number : " + phonenumber_val;
                //SendSMSMessageByNumber("Welcome to fneasy ," + content_val, phonenumber_val);


                ////AddSendEmailMobile(phonenumber_val, "Welcome to fneasy", "Welcome to fneasy  " + content_val,"", "", "mobile", "now", "", "n");

            }

            DataTable temptable;
            temptable = GetAutoRespond_by_CampaignID(campaignid_val);

            if (temptable.Rows.Count > 0)
            {
                content_val = content_val +"<br>  "+ temptable.Rows[0]["Message"].ToString();
                if (temptable.Rows[0]["SendType"].ToString() == "email")
                {
                    if (email_val == "")
                    {
                    }
                    else
                    {
                        
                        if (temptable.Rows[0]["SendAttachment"].ToString() != "" && temptable.Rows[0]["SendAttachment"].ToString() != "null")
                        {
                            AddSendEmailMobile(email_val, temptable.Rows[0]["Subject"].ToString(), content_val, temptable.Rows[0]["AttachmentID"].ToString(), temptable.Rows[0]["SendAttachment"].ToString(), "email", "now", "", "n");
                        }
                        else
                        {
                            AddSendEmailMobile(email_val, temptable.Rows[0]["Subject"].ToString(), content_val, "", "", "email", "now", "", "n");
                        }
                       
                    }
                }
                else if (temptable.Rows[0]["SendType"].ToString() == "sms")
                {
                    if (phonenumber_val == "")
                    {
                    }
                    else
                    {
                        AddSendEmailMobile(phonenumber_val, "",  content_val, "", "", "mobile", "now", "", "n");
                    }
                }
                else if (temptable.Rows[0]["SendType"].ToString() == "emailsms")
                {
                    if (phonenumber_val == "")
                    {
                    }
                    else
                    {
                        AddSendEmailMobile(phonenumber_val, "", content_val, "", "", "mobile", "now", "", "n");
                    }

                    if (email_val == "")
                    {
                    }
                    else
                    {
                        content_val = content_val + temptable.Rows[0]["Message"].ToString();
                        if (temptable.Rows[0]["SendAttachment"].ToString() != "" && temptable.Rows[0]["SendAttachment"].ToString() != "null")
                        {
                            AddSendEmailMobile(email_val, temptable.Rows[0]["Subject"].ToString(), content_val, temptable.Rows[0]["AttachmentID"].ToString(), temptable.Rows[0]["SendAttachment"].ToString(), "email", "now", "", "n");
                        }
                        else
                        {
                            AddSendEmailMobile(email_val, temptable.Rows[0]["Subject"].ToString(), content_val, "", "", "email", "now", "", "n");
                        }

                    }
                }
            }
            else
            {
                if (email_val == "")
                {
                }
                else
                {
                    AddSendEmailMobile(email_val, "Welcome to fneasy", content_val, "","", "email", "now", "", "n");
                }

                if (phonenumber_val == "")
                {
                }
                else
                {
                   AddSendEmailMobile(phonenumber_val, "Welcome to fneasy", "Welcome to fneasy  " + content_val,"", "", "mobile", "now", "", "n");
                }
            }
            new_base.init_connection(true);
            string InsertCMD;

            InsertCMD = "INSERT INTO ClientInfoCollect (ID,UserID,CampaignID,Email,MobileNumber,FirstName,LastName,DrivingLicenceNumber,Address,State,Postcode,Age) Values  (@ID,@UserID,@CampaignID,@Email,@MobileNumber,@FirstName,@LastName,@DrivingLicenceNumber,@Address,@State,@Postcode,@Age)";

            try
            {
                //open connection

                SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);



                System.Guid guid = new Guid();
                guid = Guid.NewGuid();
                string guidstr = guid.ToString();

                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(guidstr);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(userid_val);
                cmd.Parameters.Add("@CampaignID", SqlDbType.UniqueIdentifier).Value = new Guid(campaignid_val);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email_val;

                cmd.Parameters.Add("@MobileNumber", SqlDbType.NVarChar).Value = phonenumber_val;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstname_val;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastname_val;
                cmd.Parameters.Add("@DrivingLicenceNumber", SqlDbType.NVarChar).Value = drivinglicencenumber_val;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address_val;
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = state_val;
                cmd.Parameters.Add("@Postcode", SqlDbType.NVarChar).Value = postcode_val;
                cmd.Parameters.Add("@Age", SqlDbType.NVarChar).Value = age_val;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
               
            }
            finally
            {
                //close connection
               // new_base.conn.Close();
                new_base.init_connection(false);

            }
        }
    }
}
