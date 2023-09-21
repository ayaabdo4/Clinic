using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewwebApp.Models;
using NewwebApp.ViewModel;

namespace NewwebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NewwebApp.ViewModel.UserViewmodel>? UserViewmodel { get; set; }
    }
}