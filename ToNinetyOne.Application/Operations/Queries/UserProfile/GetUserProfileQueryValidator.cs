using FluentValidation;

namespace ToNinetyOne.Application.Operations.Queries.UserProfile;

public class GetUserProfileQueryValidator : AbstractValidator<GetUserProfileQuery>
{
    public GetUserProfileQueryValidator()
    {
        RuleFor(labWork=> labWork.UserId).NotEqual(Guid.Empty);
    }
}