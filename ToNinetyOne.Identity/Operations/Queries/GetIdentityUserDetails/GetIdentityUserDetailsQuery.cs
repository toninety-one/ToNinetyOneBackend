using MediatR;

namespace ToNinetyOne.Identity.Operations.Queries.GetIdentityUserDetails;

public class GetIdentityUserDetailsQuery : IRequest<IdentityUserDetailsViewModel>
{
    public GetIdentityUserDetailsQuery()
    {
    }

    public GetIdentityUserDetailsQuery(Guid userId, Guid? selfId, string userRole)
    {
        UserId = userId;
        SelfId = selfId;
        UserRole = userRole;
    }

    public Guid? UserId { get; set; }
    public Guid? SelfId { get; set; }
    public string UserRole { get; set; }
}