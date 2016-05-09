using System;


using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Touchdevice.Common;
using System.Data.SqlClient;
using Touchdevice.Dal;
using System.Data;

namespace Touchdevice.Web
{
    public class FrontPage : Page
    {
        private DateTime processStartTime;

        public Membership mymembership;
        public string userid_val;
        public string pagetitle;


        public FrontPage()
        {
            mymembership = new Membership();
            processStartTime = DateTime.Now;

        }
        protected void Page_PreInit(Object sender, EventArgs e)
        {
           
        }


        public bool goCampaignLogin(string username_val, string password_val)
        {
            if (username_val == "" || username_val == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type email or username'); ", true);
            }
            else if (password_val == "" || password_val == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type password'); ", true);
            }
            else
            {
                if (username_val.Contains("@"))
                {
                    if (mymembership.isLoginUser_by_email(username_val, password_val))
                    {
                        //Session["userID"] = mymembership.Get_UserID_by_Email(username_val).ToString();
                        //ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('You already successfully login the system'); ", true);
                        //Server.Transfer("index.aspx");
                        return true;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "in_Scr", "javascript: alert('Your email or password is wrong, you failed to login the system'); ", true);
                    }
                }
                else
                {
                    if (mymembership.isLoginUser_by_username(username_val, password_val))
                    {
                        //Session["userID"] = mymembership.Get_UserID_by_Username(username_val).ToString();
                        //ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('You already successfully login the system'); ", true);
                        //Server.Transfer("index.aspx");
                        return true;
                    }
                    else
                    {
                        if (mymembership.isLoginGuest_by_username(username_val, password_val))
                        {


                            //ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('You already successfully login the system'); ", true);
                           // Server.Transfer("index.aspx");
                            return true;
                        }
                        else
                        {

                           // ClientScript.RegisterStartupScript(GetType(), "in_Scr", "javascript: alert('Your username or password is incorrect'); ", true);
                        }

                    }
                }
            }

            return false;
        }
        public void goPageLogin(string username_val, string password_val)
        {
            if (username_val == "" || username_val == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type email or username'); ", true);
            }
            else if (password_val == "" || password_val == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('Please type password'); ", true);
            }
            else
            {
                if (username_val.Contains("@"))
                {
                    if (mymembership.isLoginUser_by_email(username_val, password_val))
                    {
                        Session["userID"] = mymembership.Get_UserID_by_Email(username_val).ToString();
                        ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('You already successfully login the system'); ", true);
                        Server.Transfer("index.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "in_Scr", "javascript: alert('Your email or password is wrong, you failed to login the system'); ", true);
                    }
                }
                else
                {
                    if (mymembership.isLoginUser_by_username(username_val, password_val))
                    {
                        Session["userID"] = mymembership.Get_UserID_by_Username(username_val).ToString();
                        ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('You already successfully login the system'); ", true);
                        Server.Transfer("index.aspx");
                    }
                    else
                    {
                        if (mymembership.isLoginGuest_by_username(username_val, password_val))
                        {


                            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('You already successfully login the system'); ", true);
                            Server.Transfer("index.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "in_Scr", "javascript: alert('Your username or password is incorrect'); ", true);
                        }

                    }
                }
            }
        }

        
    }

}