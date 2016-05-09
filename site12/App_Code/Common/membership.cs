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
using System.Net;
using System.Net.Mail;



namespace Touchdevice.Common
{

    public class baseclass
    {
        public SqlConnection conn;
        public baseclass()
        {
            //
            // TODO: Add constructor logic here
        }

        public Boolean init_connection(bool param)
        {

            try
            {
                String connString = ConfigurationManager.ConnectionStrings["TouchConStr"].ConnectionString;
                if (this.conn == null)
                {

                }
                else
                {
                    this.conn.Close();
                }
                this.conn = new SqlConnection(connString);
                if (param == true)
                {
                    //if(this.conn.
                    this.conn.Open();
                    return true;
                }
                else
                {
                    this.conn.Close();
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }



        }


    }


    public class Membership
    {
        private DalLayer objDalLayer = new DalLayer();
        private  baseclass new_base = new baseclass();
            

        public Membership()
        {
            //new_base.init_connection(true);
        }


        public void SendMailUseGmail(string  toEmail, string fromEmail , string subject_val , string body_val)  
        {    
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(toEmail);    
            //msg.To.Add("b@b.com");    /**//*    * msg.To.Add("b@b.com");    * msg.To.Add("b@b.com");    * msg.To.Add("b@b.com");可以发送给多人    */   
            //msg.CC.Add("c@c.com");    /**//*    * msg.CC.Add("c@c.com");    * msg.CC.Add("c@c.com");可以抄送给多人    */
            msg.From = new MailAddress("smstest5726@hotmail.com", "Touch Device", System.Text.Encoding.UTF8);    /**//* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
            msg.Subject = subject_val;//邮件标题    
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码    
            msg.Body = body_val;//邮件内容    
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码    
            msg.IsBodyHtml = false;//是否是HTML邮件    
            msg.Priority = MailPriority.High;//邮件优先级       
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("smstest5726@hotmail.com", "t5r4e3");    //上述写你的GMail邮箱和密码   
            //client.Port = 587;//Gmail使用的端口    
            client.Host = "smtp.hotmail.com";    
            //client.EnableSsl = true;//经过ssl加密    
            object userState = msg;    
            try {    
                    client.SendAsync(msg, userState);    //简单一点儿可以
                    client.Send(msg);    
                    //MessageBox.Show("发送成功");    
            }    
            catch (System.Net.Mail.SmtpException ex) 
            {    
                //MessageBox.Show(ex.Message, "发送邮件出错");    
            }    
        }  


        public String md5(String s) 
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();            
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for(int i=0 ; i<bytes.Length ; i++)
            {                
                ret += Convert.ToString(bytes[i],16).PadLeft(2,'0');
            }

            return ret.PadLeft(32,'0');
        }




        public DataTable User_by_EmailPassword(string Email_val, string Password_val)
        {
           // string scalarValue = null;
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, Email, BusinessName, PhoneNumber, Username, NameToDisplay, Password,ContactPerson,ActivationCode FROM  OwnerUser where Email= @Email   and Password=@Password ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email_val;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password_val;
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable User_by_UsernamePassword(string Username_val, string Password_val)
        {
            // string scalarValue = null;
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, Email, BusinessName, PhoneNumber, Username, NameToDisplay, Password,ContactPerson,ActivationCode FROM  OwnerUser where Username= @Username   and Password=@Password ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username_val;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password_val;
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable Get_User_by_Email(string Email_val)
        {
            // string scalarValue = null;
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, Email, BusinessName, PhoneNumber, Username, NameToDisplay, Password,ContactPerson,ActivationCode FROM  OwnerUser where Email= @Email    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email_val;

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
             return table;;
        }

        public DataTable Get_User_by_Username(string Username_val)
        {
            // string scalarValue = null;
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, Email, BusinessName, PhoneNumber, Username, NameToDisplay, Password,ContactPerson,ActivationCode FROM  OwnerUser where Username= @Username    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username_val;

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table; ;
        }


        public bool Set_UserPass_by_Email(string password_val, string email_val)
        {
            new_base.init_connection(true);
            try
            {

                string query_update = "UPDATE    OwnerUser set  Password = @Password where Email =@Email";
                SqlCommand base_command = new SqlCommand(query_update, new_base.conn);
                base_command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password_val;
                base_command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email_val;
                base_command.ExecuteNonQuery();
                new_base.init_connection(false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
           

        }


        public String Get_UserID_by_Username(string Username_val)
        {
            // string scalarValue = null;
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, Email, BusinessName, PhoneNumber, Username, NameToDisplay, Password,ContactPerson,ActivationCode FROM  OwnerUser where Username= @Username    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = Username_val;

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table.Rows[0]["ID"].ToString();
        }


        public DataTable Get_User_by_UserID(string UserID_val)
        {
            // string scalarValue = null;
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, Email, BusinessName, Address,PhoneNumber, Username, NameToDisplay, Password,ContactPerson,ActivationCode FROM  OwnerUser where ID= @ID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;


            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable Get_PackageDetail_by_UserID(string UserID_val)
        {
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                new_base.init_connection(true);
                string queryTxt = "";
                queryTxt = "SELECT ID, UserID, PackageID, SmsNumber,Volume, UsedSmsNumber, UsedVolume FROM  PackageUserDetails where UserID= @UserID    ";
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
        public bool Set_User_by_UserID(string UserID_val, string Email_val, string BusinessName_val, string Address_val, string PhoneNumber_val, string NameToDisplay_val, string ContactPerson_val)
        {
            try
            {
                
                new_base.init_connection(true);
                string query_update = "UPDATE    OwnerUser set  Email = @Email , BusinessName =@BusinessName ,Address =@Address , PhoneNumber =@PhoneNumber , NameToDisplay =@NameToDisplay , ContactPerson =@ContactPerson  where ID=@ID ";
                SqlCommand base_command = new SqlCommand(query_update, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val) ;
                base_command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email_val;
                base_command.Parameters.Add("@BusinessName", SqlDbType.NVarChar).Value = BusinessName_val;
                base_command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address_val;
                base_command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = PhoneNumber_val;
                base_command.Parameters.Add("@NameToDisplay", SqlDbType.NVarChar).Value = NameToDisplay_val;
                base_command.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = ContactPerson_val;

                base_command.ExecuteNonQuery();
                new_base.init_connection(false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

           

        }
        public String Get_UserID_by_Email(string Email_val)
        {
            // string scalarValue = null;
           
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, Email, BusinessName, PhoneNumber, Username, NameToDisplay, Password,ContactPerson,ActivationCode FROM  OwnerUser where Email= @Email    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email_val;
               
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
               

            }
            new_base.init_connection(false);
            return table.Rows[0]["ID"].ToString();
        }


        public DataTable Site_by_order()
        {
            
            new_base.init_connection(true);
            DataTable table;
            try
            {
                //DalLayer objDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, Website, Url, Price, Sorder FROM  Site  order by Sorder ";
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

        public DataTable Package_by_site(string siteID)
        {
            
            new_base.init_connection(true);
            DataTable table;
            try
            {
                DalLayer myDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT ID, PackageName, SiteID, SmsNumber, Volume, Price FROM  Package where SiteID= @SiteID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@SiteID", SqlDbType.UniqueIdentifier).Value = new Guid(siteID);

                table = myDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            new_base.init_connection(false);
            return table;
        }

        public DataTable Package_by_ID(string PackageID)
        {
           
            new_base.init_connection(true);
            DataTable table;
            try
            {
                DalLayer myDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT Package.ID, Package.PackageName, Package.SiteID, Package.SmsNumber, Package.Volume, Package.Price, Site.Website  FROM  Package , Site where Package.SiteID=Site.ID and   Package.ID= @PackageID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@PackageID", SqlDbType.UniqueIdentifier).Value = new Guid(PackageID);

                table = myDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            new_base.init_connection(false);
            return table;
        }

       
     
        public bool isLoginGuest_by_username(string username_val, string pass_val)
        {
            string dbpass = "";
            new_base.init_connection(true);
            try
            {
                DalLayer layer = new DalLayer();
                string cmdText = "";
                cmdText = "SELECT       Password   FROM            GuestUser  WHERE     Username= @Username";
                SqlCommand cmd = new SqlCommand(cmdText);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username_val;

                dbpass = layer.GetScalarValue(cmd);
                new_base.init_connection(false);
                if (dbpass == "")
                {
                    if (pass_val == "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (dbpass == md5(pass_val))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }



        }


        public bool isLoginUser_by_username(string username_val, string pass_val)
        {
            string dbpass = "";
            new_base.init_connection(true);
            try
            {
                DalLayer layer = new DalLayer();
                string cmdText = "";
                cmdText = "SELECT       Password   FROM            OwnerUser  WHERE     Username= @Username";
                SqlCommand cmd = new SqlCommand(cmdText);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username_val;

                dbpass = layer.GetScalarValue(cmd);
                new_base.init_connection(false);
                if (dbpass == "")
                {
                    if (pass_val == "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (dbpass == md5(pass_val))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }



        }
        public bool restorePassword_by_ID(string userID_val, string oldpass_val, string newpass_val)
        {

            DataTable mytable;
            string dbpass = "";
            string newpass = md5(newpass_val);
            mytable = Get_User_by_UserID(userID_val);
            if (mytable.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                dbpass = mytable.Rows[0]["Password"].ToString();
                if (dbpass == md5(oldpass_val))
                {
                    try
                    {
                        
                        new_base.init_connection(true);
                        string query_update = "UPDATE    OwnerUser set   Password =@Password  where ID=@ID ";
                        SqlCommand base_command = new SqlCommand(query_update, new_base.conn);
                        base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(userID_val);
                        base_command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = newpass;
                        base_command.ExecuteNonQuery();
                        new_base.init_connection(false);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            

        }

        public bool isLoginUser_by_email(string email_val, string pass_val)
        {
            string dbpass = "";
            
            
            try
            {
                new_base.init_connection(true);
                DalLayer layer = new DalLayer();
                string cmdText = "";
                cmdText = "SELECT       Password   FROM            OwnerUser  WHERE     Email= @Email";
                SqlCommand cmd = new SqlCommand(cmdText);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email_val;

                dbpass= layer.GetScalarValue(cmd);
                new_base.init_connection(false);
                if (dbpass == "")
                {
                    if (pass_val == "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if(dbpass==md5(pass_val))
                    {
                        return true;
                    }else{
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            
           

        }
        public bool CreateGuestuser( string Username_val,  string Password_val)
        {



            SqlDataReader reader = null;
            string InsertCMD;
            new_base.init_connection(true);
            Password_val = md5(Password_val);

            InsertCMD = @"insert into GuestUser (Username,Password) Values('" + Username_val + @"','" + Password_val + @"')";

            try
            {
                //open connection

                SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            finally
            {
                //close connection
                reader.Close();
                new_base.init_connection(false);

            }

            return true;
        }



        public bool Createuser(string Email_val, string BusinessName_val, string Address_val,string PhoneNumber_val, string Username_val, string NameToDisplay_val, string Password_val, string ContactPerson_val, string ActivationCode)
        {
           
            new_base.init_connection(true);
            

            SqlDataReader reader = null;
            string InsertCMD;

            Password_val = md5(Password_val);

            InsertCMD = @"insert into OwnerUser (Email,BusinessName,Address,PhoneNumber,Username,NameToDisplay,Password,ContactPerson,ActivationCode) Values('" + Email_val + @"','" + BusinessName_val + @"','" + Address_val + @"','" + PhoneNumber_val + @"','" + Username_val + @"','" + NameToDisplay_val + @"','" + Password_val + @"','" + ContactPerson_val + @"','" + ActivationCode + @"')";

            try
            {
                //open connection

                SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            finally
            {
                //close connection
                reader.Close();
                new_base.init_connection(false);
            }

            return true;
        }
        
        
         public string Get_phonestate_by_phonenumber(string phone_num)
        {

            try
            {
                
                new_base.init_connection(true);
                DalLayer layer = new DalLayer();
                string cmdText = "";
                cmdText = "SELECT       State   FROM            PhoneState WHERE     TelephoneNumber= @TelephoneNumber";
                SqlCommand cmd = new SqlCommand(cmdText);
                cmd.Parameters.Add("@TelephoneNumber", SqlDbType.NVarChar).Value = phone_num;
                new_base.init_connection(false);
                return layer.GetScalarValue(cmd);
            }
            catch (Exception)
            {
                return "";
            }
        }


        public bool Set_phonestate(string phone_num, string state_val)
        {
            //baseclass new_base = new baseclass();
           // new_base.init_connection(true);
            
            new_base.init_connection(true);
            SqlDataReader reader = null;
            string InsertCMD;

            if (Get_phonestate_by_phonenumber(phone_num) == "")
            {
               

                InsertCMD = @"insert into PhoneState (TelephoneNumber,State) Values('" + phone_num + @"','" + state_val + @"')";

                try
                {
                    //open connection

                    SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);
                    reader = cmd.ExecuteReader();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                    return false;
                }
                finally
                {
                    //close connection
                    reader.Close();
                    new_base.init_connection(false);
                }
            }
            else
            {
                try
                {

                    string query_update = "UPDATE    PhoneState set  State = @State_val where TelephoneNumber =@TelephoneNumber";
                    SqlCommand base_command = new SqlCommand(query_update, new_base.conn);
                    base_command.Parameters.Add("@TelephoneNumber", SqlDbType.NVarChar).Value = phone_num;
                    base_command.Parameters.Add("@State_val", SqlDbType.NVarChar).Value = state_val;
                    base_command.ExecuteNonQuery();
                    new_base.init_connection(false);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

            return true;
        }

        public bool update_packageuser(string packageID, string userID,string type)
        {

           
            SqlDataReader reader = null;
            SqlDataReader reader2 = null;

            SqlDataReader reader3 = null;
            //SqlDataReader reader4 = null;
            string updateSQL;
            new_base.init_connection(true);

            updateSQL = @"delete from  PackageUser where UserID = "
                       + "'" + userID + "'";

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

            updateSQL = @"INSERT INTO PackageUser (UserID,PackageID,Type) Values('" + userID + @"','" + packageID + @"','" + type + @"')";

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

            updateSQL = @"delete from  PackageUserDetails where UserID = "
                       + "'" + userID + "'";

            try
            {

                SqlCommand cmd = new SqlCommand(updateSQL, new_base.conn);
                reader3 = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            finally
            {
                reader3.Close();
            }

            DataTable mytable;
            try
            {
                DalLayer myDalLayer = new DalLayer();
                string queryTxt = "";
                queryTxt = "SELECT Package.ID, Package.PackageName, Package.SiteID, Package.SmsNumber, Package.Volume, Package.Price, Site.Website  FROM  Package , Site where Package.SiteID=Site.ID and   Package.ID= @PackageID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@PackageID", SqlDbType.UniqueIdentifier).Value = new Guid(packageID);

                mytable = myDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }

            string SmsNumber_val = mytable.Rows[0]["SmsNumber"].ToString();
            string Volume_val = mytable.Rows[0]["Volume"].ToString();
            InsertPackageUserDetails(userID, packageID, SmsNumber_val, Volume_val);

            new_base.init_connection(false);

            return true;
        }


        public bool InsertPackageUserDetails(string UserID_val, string PackageID_val, string SmsNumber_val, string Volume_val)
        {


           
            new_base.init_connection(true);
            //SqlDataReader reader = null;
            string InsertCMD;



            InsertCMD = "INSERT INTO PackageUserDetails (UserID,PackageID,SmsNumber,Volume) Values  (@UserID,@PackageID,@SmsNumber,@Volume)";

            try
            {
                //open connection

                SqlCommand cmd = new SqlCommand(InsertCMD, new_base.conn);
                cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val); ;
                cmd.Parameters.Add("@PackageID", SqlDbType.UniqueIdentifier).Value = new Guid(PackageID_val); ;
                cmd.Parameters.Add("@SmsNumber", SqlDbType.NVarChar).Value = SmsNumber_val;
                cmd.Parameters.Add("@Volume", SqlDbType.NVarChar).Value = Volume_val;

                cmd.ExecuteNonQuery();
               // reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;
            }
            finally
            {
                //close connection
                //reader.Close();
                new_base.init_connection(false);

            }

            return true;
        }
    }
}