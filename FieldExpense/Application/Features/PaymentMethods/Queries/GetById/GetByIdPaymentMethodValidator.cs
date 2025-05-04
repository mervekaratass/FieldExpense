using Application.Features.ExpenseRequests.Queries.Common.GetById;
using FluentValidation;

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
