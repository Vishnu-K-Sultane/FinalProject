using FinalProject.Contracts;
using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly RepositoryContext _context; // Context for accessing the database

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PatientRepository(RepositoryContext context)
        {
            _context = context; // Initializing the context through dependency injection
        }

        /// <summary>
        /// Retrieves all patients, optionally tracking changes.
        /// </summary>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>A list of all patients.</returns>
        public IEnumerable<Patient> GetAllPatients(bool trackChanges) =>
            !trackChanges
                ? _context.Patients.AsNoTracking().ToList()
                : _context.Patients.ToList();

        /// <summary>
        /// Retrieves a patient by their ID, optionally tracking changes.
        /// </summary>
        /// <param name="id">The ID of the patient.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>The patient with the specified ID, or null if not found.</returns>
        public Patient? GetPatientById(Guid id, bool trackChanges) =>
            !trackChanges
                ? _context.Patients.AsNoTracking().FirstOrDefault(p => p.PatientId == id)
                : _context.Patients.FirstOrDefault(p => p.PatientId == id);

        /// <summary>
        /// Adds a new patient to the database.
        /// </summary>
        /// <param name="patient">The patient to add.</param>
        public void CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
        }

        /// <summary>
        /// Updates an existing patient in the database.
        /// </summary>
        /// <param name="patient">The patient to update.</param>
        public void UpdatePatient(Patient patient)
        {
            // No code required for EF Core tracking, but method must exist
            // Updates an existing patient in the database, handled automatically by EF Core
        }

        /// <summary>
        /// Removes a patient from the database.
        /// </summary>
        /// <param name="patient">The patient to remove.</param>
        public void DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        public Patient? FindByAadhar(string aadharId)
        {
            return _context.Patients.FirstOrDefault(p => p.AadharId == aadharId);
        }

        public Patient? FindByMobile(string mobileNumber)
        {
            return _context.Patients.FirstOrDefault(p => p.MobileNumber == mobileNumber);
        }

        public bool IsRoomOccupied(int roomId)
        {
            return _context.Patients.Any(p => p.roomId == roomId);
        }

    }
}