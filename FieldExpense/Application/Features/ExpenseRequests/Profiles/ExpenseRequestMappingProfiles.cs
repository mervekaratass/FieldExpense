using Application.Features.ExpenseRequests.Commands.Admin.MarkAsPaid;
using Application.Features.ExpenseRequests.Commands.Common.Create;
using Application.Features.ExpenseRequests.Commands.Common.Delete;
using Application.Features.ExpenseRequests.Commands.Common.Update;
using Application.Features.ExpenseRequests.Commands.Decision.Approve.Application.Features.ExpenseRequests.Commands.Approve;
using Application.Features.ExpenseRequests.Commands.Decision.Reject.Application.Features.ExpenseRequests.Commands.Reject;
using Application.Features.ExpenseRequests.Commands.Employee.CreateForSelf;
using Application.Features.ExpenseRequests.Queries.Common.GetById;
using Application.Features.ExpenseRequests.Queries.Common.GetList;
using Application.Features.ExpenseRequests.Queries.Employee.GetFiltered;
using Application.Features.ExpenseRequests.Queries.Employee.GetMyList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ExpenseRequests.Profiles
{
    public class ExpenseRequestMappingProfiles : Profile
    {
        public ExpenseRequestMappingProfiles()
        {
          
            CreateMap<ExpenseRequest, CreateExpenseRequestResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
            CreateMap<ExpenseRequest, CreateExpenseRequestCommand>().ReverseMap();



            CreateMap<ExpenseRequest, DeleteExpenseRequestResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ReverseMap();


            CreateMap<ExpenseRequest, UpdateExpenseRequestResponse>()
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
            CreateMap<UpdateExpenseRequestCommand, ExpenseRequest>().ReverseMap();

            CreateMap<ExpenseRequest, GetByIdExpenseRequestResponse>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
            .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
            .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();


            CreateMap<ExpenseRequest, GetListExpenseRequestResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();

            //Approve
            CreateMap<ExpenseRequest, ApproveExpenseRequestResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name)).ReverseMap();

            //Reject
            CreateMap<ExpenseRequest, RejectExpenseRequestResponse>()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
               .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
               .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name)).ReverseMap();


            //GetMyList
            CreateMap<ExpenseRequest, GetMyListExpenseRequestResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();


            //MarkAsPaid
            CreateMap<BankTransaction, MarkAsPaidResponse>()
           .ForMember(dest => dest.TransactionStatus, opt => opt.MapFrom(src => src.TransactionStatus.ToString())).ReverseMap();

            //CreateMyExpenseRequest
            CreateMap<ExpenseRequest, CreateMyExpenseRequestResponse>()
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName)).ReverseMap();
            CreateMap<ExpenseRequest, CreateMyExpenseRequestCommand>().ReverseMap();



            CreateMap<ExpenseRequest, GetFilteredExpenseRequestResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        }
    }
}
