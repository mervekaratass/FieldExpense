using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Queries.GetById
{
    public class GetByIdExpenseRequestQueryValidator : AbstractValidator<GetByIdExpenseRequestQuery>
    {
        public GetByIdExpenseRequestQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Geçerli bir masraf ID'si girilmelidir.");
        }
    }
}
