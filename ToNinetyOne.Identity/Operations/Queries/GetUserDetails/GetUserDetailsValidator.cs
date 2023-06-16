using FluentValidation;

namespace ToNinetyOne.Identity.Operations.Queries.GetUserDetails;

public class GetUserValidator : AbstractValidator<GetUserDetailsQuery>
{
    public GetUserValidator()
    {
        RuleFor(query => query.UserId).NotEqual(Guid.Empty);
        RuleFor(query => query.SelfId).NotEqual(Guid.Empty);
        RuleFor(query => query.UserRole).NotEqual(string.Empty);
    }
}