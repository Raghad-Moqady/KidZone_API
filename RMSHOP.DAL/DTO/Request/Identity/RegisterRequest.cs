using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.DTO.Request.Identity
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Full Name Is Required")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "UserName Is Required")]
        [MinLength(4, ErrorMessage = "username must be at least 4 characters")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+$", ErrorMessage = "Invalid UserName")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Phone Number Is Required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$&?!]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character (@#$&?!)")]
        public string Password { get; set; }

    }
}
