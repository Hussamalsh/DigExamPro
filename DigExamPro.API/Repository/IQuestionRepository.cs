using DigExamPro.Models;

namespace DigExamPro.API.Repository;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetAllAsync();
    Task<Question> GetByIdAsync(int id);
    Task<int> CreateAsync(Question question);
    Task<bool> UpdateAsync(Question question);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Question>> GetByExamIdAsync(int examId);
}

