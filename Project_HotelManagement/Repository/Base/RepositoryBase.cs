namespace Project_HotelManagement
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public List<T> Items { get; set; }

        public RepositoryBase()
        {
            Items = new List<T>();
        }

        public int Length()
        {
            return Items.Count();
        }

        public List<T> Gets()
        {
            return Items;
        }

        public T GetByIndex(int index)
        {
            return Items[index];
        }
    }
}
