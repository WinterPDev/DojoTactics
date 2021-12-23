using System.ComponentModel.DataAnnotations;

namespace DojoTactics.Models
{
    public class LoginUser
    {
        // [EmailAddress]
        // [Required(ErrorMessage = "Must Enter Email!")]
        // public string LEmail{get; set;}
        [Required]
        public string LUsername {get;set;}
        
        [Required(ErrorMessage = "Must Enter Password!")]
        [DataType(DataType.Password)]
        public string LPassword{get; set;}

    }
}