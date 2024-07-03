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
        public async Task<ActionResult> AddDepartment(Department departmentDto)
        {
            await _departmentService.AddDepartmentAsync(departmentDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, Department departmentDto)
        {
            if (id != departmentDto.Id)
            {
                return BadRequest("Department ID mismatch");
            }

            await _departmentService.UpdateDepartmentAsync(id, departmentDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return Ok();
        }
    }
}
