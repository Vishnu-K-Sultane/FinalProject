using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.UI.Controllers
{

    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Department
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments(trackChanges: false);
            return View(departments);
        }

        // GET: Department/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var department = _departmentService.GetDepartmentById(id, trackChanges: false);
                return View(department);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: Department/Create
        public IActionResult CreateDepartment()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDepartment(DepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                _departmentService.CreateDepartment(departmentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(departmentDto);
        }

        // GET: Department/Edit/5
        public IActionResult EditDepartment(int id)
        {
            try
            {
                var department = _departmentService.GetDepartmentById(id, trackChanges: false);
                return View(department);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDepartment(DepartmentDto departmentDto)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentService.UpdateDepartment(departmentDto.DepartmentId, departmentDto,true);
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(departmentDto);
        }

        // GET: Department/Delete/5
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                var department = _departmentService.GetDepartmentById(id, trackChanges: false);
                return View(department);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("DeleteDepartment")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _departmentService.DeleteDepartment(id, trackChanges: false);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
