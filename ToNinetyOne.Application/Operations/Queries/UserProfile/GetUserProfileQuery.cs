using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.UserProfile;

public class GetUserProfileQuery : IRequest<UserProfileViewModel>
{
    public GetUserProfileQuery()
    {
    }

    public GetUserProfileQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}