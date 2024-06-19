using Microsoft.EntityFrameworkCore;

namespace Project_HotelManagement
{
    public class RepositoryPayment : RepositoryBase<Payments>
    {
        private readonly HotelManagementDbContext _context;
        public RepositoryPayment(HotelManagementDbContext context) 
        {   
            _context = context;
            Items = _context.Payments.ToList();
        }

        public List<Payments> GetAllFromDatabase()
        {
            var result = _context.Payments.ToList();
            return result;
        }

        public Payments GetByIdFromDatabase(int id)
        {
            return _context.Payments.FirstOrDefault(u => u.payment_id == id);
        }

        public ResponseDto AddToDatabase(Payments payments)
        {

            if (_context.Payments.FirstOrDefault(i => i.payment_id == payments.payment_id) != null)
            {
                return new ResponseDto("Existed Payment", 1);
            }
            _context.Payments.Add(payments);
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
            return new ResponseDto("Success", 0, payments);
        }

        public int GetCount()
        {
            var result = _context.Payments.ToList().Count;
            return result;
        }
    }
}
