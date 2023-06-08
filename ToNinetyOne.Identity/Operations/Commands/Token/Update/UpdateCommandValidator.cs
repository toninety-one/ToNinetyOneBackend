using FluentValidation;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Update;

public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
{
    public UpdateCommandValidator()
    {
        RuleFor(command => command.RefreshToken).NotEmpty();
    }
}