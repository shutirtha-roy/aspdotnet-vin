﻿using HRIS.Web.Data;

namespace HRIS.Web.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ILeaveTypeRepository LeaveType { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            LeaveType = new LeaveTypeRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
