namespace Project_HotelManagement
{
    public class AddBookingRequest
    {
        public int customer_id { get; set; }
        public int room_id { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; private set; }
        public int quantity { get; set; }
    }
}
