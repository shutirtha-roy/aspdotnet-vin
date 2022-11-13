using EmployeeAttendance.Infrastructure.DbContexts;
using EmployeeAttendance.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Infrastructure.Repositories
{
    public class AttendanceRepository : Repository<AttendanceEntity, Guid>, IAttendanceRepository
    {

        public AttendanceRepository(ITrainingDbContext context) : base((DbContext)context)
        {
        }

    }
}