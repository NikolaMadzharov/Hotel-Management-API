using aspnetcore.ntier.DAL.Repositories;
using aspnetcore.ntier.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DataAccess.DataContext;

namespace Hotel_Management_Software.DAL.Repositories;


public class SalaryReportRepository : GenericRepository<SalaryReport>, ISalaryReportRepository
{
    public SalaryReportRepository(ContextDB context) : base(context)
    {
    }
}
