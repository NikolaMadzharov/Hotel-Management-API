using aspnetcore.ntier.DAL.Repositories;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DataAccess.DataContext;

namespace Hotel_Management_Software.DAL.Repositories;

public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
{
    private readonly ContextDB _dbContext;

    public UserRepository(ContextDB dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
