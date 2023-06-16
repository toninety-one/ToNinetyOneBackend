using MediatR;

namespace ToNinetyOne.Identity.Operations.Queries.GetUserDetails;

public class GetUserDetailsQuery : IRequest<UserDetailsViewModel>
{
    public GetUserDetailsQuery()
    {
    }

    public GetUserDetailsQuery(Guid userId, Guid? selfId, string userRole)
    {
        UserId = userId;
        SelfId = selfId;
        UserRole = userRole;
    }

    public Guid? UserId { get; set; }
    public Guid? SelfId { get; set; }
    public string UserRole { get; set; }
}