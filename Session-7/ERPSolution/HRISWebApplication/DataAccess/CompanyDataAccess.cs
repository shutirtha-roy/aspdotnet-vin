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
    public class CompanyDataAccess : DataAccess
    {
        public CompanyDataAccess()
        {

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

        public override void Save(IDictionary<string, string> companyDetails)
        {

            _conn.Open();

            if (companyDetails["companyId"] == "")
            {
                string primaryKeyExceptionMessage = "Empty Primary Key entered";
                HttpContext.Current.Response.Write($"<script>alert('{primaryKeyExceptionMessage}')</script>");
            }
            else
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

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string primaryKeyExceptionMessage = "Duplicate Primary Key Entered";
                    HttpContext.Current.Response.Write($"<script>alert('{primaryKeyExceptionMessage}')</script>");
                }
            }

            _conn.Close();
        }

        public override void DeleteRow<T>(T companyId)
        {
            _conn.Open();
            string sqlQuery = $"DELETE FROM [dbo].[Hrms_Company_Master] WHERE CompanyId='{companyId}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }

        public override void Update(IDictionary<string, string> companyDetails)
        {
            _conn.Open();
            string sqlQuery = $@"UPDATE [dbo].[Hrms_Company_Master] Set CompanyName = '{companyDetails["companyName"]}',
                               Address1 = '{companyDetails["address1"]}', Address2 = '{companyDetails["address2"]}', Address3 = '{companyDetails["address3"]}',
                               ContPer1 = '{companyDetails["contactPersonAddress"]}', ContPer2 = '{companyDetails["contactPersonEmail"]}', Phone1 = '{companyDetails["contactPersonPhoneNo"]}',
                               Fax1 = '{companyDetails["fax"]}', Email1 = '{companyDetails["email"]}', Url1 = '{companyDetails["url"]}', TIN = '{companyDetails["tin"]}',
                               RegNo = '{companyDetails["regNo"]}', VATNo = '{companyDetails["vatNo"]}', Insurance1 = '{companyDetails["insurance"]}'
                               WHERE CompanyId = '{companyDetails["companyId"]}'";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
    }
}