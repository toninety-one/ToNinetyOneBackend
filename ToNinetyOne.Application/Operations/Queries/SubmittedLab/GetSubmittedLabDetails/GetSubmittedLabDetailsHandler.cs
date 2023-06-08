using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.SubmittedLab.GetSubmittedLabDetails;

public class GetSubmittedLabDetailsHandler : IRequestHandler<GetSubmittedLabDetailsQuery, SubmittedLabDetailsViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetSubmittedLabDetailsHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<SubmittedLabDetailsViewModel> Handle(GetSubmittedLabDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity = await _dbContext.SubmittedLabs
            .Include(s => s.SelfUser)
            .Include(s => s.SelfLabWork)
            .FirstOrDefaultAsync(
                s => s.SelfLabWork.Id == request.Id && s.Id == request.SubmittedId &&
                     (s.SelfUser.Id == user.Id || request.UserRole != Roles.User), cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Domain.SubmittedLab), request.SubmittedId);
        
        var view = _mapper.Map<SubmittedLabDetailsViewModel>(entity);

        var files = await _dbContext.Files.Where(f => f.FileType == FileTypes.SubmittedLab && f.SelfId == entity.Id)
            .ToListAsync(cancellationToken);

        view.Files = files;

        return view;
    }
}