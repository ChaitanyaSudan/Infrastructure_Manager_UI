using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HPIMS_MVC_SignalR_Integrated.Models
{
    public class ServerAppConfigurationModel
    {
        [DisplayName("ID")]
        public long Id { get; set; }

        [DisplayName("Server ID")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public long ServerId { get; set; }

        [DisplayName("APP Installed")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string APPInstalled { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}