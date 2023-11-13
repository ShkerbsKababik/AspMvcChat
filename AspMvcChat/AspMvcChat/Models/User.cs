using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspMvcChat.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Login { get; set; } 
        public string? Password { get; set; }
    }
}
