namespace GreenCareApi.Presentation.Responses
{
    public class ApiError
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Details { get; set; }
    }
}
