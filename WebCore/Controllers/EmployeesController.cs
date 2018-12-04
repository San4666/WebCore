using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebCore.Entities;
using WebCore.Filters;
using WebCore.Repositories;
using WebCore.ViewModels;

namespace WebCore.Controllers
{
    [ServiceFilter(typeof(EmployeeFormFilter))]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILanguageRepository languageRepository;

        public EmployeesController(
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            ILanguageRepository languageRepository)
        {
            this.employeeRepository = employeeRepository;
            this.departmentRepository = departmentRepository;
            this.languageRepository = languageRepository;
        }


        [HttpGet("/add")]
        public IActionResult Create()
        {
            return View(new EmployeeForm());
        }

        [HttpPost("/add")]
        public IActionResult Create(EmployeeForm employeeForm)
        {
            if (ModelState.IsValid)
            {
                var entity = new Employee();
                employeeForm.UpdateModel(entity);
                employeeRepository.Insert(entity);

                return RedirectToAction("List");
            }

            return View(employeeForm);
        }

        [HttpGet("/edit/{id}")]
        public IActionResult Update(int id)
        {
            var entity = GetEntity(id);
            var employeeForm = new EmployeeForm();
            employeeForm.LoadModel(entity);

            return View(employeeForm);
        }

        [HttpPost("/edit/{id}")]
        public IActionResult Update(int id, EmployeeForm employeeForm)
        {
            if (ModelState.IsValid)
            {
                var entity = GetEntity(id);
                employeeForm.UpdateModel(entity);
                employeeRepository.Update(entity);

                return RedirectToAction("List");
            }

            return View(employeeForm);
        }

        [HttpGet("/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var entity = GetEntity(id);
            employeeRepository.Delete(entity);

            return RedirectToAction("List");
        }

        [HttpGet("/")]
        public IActionResult List()
        {
            var employees = employeeRepository.All();
            foreach (var employee in employees)
            {
                employee.Department = departmentRepository.Find(employee.DepartmentId);
                employee.Language = languageRepository.Find(employee.LanguageId);
            }

            return View(employees);
        }

        private Employee GetEntity(int id)
        {
            var entity = employeeRepository.Find(id);
            if (entity == null)
            {
                throw new HttpListenerException(404, "HTTP/1.1 404 Not Found Employee");
            }

            return entity;
        }
    }
}