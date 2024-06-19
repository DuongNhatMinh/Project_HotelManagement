using Microsoft.EntityFrameworkCore;

namespace Project_HotelManagement
{
    public class RepositoryServices : RepositoryBase<Services>
    {
        private readonly HotelManagementDbContext _context;
        public RepositoryServices(HotelManagementDbContext context) 
        {
            _context = context;
            Items = _context.Services.ToList();
        }

        public List<Services> GetAllFromDatabase()
        {
            var result = _context.Services.ToList();
            return result;
        }

        public Services GetByIdFromDatabase(int id)
        {
            return _context.Services.FirstOrDefault(u => u.service_id == id);
        }

        public ResponseDto AddToDatabase(Services services)
        {

            if (_context.Services.FirstOrDefault(i => i.service_id == services.service_id) != null)
            {
                return new ResponseDto("Existed Service", 1);
            }
            _context.Services.Add(services);
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
            return new ResponseDto("Success", 0, services);
        }

        public ResponseDto UpdateCustomerFromDatabase(int id, UpdateServicesRequest service)
        {
            var existingService = GetByIdFromDatabase(id);
            if (existingService != null)
            {
                existingService.name = service.name;
                existingService.name = service.name;
                _context.SaveChanges();
                return new ResponseDto("Success", 0);
            }
            return new ResponseDto("Not found service", 3, existingService);
        }

        public int GetCount()
        {
            var result = _context.Customers.ToList().Count;
            return result;
        }
    }
}
