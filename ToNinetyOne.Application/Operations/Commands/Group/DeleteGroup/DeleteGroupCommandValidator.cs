using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.Group.DeleteGroup;

public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
{
    public DeleteGroupCommandValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
    }
}
    
