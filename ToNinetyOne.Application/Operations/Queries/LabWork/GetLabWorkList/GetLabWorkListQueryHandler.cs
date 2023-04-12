using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;

public class GetLabWorkListQueryHandler : IRequestHandler<GetLabWorkListQuery, LabWorkListViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLabWorkListQueryHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LabWorkListViewModel> Handle(GetLabWorkListQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var labWorkQuery = await _dbContext.LabWorks
            .Include(l => l.SelfDiscipline)
            .Where(labWork => labWork.SelfDiscipline.Id == request.DisciplineId || request.DisciplineId == null)
            .Where(labWork => labWork.SelfDiscipline.UserId == user.Id || user.Role == Roles.Administrator ||
                              (labWork.SelfDiscipline.Groups != null &&
                               labWork.SelfDiscipline.Groups.Any(
                                   g => user.UserGroup != null && g.Id == user.UserGroup.Id)))
            .ProjectTo<LabWorkLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

        foreach (var query in labWorkQuery)
        {
            var submitted = await _dbContext.SubmittedLabs
                .Include(l => l.SelfLabWork)
                .FirstOrDefaultAsync(l => l.SelfLabWork.Id == query.Id, cancellationToken);

            query.Mark = submitted?.Mark ?? "";
        }

        return new LabWorkListViewModel(labWorkQuery);
    }
}