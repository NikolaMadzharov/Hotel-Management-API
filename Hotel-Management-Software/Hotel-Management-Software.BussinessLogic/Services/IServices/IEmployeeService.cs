namespace Hotel_Management_Software.BBL.Services.IServices;

using Hotel_Management_Software.DTO.Employee;

public interface IEmployeeService
{
    Task<EmployeeDTO?> CreateAsync(AddEmployeeDTO addEmployeeDTO);

    Task<List<EmployeeDTO>?> GetAllByHotelAsync(Guid hotelId);

    Task<EmployeeDTO?> GetAnEmployeeById(Guid employeeId);

    Task<string?[]> GetEmployeeRolesAsync();

    Task<EmployeeDTO?> EditAsync(EditEmployeeDTO editEmployeeDTO);

    Task<EmployeeDTO?> ActivateAccount(Guid employeeId);
    Task<EmployeeDTO?> DeactivateAccount(Guid employeeId);
}
