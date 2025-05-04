using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.UpdatePassword
{
    public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
    {
        public UpdatePasswordCommandValidator()
        {
            RuleFor(x => x.CurrentPassword).NotEmpty().MinimumLength(9);
            RuleFor(x => x.NewPassword)
                      .NotEmpty().WithMessage("Şifre boş olamaz.")
                      .MinimumLength(9).WithMessage("Şifre en az 9 karakter olmalıdır.")
                      .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                      .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                      .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
                      .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir.");
        }
    }
}
