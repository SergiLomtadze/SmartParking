using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartParking.BusinessLogic;
using SmartParking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace SmartParking.Persistence;

public static class PersistenceServiceExtensions
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>((s, option) =>
            option.UseSqlServer(s.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
    }
}
