using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineList;
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
        
        var labWorkQuery = _dbContext.LabWorks
            .Include(l => l.SubmittedLabs)
            .Include(l=>l.SelfDiscipline.Groups)
            .ToList()
            .Where(lab =>
                request.UserRole == Roles.Administrator || lab.SelfDiscipline.UserId == request.UserId ||
                (lab.SelfDiscipline.Groups != null &&
                 lab.SelfDiscipline.Groups
                     .Any(g => g.Users != null && g.Users
                         .Any(u => u.Id == request.UserId))))
            .AsQueryable()
            .Include(l=>l.SelfDiscipline)
            .ProjectTo<LabWorkLookupDto>(_mapper.ConfigurationProvider)
            .ToList();
        
        foreach (var query in labWorkQuery)
        {
            var submitted = await _dbContext.SubmittedLabs
                .Include(l => l.SelfLabWork)
                .Include(l => l.SelfUser)
                .FirstOrDefaultAsync(l => l.SelfLabWork.Id == query.Id && l.SelfUser.Id == request.UserId,
                    cancellationToken);

            query.Mark = submitted?.Mark;
        }

        return new LabWorkListViewModel(labWorkQuery);
    }
}