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
    public class owner
    {
        private DalLayer objDalLayer = new DalLayer();
        private baseclass new_base = new baseclass();

        private MailMessage mail;

        public owner()
        {
             mail = new MailMessage();
        }

        public DataTable GetOwnerList()
        {
            new_base.init_connection(true);
            DataTable table;

            try
            {
                string queryTxt = "";
                queryTxt = "SELECT * FROM OwnerUser";
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

        public DataTable GetOwnerList(string ownerID)
        {
            new_base.init_connection(true);
            DataTable table;

            try
            {
                string queryTxt = "SELECT * FROM OwnerUser WHERE ID = @OwnerID ";
                SqlCommand cmd = new SqlCommand(queryTxt);

                cmd.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = new Guid(ownerID);
                table = objDalLayer.ReturnDataset(cmd).Tables[0];
            }
            catch (Exception exception)
            {
                throw exception;
            }

            new_base.init_connection(false);

            return table;
        }

        public bool DeleteOwner(string ownerID)
        {
            new_base.init_connection(true);
            SqlDataReader reader = null;

            string updateSQL;

            updateSQL = @"DELETE FROM OwnerUser WHERE ID = " + "'" + ownerID + "'";

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

            new_base.init_connection(false);

            return true;
        }

        public bool UpdateOwner(string ownerID, string Email, string BusinessName, string Address, string PhoneNumber, string NameToDisplay, string ContactPerson, string ActivationCode)
        {
            new_base.init_connection(true);

            string queryTxt;
            queryTxt = "UPDATE OwnerUser set Email=@Email ,BusinessName=@BusinessName, Address=@Address, PhoneNumber=@PhoneNumber, NameToDisplay=@NameToDisplay, ContactPerson=@ContactPerson, ActivationCode=@ActivationCode WHERE ID=@ID";
            
            try
            {
                SqlCommand base_command = new SqlCommand(queryTxt, new_base.conn);
                base_command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = new Guid(ownerID);
                base_command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                base_command.Parameters.Add("@BusinessName", SqlDbType.NVarChar).Value = BusinessName;
                base_command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
                base_command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = PhoneNumber;
                base_command.Parameters.Add("@NameToDisplay", SqlDbType.NVarChar).Value = NameToDisplay;
                base_command.Parameters.Add("@ContactPerson", SqlDbType.NVarChar).Value = ContactPerson;
                base_command.Parameters.Add("@ActivationCode", SqlDbType.NVarChar).Value = ActivationCode;

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

        public static string GetUrl()
        {
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
    }
}
