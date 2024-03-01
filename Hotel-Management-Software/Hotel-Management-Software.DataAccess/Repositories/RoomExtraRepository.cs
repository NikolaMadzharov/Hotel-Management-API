using aspnetcore.ntier.DAL.Repositories;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DataAccess.DataContext;

namespace Hotel_Management_Software.DAL.Repositories;

internal class RoomExtraRepository : GenericRepository<RoomExtra>, IRoomExtraRepository
{
    public RoomExtraRepository(ContextDB context) : base(context)
    {
    }
}
