using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HPIMS_MVC_SignalR_Integrated.Models
{
    public class NotificationMappingModel
    {
        [DisplayName("ID")]
        public long Id { get; set; }

        [DisplayName("Server ID")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public long ServerId { get; set; }

        [DisplayName("Project ID")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public long ProjectId { get; set; }

        [DisplayName("Notification ID")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public long NotificationId { get; set; }

        [DisplayName("To-Address")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public string ToAddress { get; set; }

        [DisplayName("CC-Address")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string CCAddress { get; set; }

        [DisplayName("BCC-Address")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string BCCAddress { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}