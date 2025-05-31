using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Service.Contract;

namespace FinalProject.Services
{
    /// <summary>
    /// Service manager class for managing various services.
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAmbulanceService> _ambulanceService;
        private readonly Lazy<IPatientService> _patientService;
        private readonly Lazy<IRoomService> _roomService;
        private readonly Lazy<IDepartmentService> _deptSvc;
        private readonly Lazy<IEmployeeService> _empSvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager"/> class.
        /// </summary>
        /// <param name="repositoryManager">The repository manager.</param>
        /// <param name="mapper">The mapper.</param>
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerManager logger, IMapper mapper)
        {
            _ambulanceService = new Lazy<IAmbulanceService>(() => new AmbulanceService(repositoryManager, logger, mapper));
            _patientService = new Lazy<IPatientService>(() => new PatientService(repositoryManager,logger ,mapper));
            _roomService = new Lazy<IRoomService>(() => new RoomService(repositoryManager, logger, mapper));
            _deptSvc = new Lazy<IDepartmentService>(() => new DepartmentService(repositoryManager,logger, mapper));
            _empSvc = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger , mapper));
        }

        /// <summary>
        /// Gets the ambulance service.
        /// </summary>
        public IAmbulanceService AmbulanceService => _ambulanceService.Value;

        /// <summary>
        /// Gets the patient service.
        /// </summary>
        public IPatientService PatientService => _patientService.Value;

        /// <summary>
        /// Gets the room service.
        /// </summary>
        public IRoomService RoomService => _roomService.Value;

        /// <summary>
        /// Gets the department service.
        /// </summary>
        public IDepartmentService DepartmentService => _deptSvc.Value;

        /// <summary>
        /// Gets the employee service.
        /// </summary>
        public IEmployeeService EmployeeService => _empSvc.Value;
    }
}
