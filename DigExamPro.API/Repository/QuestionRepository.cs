using Dapper;
using DigExamPro.Models;
using System.Data;

namespace DigExamPro.API.Repository;

public class QuestionRepository : IQuestionRepository
{
    private readonly IDbConnection _db;

    public QuestionRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        const string query = "SELECT * FROM Questions";
        return await _db.QueryAsync<Question>(query);
    }

    public async Task<Question> GetByIdAsync(int id)
    {
        const string query = "SELECT * FROM Questions WHERE Id = @Id";
        return await _db.QueryFirstOrDefaultAsync<Question>(query, new { Id = id });
    }

    public async Task<int> CreateAsync(Question question)
    {
        const string query = "INSERT INTO Questions (ExamId, Type, QuestionText, Options, CorrectOptionIndex) VALUES (@ExamId, @Type, @QuestionText, @Options, @CorrectOptionIndex) OUTPUT INSERTED.Id;";
        return await _db.ExecuteScalarAsync<int>(query, question);
    }

    public async Task<bool> UpdateAsync(Question question)
    {
        const string query = "UPDATE Questions SET Type = @Type, QuestionText = @QuestionText, Options = @Options, CorrectOptionIndex = @CorrectOptionIndex WHERE Id = @Id";
        var affectedRows = await _db.ExecuteAsync(query, question);
        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string query = "DELETE FROM Questions WHERE Id = @Id";
        var affectedRows = await _db.ExecuteAsync(query, new { Id = id });
        return affectedRows > 0;
    }

    public async Task<IEnumerable<Question>> GetByExamIdAsync(int examId)
    {
        const string query = "SELECT * FROM Questions WHERE ExamId = @ExamId";
        return await _db.QueryAsync<Question>(query, new { ExamId = examId });
    }
}

