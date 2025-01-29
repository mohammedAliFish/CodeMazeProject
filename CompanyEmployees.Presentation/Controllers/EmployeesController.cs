﻿

using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;


namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var employees = _service.EmployeeService.GetEmployees(companyId, trackChanges: false);
            return Ok(employees);
        }

        //[HttpGet("{id:guid}"  , Name = "GetEmployeeForCompany")]
        //public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        //{
        //    var employee = _service.EmployeeService.GetEmployee(companyId, id, trackChanges: false);
        //    return Ok(employee);
        //}
        [HttpGet("all-employees-with-companies")]
        public IActionResult GetAllEmployeesWithCompanyNames()
        {
            var employeesWithCompanyNames = _service.EmployeeService.GetAllEmployeesWithCompanyNames(trackChanges: false);

            if (employeesWithCompanyNames == null || !employeesWithCompanyNames.Any())
            {
                return NotFound("No employees found.");
            }

            return Ok(employeesWithCompanyNames);
        }

       



        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            _service.EmployeeService.DeleteEmployeeForCompany(companyId, id, trackChanges: false);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.EmployeeGuid },
                employeeToReturn);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
        {
            _service.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, compTrackChanges: false, empTrackChanges: true);
            return NoContent();
        }
    }
}
