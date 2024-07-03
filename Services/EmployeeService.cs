using PhoneDirectory.Models;
using PhoneDirectory.Repositories;

namespace PhoneDirectory.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return _employeeRepository.GetEmployeesAsync();
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            return _employeeRepository.GetEmployeesByDepartmentAsync(departmentId);
        }

        public Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchText)
        {
            return _employeeRepository.SearchEmployeesAsync(searchText);
        }

        public Task AddEmployeeAsync(Employee employeeDto)
        {
            return _employeeRepository.AddEmployeeAsync(employeeDto);
        }

        public Task UpdateEmployeeAsync(int id, Employee employeeDto)
        {
            return _employeeRepository.UpdateEmployeeAsync(id, employeeDto);
        }

        public Task DeleteEmployeeAsync(int id)
        {
            return _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
