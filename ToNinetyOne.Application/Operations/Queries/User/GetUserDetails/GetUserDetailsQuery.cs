using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUserDetails;

public class GetUserDetailsQuery : IRequest<UserDetailsViewModel>
{
    public GetUserDetailsQuery()
    {
    }

    public GetUserDetailsQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}