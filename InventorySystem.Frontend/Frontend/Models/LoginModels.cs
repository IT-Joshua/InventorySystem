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

    public class RegisterResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class LoginCredentials
    {
        public required string UsernameOrEmail {get; set;}
        public required string Password {get; set;}
    }

    public class LoginResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public Tokens? Tokens { get; set; }
    }

    public class UserCredentials{
        public required string FirstName {get;set;}
        public required string LastName {get;set;}
        public required string Email {get;set;}
    }

    public class Tokens
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }

    }
}