using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.Users;

public class UserTransferCommandValidator : AbstractValidator<UserTransferCommand>
{
    public UserTransferCommandValidator()
    {
        RuleFor(command => command.RegisterId).NotEqual(Guid.Empty);
    }
}