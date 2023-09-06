using DigExamPro.Models;

namespace DigExamPro.API.Repository;

public interface IExamRepository
{
    Task<IEnumerable<Exam>> GetAllAsync();
    Task<Exam> GetByIdAsync(Guid id);
    Task<bool> CreateAsync(Exam exam);
    Task<bool> UpdateAsync(Exam exam);
    Task<bool> DeleteAsync(Guid id);
}

