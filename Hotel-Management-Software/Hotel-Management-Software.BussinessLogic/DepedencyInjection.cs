namespace Hotel_Management_Software.BussinessLogic;

using Hotel_Management_Software.BBL.Services;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.BussinessLogic.Services;
using Hotel_Management_Software.BussinessLogic.Services.IServices;
using Hotel_Management_Software.BussinessLogic.Utilities.AutoMapperProfiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



public static class DepedencyInjection
{

    public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddAutoMapper(typeof(HotelProfile));

        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IEmailService, EmailService>();

    }

}

