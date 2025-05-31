using FinalProject.Contracts;
using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RepositoryContext _context; // Context for accessing the database

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public RoomRepository(RepositoryContext context)
        {
            _context = context; // Initializing the context through dependency injection
        }

        /// <summary>
        /// Retrieves all rooms, optionally tracking changes.
        /// </summary>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>A list of all rooms.</returns>
        public IEnumerable<Room> GetAllRooms(bool trackChanges) =>
            !trackChanges ? _context.Rooms.AsNoTracking().ToList() : _context.Rooms.ToList();

        /// <summary>
        /// Retrieves a room by its ID, optionally tracking changes.
        /// </summary>
        /// <param name="id">The ID of the room.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>The room with the specified ID, or null if not found.</returns>
        public Room? GetRoomById(int id, bool trackChanges) =>
            !trackChanges
                ? _context.Rooms.AsNoTracking().FirstOrDefault(r => r.RoomId == id)
                : _context.Rooms.FirstOrDefault(r => r.RoomId == id);

        /// <summary>
        /// Retrieves a room by its number, optionally tracking changes.
        /// </summary>
        /// <param name="roomNumber">The number of the room.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>The room with the specified number, or null if not found.</returns>
        public Room? GetRoomByNumber(string roomNumber, bool trackChanges) =>
            !trackChanges
                ? _context.Rooms.AsNoTracking().FirstOrDefault(r => r.RoomNumber == roomNumber)
                : _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

        /// <summary>
        /// Adds a new room to the database.
        /// </summary>
        /// <param name="room">The room to add.</param>
        public void CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
        }

        /// <summary>
        /// Updates an existing room in the database.
        /// </summary>
        /// <param name="room">The room to update.</param>
        public void UpdateRoom(Room room)
        {
            // No code here if using EF Core's tracked entities, 
            // update is done automatically after retrieving and modifying entity
        }

        /// <summary>
        /// Removes a room from the database.
        /// </summary>
        /// <param name="room">The room to remove.</param>
        public void DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
        }

        // Optional methods implementations if added to interface
    }
}