using System;
using System.ComponentModel.DataAnnotations;

namespace TrackerApp.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty; // In a real app: store hash, not plain text

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public bool IsBusinessProfile { get; set; } = false;
    }
}