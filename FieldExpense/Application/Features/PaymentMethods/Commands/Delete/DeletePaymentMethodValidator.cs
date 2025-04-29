using FluentValidation;


namespace Application.Features.PaymentMethods.Commands.Delete
{
    public class DeletePaymentMethodValidator : AbstractValidator<DeletePaymentMethodCommand>
    {
        public DeletePaymentMethodValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir ödeme yöntemi ID'si girilmelidir.");
        }
    }
}
