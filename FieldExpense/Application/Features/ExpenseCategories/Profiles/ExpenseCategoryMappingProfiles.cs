using Application.Features.ExpenseCategories.Commands.Create;
using Application.Features.ExpenseCategories.Commands.Delete;
using Application.Features.ExpenseCategories.Commands.Update;
using Application.Features.ExpenseCategories.Queries.GetById;
using Application.Features.ExpenseCategories.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategories.Profiles
{
    public class ExpenseCategoryMappingProfiles : Profile
    {
        public ExpenseCategoryMappingProfiles()
        {
            CreateMap<ExpenseCategory, CreateExpenseCategoryCommand>().ReverseMap();
            CreateMap<ExpenseCategory,CreateExpenseCategoryResponse>().ReverseMap();

            CreateMap<ExpenseCategory, DeleteExpenseCategoryResponse>().ReverseMap();

            CreateMap<ExpenseCategory, UpdateExpenseCategoryCommand>().ReverseMap();
            CreateMap<ExpenseCategory, UpdateExpenseCategoryResponse>().ReverseMap();

            CreateMap<ExpenseCategory, GetListExpenseCategoryResponse>().ReverseMap();
            CreateMap<ExpenseCategory, GetByIdExpenseCategoryResponse>().ReverseMap();



        }
    }
}
