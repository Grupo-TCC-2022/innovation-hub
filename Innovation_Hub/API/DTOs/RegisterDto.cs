using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime Birthday { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Select at least one interest area"), MinLength(1, ErrorMessage = "Select at least one interest area")]
        public string[] InterestAreas { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}