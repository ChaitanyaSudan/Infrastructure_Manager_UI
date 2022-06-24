using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HPIMS_MVC_SignalR_Integrated.Models
{
    public class ProjectServerMappingModel
    {
        [DisplayName("ID")]
        public long Id { get; set; }

        [DisplayName("Server ID")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public long ServerId { get; set; }

        [DisplayName("Project ID")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public long ProjectId { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}