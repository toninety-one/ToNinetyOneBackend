using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.DeleteSubmittedLab;

public class DeleteSubmittedLabCommandValidator : AbstractValidator<DeleteSubmittedLabCommand>
{
    public DeleteSubmittedLabCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}