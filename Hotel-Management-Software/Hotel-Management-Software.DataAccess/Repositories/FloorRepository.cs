using aspnetcore.ntier.DAL.Repositories;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DataAccess.DataContext;

namespace Hotel_Management_Software.DAL.Repositories
{
    public class FloorRepository:GenericRepository<Floor>, IFloorRepository
    {
        private readonly ContextDB _dbContext;

        public FloorRepository(ContextDB context) : base(context)
        {
            _dbContext = context;
        }
    }
}
