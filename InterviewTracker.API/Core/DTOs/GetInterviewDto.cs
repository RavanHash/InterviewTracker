namespace InterviewTracker.API.Core.DTOs;

public class GetInterviewDto
{
    public long Id { get; set; }
    public DateTime InterviewDate { get; set; }
    public string IntervieweeName { get; set; }
    public string InterviewerName { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public int IncorrectAnswers { get; set; }
}