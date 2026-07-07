using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.DTO.Request.Identity
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$&?!]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character (@#$&?!)")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Code must be 4 digits")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Code must contain numbers only")]
        public string Code { get; set; }
    }
}
