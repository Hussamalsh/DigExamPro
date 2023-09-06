using DigExamPro.Models;

namespace DigExamPro.Services;

public interface IUserService
{
    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    Task<ApplicationUser> GetUserByIdAsync(int id);
    //Task CreateStudentAsync(ApplicationUser student);
}

