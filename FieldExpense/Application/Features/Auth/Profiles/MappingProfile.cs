using Application.Features.Auth.Commands.Register;
using AutoMapper;


namespace Application.Features.Auth.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.User, RegisterCommand>().ReverseMap();
        }
    }
}
