using FluentValidation;

namespace ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineList;

public class GetDisciplineListQueryValidator : AbstractValidator<GetDisciplineListQuery>
{
    public GetDisciplineListQueryValidator()
    {
        RuleFor(discipline => discipline.UserId).NotEqual(Guid.Empty);
    }
}