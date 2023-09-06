using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DigExamPro;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _jsRuntime;

    public JwtAuthenticationStateProvider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "jwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            // Decode the token and set up the ClaimsPrincipal.
            // This is a simplified example; in a real-world scenario, 
            // you'd want to validate the token's signature and handle token expiration.
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        } catch {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())); // Return anonymous user during pre-rendering.
        }
    }

    public void NotifyUserAuthentication(string token)
    {
        var authenticatedUser = CreateClaimsPrincipalFromToken(token);
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    private ClaimsPrincipal CreateClaimsPrincipalFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
        return new ClaimsPrincipal(identity);
    }
}
