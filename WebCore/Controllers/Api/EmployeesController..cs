using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCore.Entities;
using WebCore.Models;
using WebCore.Repositories;

namespace WebCore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet()]
        public ICollection<Employee> Get([FromQuery] EmployeeSearch employeeSearch)
        {
            return employeeRepository.Search(employeeSearch);
        }
    }
}