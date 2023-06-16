using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Identity.Interfaces;

namespace ToNinetyOne.Identity.Operations.Queries.GetIdentityUserRoles;

public class GetIdentityUserRolesQueryHandler : IRequestHandler<GetIdentityUserRolesQuery, IdentityUserRolesViewModel>
{
    private readonly IToNinetyOneUserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetIdentityUserRolesQueryHandler(IToNinetyOneUserDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IdentityUserRolesViewModel> Handle(GetIdentityUserRolesQuery request, CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users
            .Where(u => request.UserIdList
                .Any(id => id == u.Id))
            .ProjectTo<IdentityUserRolesLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new IdentityUserRolesViewModel(users);
    }
}