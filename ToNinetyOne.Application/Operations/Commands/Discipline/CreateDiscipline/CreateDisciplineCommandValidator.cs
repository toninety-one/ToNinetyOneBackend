using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.CreateDiscipline;

public class CreateDisciplineCommandValidator : AbstractValidator<CreateDisciplineCommand>
{
    public CreateDisciplineCommandValidator()
    {
        RuleFor(command => command.Title).NotEmpty();
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}