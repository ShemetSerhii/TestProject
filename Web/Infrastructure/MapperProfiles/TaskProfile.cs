using System;
using System.Globalization;
using AutoMapper;
using Domain.Entities;
using Web.Models.TaskModels;

namespace Web.Infrastructure.MapperProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<ClientTask, TaskViewModel>()
                .ForMember(task => task.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString(CultureInfo.InvariantCulture)))
                .ForMember(task => task.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString(CultureInfo.InvariantCulture)));

            CreateMap<TaskModel, ClientTask>()
                .ForMember(task => task.StartTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(task => task.EndTime, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(5)));
        }
    }
}
