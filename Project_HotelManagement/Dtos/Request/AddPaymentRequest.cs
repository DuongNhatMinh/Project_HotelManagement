namespace Project_HotelManagement
{
    public class AddPaymentRequest
    {
        public int booking_id { get; set; }
        public decimal price { get; set; }
        public DateTime payment_date { get; set; }
    }
}
