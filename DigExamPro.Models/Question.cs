using System.ComponentModel.DataAnnotations;

namespace DigExamPro.Models;

public class Question
{
    [Key]
    public Guid QuestionID { get; set; }

    public Guid ExamID { get; set; }

    [Required]
    public QuestionType QuestionType { get; set; }

    [Required]
    [MaxLength(4000)] // Assuming max length of a SQL NVARCHAR(MAX) field is 4000 for the ORM. Adjust if needed.
    public string QuestionText { get; set; }

    public int? Points { get; set; }

    public int? CorrectOptionIndex { get; set; }

    // Navigation properties if needed
     public Exam Exam { get; set; }
     public List<Option> Options { get; set; }
}