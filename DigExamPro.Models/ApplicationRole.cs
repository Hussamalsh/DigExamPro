using System.Security.Claims;

namespace DigExamPro.Models;

public class ApplicationRole
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    internal List<Claim> Claims { get; set; }
    public ApplicationRole() { }

    public ApplicationRole(string roleName)
    {
        Name = roleName;
    }
}