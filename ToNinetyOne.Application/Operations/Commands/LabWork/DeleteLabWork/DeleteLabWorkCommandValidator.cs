using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.DeleteLabWork;

public class DeleteLabWorkCommandValidator : AbstractValidator<DeleteLabWorkCommand>
{
    public DeleteLabWorkCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
    }
}