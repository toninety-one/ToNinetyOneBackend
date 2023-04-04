using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.Group.CreateGroup;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(command => command.Title).NotEmpty();
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}
    
