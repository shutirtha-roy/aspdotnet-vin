using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Infrastructure.Services
{
    public interface IEmployeeService
    {
        dynamic GetAllEmployee();
        string GetEmployeeName(Guid id);
    }
}