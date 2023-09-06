using DigExamPro.Models;
using DigExamPro.API.Repository;

namespace DigExamPro.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository studentRepository)
    {
        _userRepository = studentRepository;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync() => await _userRepository.GetAllAsync();
    public async Task<ApplicationUser> GetUserByIdAsync(int id) => await _userRepository.GetByIdAsync(id);
    //public async Task<int> CreateUserAsync(ApplicationUser user) => await _userRepository.CreateAsync(user);
    public async Task<bool> UpdateUserAsync(ApplicationUser user) => await _userRepository.UpdateAsync(user);
    public async Task<bool> DeleteUserAsync(int id) => await _userRepository.DeleteAsync(id);
    public async Task<bool> VerifyUserPasswordAsync(string email, string passwordToVerify) => await _userRepository.VerifyPasswordAsync(email, passwordToVerify);
}

