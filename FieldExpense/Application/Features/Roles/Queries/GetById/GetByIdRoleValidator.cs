using Domain.Entities;
using FluentValidation;

namespace Application.Features.Roles.Queries.GetById
{ 
    public class GetByIdRoleValidator : AbstractValidator<Role>
    {
        public GetByIdRoleValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Geçerli bir rol ID'si girilmelidir.");
        }
    }
}
