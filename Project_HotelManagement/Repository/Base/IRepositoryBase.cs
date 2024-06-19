namespace Project_HotelManagement
{
    public interface IRepositoryBase<T>
    {
        int Length();
        List<T> Gets();
        T GetByIndex(int index);
    }
}
