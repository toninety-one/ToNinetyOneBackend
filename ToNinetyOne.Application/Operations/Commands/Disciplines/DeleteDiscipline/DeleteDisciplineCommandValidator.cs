using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.Disciplines.DeleteDiscipline;

public class DeleteDisciplineCommandValidator : AbstractValidator<DeleteDisciplineCommand>
{
    public DeleteDisciplineCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
    }
}