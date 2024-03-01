namespace Hotel_Management_Software.DataAccess;

using Hotel_Management_Software.DAL.Repositories;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DataAccess.DataContext;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependecyInjection
{
    public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<ContextDB>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            .UseLazyLoadingProxies();
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IFloorRepository, FloorRepository>();
    }
}
