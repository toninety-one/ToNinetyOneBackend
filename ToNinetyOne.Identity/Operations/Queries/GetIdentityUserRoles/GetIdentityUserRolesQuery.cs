using MediatR;

namespace ToNinetyOne.Identity.Operations.Queries.GetIdentityUserRoles;

public class GetIdentityUserRolesQuery : IRequest<IdentityUserRolesViewModel>
{
    public GetIdentityUserRolesQuery()
    {
    }

    public GetIdentityUserRolesQuery(List<Guid> userIdList)
    {
        UserIdList = userIdList;
    }

    public List<Guid> UserIdList { get; set; }
}