using MediatR;

namespace ToNinetyOne.Identity.Operations.Queries.GetUserRoles;

public class GetUserRolesQuery : IRequest<UserRolesViewModel>
{
    public GetUserRolesQuery()
    {
    }

    public GetUserRolesQuery(List<Guid> userIdList)
    {
        UserIdList = userIdList;
    }

    public List<Guid> UserIdList { get; set; }
}