using Microsoft.AspNetCore.Mvc;
using Model.DBContext;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Model.Repository;
using Service1.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var listEmployees =  await _employeeService.GetAllEmployee().ConfigureAwait(false);
            return Ok(listEmployees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _employeeService.CreateEmployee(employee).ConfigureAwait(false);
            if (result == null) return BadRequest();
            return Ok(employee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employeeService.UpdateEmployee(employee).ConfigureAwait(false);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
