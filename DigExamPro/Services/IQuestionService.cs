using DigExamPro.Models;

namespace DigExamPro.Services;

public interface IQuestionService
{
    Task<IEnumerable<Question>> GetAllQuestionsByExamIdAsync(Guid examId);
    Task<Question> GetQuestionByIdAsync(Guid id);
    Task CreateQuestionAsync(Question question);
    Task UpdateQuestionAsync(Question question);
    Task DeleteQuestionAsync(Guid id);
}

