namespace Hotel_Management_Software.BussinessLogic;

using Hotel_Management_Software.BBL.Services;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;
using Hotel_Management_Software.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public static class DepedencyInjection
{

    public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddAutoMapper(typeof(UserProfile));
        services.AddAutoMapper(typeof(HotelProfile));
        services.AddAutoMapper(typeof(RoomProfile));
        services.AddAutoMapper(typeof(ImageProfile));
        services.AddAutoMapper(typeof(GuestProfile));
        services.AddAutoMapper(typeof(ReservationProfile));
        services.AddAutoMapper(typeof(EmployeeProfile));
        services.AddAutoMapper(typeof(SalaryReportProfile));

        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IFloorService, FloorService>();
        services.AddScoped<IFileStorageService, CloudinaryService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ISalaryReportService, SalaryReportService>();

        services.AddScoped<ILogger, Logger<Floor>>();
    }
}

