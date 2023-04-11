using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.UpdateDiscipline;

public class UpdateDisciplineCommandValidator : AbstractValidator<UpdateDisciplineCommand>
{
    public UpdateDisciplineCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.Title).NotEmpty();
    }
}