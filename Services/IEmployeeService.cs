using PhoneDirectory.Models;

namespace PhoneDirectory.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId);
        Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchText);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(int id, Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
