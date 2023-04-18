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
        public DbSet<Assignment3.Models.Reservation> Reservation { get; set; } = default!;
        public DbSet<Assignment3.Models.CheckInd> CheckInd { get; set; } = default!;

        public DbSet<Reservation> Reservations => Set<Reservation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationId);
            modelBuilder.Entity<CheckInd>()
                .HasKey(c => c.CheckIndId);
        }
    }
}