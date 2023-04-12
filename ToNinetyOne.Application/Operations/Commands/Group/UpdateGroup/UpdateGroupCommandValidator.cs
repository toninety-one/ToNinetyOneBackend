using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.Group.UpdateGroup;

public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupCommandValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.Title).NotEmpty();
    }
}