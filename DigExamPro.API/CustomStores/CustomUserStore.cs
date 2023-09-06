using Dapper;
using DigExamPro.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace DigExamPro.API.CustomStores;

public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserEmailStore<ApplicationUser>, IUserRoleStore<ApplicationUser>
{
    private readonly IDbConnection _connection;

    public CustomUserStore(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        const string sql = "INSERT INTO Users (UserID, UserName, Email, PasswordHash) VALUES (@Id, @UserName, @Email, @PasswordHash)";
        var rows = await _connection.ExecuteAsync(sql, user);
        return rows > 0 ? IdentityResult.Success : IdentityResult.Failed();
    }

    public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        const string sql = "DELETE FROM Users WHERE UserID = @Id";
        var rows = await _connection.ExecuteAsync(sql, new { Id = user.Id });
        return rows > 0 ? IdentityResult.Success : IdentityResult.Failed();
    }

    public void Dispose() => _connection.Dispose();

    public async Task<ApplicationUser?> FindByEmailAsync(string Email, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        const string sql = "SELECT * FROM Users WHERE Email = @Email";
        return await _connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new { Email = Email });
    }

    public async Task<ApplicationUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        const string sql = "SELECT * FROM Users WHERE UserID = @Id";
        return await _connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new { Id = userId });
    }

    public async Task<ApplicationUser?> FindByNameAsync(string UserName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        const string sql = "SELECT * FROM Users WHERE UserName = @UserName";
        return await _connection.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new { UserName = UserName });
    }

    public Task<string?> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(user?.Email);
    }

    public Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        // Assuming a field 'EmailConfirmed' exists in ApplicationUser, else modify accordingly.
        return Task.FromResult(false);
    }

    public Task<string?> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(user.Email);
    }

    public Task<string?> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(user?.UserName);
    }

    public Task<string?> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(user?.PasswordHash);
    }

    public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(user?.Id.ToString());
    }

    public Task<string?> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(user?.UserName);
    }

    public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(!string.IsNullOrEmpty(user?.PasswordHash));
    }

    public async Task AddToRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        const string roleSql = "SELECT RoleID FROM Roles WHERE Name = @Name";
        var roleId = await _connection.QuerySingleOrDefaultAsync<Guid>(roleSql, new { Name = roleName.ToUpper() });

        if (roleId != null)
        {
            const string sql = "INSERT INTO UserRoles (UserID, RoleID) VALUES (@UserId, @RoleId)";
            await _connection.ExecuteAsync(sql, new { UserId = user.Id, RoleId = roleId });
        }
    }

    public async Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        const string sql = "SELECT r.Name FROM Roles r INNER JOIN UserRoles ur ON r.RoleID = ur.RoleID WHERE ur.UserID = @UserId";
        return (await _connection.QueryAsync<string>(sql, new { UserId = user.Id })).ToList();
    }

    public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        const string sql = "SELECT u.* FROM Users u INNER JOIN UserRoles ur ON u.UserID = ur.UserID INNER JOIN Roles r ON ur.RoleID = r.RoleID WHERE r.Name = @Name";
        return (await _connection.QueryAsync<ApplicationUser>(sql, new { NormalizedName = roleName.ToUpper() })).ToList();
    }

    public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        IList<string> roles = await GetRolesAsync(user, cancellationToken);
        return roles.Contains(roleName);
    }

    public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        const string roleSql = "SELECT RoleID FROM Roles WHERE Name = @Name";
        var roleId = await _connection.QuerySingleOrDefaultAsync<Guid>(roleSql, new { Name = roleName.ToUpper() });

        if (roleId != null)
        {
            const string sql = "DELETE FROM UserRoles WHERE UserID = @UserId AND RoleID = @RoleId";
            await _connection.ExecuteAsync(sql, new { UserId = user.Id, RoleId = roleId });
        }
    }


    public async Task SetEmailAsync(ApplicationUser user, string? email, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        user.Email = email;
        await UpdateAsync(user, cancellationToken);
    }

    public async Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        //user.EmailConfirmed = confirmed;
        await UpdateAsync(user, cancellationToken);
    }

    public async Task SetNormalizedEmailAsync(ApplicationUser user, string? normalizedEmail, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        //user.NormalizedEmail = normalizedEmail;
        await UpdateAsync(user, cancellationToken);
    }

    public async Task SetNormalizedUserNameAsync(ApplicationUser user, string? normalizedName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        //user.NormalizedUserName = normalizedName;
        await UpdateAsync(user, cancellationToken);
    }

    public async Task SetPasswordHashAsync(ApplicationUser user, string? passwordHash, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        user.PasswordHash = passwordHash;
        await UpdateAsync(user, cancellationToken);
    }

    public async Task SetUserNameAsync(ApplicationUser user, string? userName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        user.UserName = userName;
        await UpdateAsync(user, cancellationToken);
    }

    public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        const string sql = "UPDATE Users SET UserName = @UserName, Email = @Email, PasswordHash = @PasswordHash WHERE UserID = @Id";
        var rows = await _connection.ExecuteAsync(sql, user);
        return rows > 0 ? IdentityResult.Success : IdentityResult.Failed();
    }
}

