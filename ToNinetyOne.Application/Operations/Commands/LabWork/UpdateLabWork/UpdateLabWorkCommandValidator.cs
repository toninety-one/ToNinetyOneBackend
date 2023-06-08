using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.UpdateLabWork;

public class UpdateLabWorkCommandValidator : AbstractValidator<UpdateLabWorkCommand>
{
    public UpdateLabWorkCommandValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.Title).NotEmpty();
    }
}