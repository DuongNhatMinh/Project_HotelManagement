using Microsoft.EntityFrameworkCore;

namespace Project_HotelManagement
{
    public class BookingsService : IBookingService
    {
        private readonly RepositoryBookings repositoryBookings;
        public BookingsService(HotelManagementDbContext context)
        {
            repositoryBookings = new RepositoryBookings(context);  
        }
        public Bookings GetByIdFromDatabase(int id)
        {
            return repositoryBookings.GetByIdFromDatabase(id);
        }
        public ResponseDto AddToDatabase(Bookings booking)
        {
            return repositoryBookings.AddToDatabase(booking);
        }

        public ResponseDto DeleteFromDatabase(int id)
        {
            return repositoryBookings.DeleteFromDatabase(id);
        }

        public int GetCount()
        {
            return repositoryBookings.GetCount();
        }

        public ResponseDto UpdateBookingFromDatabase(int id, UpdateBookingRequest booking)
        {
            return repositoryBookings.UpdateBookingFromDatabase(id, booking);
        }
    }
}
