using FluentValidation;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineDetails;

public class GetDisciplineDetailsQueryValidator : AbstractValidator<GetDisciplineDetailsQuery>
{
    public GetDisciplineDetailsQueryValidator()
    {
        RuleFor(discipline => discipline.UserId).NotEqual(Guid.Empty);
        RuleFor(discipline => discipline.Id).NotEqual(Guid.Empty);
    }
}