using PhoneDirectory.Models;

namespace PhoneDirectory.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(int id, Department department);
        Task DeleteDepartmentAsync(int id);
        Task<IEnumerable<Department>> GetSubDepartmentsAsync(int id);
    }
}
