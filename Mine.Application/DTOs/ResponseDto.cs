namespace Mine.Application.DTOs
{
    public class ResponseDto<T>
    {
        public T data { get; set; }
        public string message { get; set; }
        public List<object> errors { get; set; }
        public bool success { get; set; }
    }
}
