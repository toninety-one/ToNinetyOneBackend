using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUserList;

public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUsersListQueryHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UsersListViewModel> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var users = await _dbContext.Users
            .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new UsersListViewModel(users);
    }
}