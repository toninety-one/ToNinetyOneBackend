using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.LabWorks.UpdateLabWork;

public class UpdateLabWorkCommandValidator : AbstractValidator<UpdateLabWorkCommand>
{
    public UpdateLabWorkCommandValidator()
    {
        RuleFor(command => command.DisciplineId).NotEqual(Guid.Empty);
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.Title).NotEmpty();
    }
}