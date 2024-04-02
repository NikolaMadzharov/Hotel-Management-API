using AutoMapper;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DTO.Employee;
using Hotel_Management_Software.DTO.SalaryReport;

namespace Hotel_Management_Software.BBL.Utilities.AutoMapperProfiles;



public class SalaryReportProfile :Profile
{
    public SalaryReportProfile()
    {
        CreateMap<SalaryReport, AddSalaryReportDTO>().ReverseMap();

        CreateMap<SalaryReport, SalaryReportDTO>().ReverseMap();

    }
}
