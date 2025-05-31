using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Entities.Models;
using FinalProject.Service.Contract;
using FinalProject.Shared;

namespace FinalProject.Services
{
    /// <summary>
    /// Service class for managing patient-related operations.
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientService"/> class.
        /// </summary>
        /// <param name="repositoryManager">The repository manager.</param>
        /// <param name="mapper">The mapper.</param>
        public PatientService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all patients, optionally tracking changes.
        /// </summary>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>A collection of PatientDto objects.</returns>
        public IEnumerable<PatientDto> GetAllPatients(bool trackChanges)
        {
            var patients = _repository.Patient.GetAllPatients(trackChanges);
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }

        /// <summary>
        /// Retrieves a patient by their ID, optionally tracking changes.
        /// </summary>
        /// <param name="id">The ID of the patient.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>A PatientDto object.</returns>
        public PatientDto GetPatientById(Guid id, bool trackChanges)
        {
            var patient = _repository.Patient.GetPatientById(id, trackChanges);
            return _mapper.Map<PatientDto>(patient);
        }

        /// <summary>
        /// Creates a new patient.
        /// </summary>
        /// <param name="patientDto">The patient data transfer object.</param>

        public PatientDto CreatePatient(PatientDto patientDto)
        {
            if (_repository.Patient.FindByAadhar(patientDto.AadharId) != null)
                throw new Exception("Aadhaar ID already registered");

            if (_repository.Patient.FindByMobile(patientDto.MobileNumber) != null)
                throw new Exception("Mobile number already registered");

            if (_repository.Patient.IsRoomOccupied(patientDto.RoomId))
                throw new Exception("Room is already occupied");

            var patient = _mapper.Map<Patient>(patientDto);
            patient.PatientId = Guid.NewGuid();

            _repository.Patient.CreatePatient(patient);
            _repository.Save();

            return _mapper.Map<PatientDto>(patient); // return created patient with new ID
        }





        /// <summary>
        /// Updates an existing patient.
        /// </summary>
        /// <param name="id">The ID of the patient.</param>
        /// <param name="patientDto">The patient data transfer object.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <exception cref="Exception">Thrown when the patient with the specified ID is not found.</exception>
        public void UpdatePatient(Guid id, PatientDto patientDto, bool trackChanges)
        {
            var patientEntity = _repository.Patient.GetPatientById(id, trackChanges);
            if (patientEntity == null) throw new Exception("Patient not found");

            _mapper.Map(patientDto, patientEntity);
            _repository.Save();
        }

        /// <summary>
        /// Deletes a patient by their ID.
        /// </summary>
        /// <param name="id">The ID of the patient.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <exception cref="Exception">Thrown when the patient with the specified ID is not found.</exception>
        public void DeletePatient(Guid id, bool trackChanges)
        {
            var patient = _repository.Patient.GetPatientById(id, trackChanges);
            if (patient == null) throw new Exception("Patient not found");

            _repository.Patient.DeletePatient(patient);
            _repository.Save();
        }

       
    }
}