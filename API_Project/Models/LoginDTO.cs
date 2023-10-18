using System.ComponentModel.DataAnnotations;

namespace API_Project.Models
{
    public class LoginDTO
    {
        public string username { get; set; }
        public string password { get; set; }    
    }
}
