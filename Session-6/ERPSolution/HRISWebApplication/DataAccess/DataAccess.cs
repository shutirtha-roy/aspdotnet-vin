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
    public class DataAccess : IDataAccess
    {
        protected readonly SqlConnection _conn;
        public DataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringHRIS"].ConnectionString);
        }

        public virtual void DeleteRow(string officeLocationCode)
        {
            
        }

        public virtual void Save(IDictionary<string, string> companyDivisionDetails)
        {
            
        }

        public virtual void Update(IDictionary<string, string> companyDetails)
        {
            
        }
    }
}