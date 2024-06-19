
using Microsoft.EntityFrameworkCore;

namespace Project_HotelManagement
{
    public class RoomService : IRoomService
    {
        private readonly RepositoryRooms repositoryRooms;
        public RoomService(HotelManagementDbContext context)
        {
            repositoryRooms = new RepositoryRooms(context);
        }
        public Rooms GetByIdFromDatabase(int id)
        {
            return repositoryRooms.GetByIdFromDatabase(id);
        }
        public ResponseDto AddToDatabase(Rooms room)
        {
            return repositoryRooms.AddToDatabase(room);
        }

        public List<Rooms> GetAllFromDatabase()
        {
            return repositoryRooms.GetAllFromDatabase();
        }

        public int GetCount()
        {
            return repositoryRooms.GetCount();
        }

        public ResponseDto UpdateRoomFromDatabase(int id, UpdateRoomRequest room)
        {
            return repositoryRooms.UpdateRoomFromDatabase(id, room);
        }
    }
}
