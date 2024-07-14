using PhoneDirectory.Models;
using PhoneDirectory.Repositories;

namespace PhoneDirectory.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _departmentRepository.GetDepartmentsAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _departmentRepository.AddDepartmentAsync(department);
        }

        public async Task UpdateDepartmentAsync(int id, Department department)
        {
            await _departmentRepository.UpdateDepartmentAsync(id, department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
        }

        public async Task<IEnumerable<Department>> GetSubDepartmentsAsync(int id)
        {
            return await _departmentRepository.GetSubDepartmentsAsync(id);
        }

    }
}
