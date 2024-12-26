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
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetAllEmployeesAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        // Add a new employee
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeInfo employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid employee data.");
            }

            var result = await _employeeRepository.AddEmployeeAsync(employee);
            
            //if (result != null)
            if (result > 0)
            {
                // var res = CreatedAtAction(nameof(GetEmployeeById), new { empId = result }, employee);
                return Ok(new { message = "Employee inserted successfully." });
            }

            return StatusCode(500, "Error occurred while adding the employee.");
        }
        // Update an existing employee
        [HttpPut("{empId}")]
        public async Task<ActionResult> UpdateEmployee(int empId, [FromBody] EmployeeInfo employee)
        {
            if (employee == null || empId != employee.EmpID)
            {
                return BadRequest(new { message = "Invalid employee data." });
            }

            var result = await _employeeRepository.UpdateEmployeeAsync(employee);

            if (result == -1)
            {
                return Ok(new { message = "Employee updated successfully." });
            }

            return NotFound(new { message = "Employee not found." });
        }
        // Delete an employee
        [HttpDelete("{empId}")]
        public async Task<ActionResult> DeleteEmployee(int empId)
        {
            var result = await _employeeRepository.DeleteEmployeeAsync(empId);

            if (result == -1)
            {
                return Ok(new { message = "Employee deleted successfully." });
            }

            return NotFound(new { message = "Employee not found." });
        }
    }
}
