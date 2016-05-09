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

public partial class UploadLogo : FrontPage
{

    private string userIDstr;
    public common mycommon;
    private DataTable temp_table;

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
        this.Title = "Logo Upload";
        mycommon = new common();
        if (Session["userID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            userIDstr = Session["userID"].ToString();

           temp_table= mycommon.Get_User_by_UserID(userIDstr);
           if (temp_table.Rows[0]["LogoFile"] == null)
           {
               currentLogoPanel.Visible = false;

           }
           else
           {
               //currentLogoLabel.Text = temp_table.Rows[0]["LogoFile"].ToString();
               currentLogoHyperLink.Text = temp_table.Rows[0]["LogoFile"].ToString();
               //currentLogoHyperLink.ImageUrl = common.GetUrl().ToString().Replace("UploadLogo.aspx", "") + "Uploads/" + userIDstr + "/" + temp_table.Rows[0]["LogoFile"].ToString();

               currentLogoHyperLink.NavigateUrl = common.GetUrl().ToString().Replace("UploadLogo.aspx", "") + "Uploads/" + userIDstr + "/" + temp_table.Rows[0]["LogoFile"].ToString();
               currentLogoPanel.Visible = true;

           }

        }
    }
    protected void upload_btn_Click(object sender, EventArgs e)
    {
       // FileUpload1.
        showinfo.Text = "";
        Boolean fileOkExtenen = false;
        string path = Server.MapPath("~/Uploads/"+userIDstr+"/");
        if (FileUpload1.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            string[] allowedExtensions = {  ".png", ".jpeg", ".jpg" };
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
            if (FileUpload1.PostedFile.ContentLength <= 500 * 1024)
            {
                try
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);  


                    FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                    mycommon.UpdateLogoToDB_by_UserID(userIDstr, FileUpload1.FileName);
                    showinfo.Text = "You already  sucessfully uploaded logo file.";
                }
                catch (Exception ex)
                {
                    
                    ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the logo file  didn't successfully uploaded , the reason :" + ex.Message + "' ); ", true);
                    showinfo.Text = "The logo file  didn't successfully uploaded , the reason :" + ex.Message;

                }
               

            }
            else
            {
                showinfo.Text = "The file size can't exceeds 500KB.";
                ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the file size can't exceeds 500KB  '); ", true);
            }
        }
        else
        {
            showinfo.Text = "The logo file  only accept JPG and PNG  formats .";
            ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the logo file  only accept JPG and PNG  formats  '); ", true);
        }
    }
    protected void currentLogoDelButton_Click(object sender, EventArgs e)
    {
        mycommon.UpdateLogoToDB_by_UserID(userIDstr, "");
        //currentLogoHyperLink.Text = temp_table.Rows[0]["LogoFile"].ToString();
       
        //currentLogoHyperLink.NavigateUrl = common.GetUrl().ToString().Replace("UploadLogo.aspx", "") + "Uploads/" + userIDstr + "/" + temp_table.Rows[0]["LogoFile"].ToString();


    }

    protected void onMyFileUpload(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "Success_Scr", "javascript: alert('the logo file  is uploaded  '); ", true);
    }
}