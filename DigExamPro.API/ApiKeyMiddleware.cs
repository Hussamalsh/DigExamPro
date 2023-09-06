namespace DigExamPro.API;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _apiKey;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _apiKey = config["ApiKey"];

    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("X-Api-Key", out var apiKey) || apiKey != _apiKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid API key");
            return;
        }

        await _next.Invoke(context);
    }
}