

namespace DigExamPro.Models;
public class Option
{
    public Guid OptionID { get; set; }
    public Guid? QuestionID { get; set; }
    public string OptionText { get; set; }
    public bool? IsCorrect { get; set; }
}