using System.ComponentModel.DataAnnotations;

namespace HRIS.Web.Models
{
    public class EmployeeLeaveModel : IModel<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid LeaveTypeId { get; set; }
        public DateTime LeaveDate { get; set; }
        public string? Remarks { get; set; }
    }
}
