using MediatR;
using ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;

namespace ToNinetyOne.Application.Operations.Queries.UserProfile;

public class GetUserProfileQuery : IRequest<UserProfileViewModel>
{ 
    public Guid UserId { get; set; }

    public GetUserProfileQuery()
    {
        
    }

    public GetUserProfileQuery(Guid userId)
    {
        UserId = userId;
    }
}