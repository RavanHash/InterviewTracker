namespace InterviewTracker.API.Core.Context;

public class CreateInterviewDto
{
    public DateTime InterviewDate { get; set; }
    public string IntervieweeName { get; set; }
    public string InterviewerName { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public int IncorrectAnswers { get; set; }
}