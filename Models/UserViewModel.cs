using System;
using System.ComponentModel.DataAnnotations;
namespace BankAccount.Models
{
    
    public class UserView
    {

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }

    }

    public class LoginView
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        [EmailAddress(ErrorMessage="Invalid Email")]
        public string LogEmail {get;set;}

        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string LogPassword{get;set;}
    }
}