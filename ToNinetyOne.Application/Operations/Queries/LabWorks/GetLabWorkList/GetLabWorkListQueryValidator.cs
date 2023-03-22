using FluentValidation;

namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkList;

public class GetLabWorkListQueryValidator : AbstractValidator<GetLabWorkListQuery>
{
    public GetLabWorkListQueryValidator()
    {
        RuleFor(labWork => labWork.DisciplineId).NotEqual(Guid.Empty);
    }
}