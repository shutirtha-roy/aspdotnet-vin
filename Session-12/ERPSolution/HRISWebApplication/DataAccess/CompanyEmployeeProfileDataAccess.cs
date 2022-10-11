using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class CompanyEmployeeProfileDataAccess : DataAccess
    {
        public CompanyEmployeeProfileDataAccess()
        {

        }

        public DataTable GetAllCompanyEmployeeProfile()
        {
            _conn.Open();
            string sqlQuery = @"SELECT [CompanyId], [OfficeLocationId], [DepartmentCode], [SectionCode], [DesignationCode], 
                                [EmployeeName], [EmployeeSchool], [EmployeeUniversity], 
                                [EmployeeFatherName], [EmployeeMotherName], [EmployeeAddress] FROM [dbo].[Hrms_Company_Employee_Profile]";
            SqlCommand cmd = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            _conn.Close();
            return dataTable;
        }

        public void Save(IDictionary<string, string> companyEmployeeProfile)
        {
            _conn.Open();

            string sqlQuery = $@"INSERT INTO [dbo].[Hrms_Company_Employee_Profile] 
                ([CompanyId] ,[OfficeLocationId], [DepartmentCode] ,[SectionCode], [DesignationCode]
                , [EmployeeProfileId], [EmployeeName],[EmployeeSchool],[EmployeeUniversity],[EmployeeFatherName],[EmployeeMotherName],[EmployeeAddress]) VALUES 
                ('{companyEmployeeProfile["companyId"]}', '{companyEmployeeProfile["locationId"]}',
                '{companyEmployeeProfile["departmentCode"]}', '{companyEmployeeProfile["sectionCode"]}',
                '{companyEmployeeProfile["designationCode"]}', '{companyEmployeeProfile["employeeProfileId"]}', 
                '{companyEmployeeProfile["employeeName"]}', '{companyEmployeeProfile["employeeSchool"]}'
                , '{companyEmployeeProfile["employeeUniversity"]}', '{companyEmployeeProfile["employeeFatherName"]}', 
                '{companyEmployeeProfile["employeeMotherName"]}', '{companyEmployeeProfile["employeeAddress"]}')";

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

            _conn.Close();
        }
    }
}