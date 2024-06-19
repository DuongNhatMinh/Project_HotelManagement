namespace Project_HotelManagement
{
    public interface IServices
    {
        List<Services> GetAllFromDatabase();
        ResponseDto AddToDatabase(Services services);
        ResponseDto UpdateServicesFromDatabase(int id, UpdateServicesRequest service);
        int GetCount();
    }
}
