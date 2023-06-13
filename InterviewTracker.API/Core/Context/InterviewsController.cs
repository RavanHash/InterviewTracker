using Microsoft.AspNetCore.Mvc;

namespace InterviewTracker.API.Core.Context;

[Route("InterviewTrackerAPI/[controller]")]
[ApiController]
public class InterviewsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public InterviewsController(ApplicationDbContext context)
    {
        _context = context;
    }
}