using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class CompanyDepartmentDataAccess : DataAccess
    {
        public CompanyDepartmentDataAccess()
        {

        }
        public DataTable GetAllCompanyDepartmentInformation()
        {
            _conn.Open();
            string sqlQuery = @"SELECT [CompanyId], [OfficeLocationId], [DepartmentCode], 
                [DepartmentName], [DepartmentLocation], [HeadOfDepartment], [SubstituteHeadOfDepartment]
                FROM [dbo].[Hrms_Company_Department_Master]";
            SqlCommand cmd = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            _conn.Close();
            return dataTable;
        }

        public void Save(IDictionary<string, string> companyDepartment)
        {
            _conn.Open();

            if (companyDepartment["companyId"] == "-1")
            {
                string companyExceptionMessage = "Company Id not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else if (companyDepartment["locationId"] == "-1")
            {
                string companyExceptionMessage = "Office Location Id not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else if (companyDepartment["departmentCode"] == "-1" || companyDepartment["departmentCode"] == "")
            {
                string companyExceptionMessage = "Department Code not selected";
                HttpContext.Current.Response.Write($"<script>alert('{companyExceptionMessage}')</script>");
            }
            else
            {
                string sqlQuery = $@"INSERT INTO [dbo].[Hrms_Company_Department_Master] 
                ([CompanyId] ,[OfficeLocationId], [DepartmentCode] ,[DepartmentName]
                , [DepartmentLocation], [HeadOfDepartment] ,[SubstituteHeadOfDepartment]) VALUES 
                ('{companyDepartment["companyId"]}', '{companyDepartment["locationId"]}',
                '{companyDepartment["departmentCode"]}', '{companyDepartment["departmentName"]}',
                '{companyDepartment["departmentLocation"]}', '{companyDepartment["headOfDepartment"]}',
                '{companyDepartment["substituteHeadOfDepartment"]}')";

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

        public void DeleteRow<T>(T departmentCode)
        {
            _conn.Open();
            string sqlQuery = $"DELETE FROM [dbo].[Hrms_Company_Department_Master] WHERE DepartmentCode='{departmentCode}'";

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

        

        public void Update(IDictionary<string, string> companyDepartment)
        {
            _conn.Open();
            string sqlQuery = $@"UPDATE [dbo].[Hrms_Company_Department_Master] Set CompanyId = '{companyDepartment["companyId"]}',
                               OfficeLocationId = '{companyDepartment["locationId"]}', DepartmentName = '{companyDepartment["departmentName"]}',
                               DepartmentLocation = '{companyDepartment["departmentLocation"]}', HeadOfDepartment = '{companyDepartment["headOfDepartment"]}',
                               SubstituteHeadOfDepartment = '{companyDepartment["substituteHeadOfDepartment"]}' WHERE DepartmentCode = '{companyDepartment["departmentCode"]}'";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }

        
    }
}