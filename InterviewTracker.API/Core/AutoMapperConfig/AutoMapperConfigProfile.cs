using AutoMapper;
using InterviewTracker.API.Core.Context;
using InterviewTracker.API.Core.Entities;

namespace InterviewTracker.API.Core.AutoMapperConfig;

public class AutoMapperConfigProfile : Profile
{
    public AutoMapperConfigProfile()
    {
        CreateMap<CreateInterviewDto, Interview>();
    }
}