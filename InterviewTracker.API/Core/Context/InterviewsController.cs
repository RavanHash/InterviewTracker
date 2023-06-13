using AutoMapper;
using InterviewTracker.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTracker.API.Core.Context;

[Route("api/[controller]")]
[ApiController]
public class InterviewsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public InterviewsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTicket([FromBody] CreateInterviewDto createInterviewDto)
    {
        var newInterview = new Interview();

        _mapper.Map(createInterviewDto, newInterview);

        await _context.Interviews.AddAsync(newInterview);
        await _context.SaveChangesAsync();

        return Ok("Interview saved successfully");
    }
}