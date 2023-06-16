using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Identity.Interfaces;

namespace ToNinetyOne.Identity.Operations.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsViewModel>
{
    private readonly IToNinetyOneUserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserDetailsQueryHandler(IToNinetyOneUserDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserDetailsViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(
                u => u.Id == request.UserId &&
                     (request.UserId == request.SelfId || request.UserRole == Roles.Administrator), cancellationToken);

        if (user == null) throw new NotFoundException(nameof(Domain.User), (request.UserId ?? request.SelfId)!);

        return _mapper.Map<UserDetailsViewModel>(user);
    }
}