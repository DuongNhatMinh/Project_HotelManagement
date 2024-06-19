namespace Project_HotelManagement
{
    public class ResponseDto
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

        public ResponseDto(string message, int statusCode, object data)
        {
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }

        public ResponseDto(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

    }
}
