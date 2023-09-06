using DigExamPro.Models;

namespace DigExamPro.API.Repository;

public interface IUserRepository
{
    Task<IEnumerable<ApplicationUser>> GetAllAsync();
    Task<ApplicationUser> GetByIdAsync(int id);
    //Task<int> CreateAsync(ApplicationUser user);
    Task<bool> UpdateAsync(ApplicationUser user);
    Task<bool> DeleteAsync(int id);
    Task<bool> VerifyPasswordAsync(string email, string passwordToVerify);
}
