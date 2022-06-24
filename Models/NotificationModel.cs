using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HPIMS_MVC_SignalR_Integrated.Models
{
    public class NotificationModel
    {
        [DisplayName("ID")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public long Id { get; set; }

        [DisplayName("Type")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string Type { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string Subject { get; set; }

        [DisplayName("Message Body")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string MessageBody { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}