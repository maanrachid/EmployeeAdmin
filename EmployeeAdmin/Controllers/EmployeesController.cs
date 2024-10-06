using EmployeeAdmin.Data;
using EmployeeAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdmin.Controllers
{
    // localhost/api/
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EmployeesController(AppDbContext appdb1) {
            this._appDbContext = appdb1;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var allemp = _appDbContext.employees.ToList();
            return Ok(allemp);
        }


        [HttpPost]
        public IActionResult AddEmployee(EmployeeDT e)
        {
            var employeeVar = new Employee()
            {
                Name = e.Name,
                Email = e.Email,
                Phone = e.Phone,
                Salary = e.Salary
            };

            _appDbContext.employees.Add(employeeVar);
            _appDbContext.SaveChanges();
            return Ok(employeeVar);


        }
    }
}
