using PhoneDirectory.Models;

namespace PhoneDirectory.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId);
        Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchText);
        Task AddEmployeeAsync(Employee employeeDto);
        Task UpdateEmployeeAsync(int id, Employee employeeDto);
        Task DeleteEmployeeAsync(int id);
    }
}
