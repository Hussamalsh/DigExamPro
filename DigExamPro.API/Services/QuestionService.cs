using DigExamPro.Models;
using DigExamPro.API.Repository;

namespace DigExamPro.API.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<IEnumerable<Question>> GetAllQuestionsAsync() => await _questionRepository.GetAllAsync();
    public async Task<Question> GetQuestionByIdAsync(int id) => await _questionRepository.GetByIdAsync(id);
    public async Task<int> CreateQuestionAsync(Question question) => await _questionRepository.CreateAsync(question);
    public async Task<bool> UpdateQuestionAsync(Question question) => await _questionRepository.UpdateAsync(question);
    public async Task<bool> DeleteQuestionAsync(int id) => await _questionRepository.DeleteAsync(id);
    public async Task<IEnumerable<Question>> GetQuestionsByExamIdAsync(int examId) => await _questionRepository.GetByExamIdAsync(examId);
}

