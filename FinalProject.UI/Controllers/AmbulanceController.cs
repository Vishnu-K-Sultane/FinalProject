using FinalProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.UI.Controllers
{
    public class AmbulanceController : Controller
    {
        // Temporary in-memory store (replace with DB or service)
        private static List<Ambulance> _ambulances = new List<Ambulance>();

        public IActionResult Index()
        {
            return View(_ambulances);
        }

        public IActionResult Details(Guid id)
        {
            var ambulance = _ambulances.FirstOrDefault(a => a.AmbulanceId == id);
            if (ambulance == null) return NotFound();
            return View(ambulance);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ambulance ambulance)
        {
            if (ModelState.IsValid)
            {
                ambulance.AmbulanceId = Guid.NewGuid();
                _ambulances.Add(ambulance);
                return RedirectToAction(nameof(Index));
            }
            return View(ambulance);
        }

        public IActionResult Edit(Guid id)
        {
            var ambulance = _ambulances.FirstOrDefault(a => a.AmbulanceId == id);
            if (ambulance == null) return NotFound();
            return View(ambulance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Ambulance updated)
        {
            var existing = _ambulances.FirstOrDefault(a => a.AmbulanceId == id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                existing.VehicleNumber = updated.VehicleNumber;
                existing.VehicleType = updated.VehicleType;
                existing.DriverName = updated.DriverName;
                existing.MobileNumber = updated.MobileNumber;
                return RedirectToAction(nameof(Index));
            }
            return View(updated);
        }

        public IActionResult Delete(Guid id)
        {
            var ambulance = _ambulances.FirstOrDefault(a => a.AmbulanceId == id);
            if (ambulance == null) return NotFound();
            return View(ambulance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var ambulance = _ambulances.FirstOrDefault(a => a.AmbulanceId == id);
            if (ambulance != null)
                _ambulances.Remove(ambulance);

            return RedirectToAction(nameof(Index));
        }
    }
}
