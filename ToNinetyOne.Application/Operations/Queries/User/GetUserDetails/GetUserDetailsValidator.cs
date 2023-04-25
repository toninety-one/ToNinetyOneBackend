using FluentValidation;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUserDetails;

public class GetUserValidator : AbstractValidator<GetUserDetailsQuery>
{
    public GetUserValidator()
    {
        RuleFor(labWork => labWork.UserId).NotEqual(Guid.Empty);
    }
}