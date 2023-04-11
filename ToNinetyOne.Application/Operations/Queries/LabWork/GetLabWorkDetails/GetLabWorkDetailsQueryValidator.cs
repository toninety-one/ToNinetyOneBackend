using FluentValidation;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;

public class GetLabWorkDetailsQueryValidator : AbstractValidator<GetLabWorkDetailsQuery>
{
    public GetLabWorkDetailsQueryValidator()
    {
        RuleFor(labWork=> labWork.Id).NotEqual(Guid.Empty);
    }
}