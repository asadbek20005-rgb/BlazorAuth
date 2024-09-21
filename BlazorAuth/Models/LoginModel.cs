using System.ComponentModel.DataAnnotations;

namespace BlazorAuth.Models
{
    public class LoginModel
    {
        [Required]
        public string Token { get; set; }
    
    }
}
