using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserDetailsQueryHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserDetailsViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(
                u => u.Id == request.UserId &&
                     (request.UserId == request.SelfId || request.UserRole == Roles.Administrator), cancellationToken);

        if (user == null) throw new NotFoundException(nameof(Domain.User), request.UserId ?? request.SelfId);

        var viewModel = _mapper.Map<UserDetailsViewModel>(user);

        var submittedLabs = _dbContext.SubmittedLabs
            // TODO: test this and if it doesnt work,
            // remove the user from the submitted lab    
            // .Include(s => s.SelfUser)
            .Where(s => s.SelfUser.Id == user.Id)
            .Take(10);

        viewModel.LastSubmittedLabs = submittedLabs;

        return viewModel;
    }
}