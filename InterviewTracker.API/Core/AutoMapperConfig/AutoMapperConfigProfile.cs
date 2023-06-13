using AutoMapper;
using InterviewTracker.API.Core.DTOs;
using InterviewTracker.API.Core.Entities;

namespace InterviewTracker.API.Core.AutoMapperConfig;

public class AutoMapperConfigProfile : Profile
{
    public AutoMapperConfigProfile()
    {
        CreateMap<CreateInterviewDto, Interview>();
        CreateMap<Interview, GetInterviewDto>();
    }
}