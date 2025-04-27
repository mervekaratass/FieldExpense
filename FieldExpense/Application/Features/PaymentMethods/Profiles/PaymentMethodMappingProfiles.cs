

using Application.Features.PaymentMethods.Commands.Create;
using Application.Features.PaymentMethods.Commands.Delete;
using Application.Features.PaymentMethods.Commands.Update;
using Application.Features.PaymentMethods.Queries.GetById;
using Application.Features.PaymentMethods.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.PaymentMethods.Profiles
{
    public class PaymentMethodMappingProfiles : Profile
    {
        public PaymentMethodMappingProfiles()
        {
            CreateMap<PaymentMethod,CreatePaymentMethodCommand>().ReverseMap();
            CreateMap<PaymentMethod,CreatePaymentMethodResponse>().ReverseMap();

            CreateMap<PaymentMethod,DeletePaymentMethodResponse>().ReverseMap();

            CreateMap<PaymentMethod,UpdatePaymentMethodCommand>().ReverseMap();
            CreateMap<PaymentMethod, UpdatePaymentMethodResponse>().ReverseMap();

            CreateMap<PaymentMethod, GetListPaymentMethodResponse>().ReverseMap();
            CreateMap<PaymentMethod,GetByIdPaymentMethodResponse>().ReverseMap();
        }
    }
}
