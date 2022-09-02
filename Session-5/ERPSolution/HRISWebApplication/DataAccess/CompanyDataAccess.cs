using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace HRISWebApplication.DataAccess
{
    public class CompanyDataAccess
    {
        private readonly SqlConnection _conn;

        public CompanyDataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringHRIS"].ConnectionString);
            
        }
        public DataTable GetAllCompanyInformation()
        {
            _conn.Open();
            string sqlQuery = @"SELECT [CompanyId], [CompanyName], 
                [Address1], [Address2], [Address3], [ContPer1], [ContPer2], [Phone1]
                , [Fax1], [Email1] ,[Url1] ,[TIN],[RegNo] ,[VATNo] ,[Insurance1] FROM [dbo].[Hrms_Company_Master]";
            SqlCommand cmd = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            _conn.Close();
            return dataTable;
        }

        public void Save(IDictionary<string, string> companyDetails)
        {

            _conn.Open();
            string sqlQuery = $"INSERT INTO [dbo].[Hrms_Company_Master] " +
                $"([CompanyName] ,[CompanyId], [Address1] ,[Address2], [Address3],[ContPer1], [ContPer2], [Phone1]" +
                $", [Fax1], [Email1] ,[Url1] ,[TIN],[RegNo] ,[VATNo] ,[Insurance1])" +
                $"VALUES " +
                $"('{companyDetails["companyName"]}', '{companyDetails["companyId"]}', " +
                $"'{companyDetails["address1"]}', '{companyDetails["address2"]}', " +
                $"'{companyDetails["address3"]}', '{companyDetails["contactPersonAddress"]}', " +
                $"'{companyDetails["contactPersonEmail"]}', '{companyDetails["contactPersonPhoneNo"]}'," +
                $"'{companyDetails["fax"]}', '{companyDetails["email"]}', '{companyDetails["url"]}', '{companyDetails["tin"]}'," +
                $"'{companyDetails["regNo"]}', '{companyDetails["vatNo"]}', '{companyDetails["insurance"]}')";


            SqlCommand command = new SqlCommand(sqlQuery, _conn);

            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                string primaryKeyExceptionMessage = "Duplicate Primary Key Entered";
                HttpContext.Current.Response.Write($"<script>alert('{primaryKeyExceptionMessage}')</script>"); 
            }

            _conn.Close();
        }

        public void DeleteRow(string companyId)
        {
            _conn.Open();
            string sqlQuery = $"DELETE FROM [dbo].[Hrms_Company_Master] WHERE CompanyId='{companyId}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
    }
}