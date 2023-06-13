using FluentValidation;

namespace ToNinetyOne.Identity.Operations.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}
    
