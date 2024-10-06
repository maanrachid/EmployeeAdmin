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


        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeByID(Guid id)
        {
            var emp = _appDbContext.employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            } else
            {
                return Ok(emp);
            }
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

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, EmployeeDT empdt)
        {
            var emp = _appDbContext.employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }else
            {
                emp.Name = empdt.Name;
                emp.Email = empdt.Email;
                emp.Phone = empdt.Phone;
                emp.Salary = empdt.Salary;
                _appDbContext.SaveChanges();
            }

            return Ok(emp);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var emp = _appDbContext.employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }else
            {
                _appDbContext.employees.Remove(emp);
                _appDbContext.SaveChanges();
            }
            return Ok(emp);
        }

    }
}
