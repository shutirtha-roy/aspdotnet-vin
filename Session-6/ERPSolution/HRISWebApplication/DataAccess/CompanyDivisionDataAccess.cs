using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HRISWebApplication.DataAccess
{
    public class CompanyDivisionDataAccess
    {
        private readonly SqlConnection _conn;

        public CompanyDivisionDataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringHRIS"].ConnectionString);
        }
    }
}