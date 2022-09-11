using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISWebApplication.DataAccess
{
    public interface IDataAccess
    {
        void Save(IDictionary<string, string> companyDivisionDetails);
        void Update(IDictionary<string, string> companyDetails);
        void DeleteRow(string officeLocationCode);
    }
}
