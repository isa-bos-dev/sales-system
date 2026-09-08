using MyStore.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyStore.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public required string FullName { get; set; }

        [Required]
        public required string Email { get; set; }

        public string Type { get; set; }= UserTypes.Admin;

        [Required]
        public required string Password { get; set; }

        public bool ResetPassword { get; set; } = true;

        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    }
}
