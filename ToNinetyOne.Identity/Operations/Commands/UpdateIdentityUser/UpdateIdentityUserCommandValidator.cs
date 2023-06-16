using FluentValidation;

namespace ToNinetyOne.Identity.Operations.Commands.UpdateIdentityUser;

public class UpdateIdentityUserCommandValidator : AbstractValidator<UpdateIdentityUserCommand>
{
    public UpdateIdentityUserCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}
    
