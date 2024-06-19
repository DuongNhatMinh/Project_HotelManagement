using Microsoft.EntityFrameworkCore;

namespace Project_HotelManagement
{
    public class CustomersService : ICustomersService
    {
        private readonly RepositoryCustomers repositoryCustomers;
        public CustomersService(HotelManagementDbContext context)
        {
            repositoryCustomers = new RepositoryCustomers(context);
        }

        public List<Customers> GetAllFromDatabase()
        {
            return repositoryCustomers.GetAllFromDatabase();
        }

        public Customers GetByIdFromDatabase(int id)
        {
            return repositoryCustomers.GetByIdFromDatabase(id);
        }

        public ResponseDto AddToDatabase(Customers customer)
        {
           return repositoryCustomers.AddToDatabase(customer);
        }

        public ResponseDto DeleteFromDatabase(int id)
        {
            return repositoryCustomers.DeleteFromDatabase(id);
        }

        public ResponseDto UpdateCustomerFromDatabase(int id, UpdateCustomerRequest user)
        {
            return repositoryCustomers.UpdateCustomerFromDatabase(id, user);
        }

        public int GetCount()
        {
            return repositoryCustomers.GetCount();
        }
    }
}
