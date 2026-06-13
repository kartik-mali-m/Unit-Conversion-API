using System.Net;
using System.Text.Json;
using UnitConversionAPI.Exceptions;
using UnitConversionAPI.Models.Response;
using UnitConversionAPI.Models.Responses;

namespace UnitConversionAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (InvalidUnitException ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.BadRequest,
                ex.Message);
        }
        catch (Exception)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.InternalServerError,
                "An unexpected error occurred.");
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        HttpStatusCode statusCode,
        string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new ErrorResponse
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        };

        var jsonResponse = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(jsonResponse);
    }
}