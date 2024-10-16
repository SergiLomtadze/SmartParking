using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartParking.BusinessLogic;
using SmartParking.DataAccess.Entities;


namespace SmartParking.Persistence.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext<IdentityUser>(options), IApplicationDbContext
    {
        public DbSet<CarSize> CarSizes { get; set; }
        public DbSet<ParkingPlace> ParkingPlaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base OnModelCreating method to ensure Identity tables are configured
            base.OnModelCreating(modelBuilder);

            // Apply any custom configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}