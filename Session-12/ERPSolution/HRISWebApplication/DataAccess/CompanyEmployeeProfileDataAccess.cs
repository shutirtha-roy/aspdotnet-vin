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

            string storedProcedureName = "SP_GetAllEmployee";
            SqlCommand command = new SqlCommand(storedProcedureName, _conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            _conn.Close();
            return dataTable;
        }

        public void Save(IDictionary<string, string> companyEmployeeProfile)
        {
            _conn.Open();

            string storedProcedureName = "SP_AddEmployers";
            SqlCommand command = new SqlCommand(storedProcedureName, _conn);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CompanyId", companyEmployeeProfile["companyId"]);
            command.Parameters.AddWithValue("@OfficeLocationId", companyEmployeeProfile["locationId"]);
            command.Parameters.AddWithValue("@DepartmentCode", companyEmployeeProfile["departmentCode"]);
            command.Parameters.AddWithValue("@SectionCode", companyEmployeeProfile["sectionCode"]);
            command.Parameters.AddWithValue("@DesignationCode", companyEmployeeProfile["designationCode"]);
            command.Parameters.AddWithValue("@EmployeeProfileId", companyEmployeeProfile["employeeProfileId"]);
            command.Parameters.AddWithValue("@EmployeeName", companyEmployeeProfile["employeeName"]);
            command.Parameters.AddWithValue("@EmployeeSchool", companyEmployeeProfile["employeeSchool"]);
            command.Parameters.AddWithValue("@EmployeeUniversity", companyEmployeeProfile["employeeUniversity"]);
            command.Parameters.AddWithValue("@EmployeeFatherName", companyEmployeeProfile["employeeFatherName"]);
            command.Parameters.AddWithValue("@EmployeeMotherName", companyEmployeeProfile["employeeMotherName"]);
            command.Parameters.AddWithValue("@EmployeeAddress", companyEmployeeProfile["employeeAddress"]);

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