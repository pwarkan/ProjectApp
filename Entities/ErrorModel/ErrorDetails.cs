using System.Text.Json;

namespace Entities.ErrorModel
{
    // модель для вывода ошибок с кодом и сообщением
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
