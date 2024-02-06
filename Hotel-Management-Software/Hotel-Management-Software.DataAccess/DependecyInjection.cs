
namespace Hotel_Management_Software.DataAccess;

using Hotel_Management_Software.DataAccess.DataContext;
using Hotel_Management_Software.DataAccess.Repositories;
using Hotel_Management_Software.DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



public static class DependecyInjection
{
    public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<ContextDB>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        });

       services.AddScoped<IHotelRepository, HotelRepository>();
    }
}
