using DigExamPro.Models;

namespace DigExamPro.API.Services;

public interface IUserService
{
    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    Task<ApplicationUser> GetUserByIdAsync(int id);
    //Task<int> CreateUserAsync(ApplicationUser user);
    Task<bool> UpdateUserAsync(ApplicationUser user);
    Task<bool> DeleteUserAsync(int id);
    Task<bool> VerifyUserPasswordAsync(string email, string passwordToVerify);
}
