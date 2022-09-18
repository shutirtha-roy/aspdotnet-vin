using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class CompanySectionDataAccess : DataAccess
    {
        public CompanySectionDataAccess()
        {
                
        }

        public DataTable GetAllCompanySectionInformation()
        {
            _conn.Open();
            string sqlQuery = @"SELECT [CompanyId], [OfficeLocationId], [DepartmentCode], 
                [SectionCode], [SectionName], [HeadOfSection], [SubstituteHeadOfSection]
                FROM [dbo].[Hrms_Company_Section_Master]";
            SqlCommand cmd = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            _conn.Close();
            return dataTable;
        }

        public void DeleteRow<T>(T sectionCode)
        {
            _conn.Open();
            string sqlQuery = $"DELETE FROM [dbo].[Hrms_Company_Section_Master] WHERE SectionCode='{sectionCode}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }

        public void Save(IDictionary<string, string> companySection)
        {
            _conn.Open();

            if (companySection["companyId"] == "-1")
            {
                string companyExceptionMessage = "Company Id not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else if (companySection["locationId"] == "-1")
            {
                string companyExceptionMessage = "Office Location Id not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else if (companySection["departmentCode"] == "-1")
            {
                string companyExceptionMessage = "Department Code not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else if (companySection["sectionCode"] == "-1" || companySection["sectionCode"] == "")
            {
                string companyExceptionMessage = "Section Code not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else
            {
                string sqlQuery = $@"INSERT INTO [dbo].[Hrms_Company_Section_Master] 
                ([CompanyId] ,[OfficeLocationId], [DepartmentCode] ,[SectionCode]
                , [SectionName], [HeadOfSection] ,[SubstituteHeadOfSection]) VALUES 
                ('{companySection["companyId"]}', '{companySection["locationId"]}',
                '{companySection["departmentCode"]}', '{companySection["sectionCode"]}',
                '{companySection["sectionName"]}', '{companySection["headOfSection"]}',
                '{companySection["substituteHeadOfSection"]}')";

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

        public void Update(IDictionary<string, string> companySection)
        {
            _conn.Open();
            string sqlQuery = $@"UPDATE [dbo].[Hrms_Company_Section_Master] Set CompanyId = '{companySection["companyId"]}',
                               OfficeLocationId = '{companySection["locationId"]}', DepartmentCode = '{companySection["departmentCode"]}',
                               SectionName = '{companySection["sectionName"]}', HeadOfSection = '{companySection["headOfSection"]}',
                               SubstituteHeadOfSection = '{companySection["substituteHeadOfSection"]}' WHERE SectionCode = '{companySection["sectionCode"]}'";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }

        
    }
}