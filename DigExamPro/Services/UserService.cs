using DigExamPro.Models;
using System.Text.Json;

namespace DigExamPro.Services;

public class UserService : IUserService
{
    private readonly HttpClient _http;

    public UserService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        => JsonSerializer.Deserialize<IEnumerable<ApplicationUser>>(await _http.GetStringAsync("/api/users"));

    public Task<ApplicationUser> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

}

