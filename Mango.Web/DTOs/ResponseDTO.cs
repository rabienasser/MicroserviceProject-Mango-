namespace Mango.Web.DTOs
{
    public class ResponseDTO<T>
    {
        public bool IsSuccess { get; set; } = true;
        public T? Result { get; set; }
        public string Message { get; set; } = "";
    }
}
