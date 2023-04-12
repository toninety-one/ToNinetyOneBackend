using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.UpdateSubmittedLab;

public class UpdateSubmittedLabCommandValidator : AbstractValidator<UpdateSubmittedLabCommand>
{
    public UpdateSubmittedLabCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}
    
