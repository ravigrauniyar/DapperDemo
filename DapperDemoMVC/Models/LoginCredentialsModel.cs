using System.ComponentModel.DataAnnotations;

namespace DapperDemoMVC.Models
{
    public class LoginCredentialsModel
    {
        [Key]
        [Required]
        public string username { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
