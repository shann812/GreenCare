using GreenCareApi.Domain.Exceptons;
using GreenCareApi.Presentation.Responses;

namespace GreenCareApi.Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(BusinessException bussinesEx)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(
                    ApiResponse.Fail(new ApiError
                    {
                        Code = 400,
                        Message = bussinesEx.Message
                    })
                );
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(
                    ApiResponse.Fail(new ApiError
                    {
                        Code = 500,
                        Message = "Enexpected error"
                    })
                );
            }
        }
    }
}
