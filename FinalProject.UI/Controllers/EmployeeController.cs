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
            return View(employees);
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
        public IActionResult DeleteEmployee(Guid id)
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
        [HttpPost, ActionName("DeleteEmployee")]
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
