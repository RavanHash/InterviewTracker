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

        return Ok("Interview Saved Successfully");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetInterviewDto>>> GetInterviews(string? q)
    {
        IQueryable<Interview> query = _context.Interviews;
        if (q is not null) query = query.Where(i => i.IntervieweeName.Contains(q));

        var interviews = await query.ToListAsync();
        var convertedInterviews = _mapper.Map<IEnumerable<GetInterviewDto>>(interviews);

        return Ok(convertedInterviews);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetInterviewDto>> GetInterviewById([FromRoute] long id)
    {
        var interview = await _context.Interviews.FirstOrDefaultAsync(i => i.Id == id);
        if (interview is null) return NotFound("Interview Not Found");

        var convertedInterview = _mapper.Map<GetInterviewDto>(interview);

        return Ok(convertedInterview);
    }

    [HttpPut]
    [Route("edit/{id}")]
    public async Task<IActionResult> EditInterview([FromRoute] long id,
        [FromBody] UpdateInterviewDto updateInterviewDto)
    {
        var interview = await _context.Interviews.FirstOrDefaultAsync(t => t.Id == id);
        if (interview is null) return NotFound("Interviews Not found");

        _mapper.Map(updateInterviewDto, interview);
        interview.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();

        return Ok("Interview Updated Successfully");
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteInterview([FromRoute] long id)
    {
        var interview = await _context.Interviews.FirstOrDefaultAsync(t => t.Id == id);
        if (interview is null) return NotFound("Interview Not found");

        _context.Interviews.Remove(interview);
        await _context.SaveChangesAsync();

        return Ok("Interview Deleted successfully");
    }
}