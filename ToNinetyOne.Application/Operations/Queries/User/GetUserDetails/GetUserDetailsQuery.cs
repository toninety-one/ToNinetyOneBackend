using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUserDetails;

public class GetUserDetailsQuery : IRequest<UserDetailsViewModel>
{
    public GetUserDetailsQuery()
    {
    }

    public GetUserDetailsQuery(Guid userId, string userRole)
    {
        UserId = userId;
        UserRole = userRole;
    }

    public Guid UserId { get; set; }
    public string UserRole { get; set; }
}