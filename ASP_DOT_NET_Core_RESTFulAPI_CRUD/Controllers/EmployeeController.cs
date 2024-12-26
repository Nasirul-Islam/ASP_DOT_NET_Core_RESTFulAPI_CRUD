using ASP_DOT_NET_Core_RESTFulAPI_CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using static ASP_DOT_NET_Core_RESTFulAPI_CRUD.Models.EmployeesModel;

namespace ASP_DOT_NET_Core_RESTFulAPI_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployees([FromBody] EmployeeInfo employee)
        {
            var result = await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetProductById), new { id = employee.EmpID }, employee);
        }
    }
}
