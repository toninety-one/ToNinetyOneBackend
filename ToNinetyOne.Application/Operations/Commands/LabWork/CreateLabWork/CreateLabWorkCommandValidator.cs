using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.CreateLabWork;

public class CreateLabWorkCommandValidator : AbstractValidator<CreateLabWorkCommand>
{
    public CreateLabWorkCommandValidator()
    {
        RuleFor(command => command.DisciplineId).NotEqual(Guid.Empty);
    }
}
    
