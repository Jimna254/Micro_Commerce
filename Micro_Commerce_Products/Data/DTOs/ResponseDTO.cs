namespace Micro_Commerce_Products.Data.DTOs
{
    public class ResponseDTO
    {
        public object? Result { get; set; }

        public bool? IsSuccess { get; set; } = true;

        public string Message { get; set; } = string.Empty;
    }
}
