using FluentValidation;

namespace ToNinetyOne.Identity.Operations.Commands.Registration;

public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
{
    public RegistrationCommandValidator()
    {
        RuleFor(command => command.UserName).NotEmpty();
        RuleFor(command => command.Password).NotEmpty();
    }
}