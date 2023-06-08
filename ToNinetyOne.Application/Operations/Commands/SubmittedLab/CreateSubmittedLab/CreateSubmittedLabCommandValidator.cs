using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.CreateSubmittedLab;

public class CreateSubmittedLabCommandValidator : AbstractValidator<CreateSubmittedLabCommand>
{
    public CreateSubmittedLabCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.LabWorkId).NotEqual(Guid.Empty);
    }
}