using InterviewTracker.API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewTracker.API.Core.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Interview> Interviews { get; set; }
}