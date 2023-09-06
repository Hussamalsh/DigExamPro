using Dapper;
using DigExamPro.Models;
using System.Data;
using System.Data.Common;

namespace DigExamPro.API.Repository;

public class ExamRepository : IExamRepository
{
    private readonly IDbConnection _db;

    public ExamRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Exam>> GetAllAsync()
    {
        const string query = "SELECT * FROM Exams";
        return await _db.QueryAsync<Exam>(query);
    }
    public async Task<Exam> GetByIdAsync(Guid id)
    {
        const string query = "SELECT * FROM Exams WHERE ExamID = @Id";
        return await _db.QueryFirstOrDefaultAsync<Exam>(query, new { Id = id });
    }

    public async Task<bool> CreateAsync(Exam exam)
    {
        const string sql = @"
            INSERT INTO [dbo].[Exams] (ExamID, Title, Description, DateTimeCreated, DateTimeUpdated, Duration)
            VALUES (@ExamID, @Title, @Description, @DateTimeCreated, @DateTimeUpdated, @Duration)";

        var rows = await _db.ExecuteAsync(sql, exam);
        return rows > 0;
    }

    public async Task<bool> UpdateAsync(Exam exam)
    {
        const string sql = @"
            UPDATE [dbo].[Exams]
            SET 
                Title = @Title, 
                Description = @Description,
                DateTimeUpdated = @DateTimeUpdated,
                Duration = @Duration
            WHERE ExamID = @ExamID";

        var rows = await _db.ExecuteAsync(sql, exam);
        return rows > 0;
    }
    public async Task<bool> DeleteAsync(Guid examId)
    {
        const string sql = "DELETE FROM [dbo].[Exams] WHERE ExamID = @ExamID";
        var rows = await _db.ExecuteAsync(sql, new { ExamID = examId });
        return rows > 0;
    }

}

