using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Identity.Interfaces;

namespace ToNinetyOne.Identity.Operations.Queries.GetIdentityUserDetails;

public class GetIdentityUserDetailsQueryHandler : IRequestHandler<GetIdentityUserDetailsQuery, IdentityUserDetailsViewModel>
{
    private readonly IToNinetyOneUserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetIdentityUserDetailsQueryHandler(IToNinetyOneUserDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IdentityUserDetailsViewModel> Handle(GetIdentityUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(
                u => u.Id == request.UserId &&
                     (request.UserId == request.SelfId || request.UserRole == Roles.Administrator), cancellationToken);

        if (user == null) throw new NotFoundException(nameof(Domain.User), (request.UserId ?? request.SelfId)!);

        return _mapper.Map<IdentityUserDetailsViewModel>(user);
    }
}