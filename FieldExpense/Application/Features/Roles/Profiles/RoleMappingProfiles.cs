using Application.Features.Roles.Commands.Create;
using Application.Features.Roles.Commands.Delete;
using Application.Features.Roles.Commands.Update;
using Application.Features.Roles.Queries.GetById;
using Application.Features.Roles.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Roles.Profiles
{
    public class RoleMappingProfiles:Profile
    {
        public RoleMappingProfiles()
        {

            CreateMap<Role, CreateRoleCommand>().ReverseMap();
            CreateMap<Role, CreateRoleResponse>().ReverseMap();

            CreateMap<Role, DeleteRoleResponse>().ReverseMap();

            CreateMap<UpdateRoleCommand, Role>().ReverseMap();
            CreateMap<Role, UpdateRoleResponse>().ReverseMap();

            CreateMap<Role, GetByIdRoleResponse>().ReverseMap();

            CreateMap<Role, GetListRoleResponse>().ReverseMap();
        }
      
    }
}
