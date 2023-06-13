using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Identity.Interfaces;

namespace ToNinetyOne.Identity.Operations.Queries.GetUserRoles;

public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, UserRolesViewModel>
{
    private readonly IToNinetyOneUserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserRolesQueryHandler(IToNinetyOneUserDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserRolesViewModel> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users
            .Where(u => request.UserIdList
                .Any(id => id == u.Id))
            .ProjectTo<UserRolesLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new UserRolesViewModel(users);
    }
}