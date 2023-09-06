using Dapper;
using DigExamPro.Models;
using System.Data;

namespace DigExamPro.API.Repository;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _db;

    public UserRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
    {
        const string query = "SELECT * FROM users";
        return await _db.QueryAsync<ApplicationUser>(query);
    }

    public async Task<ApplicationUser> GetByIdAsync(int id)
    {
        const string query = "SELECT * FROM Students WHERE UserID = @Id";
        return await _db.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Id = id });
    }

    /*
    public async Task<int> CreateAsync(ApplicationUser user)
    {
        // Hash the password before saving to the database
        student.Password = BCrypt.Net.BCrypt.HashPassword(ApplicationUser.Password);

        const string query = "INSERT INTO Students (Name, Email, Password /*, other properties*//*) VALUES (@Name, @Email, @Password /*, @OtherProperties*//*) OUTPUT INSERTED.Id;";
        /*return await _db.ExecuteScalarAsync<int>(query, student);
    }*/

    public async Task<bool> VerifyPasswordAsync(string email, string passwordToVerify)
    {
        const string query = "SELECT Password FROM Students WHERE Email = @Email";
        var hashedPassword = await _db.ExecuteScalarAsync<string>(query, new { Email = email });

        if (!string.IsNullOrEmpty(hashedPassword))
        {
            return BCrypt.Net.BCrypt.Verify(passwordToVerify, hashedPassword);
        }

        return false;
    }

    public async Task<bool> UpdateAsync(ApplicationUser student)
    {
        const string query = "UPDATE Students SET Name = @Name /*, OtherProperty = @OtherValue*/ WHERE Id = @Id";
        var affectedRows = await _db.ExecuteAsync(query, student);
        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string query = "DELETE FROM Students WHERE Id = @Id";
        var affectedRows = await _db.ExecuteAsync(query, new { Id = id });
        return affectedRows > 0;
    }
}

