namespace Hotel_Management_Software.BBL.Services;

using AutoMapper;
using Hotel_Management_Software.BBL.Exceptions;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.SalaryReport;

public class SalaryReportService : ISalaryReportService
{
    private readonly ISalaryReportRepository _salaryReportRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public SalaryReportService(ISalaryReportRepository salaryReportRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _salaryReportRepository = salaryReportRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<bool> AddAsync(AddSalaryReportDTO addSalaryReportDTO)
    {
        var employee = await _userRepository.GetAsync(x => x.Id == addSalaryReportDTO.EmployeeId.ToString());

        if (employee is null)
        {
            throw new CustomException("Invalid employee!", 400);


        }

        var salaryReportDTO = _mapper.Map<SalaryReport>(addSalaryReportDTO);

        salaryReportDTO.Salary = (decimal)employee.Salary; 

        await _salaryReportRepository.AddAsync(salaryReportDTO);

        employee.SalaryReports.Add(salaryReportDTO);

        return true;
    }
}
