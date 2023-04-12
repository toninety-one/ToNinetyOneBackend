using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.Group.SetUserGroup;

public class SetUserGroupCommandValidator : AbstractValidator<SetUserGroupCommand>
{
    public SetUserGroupCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.GroupId).NotEqual(Guid.Empty);
    }
}