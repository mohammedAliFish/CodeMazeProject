
namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int statusCode { get; set; }
        public string? message { get; set; }

        public override string ToString()
        {
            return $"Status Code: {statusCode}, Message: {message}";
        }
    }
}
