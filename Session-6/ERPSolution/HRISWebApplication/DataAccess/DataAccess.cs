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
    public class DataAccess
    {
        protected readonly SqlConnection _conn;
        public DataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringHRIS"].ConnectionString);
        }
    }
}