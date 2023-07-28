
using System.Net;
using System.Text.Json;
using ToDo.Api.Exceptions;

namespace ToDo.Api.Configuration
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Handle(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            var stackTrace = string.Empty;
            string message;

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(BadRequestException)) 
            {
                message = ex.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = ex.StackTrace;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                message = ex.Message;
                statusCode = HttpStatusCode.NotFound;
                stackTrace = ex.StackTrace;
            }
            else
            {
                message = ex.Message;
                statusCode = HttpStatusCode.InternalServerError;
                stackTrace = ex.StackTrace;
            }

            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
