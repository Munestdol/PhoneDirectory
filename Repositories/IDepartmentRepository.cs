using PhoneDirectory.Models;

namespace PhoneDirectory.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(Department departmentDto);
        Task UpdateDepartmentAsync(int id, Department departmentDto);
        Task DeleteDepartmentAsync(int id);
    }
}
