using aspnetcore.ntier.DAL.Repositories;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DataAccess.DataContext;

namespace Hotel_Management_Software.DAL.Repositories;

public class ReservationRepository:GenericRepository<Reservation>, IReservationRepository
{

    private readonly ContextDB _dbContext;

    public ReservationRepository(ContextDB context) : base(context)
    {
        _dbContext = context;
    }
}
