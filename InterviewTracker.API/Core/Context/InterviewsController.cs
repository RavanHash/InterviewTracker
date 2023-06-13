using AutoMapper;
using InterviewTracker.API.Core.DTOs;
using InterviewTracker.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> CreateInterview([FromBody] CreateInterviewDto createInterviewDto)
    {
        var newInterview = new Interview();

        _mapper.Map(createInterviewDto, newInterview);

        await _context.Interviews.AddAsync(newInterview);
        await _context.SaveChangesAsync();

        return Ok("Interview saved successfully");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetInterviewDto>>> GetInterviews()
    {
        var tickets = await _context.Interviews.ToListAsync();

        var convertedTickets = _mapper.Map<IEnumerable<GetInterviewDto>>(tickets);

        return Ok(convertedTickets);
    }
}