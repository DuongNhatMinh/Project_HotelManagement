using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_HotelManagement
{
    [PrimaryKey(nameof(service_id))]
    public class Services
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int service_id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}
