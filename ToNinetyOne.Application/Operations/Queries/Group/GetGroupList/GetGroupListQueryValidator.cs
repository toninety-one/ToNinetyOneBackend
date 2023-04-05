using FluentValidation;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;

public class GetGroupListQueryValidator : AbstractValidator<GetGroupListQuery>
{
    public GetGroupListQueryValidator()
    {
        RuleFor(discipline => discipline.UserId).NotEqual(Guid.Empty);
    }
}