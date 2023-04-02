using FluentValidation;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Refresh;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(command => command.UserName).NotEmpty();
    }
}