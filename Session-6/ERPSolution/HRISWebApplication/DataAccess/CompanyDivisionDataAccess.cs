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
    }
}