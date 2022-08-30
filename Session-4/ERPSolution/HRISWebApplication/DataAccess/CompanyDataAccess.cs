using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class CompanyDataAccess
    {
        private SqlConnection _conn;

        public CompanyDataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringHRIS"].ConnectionString);
            _conn.Open();
        }
        public SqlDataReader SaveAllCompanyInformation()
        {
            
            string sqlQuery = "SELECT [CompanyId], [CompanyName], " +
                "[Address1], [Address2], [Address3], [ContPer1], [ContPer2], [Phone1]" +
                ", [Fax1], [Email1] ,[Url1] ,[TIN],[RegNo] ,[VATNo] ,[Insurance1] FROM [dbo].[Hrms_Company_Master]";
            SqlCommand cmd = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void Save(IDictionary<string, string> companyDetails)
        {
            

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
            command.ExecuteNonQuery();
            //_conn.Close();
        }

        public void DeleteRow(string companyId)
        {
            string sqlQuery = $"DELETE FROM [dbo].[Hrms_Company_Master] WHERE CompanyId='{companyId}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
        }
    }
}