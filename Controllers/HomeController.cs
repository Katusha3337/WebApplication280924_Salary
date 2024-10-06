using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication280924_Salary.Models;

namespace WebApplication280924_Salary.Controllers
{
    public class HomeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FullName = "Иван Иванов", Salary = 50000 },
            new Employee { Id = 2, FullName = "Петр Петров", Salary = 60000 },
            new Employee { Id = 3, FullName = "Сергей Сергеев", Salary = 55000 }
        };

        public IActionResult Index()
        {
            return View(employees);
        }

        [HttpPost]
        public IActionResult UpdateSalaries(List<Employee> updatedEmployees)
        {
            foreach (var updatedEmployee in updatedEmployees)
            {
                var employee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
                if (employee != null)
                {
                    employee.Salary = updatedEmployee.Salary;
                }
            }
            return RedirectToAction("Index");
        }

    }
}
