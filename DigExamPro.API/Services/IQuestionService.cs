using DigExamPro.Models;

namespace DigExamPro.API.Services;

public interface IQuestionService
{
    Task<IEnumerable<Question>> GetAllQuestionsAsync();
    Task<Question> GetQuestionByIdAsync(int id);
    Task<int> CreateQuestionAsync(Question question);
    Task<bool> UpdateQuestionAsync(Question question);
    Task<bool> DeleteQuestionAsync(int id);
    Task<IEnumerable<Question>> GetQuestionsByExamIdAsync(int examId);
}

