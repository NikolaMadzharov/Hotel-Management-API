namespace Hotel_Management_Software.DAL.Repositories;

using aspnetcore.ntier.DAL.Repositories;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DataAccess.DataContext;

public class RoomRepository : GenericRepository<Room>, IRoomRepository
{
    private readonly ContextDB _dbContext;

    public RoomRepository(ContextDB context) : base(context)
    {
        _dbContext = context;
    }
}
