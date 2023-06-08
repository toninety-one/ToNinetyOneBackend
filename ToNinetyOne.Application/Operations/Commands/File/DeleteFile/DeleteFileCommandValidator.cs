using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.File.DeleteFile;

public class DeleteFileCommandValidator : AbstractValidator<DeleteFileCommand>
{
    public DeleteFileCommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}
    
