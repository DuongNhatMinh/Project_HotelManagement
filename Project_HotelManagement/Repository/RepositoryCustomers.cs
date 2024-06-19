using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Project_HotelManagement
{
    public class RepositoryCustomers : RepositoryBase<Customers>
    {
        private readonly HotelManagementDbContext _context;
        public RepositoryCustomers(HotelManagementDbContext context) 
        {
            _context = context;
            Items = _context.Customers.ToList();
        }

        public List<Customers> GetAllFromDatabase()
        {
            var result = _context.Customers.ToList();
            return result;
        }

        public Customers GetByIdFromDatabase(int id)
        {
            return _context.Customers.FirstOrDefault(u => u.customer_id == id);
        }

        public ResponseDto AddToDatabase(Customers customer)
        {

            if (_context.Customers.FirstOrDefault(i => i.email == customer.email) != null)
            {
                return new ResponseDto("Existed Customer", 1);
            }
            _context.Customers.Add(customer);
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
            return new ResponseDto("Success", 0, customer);
        }

        public ResponseDto DeleteFromDatabase(int id)
        {
            var customer = GetByIdFromDatabase(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return new ResponseDto("Success", 0);
            }
            else
            {
                return new ResponseDto("Not found customer", 2);
            }
        }

        public ResponseDto UpdateCustomerFromDatabase(int id, UpdateCustomerRequest user)
        {
            var existingCustomer = GetByIdFromDatabase(id);
            if (existingCustomer != null)
            {
                existingCustomer.address = user.Address;
                existingCustomer.phone_number = user.Phone;
                existingCustomer.email = user.Email;
                _context.SaveChanges();
                return new ResponseDto("Success", 0);
            }
            return new ResponseDto("Not found customer", 3, existingCustomer);
        }

        public int GetCount()
        {
            var result = _context.Customers.ToList().Count;
            return result;
        }
    }
}
