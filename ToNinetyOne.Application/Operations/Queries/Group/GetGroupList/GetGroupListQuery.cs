using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;

public class GetGroupListQuery : IRequest<GroupListViewModel>
{
    public GetGroupListQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}