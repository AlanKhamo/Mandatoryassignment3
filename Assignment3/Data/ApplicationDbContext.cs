using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment3.Models;

namespace Assignment3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<Assignment3.Models.Reservation> Reservation { get; set; } = default!;
        public DbSet<Assignment3.Models.CheckInd> CheckInd { get; set; } = default!;

        public DbSet<Kitchen> Kitchen { get; set; } = default!;

        

        
    }
}