using Microsoft.EntityFrameworkCore;

namespace Project_HotelManagement
{
    public class RepositoryBookings : RepositoryBase<Bookings>
    {
        private readonly HotelManagementDbContext _context;
        public RepositoryBookings(HotelManagementDbContext context)
        {
            _context = context;
            Items = _context.Bookings.ToList();
        }

        public Bookings GetByIdFromDatabase(int id)
        {
            return _context.Bookings.FirstOrDefault(u => u.booking_id == id);
        }
        public ResponseDto AddToDatabase(Bookings booking)
        {
            if (_context.Bookings.FirstOrDefault(i => i.room_id == booking.room_id) != null)
            {
                return new ResponseDto("Existed Booking", 1);
            }
            _context.Bookings.Add(booking);
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
            return new ResponseDto("Success", 0, booking);
        }

        public ResponseDto DeleteFromDatabase(int id)
        {
            var booking = GetByIdFromDatabase(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
                return new ResponseDto("Success", 0);
            }
            else
            {
                return new ResponseDto("Not found booking", 2);
            }
        }

        public int GetCount()
        {
            var result = _context.Bookings.ToList().Count;
            return result;
        }

        public ResponseDto UpdateBookingFromDatabase(int id, UpdateBookingRequest booking)
        {
            var existingBooking = GetByIdFromDatabase(id);
            if (existingBooking != null)
            {
                existingBooking.room_id = booking.room_id;
                existingBooking.check_in_date = booking.check_in_date;
                existingBooking.check_out_date = booking.check_out_date;
                _context.SaveChanges();
                return new ResponseDto("Success", 0);
            }
            return new ResponseDto("Not found booking", 3, existingBooking);
        }
    }
}
