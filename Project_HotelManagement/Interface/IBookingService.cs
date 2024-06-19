namespace Project_HotelManagement
{
    public interface IBookingService
    {
        ResponseDto AddToDatabase(Bookings booking);
        ResponseDto DeleteFromDatabase(int id);
        ResponseDto UpdateBookingFromDatabase(int id, UpdateBookingRequest booking);
        int GetCount();
    }
}
