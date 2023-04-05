using FluentValidation;
using ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupDetails;

public class GetGroupDetailsQueryValidator : AbstractValidator<GetGroupListQuery>
{
    public GetGroupDetailsQueryValidator()
    {
        RuleFor(group=> group.UserId).NotEqual(Guid.Empty);
    }
}