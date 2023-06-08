using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.File.CreateFile;

public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
{
    public CreateFileCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}
    
