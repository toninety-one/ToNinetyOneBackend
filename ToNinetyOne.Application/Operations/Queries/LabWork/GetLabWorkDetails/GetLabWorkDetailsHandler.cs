using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;

public class GetLabWorkDetailsHandler : IRequestHandler<GetLabWorkDetailsQuery, LabWorkDetailsViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLabWorkDetailsHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LabWorkDetailsViewModel> Handle(GetLabWorkDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity =
            await _dbContext.LabWorks.FirstOrDefaultAsync(labWork => labWork.Id == request.Id, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Domain.LabWork), request.Id);

        var view = _mapper.Map<LabWorkDetailsViewModel>(entity);

        var submittedLab = await _dbContext.SubmittedLabs
            .Include(s => s.SelfUser)
            .FirstOrDefaultAsync(s => s.SelfUser.Id == user.Id, cancellationToken);

        view.Mark = submittedLab?.Mark;

        var files = await _dbContext.Files.Where(f => f.FileType == FileTypes.LabWork && f.SelfId == entity.Id)
            .ToListAsync(cancellationToken);

        view.Files = files;

        if (entity.SubmittedLabs != null)
        {
            view.SubmittedLabs = _dbContext.SubmittedLabs
                .Include(s => s.SelfUser)
                .Include(s => s.SelfLabWork)
                .Where(s => (s.SelfUser.Id == request.UserId || s.SelfLabWork.SelfDiscipline.UserId == user.Id ||
                             request.UserRole == Roles.Administrator)&& s.SelfLabWork.Id == request.Id)
                .AsQueryable()
                .ProjectTo<SubmittedLabDetailsLookupDto>(_mapper.ConfigurationProvider);
        }

        return view;
    }
}