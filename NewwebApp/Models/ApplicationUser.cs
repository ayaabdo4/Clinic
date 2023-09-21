using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewwebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public int Numbber { get; set; }

       

       

        [NotMapped]
        public Collection<Appointment> AppointmentSlots { get; set; }

        


    }
}

namespace NewwebApp
{
    public enum Gender
    {
        Male , Female
    }
}