using MediatR;
using ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUsersList;

public class GetUsersListQuery : IRequest<UsersListViewModel>
{
    public GetUsersListQuery()
    {
    }

    public GetUsersListQuery(Guid userId, string userRole)
    {
        UserId = userId;
        UserRole = userRole;
    }

    public Guid UserId { get; set; }
    public string UserRole { get; set; }
}