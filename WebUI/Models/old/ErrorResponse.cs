namespace WebUI.Models
{
    public class ErrorResponse
    {
        public List<string> Errors { get; set; } = new List<string>();
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
