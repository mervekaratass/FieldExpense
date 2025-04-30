using Application.Features.User.Commands.Create;
using Application.Features.User.Commands.Delete;
using Application.Features.User.Commands.Update;
using Application.Features.User.Queries.GetById;
using Application.Features.User.Queries.GetList;
using AutoMapper;
namespace Application.Features.User.Profiles
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<CreateUserCommand, Domain.Entities.User>().ReverseMap();
            CreateMap<Domain.Entities.User, CreateUserResponse>().ReverseMap();

           
            CreateMap<Domain.Entities.User, UpdateUserResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();
            CreateMap<UpdateUserCommand, Domain.Entities.User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore()).ReverseMap();

            CreateMap<Domain.Entities.User, DeleteUserResponse>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<Domain.Entities.User, GetByIdUserResponse>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name)).ReverseMap();


            CreateMap<Domain.Entities.User, GetListUserResponse>()
           .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name)).ReverseMap();  
        }
    }
}
