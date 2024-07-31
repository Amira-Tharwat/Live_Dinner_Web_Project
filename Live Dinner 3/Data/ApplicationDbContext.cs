using Live_Dinner_3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Live_Dinner_3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Chef> chefs { get; set; }
        public DbSet<Meal> meals { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<ContactMessage> contactMessages { get; set; }
		
	}
}
