using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_HotelManagement
{
    [PrimaryKey(nameof(booking_id))]
    public class Bookings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int booking_id { get; set; }

        [ForeignKey("customer_id")]
        public int? customer_id { get; set; }

        [ForeignKey("room_id")]
        public int? room_id { get; set;}
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public int quantity { get; set; }
        public DateTime create_at { get; set; }
    }
}
