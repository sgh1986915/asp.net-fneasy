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

    

    public class common
    {
        private DalLayer objDalLayer = new DalLayer();
        private baseclass new_base = new baseclass();

        public common()
        {
            //new_base.init_connection(true);
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
                strTemp = "https://";
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
        public bool UpdateLogoToDB_by_UserID(string userID_val , string logoFilePath_val)
        {
            new_base.init_connection(true);
            try
            {
                string query_update = "UPDATE   OwnerUser  set  LogoFile = @LogoFile where ID =@ID";
                SqlCommand base_command = new SqlCommand(query_update, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(userID_val);

                base_command.Parameters.Add("@LogoFile", SqlDbType.NVarChar).Value = logoFilePath_val;
                base_command.ExecuteNonQuery();
                new_base.init_connection(false);
                return true;
            }
            catch (Exception ex)
            {
                    return false;
            }
            
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
                queryTxt = "SELECT *  FROM  OwnerUser where ID= @ID    ";
                SqlCommand cmd = new SqlCommand(queryTxt);
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(UserID_val);

                table = objDalLayer.ReturnDataset(cmd).Tables[0];
                new_base.init_connection(false);
            }
            catch (Exception exception)
            {
                throw exception;


            }
            return table;
        }

        
        
    }

}