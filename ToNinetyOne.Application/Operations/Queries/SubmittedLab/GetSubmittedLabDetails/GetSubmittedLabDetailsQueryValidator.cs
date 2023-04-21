using FluentValidation;

namespace ToNinetyOne.Application.Operations.Queries.SubmittedLab.GetSubmittedLabDetails;

public class GetSubmittedLabDetailsQueryValidator: AbstractValidator<GetSubmittedLabDetailsQuery>
{
    public GetSubmittedLabDetailsQueryValidator()
    {
        RuleFor(obj => obj.Id).NotEqual(Guid.Empty);
    }
}