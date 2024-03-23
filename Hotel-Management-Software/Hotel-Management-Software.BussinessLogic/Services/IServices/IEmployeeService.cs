namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DTO.Employee;

public interface IEmployeeService
{
    Task<EmployeeDTO?> CreateAsync(AddEmployeeDTO addEmployeeDTO);

    Task<List<EmployeeDTO>> GetAllByHotelAsync(Guid hotelId);

    Task<string[]> GetEmployeeRolesAsync();
}
