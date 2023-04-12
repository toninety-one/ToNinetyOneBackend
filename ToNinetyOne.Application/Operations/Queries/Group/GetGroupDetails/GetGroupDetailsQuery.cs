using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupDetails;

public class GetGroupDetailsQuery : IRequest<GroupDetailsViewModel>
{
    public GetGroupDetailsQuery(Guid userId, Guid id)
    {
        UserId = userId;
        Id = id;
    }

    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}