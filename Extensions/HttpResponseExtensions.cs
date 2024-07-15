using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicRestAPI.Extensions;

public static class HttpResponseExtensions
{
    public static async Task WriteJsonErrorAsync(this HttpResponse response, int statusCode, string message)
    {
        
        response.StatusCode = statusCode;
        response.ContentType = "application/json";

        var errorResponse = new
        {
            StatusCode = statusCode,
            Message = message
        };

        var jsonResponse = JsonSerializer.Serialize(errorResponse);
        await response.WriteAsync(jsonResponse);
    }
}