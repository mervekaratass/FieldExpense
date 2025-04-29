using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Queries.GetById
{
    public class GetByIdPaymentMethodQueryValidator : AbstractValidator<GetByIdExpenseRequestQuery>
    {
        public GetByIdPaymentMethodQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Geçerli bir masraf ID'si girilmelidir.");
        }
    }
}
