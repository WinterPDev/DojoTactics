using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoTactics.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [MinLength(4,ErrorMessage = "Username must be at least 4 characters!")]
        public string Username {get;set;}
        
        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        public string Email {get;set;}

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Must enter a Password!")]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password {get;set;}

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords must Match!")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-zA-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password not accepted: Please include at least 1 Special Character, 1 Letter, and 1 Number")]
        public string Confirm {get;set;}

        public List<Social> FriendsList {get;set;}

        public List<Match> Matches {get;set;}
        
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}

