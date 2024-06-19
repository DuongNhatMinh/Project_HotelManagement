using Microsoft.OpenApi.Writers;

namespace Project_HotelManagement
{
    public interface IPaymentService
    {
        List<Payments> GetAllFromDatabase();
        Payments GetByIdFromDatabase(int id);
        ResponseDto AddToDatabase(Payments payments);
        int GetCount();
    }
}
