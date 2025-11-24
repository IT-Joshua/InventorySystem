using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Components.Models
{

    public class LoginCredentialsModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LogInModels
    {

        // public string? Firstname { get; set; }
        // public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        // public string? Access { get; set; }
        // public bool Status { get; set; }
    }

    public class CreateAccountModels
    {

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        // public string? Access { get; set; }
        // public bool Status { get; set; }
    }

    public class CreateAccountCredentialsModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}