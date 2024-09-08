using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using Waddabha.API.ResponseModels;
using Waddabha.BL.CustomExceptions;

namespace Waddabha.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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
            var code = HttpStatusCode.InternalServerError; // Default to 500 if unhandled
            var response = ApiResponse<string>.ErrorResponse(new List<string> { ex.Message });

            // Example: Handle specific exception types here
            if (ex is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
            if (ex is ArgumentException) code = HttpStatusCode.BadRequest;
            if (ex is RecordNotFoundException) code = HttpStatusCode.NotFound;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, serializerSettings));
        }
    }

}
