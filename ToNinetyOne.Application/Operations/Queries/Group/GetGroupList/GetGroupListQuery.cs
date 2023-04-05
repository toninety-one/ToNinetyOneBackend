using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;

public class GetGroupListQuery : IRequest<GroupListViewModel>
{
    public Guid UserId { get; set; }

    public GetGroupListQuery(Guid userId)
    {
        UserId = userId;
    }
}