using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Queries.GetById
{
    public class GetByIdExpenseCategoryQueryValidator : AbstractValidator<GetByIdExpenseRequestQuery>
    {
        public GetByIdExpenseCategoryQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Geçerli bir masraf kategorisi ID'si girilmelidir.");
        }
    }
}
