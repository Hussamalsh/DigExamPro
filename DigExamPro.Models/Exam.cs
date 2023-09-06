using System.ComponentModel.DataAnnotations;

namespace DigExamPro.Models;

public class Exam
{
    public Guid ExamID { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "Title should be between 3 and 255 characters.")]
    public string Title { get; set; }
    [StringLength(1000, ErrorMessage = "Description should not exceed 1000 characters.")]
    public string Description { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime? DateTimeUpdated { get; set; }
    public Guid CreatedBy { get; set; } // Reference to the user who created the exam
    public int? Duration { get; set; }

    public List<Question> Questions { get; set; } = new List<Question>();
}


