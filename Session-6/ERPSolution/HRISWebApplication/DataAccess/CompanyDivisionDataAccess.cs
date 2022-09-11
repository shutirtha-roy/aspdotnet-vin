using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HRISWebApplication.DataAccess
{
    public class CompanyDivisionDataAccess : DataAccess
    {
        public CompanyDivisionDataAccess()
        {

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

        public override void Save(IDictionary<string, string> companyDivisionDetails)
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

        public override void DeleteRow<T>(T officeLocationCode)
        {
            _conn.Open();
            string sqlQuery = $"DELETE FROM [dbo].[Hrms_Company_Division_Master] WHERE OfficeLocationCode='{officeLocationCode}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }

        public override void Update(IDictionary<string, string> companyDetails)
        {
            _conn.Open();
            string sqlQuery = $@"UPDATE [dbo].[Hrms_Company_Division_Master] Set CompanyId = '{companyDetails["companyId"]}',
                               OfficeLocationCode = '{companyDetails["officeLocationCode"]}', OfficeLocationName = '{companyDetails["officeLocationName"]}',
                               Location = '{companyDetails["location"]}', Address1 = '{companyDetails["address1"]}', Address2 = '{companyDetails["address2"]}',
                               Address3 = '{companyDetails["address3"]}' WHERE OfficeLocationCode = '{companyDetails["officeLocationCode"]}'";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
    }
}