using Hotel_Management_Software.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hotel_Management_Software.DataAccess.DataContext
{
    public class ContextDB:DbContext
    {

        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }

    }
}
