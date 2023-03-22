using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.LabWorks.CreateLabWork;

public class CreateLabWorkCommandValidator : AbstractValidator<CreateLabWorkCommand>
{
    public CreateLabWorkCommandValidator()
    {
        RuleFor(command => command.Title).NotEmpty();
        RuleFor(command => command.DisciplineId).NotEqual(Guid.Empty);
    }
}