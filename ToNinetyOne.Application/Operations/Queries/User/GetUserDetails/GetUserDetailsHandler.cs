using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUserDetails;

public class GetUserDetailsHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserDetailsHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserDetailsViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(Domain.LabWork), request.UserId);

        var entity = _mapper.Map<UserDetailsViewModel>(user);

        // TODO: add resent labs and more
        
        return entity;
    }
}