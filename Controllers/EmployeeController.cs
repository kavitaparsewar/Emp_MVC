using Emp_MVC.Manager;
using Emp_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        Repository repository = new Repository();

        public IActionResult GetEmployee()
        {
            List<Employee> emplist = new List<Employee>();
            emplist = repository.GetAllEmployee().ToList();
            return View(emplist);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee([Bind] Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.AddEmployee(emp);
                    return RedirectToAction("GetEmployee");
                }
                return View(emp);
            }
            catch (Exception)
            {

                throw;
            }


        }
        [HttpGet]
        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = repository.GetAllEmployee().Where(e => e.Id == id).FirstOrDefault();

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult UpdateEmployee([Bind] Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.UpdateEmployee(emp);
                    return RedirectToAction("GetEmployee");
                }
                return View(emp);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            Employee employee = repository.GetAllEmployee().Where(e => e.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                repository.DeleteEmployee(id);
                return RedirectToAction("GetEmployee");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
