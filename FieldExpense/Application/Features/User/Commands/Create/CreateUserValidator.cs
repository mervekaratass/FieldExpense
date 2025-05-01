using FluentValidation;

namespace Application.Features.User.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim alanı boş olamaz.")
                .MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim alanı boş olamaz.")
                .MaximumLength(100).WithMessage("Soyisim en fazla 100 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .MaximumLength(100).WithMessage("Telefon numarası en fazla 100 karakter olabilir.");

            RuleFor(x => x.IBAN)
                .NotEmpty().WithMessage("IBAN boş olamaz.")
                .Length(26, 34).WithMessage("IBAN 26 ile 34 karakter arasında olmalıdır.");

            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("Geçerli bir rol seçilmelidir.").NotEmpty().WithMessage("Rol ıd 'si boş olamaz");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz.")
                .MinimumLength(9).WithMessage("Şifre en az 9 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir.");

        }
    }
}
