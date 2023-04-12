using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.DisciplineGroup.AddDisciplineGroup;

public class AddDisciplineGroupCommandValidator : AbstractValidator<AddDisciplineGroupCommand>
{
    public AddDisciplineGroupCommandValidator()
    {
        RuleFor(command => command.GroupId).NotEqual(Guid.Empty);
        RuleFor(command => command.DisciplineId).NotEqual(Guid.Empty);
    }
}