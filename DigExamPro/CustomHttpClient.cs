using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net;

namespace DigExamPro;

public class CustomHttpClient : HttpClient
{
    private readonly HttpClient _client;
    private readonly NavigationManager _navigationManager;
    private readonly IJSRuntime _jsRuntime;

    public CustomHttpClient(HttpClient client, NavigationManager navigationManager, IJSRuntime jsRuntime)
    {
        _client = client;
        _navigationManager = navigationManager;
        _jsRuntime = jsRuntime;
    }

    public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
    {
        var response = await _client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "jwtToken");
            _navigationManager.NavigateTo("/login", true);
        }
        return response;
    }

    // Override other methods as needed
}
