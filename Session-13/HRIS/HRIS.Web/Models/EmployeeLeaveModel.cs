using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRIS.Web.Models
{
    public class EmployeeLeaveModel : IModel<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string? EmployeeId { get; set; }
        [Required]
        [Display(Name = "LeaveTypeModel")]
        public Guid LeaveTypeId { get; set; }
        [ForeignKey("LeaveTypeId")]
        [ValidateNever]
        public LeaveTypeModel LeaveTypeModel { get; set; }
        public DateTime LeaveDate { get; set; }
        public string? Remarks { get; set; }
    }
}
