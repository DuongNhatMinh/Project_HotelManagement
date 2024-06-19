namespace Project_HotelManagement
{
    public interface IRoomService
    {
        List<Rooms> GetAllFromDatabase();
        ResponseDto AddToDatabase(Rooms room);
        ResponseDto UpdateRoomFromDatabase(int id, UpdateRoomRequest room);
        int GetCount();
    }
}
