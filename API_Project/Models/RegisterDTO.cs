using System.ComponentModel.DataAnnotations;

namespace API_Project.Models
{
    public class RegisterDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }    
    }
}
