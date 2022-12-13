using BLL.IService;
using BLL.Service;
using DTO.DTO;
using Entity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var AllEmployees = _employeeService.GetAllEmployees();
                if (AllEmployees == null)
                {
                    return NotFound();
                }
                List<EmployeeDto> employees = new List<EmployeeDto>();

                foreach (var employee in AllEmployees)
                {
                    EmployeeDto employeeDto = new EmployeeDto();
                    employeeDto.Id = employee.Id;
                    employeeDto.FirstName = employee.FirstName;
                    employeeDto.LastName = employee.LastName;
                    employeeDto.Salery = employee.Salery;
                    employeeDto.StartedDate = employee.StartedDate;
                    employeeDto.FinishDate = employee.FinishDate;
                    employeeDto.Role = employee.Role.RoleName;
                    employees.Add(employeeDto);
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                Employee employee = new Employee()
                {
                    Id = 0,
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    Salery = employeeDto.Salery,
                    StartedDate = employeeDto.StartedDate,
                    FinishDate = employeeDto.FinishDate,
                    
                    
                };

                if (employee.Id == null)
                    return BadRequest();

                _employeeService.AddEmployee(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id == null)
                    return NotFound();
                var employee = _employeeService.GetEmployeeById(id);
                EmployeeDto employeeDto = new EmployeeDto();
                employeeDto.Id = employee.Id;
                employeeDto.FirstName = employee.FirstName;
                employeeDto.LastName = employee.LastName;
                employeeDto.Salery = employee.Salery;
                employeeDto.StartedDate = employee.StartedDate;
                employeeDto.FinishDate = employee.FinishDate;
                employeeDto.Role = employee.Role.RoleName;

                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var savedemployee = GetById(employeeDto.Id);
                if (savedemployee == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                Employee employee = new Employee()
                {
                    Id = employeeDto.Id,
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    Salery = employeeDto.Salery,
                    StartedDate = employeeDto.StartedDate,
                    FinishDate = employeeDto.FinishDate,
                    
                };
                _employeeService.UpdateEmployee(employee);
                return Ok("Kayıt başarılı!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(EmployeeDto employeeDto)
        {
            try
            {
                var savedemployee = GetById(employeeDto.Id);
                if (savedemployee == NotFound())
                    return NotFound("Aradığınız değere ait kayıt bulunamadı!");
                Employee employee = new Employee()
                {
                    Id = employeeDto.Id,
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    Salery = employeeDto.Salery,
                    StartedDate = employeeDto.StartedDate,
                    FinishDate = employeeDto.FinishDate,
                };
                _employeeService.DeleteEmployee(employee);
                return Ok("Silme başarılı!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(500);
            }
        }
    }
}

