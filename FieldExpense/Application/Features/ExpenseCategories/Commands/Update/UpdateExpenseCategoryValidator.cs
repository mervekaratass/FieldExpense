using FluentValidation;


namespace Application.Features.ExpenseCategories.Commands.Update
{
    public class UpdateExpenseCategoryValidator : AbstractValidator<UpdateExpenseCategoryCommand>
    {
        public UpdateExpenseCategoryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir gider kategorisi ID'si girilmelidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori ismi boş olamaz.")
                .MinimumLength(2).WithMessage("Kategori ismi en az 2 karakter olmalıdır.");
        }
    }
}
