using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HPIMS_MVC_SignalR_Integrated.Models
{
    public class ProjectModel
    {
        [DisplayName("ID")]
        public long Id { get; set; }

        [DisplayName("Project Name")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string ProjectName { get; set; }

        [DisplayName("Version")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string Version { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string Status { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}