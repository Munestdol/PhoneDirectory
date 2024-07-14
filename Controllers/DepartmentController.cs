using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Models;
using PhoneDirectory.Services;

namespace PhoneDirectory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment(Department department)
        {
            await _departmentService.AddDepartmentAsync(department);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest("Department ID mismatch");
            }

            await _departmentService.UpdateDepartmentAsync(id, department);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return Ok();
        }

        [HttpGet("{id}/subdepartments")]
        public async Task<ActionResult> GetSubDepartments(int id)
        {
            var subDepartments = await _departmentService.GetSubDepartmentsAsync(id);
            return Ok(subDepartments);
        }
    }
}
