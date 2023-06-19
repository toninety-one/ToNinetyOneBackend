using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.MarkSubmittedLab;

public class MarkSubmittedLabCommandValidator : AbstractValidator<MarkSubmittedLabCommand>
{
    public MarkSubmittedLabCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.SubId).NotEqual(Guid.Empty);
    }
}