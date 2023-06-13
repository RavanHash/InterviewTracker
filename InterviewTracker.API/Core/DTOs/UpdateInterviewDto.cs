namespace InterviewTracker.API.Core.DTOs;

public class UpdateInterviewDto
{
    public DateTime InterviewDate { get; set; }
    public string IntervieweeName { get; set; }
    public string InterviewerName { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public int IncorrectAnswers { get; set; }
}