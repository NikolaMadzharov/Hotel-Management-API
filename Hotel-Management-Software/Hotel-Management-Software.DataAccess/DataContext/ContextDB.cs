
namespace Hotel_Management_Software.DataAccess.DataContext;
using Hotel_Management_Software.DAL;
using Microsoft.EntityFrameworkCore;




public class ContextDB:DbContext
{

    public ContextDB(DbContextOptions options) : base(options) { }

    public DbSet<Hotel> Hotels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
       

        base.OnModelCreating(builder);

    }
}
