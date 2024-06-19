

namespace Project_HotelManagement
{
    public class PaymentService : IPaymentService
    {
        private readonly RepositoryPayment repositoryPayment;

        public PaymentService(HotelManagementDbContext context)
        {
            repositoryPayment = new RepositoryPayment(context);
        }

        public ResponseDto AddToDatabase(Payments payments)
        {
            return repositoryPayment.AddToDatabase(payments);
        }

        public List<Payments> GetAllFromDatabase()
        {
            return repositoryPayment.GetAllFromDatabase();
        }

        public Payments GetByIdFromDatabase(int id)
        {
            return repositoryPayment.GetByIdFromDatabase(id);
        }

        public int GetCount()
        {
            return repositoryPayment.GetCount();
        }
    }
}
