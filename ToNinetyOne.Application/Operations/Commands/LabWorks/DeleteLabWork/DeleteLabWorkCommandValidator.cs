using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.LabWorks.DeleteLabWork;

public class DeleteLabWorkCommandValidator : AbstractValidator<DeleteLabWorkCommand>
{
    public DeleteLabWorkCommandValidator()
    {
        RuleFor(command => command.DisciplineId).NotEqual(Guid.Empty);
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
    }
}