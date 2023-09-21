using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NewwebApp.ViewModel
{
    [Keyless]
    public class AddUserviewmodel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public Gender Gender { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "date of birth")]
        [Required]

        public DateTime DOB { get; set; }

        [Display(Name = "Number")]
        [Required]
        public int Numbber { get; set; }

       public List<RoleViewmodel> Roles { get; set; }

    }
}
