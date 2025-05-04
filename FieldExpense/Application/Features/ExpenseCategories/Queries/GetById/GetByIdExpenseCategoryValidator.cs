using Application.Features.ExpenseRequests.Queries.Common.GetById;
using FluentValidation;
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
