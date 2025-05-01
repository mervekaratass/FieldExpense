using Application.Features.PaymentMethods.Commands.Delete;
using FluentValidation;

namespace Application.Features.User.Commands.Delete
{
 
        public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
        {
            public DeleteUserValidator()
            {
                RuleFor(x => x.Id)
                    .GreaterThan(0).WithMessage("Geçerli bir kullanıcı ID'si girilmelidir.").NotEmpty().WithMessage("Kullanıcı ID'si boş geçilemez");
            }
        }
    
}
