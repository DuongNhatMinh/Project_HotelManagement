using Microsoft.AspNetCore.Mvc;

namespace Project_HotelManagement
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : Controller
    {
        private readonly ICustomersService _customersService;
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public APIController(ICustomersService customersService, IBookingService bookingService, IRoomService roomService)
        {
            _customersService = customersService;
            _bookingService = bookingService;
            _roomService = roomService;
        }

        //[HttpGet("Customers")]
        //public IActionResult GetAllCustomerFromDatabase()
        //{
        //    var result = _customersService.GetAllFromDatabase();
        //    return Ok(new ResponseDto("Success", 0, result));
        //}

        //Customers
        [HttpGet("Customer/{id}")]
        public IActionResult GetCustomerByIdFromDatabase(int id)
        {
            var customer = _customersService.GetByIdFromDatabase(id);
            if (customer == null)
            {
                return NotFound(new ResponseDto("Not Found User", 2));
            }
            return Ok(new ResponseDto("Success", 0, customer));
        }

        [HttpPost("Customers")]
        public IActionResult AddCustomerToDatabase([FromBody] AddCustomerRequest customer)
        {
            int newid = _customersService.GetCount();
            newid++;
            var newCustomer = new Customers
            {
                customer_id = newid,
                first_name = customer.fname,
                last_name = customer.lname,
                email = customer.email,
                phone_number = customer.phone,
                address = customer.address,
                created_at = DateTime.Now
            };
            var response = _customersService.AddToDatabase(newCustomer);
            if (response.StatusCode == 0)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("Customers/{id}")]
        public IActionResult UpdateCustomerToDatabase(int id, [FromBody] UpdateCustomerRequest updateCustomer)
        {
            var response = _customersService.UpdateCustomerFromDatabase(id, updateCustomer);
            if (response.StatusCode == 0)
            {
                return Ok(updateCustomer);
            }
            return NotFound(response);
        }
        
        //Bookings
        [HttpPost("Bookings")]
        public IActionResult AddBookingToDatabase([FromBody] AddBookingRequest booking)
        {
            int newid = _bookingService.GetCount();
            newid++;
            var newBooking = new Bookings
            {
                booking_id = newid,
                customer_id = booking.customer_id,
                room_id = booking.room_id,
                check_in_date = booking.check_in_date,
                check_out_date = booking.check_out_date,
                quantity = booking.quantity,
                create_at = DateTime.Now
            };
            var response = _bookingService.AddToDatabase(newBooking);
            if (response.StatusCode == 0)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("Bookings/{id}")]
        public IActionResult UpdateBookingToDatabase(int id, [FromBody] UpdateBookingRequest updateBooking)
        {
            var response = _bookingService.UpdateBookingFromDatabase(id, updateBooking);
            if (response.StatusCode == 0)
            {
                return Ok(updateBooking);
            }
            return NotFound(response);
        }

        [HttpDelete("Bookings/{id}")]
        public IActionResult DeleteBookingFromDatabase(int id)
        {
            var response = _bookingService.DeleteFromDatabase(id);
            if (response.StatusCode == 0)
                return Ok(response);
            return NotFound(response);
        }

        //Room
        [HttpPost("Rooms")]
        public IActionResult AddRoomToDatabase([FromBody] AddRoomRequest room)
        {
            int newid = _roomService.GetCount();
            newid++;
            var newRoom = new Rooms
            {
                room_id = newid,
                room_number = room.room_number,
                type = room.type,
                price = room.price,
                status = true
            };
            var response = _roomService.AddToDatabase(newRoom);
            if (response.StatusCode == 0)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("Rooms/{id}")]
        public IActionResult UpdateRoomToDatabase(int id, [FromBody] UpdateRoomRequest updateRoom)
        {
            var response = _roomService.UpdateRoomFromDatabase(id, updateRoom);
            if (response.StatusCode == 0)
            {
                return Ok(updateRoom);
            }
            return NotFound(response);
        }

        [HttpGet("Rooms")]
        public IActionResult GetAllRoomFromDatabase()
        {
            var result = _roomService.GetAllFromDatabase();
            return Ok(new ResponseDto("Success", 0, result));
        }
    }
}
