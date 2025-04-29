using Application.Features.BankTransactions.Commands.Create;
using Application.Features.BankTransactions.Commands.Delete;
using Application.Features.BankTransactions.Commands.Update;
using Application.Features.BankTransactions.Queries.GetById;
using Application.Features.BankTransactions.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.BankTransactions.Profiles
{
    public class BankTransactionMappingProfiles : Profile
    {
        public BankTransactionMappingProfiles()
        {

            CreateMap<CreateBankTransactionCommand, BankTransaction>();
            CreateMap<BankTransaction, CreateBankTransactionResponse>()
                .ForMember(dest => dest.TransactionStatus, opt => opt.MapFrom(src => src.TransactionStatus.ToString()));

            CreateMap<BankTransaction, DeleteBankTransactionResponse>()
           .ForMember(dest => dest.UserFullName,
                      opt => opt.MapFrom(src => src.ExpenseRequest.User.FirstName + " " + src.ExpenseRequest.User.LastName));
           

            //           .ForMember(dest => dest.ExpenseRequestDescription, opt => opt.MapFrom(src => src.ExpenseRequest.Description))

              CreateMap<BankTransaction, UpdateBankTransactionResponse>()
             .ForMember(dest => dest.TransactionStatus, opt => opt.MapFrom(src => src.TransactionStatus.ToString())).ReverseMap();
              CreateMap<UpdateBankTransactionCommand, BankTransaction>().ReverseMap();

            CreateMap<BankTransaction, GetByIdBankTransactionResponse>().ForMember(dest => dest.UserFullName,
                      opt => opt.MapFrom(src => src.ExpenseRequest.User.FirstName + " " + src.ExpenseRequest.User.LastName)).ReverseMap();
            CreateMap<BankTransaction, GetListBankTransactionResponse>().ReverseMap().ReverseMap();




        }
    }
 }

