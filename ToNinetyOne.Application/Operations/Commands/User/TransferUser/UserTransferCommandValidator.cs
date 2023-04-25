using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.User.TransferUser;

public class UserTransferCommandValidator : AbstractValidator<UserTransferCommand>
{
    public UserTransferCommandValidator()
    {
        RuleFor(command => command.RegisterId).NotEqual(Guid.Empty);
    }
}