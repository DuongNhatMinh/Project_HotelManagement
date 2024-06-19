namespace Project_HotelManagement
{
    public interface ICustomersService
    {
        List<Customers> GetAllFromDatabase();
        Customers GetByIdFromDatabase(int id);
        ResponseDto AddToDatabase(Customers customer);
        ResponseDto DeleteFromDatabase(int id);
        ResponseDto UpdateCustomerFromDatabase(int id, UpdateCustomerRequest customer);
        int GetCount();
    }
}
