using Application.Features.ExpenseRequests.Commands.Create;
using Application.Features.ExpenseRequests.Commands.Delete;
using Application.Features.ExpenseRequests.Commands.Update;
using Application.Features.ExpenseRequests.Queries.GetById;
using Application.Features.ExpenseRequests.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Profiles
{
    public class ExpenseRequestMappingProfiles : Profile
    {
        public ExpenseRequestMappingProfiles()
        {
          
            CreateMap<ExpenseRequest, CreateExpenseRequestResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();




            CreateMap<ExpenseRequest, DeleteExpenseRequestResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ReverseMap();


            CreateMap<ExpenseRequest, UpdateExpenseRequestResponse>()
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<UpdateExpenseRequestCommand, ExpenseRequest>();

            CreateMap<ExpenseRequest, GetByIdExpenseRequestResponse>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
            .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
            .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));


            CreateMap<ExpenseRequest, GetListExpenseRequestResponse>()
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
    .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
    .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name))
    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));



        }
    }
}
