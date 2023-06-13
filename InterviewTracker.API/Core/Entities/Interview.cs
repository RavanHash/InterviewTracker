using System.ComponentModel.DataAnnotations;

namespace InterviewTracker.API.Core.Entities;

public class Interview
{
    [Key] public long Id { get; set; }
    public DateTime InterviewDate { get; set; }
    public string IntervieweeName { get; set; }
    public string InterviewerName { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public int IncorrectAnswers { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public string ConfidentialComment { get; set; } = "Normal";
}