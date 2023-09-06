namespace DigExamPro.Models;

public class Studentxxx
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Password { get; set; }  // Consider hashing this if it's stored in the database.
    public DateTime DateRegistered { get; set; }
    public bool IsActive { get; set; }

    // Computed property for full name
    public string FullName => $"{FirstName} {LastName}";

    // Additional properties, methods, or logic specific to a student can be added here.
}

