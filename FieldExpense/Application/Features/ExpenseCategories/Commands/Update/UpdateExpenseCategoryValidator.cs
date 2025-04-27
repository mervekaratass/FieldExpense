using FluentValidation;


namespace Application.Features.ExpenseCategories.Commands.Update
{
    public class UpdateExpenseCategoryValidator : AbstractValidator<UpdateExpenseCategoryCommand>
    {
        public UpdateExpenseCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Masraf kategorisi ID'si boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir masraf kategorisi ID'si girilmelidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Masraf kategori adı boş olamaz.")
                .MinimumLength(2).WithMessage("Masraf kategori adı en az 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Masraf kategori adı en fazla 100 karakter olabilir."); ;
        }
    }
}
