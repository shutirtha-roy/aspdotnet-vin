using System.ComponentModel.DataAnnotations;

namespace HRIS.Web.Models
{
    public class LeaveTypeModel : IModel<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Title { get; set; }
    }
}
