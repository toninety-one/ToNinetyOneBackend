using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.DisciplineGroup.AddDisciplineGroup;

public class DeleteDisciplineGroupCommandValidator : AbstractValidator<DeleteDisciplineGroupCommand>
{
    public DeleteDisciplineGroupCommandValidator()
    {
        RuleFor(command => command.GroupId).NotEqual(Guid.Empty);
        RuleFor(command => command.DisciplineId).NotEqual(Guid.Empty);
    }
}