using Microsoft.AspNetCore.Identity;

namespace DigExamPro.Models;

public class ApplicationUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    //public string PhoneNumber { get; set; }
    // Add any other necessary properties...
}

