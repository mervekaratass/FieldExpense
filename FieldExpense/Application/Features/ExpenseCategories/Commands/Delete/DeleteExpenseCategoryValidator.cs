using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategories.Commands.Delete
{
    public class DeleteExpenseCategoryValidator : AbstractValidator<DeleteExpenseCategoryCommand>
    {
        public DeleteExpenseCategoryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir gider kategorisi ID'si girilmelidir.");
        }
    }
}
