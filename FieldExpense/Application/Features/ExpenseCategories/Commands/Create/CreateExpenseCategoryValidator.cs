
using FluentValidation;


namespace Application.Features.ExpenseCategories.Commands.Create
{
    public class CreateExpenseCategoryValidator : AbstractValidator<CreateExpenseCategoryCommand>
    {
        public CreateExpenseCategoryValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Kategori adı boş olamaz.")
               .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");
        }
    }
}
