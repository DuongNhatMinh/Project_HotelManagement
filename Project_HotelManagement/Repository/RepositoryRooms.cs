using Microsoft.EntityFrameworkCore;

namespace Project_HotelManagement
{
    public class RepositoryRooms : RepositoryBase<Rooms>
    {
        private readonly HotelManagementDbContext _context;
        public RepositoryRooms(HotelManagementDbContext context) 
        { 
            _context = context;
            Items = _context.Rooms.ToList();
        }

        public Rooms GetByIdFromDatabase(int id)
        {
            return _context.Rooms.FirstOrDefault(u => u.room_id == id);
        }
        public ResponseDto AddToDatabase(Rooms room)
        {
            if (_context.Rooms.FirstOrDefault(i => i.room_id == room.room_id) != null)
            {
                return new ResponseDto("Existed Room", 1);
            }
            _context.Rooms.Add(room);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log the error (you can use a logging framework here)
                Console.WriteLine($"An error occurred while saving changes: {ex.InnerException?.Message}");
                // Rethrow or handle the exception as needed
                throw;
            }
            return new ResponseDto("Success", 0, room);
        }

        public List<Rooms> GetAllFromDatabase()
        {
            var result = _context.Rooms.ToList();
            return result;
        }

        public int GetCount()
        {
            var result = _context.Rooms.ToList().Count;
            return result;
        }

        public ResponseDto UpdateRoomFromDatabase(int id, UpdateRoomRequest room)
        {
            var existingRoom = GetByIdFromDatabase(id);
            if (existingRoom != null)
            {
                existingRoom.type = room.type;
                existingRoom.price = room.price;
                existingRoom.status = room.status;
                _context.SaveChanges();
                return new ResponseDto("Success", 0);
            }
            return new ResponseDto("Not found Room", 3, existingRoom);
        }
    }
}
