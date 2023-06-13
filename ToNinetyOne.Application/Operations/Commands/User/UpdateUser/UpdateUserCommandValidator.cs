using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.User.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}
    
