using System.Text.Json;
using Microsoft.AspNetCore.Http;
using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Shared.Exceptions;

internal sealed class ExceptionsMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (PackItException exception)
        {
            context.Response.StatusCode = 400;
            context.Response.Headers.Add("content-type", "application/json");

            var errorCode = ToUnderscoreCase(exception.GetType().Name.Replace("Exception", string.Empty));
            var json = JsonSerializer.Serialize(new { ErrorCode = errorCode, exception.Message });
            await context.Response.WriteAsync(json);
        }
    }

    public static string ToUnderscoreCase(string value)
    {
        return string
            .Concat((value ?? string.Empty).Select((x, i) =>
                value != null && i > 0 && char.IsUpper(x) && !char.IsUpper(value[i - 1]) ? $"_{x}" : x.ToString()))
            .ToLower();
    }
}