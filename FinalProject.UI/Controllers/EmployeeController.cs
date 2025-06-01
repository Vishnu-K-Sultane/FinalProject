using FinalProject.Shared;
using FinalProject.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using FinalProject.Entities.Models;

namespace FinalProject.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService; // For loading departments on Create/Edit views

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        // GET: Employee
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees(false);
            var departments = _departmentService.GetAllDepartments(false);


            var employeeVMs = employees.Select(e => new Employee
            {
                EmployeeId = e.Id,
                Name = e.Name,
                EmailId = e.EmailId,
                MobileNumber = e.MobileNumber,
                Position = e.Position,
                DepartmentId = e.DepartmentId,
                Department = departments
         .Where(d => d.DepartmentId == e.DepartmentId)
         .Select(d => new Department
         {
             DepartmentId = d.DepartmentId,
             DeptName = d.DeptName,
             HODName = d.HODName,
             PhoneExtensionNo = d.PhoneExtensionNo
         })
         .FirstOrDefault()
            }).ToList();


            return View(employeeVMs);
        }

        // GET: Employee/Details/{id}
        public IActionResult Details(Guid id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id, trackChanges: false);
                return View(employee);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["Departments"] = _departmentService.GetAllDepartments(false);
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeService.CreateEmployee(employeeDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            ViewData["Departments"] = _departmentService.GetAllDepartments(false);
            return View(employeeDto);
        }

        // GET: Employee/Edit/{id}
        public IActionResult Edit(Guid id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id, trackChanges: false);
                ViewData["Departments"] = _departmentService.GetAllDepartments(false);
                return View(employee);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Employee/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _employeeService.UpdateEmployee(id, employeeDto, trackChanges: true);
                    return RedirectToAction(nameof(Index));
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            ViewData["Departments"] = _departmentService.GetAllDepartments(false);
            return View(employeeDto);
        }

        // GET: Employee/Delete/{id}
        public IActionResult Delete(Guid id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id, trackChanges: false);
                return View(employee);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Employee/DeleteConfirmed/{id}
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                _employeeService.DeleteEmployee(id, trackChanges: true);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
