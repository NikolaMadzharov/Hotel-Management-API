namespace Hotel_Management_Software.DataAccess.DataContext;

using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


public class ContextDB : IdentityDbContext<ApplicationUser>
{

    public ContextDB(DbContextOptions options) : base(options) { }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<RoomExtra> RoomExtras { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<SalaryReport> SalaryReports { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
