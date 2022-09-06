using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HRISWebApplication.DataAccess
{
    public class CompanyDivisionDataAccess
    {
        private readonly SqlConnection _conn;

        public CompanyDivisionDataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringHRIS"].ConnectionString);
        }

        public DataTable GetAllCompanyDivisionInformation()
        {
            _conn.Open();
            string sqlQuery = @"SELECT [CompanyId], [OfficeLocationCode], [OfficeLocationName], 
                [Location], [Address1], [Address2], [Address3]
                FROM [dbo].[Hrms_Company_Division_Master]";
            SqlCommand cmd = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            _conn.Close();
            return dataTable;
        }

        public void Save(IDictionary<string, string> companyDivisionDetails)
        {

            _conn.Open();

            if (companyDivisionDetails["officeLocationCode"] == "")
            {
                string primaryKeyExceptionMessage = "Empty Primary Key entered";
                HttpContext.Current.Response.Write($"<script>alert('{primaryKeyExceptionMessage}')</script>");
            }
            else if (companyDivisionDetails["companyId"] == "-1")
            {
                string companyExceptionMessage = "Company Id not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else
            {
                string sqlQuery = $@"INSERT INTO [dbo].[Hrms_Company_Division_Master] 
                ([CompanyId] ,[OfficeLocationCode], [OfficeLocationName] ,[Location]
                , [Address1], [Address2] ,[Address3]) VALUES 
                ('{companyDivisionDetails["companyId"]}', '{companyDivisionDetails["officeLocationCode"]}',
                '{companyDivisionDetails["officeLocationName"]}', '{companyDivisionDetails["location"]}',
                '{companyDivisionDetails["address1"]}', '{companyDivisionDetails["address2"]}',
                '{companyDivisionDetails["address3"]}')";

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
    }
}