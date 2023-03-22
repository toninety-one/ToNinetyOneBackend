using FluentValidation;

namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkDetails;

public class GetLabWorkDetailsQueryValidator : AbstractValidator<GetLabWorkDetailsQuery>
{
    public GetLabWorkDetailsQueryValidator()
    {
        RuleFor(labWork=> labWork.DisciplineId).NotEqual(Guid.Empty);
        RuleFor(labWork=> labWork.Id).NotEqual(Guid.Empty);
    }
}