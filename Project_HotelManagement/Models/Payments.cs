using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_HotelManagement
{
    [PrimaryKey(nameof(payment_id))]
    public class Payments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int payment_id { get; set; }

        [ForeignKey("booking_id")]
        public int? booking_id { get; set; }
        public decimal price { get; set; }
        public DateTime payment_date { get; set; }
    }
}
