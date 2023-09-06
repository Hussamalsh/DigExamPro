using DigExamPro.Models;

namespace DigExamPro.Services;

public interface IExamService
{
    Task<IEnumerable<Exam>> GetAllExamsAsync();
    Task<Exam> GetExamByIdAsync(Guid id);
    Task CreateExamAsync(Exam exam);
    Task UpdateExamAsync(Exam exam);
    Task DeleteExamAsync(Guid id);
}

