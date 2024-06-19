using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_HotelManagement
{
    [PrimaryKey(nameof(bookingservice_id))]
    public class Booking_Services
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookingservice_id { get; set; }

        [ForeignKey("booking_id")]
        public int? booking_id { get; set; }

        [ForeignKey("service_id")]
        public int? service_id { get; set; }
        public int quantity { get; set; }
    }
}
