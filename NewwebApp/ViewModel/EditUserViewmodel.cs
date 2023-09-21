using System.ComponentModel.DataAnnotations;

namespace NewwebApp.ViewModel
{
    public class EditUserViewmodel
    {
      
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


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

        
    }
}
