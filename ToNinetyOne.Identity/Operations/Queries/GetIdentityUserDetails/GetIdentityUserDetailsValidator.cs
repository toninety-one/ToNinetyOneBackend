using FluentValidation;

namespace ToNinetyOne.Identity.Operations.Queries.GetIdentityUserDetails;

public class GetUserValidator : AbstractValidator<GetIdentityUserDetailsQuery>
{
    public GetUserValidator()
    {
        RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        RuleFor(query => query.SelfId).NotEqual(Guid.Empty);
        RuleFor(query => query.UserRole).NotEqual(string.Empty);
    }
}