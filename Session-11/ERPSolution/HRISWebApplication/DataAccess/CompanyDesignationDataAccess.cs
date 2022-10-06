using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class CompanyDesignationDataAccess : DataAccess
    {
        public CompanyDesignationDataAccess()
        {

        }

        public DataTable GetAllCompanyDesignationInformation()
        {
            _conn.Open();
            string sqlQuery = @"SELECT [CompanyId], [OfficeLocationId], [DepartmentCode], 
                [SectionCode], [DesignationCode], [DesignationName] FROM [dbo].[Hrms_Company_Designations_Master]";
            SqlCommand cmd = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            _conn.Close();
            return dataTable;
        }

        public void DeleteRow<T>(T designationCode)
        {
            _conn.Open();
            string sqlQuery = $"DELETE FROM [dbo].[Hrms_Company_Designations_Master] WHERE DesignationCode='{designationCode}'";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string cascadingExceptionMessage = "Error in deleting due Cascading Relationship";
                HttpContext.Current.Response.Write($"<script>alert('{cascadingExceptionMessage}')</script>");
            }

            _conn.Close();
        }

        public void Save(IDictionary<string, string> companyDesignation)
        {
            _conn.Open();

            if (companyDesignation["companyId"] == "-1")
            {
                string companyExceptionMessage = "Company Id not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else if (companyDesignation["locationId"] == "-1")
            {
                string companyExceptionMessage = "Office Location Id not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else if (companyDesignation["departmentCode"] == "-1")
            {
                string companyExceptionMessage = "Department Code not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else if (companyDesignation["sectionCode"] == "-1" || companyDesignation["sectionCode"] == "")
            {
                string companyExceptionMessage = "Section Code not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else if (companyDesignation["designationCode"] == "-1" || companyDesignation["designationCode"] == "")
            {
                string companyExceptionMessage = "Designation Code not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else
            {
                string sqlQuery = $@"INSERT INTO [dbo].[Hrms_Company_Designations_Master] 
                ([CompanyId] ,[OfficeLocationId], [DepartmentCode] ,[SectionCode], [DesignationCode]
                , [DesignationName]) VALUES 
                ('{companyDesignation["companyId"]}', '{companyDesignation["locationId"]}',
                '{companyDesignation["departmentCode"]}', '{companyDesignation["sectionCode"]}',
                '{companyDesignation["designationCode"]}', '{companyDesignation["designationName"]}')";

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

        public void Update(IDictionary<string, string> companyDesignation)
        {
            _conn.Open();
            string sqlQuery = $@"UPDATE [dbo].[Hrms_Company_Designations_Master] Set CompanyId = '{companyDesignation["companyId"]}',
                               OfficeLocationId = '{companyDesignation["locationId"]}', DepartmentCode = '{companyDesignation["departmentCode"]}',
                               SectionCode = '{companyDesignation["sectionCode"]}',  DesignationName = '{companyDesignation["designationName"]}' 
                               WHERE DesignationCode = '{companyDesignation["designationCode"]}'";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
    }
}