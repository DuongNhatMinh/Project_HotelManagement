using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_HotelManagement
{
    [PrimaryKey(nameof(room_id))]
    public class Rooms
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int room_id { get; set; }
        public string room_number { get; set; }
        public string type { get; set; }
        public decimal price { get; set; }
        public bool status { get; set; }
    }
}
