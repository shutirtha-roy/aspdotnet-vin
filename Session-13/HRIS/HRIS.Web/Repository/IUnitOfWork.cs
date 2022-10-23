namespace HRIS.Web.Repository
{
    public interface IUnitOfWork
    {
        ILeaveTypeRepository LeaveType { get; }
        void Save();
    }
}
