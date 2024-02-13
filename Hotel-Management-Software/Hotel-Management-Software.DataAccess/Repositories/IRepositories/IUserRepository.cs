using aspnetcore.ntier.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DAL.Entities.ApplicationUser;

namespace Hotel_Management_Software.DAL.Repositories.IRepositories;

public interface IUserRepository :IGenericRepository<ApplicationUser>
{

}
