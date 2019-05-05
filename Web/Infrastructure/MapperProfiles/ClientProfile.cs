using AutoMapper;
using Domain.Entities;
using Web.Models.ClientModels;

namespace Web.Infrastructure.MapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {       
            CreateMap<Client, ClientViewModel>();
        }
    }
}
