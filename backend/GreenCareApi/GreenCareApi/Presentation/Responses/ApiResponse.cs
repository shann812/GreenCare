namespace GreenCareApi.Presentation.Responses
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public ApiError Error { get; set; }

        public static ApiResponse Fail(ApiError error)
        {
            return new ApiResponse
            {
                Success = false,
                Error = error
            };
        }

        public static ApiResponse Ok()
            => new ApiResponse { Success = true };
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
        public static ApiResponse Ok(T data)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data
            };
        }
    }
}
