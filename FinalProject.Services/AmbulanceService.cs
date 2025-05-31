using System;
using System.Collections.Generic;
using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Service.Contract;
using FinalProject.Shared;
using FinalProject.Entities.Models;

namespace FinalProject.Services
{
    /// <summary>
    /// Service class for managing ambulance-related operations.
    /// </summary>
    public class AmbulanceService : IAmbulanceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="AmbulanceService"/> class.
        /// </summary>
        /// <param name="repositoryManager">The repository manager.</param>
        /// <param name="mapper">The mapper.</param>
        public AmbulanceService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all ambulances, optionally tracking changes.
        /// </summary>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>A collection of AmbulanceDto objects.</returns>
        public IEnumerable<AmbulanceDto> GetAllAmbulances(bool trackChanges)
        {
            var ambulances = _repositoryManager.Ambulance.GetAllAmbulances(trackChanges);
            return _mapper.Map<IEnumerable<AmbulanceDto>>(ambulances);
        }

        /// <summary>
        /// Retrieves an ambulance by its ID, optionally tracking changes.
        /// </summary>
        /// <param name="id">The ID of the ambulance.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>An AmbulanceDto object.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the ambulance with the specified ID is not found.</exception>
        public AmbulanceDto GetAmbulanceById(Guid id, bool trackChanges)
        {
            var ambulance = _repositoryManager.Ambulance.GetAmbulanceById(id, trackChanges);
            if (ambulance == null)
                throw new KeyNotFoundException($"Ambulance with id {id} not found.");
            return _mapper.Map<AmbulanceDto>(ambulance);
        }

        /// <summary>
        /// Creates a new ambulance.
        /// </summary>
        /// <param name="ambulanceDto">The ambulance data transfer object.</param>
        public AmbulanceDto CreateAmbulance(AmbulanceDto dto)
        {
            // Check duplicates by VehicleNumber or MobileNumber
            var exists = _repositoryManager.Ambulance.Exists(a =>
                a.VehicleNumber == dto.VehicleNumber || a.MobileNumber == dto.MobileNumber);

            if (exists)
            {
                throw new ArgumentException("Ambulance with same Vehicle Number or Mobile Number already exists.");
            }

            var entity = _mapper.Map<Ambulance>(dto);
            _repositoryManager.Ambulance.CreateAmbulance(entity);
            _repositoryManager.Save();

            return _mapper.Map<AmbulanceDto>(entity);
        }



        /// <summary>
        /// Updates an existing ambulance.
        /// </summary>
        /// <param name="id">The ID of the ambulance.</param>
        /// <param name="ambulanceDto">The ambulance data transfer object.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the ambulance with the specified ID is not found.</exception>
        public void UpdateAmbulance(Guid id, AmbulanceDto ambulanceDto, bool trackChanges)
        {
            var ambulanceEntity = _repositoryManager.Ambulance.GetAmbulanceById(id, trackChanges);
            if (ambulanceEntity == null)
                throw new KeyNotFoundException($"Ambulance with id {id} not found.");

            // Map all except Id to avoid modifying PK
            ambulanceEntity.DriverName = ambulanceDto.DriverName;
            ambulanceEntity.MobileNumber = ambulanceDto.MobileNumber;
            ambulanceEntity.VehicleType = Enum.TryParse(ambulanceDto.VehicleType, out VehicleType vt) ? vt : ambulanceEntity.VehicleType;

            _repositoryManager.Ambulance.UpdateAmbulance(ambulanceEntity);
            _repositoryManager.Save();
        }

        /// <summary>
        /// Deletes an ambulance by its ID.
        /// </summary>
        /// <param name="id">The ID of the ambulance.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the ambulance with the specified ID is not found.</exception>
        public void DeleteAmbulance(Guid id, bool trackChanges)
        {
            var ambulanceEntity = _repositoryManager.Ambulance.GetAmbulanceById(id, trackChanges);
            if (ambulanceEntity == null)
                throw new KeyNotFoundException($"Ambulance with id {id} not found.");

            _repositoryManager.Ambulance.DeleteAmbulance(ambulanceEntity);
            _repositoryManager.Save();
        }

       
    }
}

