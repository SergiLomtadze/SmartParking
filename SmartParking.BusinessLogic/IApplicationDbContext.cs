using Microsoft.EntityFrameworkCore;
using SmartParking.DataAccess.Entities;

namespace SmartParking.BusinessLogic;

public interface IApplicationDbContext
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public DbSet<CarSize> CarSizes { get; set; }
    public DbSet<ParkingPlace> ParkingPlaces { get; set; }
    
}
