﻿using System.ComponentModel.DataAnnotations;

namespace API_Project.Models
{
    public class RegisterDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        [StringLength(8,MinimumLength =4)]
        public string password { get; set; }    
    }
}
