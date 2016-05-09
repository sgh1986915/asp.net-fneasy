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

using System.Net.Mail;
using System.Net;


public partial class forgottenpassword  : FrontPage
{
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
        this.Title = "Forgotten Password";
    }

    protected void submit_btn_Click(object sender, EventArgs e)
    {
        if (Email_txt.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('please type email'); ", true);
        }
        else
        {

            if (mymembership.Get_User_by_Email(Email_txt.Text).Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr2", "javascript: alert('your email is not existed in our database'); ", true);
            }
            else
            {
                Random r = new Random();
                string ranstr = r.Next(10000, 90000).ToString();
                string oldpass = mymembership.Get_User_by_Email(Email_txt.Text).Rows[0]["Password"].ToString().Substring(0, 5);
                string newpass = ranstr + oldpass;
                // ClientScript.RegisterStartupScript(GetType(), "Success_Scr0", "javascript: alert(' ranstr" + ranstr + " type email'); ", true);
                //  ClientScript.RegisterStartupScript(GetType(), "Success_Scr1", "javascript: alert(' oldpass" + oldpass + " type email'); ", true);
                // ClientScript.RegisterStartupScript(GetType(), "Success_Scr2", "javascript: alert(' please" + newpass + " type email'); ", true);

                mymembership.Set_UserPass_by_Email(mymembership.md5(newpass), Email_txt.Text);

                string bodystr = " You have recently requested to reset your fneasy password.  Your new password is:" + newpass;


                MailMessage mail = new MailMessage();
                //add the email address we will be sending the message to
                mail.To.Add(Email_txt.Text);
                //add our email here
                mail.From = new MailAddress("touchsms666@gmail.com");
                //email's subject
                mail.Subject = "Your Password Reset Request";
                //email's body, this is going to be html. note that we attach the image as using cid
                mail.Body = bodystr;
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
                }
                catch
                {
                    //some feedback if it does not work
                    submit_btn.Text = "Fail";
                }

            }


        }
    }
}