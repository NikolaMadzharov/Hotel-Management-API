namespace Hotel_Management_Software.DataAccess.Repositories;
using aspnetcore.ntier.DAL.Repositories;
using Hotel_Management_Software.DataAccess.DataContext;
using Hotel_Management_Software.DataAccess.Entities;
using Hotel_Management_Software.DataAccess.Repositories.IRepositories;



public class HotelRepository:GenericRepository<Hotel>, IHotelRepository
{
    private readonly ContextDB _context;
    public HotelRepository(ContextDB context) : base(context)
    {
        _context = context;
    }

}
