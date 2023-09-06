using Dapper;
using DigExamPro.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace DigExamPro.API.CustomStores;

public class CustomRoleStore : IRoleStore<ApplicationRole>
{
    private readonly IDbConnection _connection;

    public CustomRoleStore(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));

        const string sql = "INSERT INTO Roles (RoleID, Name) VALUES (@Id, @Name)";
        var rows = await _connection.ExecuteAsync(sql, role);
        return rows > 0 ? IdentityResult.Success : IdentityResult.Failed();
    }

    public async Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));

        const string sql = "DELETE FROM Roles WHERE RoleID = @Id";
        var rows = await _connection.ExecuteAsync(sql, new { Id = role.Id });
        return rows > 0 ? IdentityResult.Success : IdentityResult.Failed();
    }

    public void Dispose() => _connection.Dispose();

    public async Task<ApplicationRole?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        const string sql = "SELECT * FROM Roles WHERE RoleID = @Id";
        return await _connection.QuerySingleOrDefaultAsync<ApplicationRole>(sql, new { Id = roleId });
    }

    public async Task<ApplicationRole?> FindByNameAsync(string RoleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        const string sql = "SELECT * FROM Roles WHERE Name = @Name";
        return await _connection.QuerySingleOrDefaultAsync<ApplicationRole>(sql, new { Name = RoleName });
    }

    public Task<string?> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(role?.Name);
    }

    public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(role?.Id.ToString());
    }

    public Task<string?> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(role?.Name);
    }

    public async Task SetNormalizedRoleNameAsync(ApplicationRole role, string? normalizedName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));

        //role.NormalizedName = normalizedName;
        await UpdateAsync(role, cancellationToken);
    }

    public async Task SetRoleNameAsync(ApplicationRole role, string? roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));

        role.Name = roleName;
        await UpdateAsync(role, cancellationToken);
    }

    public async Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role == null)
            throw new ArgumentNullException(nameof(role));

        const string sql = "UPDATE Roles SET Name = @Name WHERE RoleID = @Id";
        var rows = await _connection.ExecuteAsync(sql, role);
        return rows > 0 ? IdentityResult.Success : IdentityResult.Failed();
    }
}

