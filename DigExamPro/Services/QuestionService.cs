using DigExamPro.Models;
using System.Text.Json;

namespace DigExamPro.Services;


public class QuestionService : IQuestionService
{
    private readonly HttpClient _http;

    public QuestionService(HttpClient http)
    {
        _http = http;
    }

    public Task CreateQuestionAsync(Question question)
    {
        throw new NotImplementedException();
    }

    public Task DeleteQuestionAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        => JsonSerializer.Deserialize<IEnumerable<Question>>(await _http.GetStringAsync("/api/questions"));

    public Task<IEnumerable<Question>> GetAllQuestionsByExamIdAsync(Guid examId)
    {
        throw new NotImplementedException();
    }

    public Task<Question> GetQuestionByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Question> GetQuestionByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateQuestionAsync(Question question)
    {
        throw new NotImplementedException();
    }

}
