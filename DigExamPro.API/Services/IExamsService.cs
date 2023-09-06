using DigExamPro.Models;

namespace DigExamPro.API.Services;

public interface IExamsService
{
    Task<IEnumerable<Exam>> GetAllExamsAsync();
    Task<Exam> GetExamByIdAsync(Guid id);
    Task<bool> CreateExamAsync(Exam exam);
    Task<bool> UpdateExamAsync(Exam exam);
    Task<bool> DeleteExamAsync(Guid id);
    // Additional methods for grading, student progress tracking, etc. can be added here.
}
