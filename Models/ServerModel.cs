using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HPIMS_MVC_SignalR_Integrated.Models
{
    public class ServerModel
    {
        [DisplayName("ID")]
        public long Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public string ServerName { get; set; }

        [DisplayName("Type")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public string ServerType { get; set; }

        [DisplayName("Location")]
        [Required(ErrorMessage = "REQUIRED FIELD")]
        public string Location { get; set; }

        [DisplayName("Running Status")]
        public bool IsServerUp { get; set; }

        [DisplayName("User Status")]
        public bool IsUserLoggedIn { get; set; }

        [DisplayName("C-Drive Usage")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string DriveCUsage { get; set; }

        [DisplayName("E-Drive Usage")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string DriveEUsage { get; set; }

        [DisplayName("F-Drive Usage")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER NA FOR NULL VALUE")]
        public string DriveFUsage { get; set; }

        [DisplayName("Threshold Usage")]
        [Required(ErrorMessage = "REQUIRED FIELD. ENTER 0 FOR NULL VALUE")]
        public int ThresholdUsage { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}