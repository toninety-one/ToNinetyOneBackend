using System.Text.Json;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineList;

public class GetDisciplineListQueryHandler : IRequestHandler<GetDisciplineListQuery, DisciplineListViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDisciplineListQueryHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<DisciplineListViewModel> Handle(GetDisciplineListQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var disciplineQuery = _dbContext.Disciplines
            .Include(d => d.Groups)
            .ToList()
            .Where(discipline => discipline.UserId == request.UserId || request.UserRole == Roles.Administrator ||
                                                        (discipline.Groups != null && user.UserGroup != null &&
                                                         discipline.Groups
                                                             .Any(g => g.Id == user.UserGroup.Id)))
            .AsQueryable()
            .ProjectTo<DisciplineLookupDto>(_mapper.ConfigurationProvider)
            .ToList();

        return new DisciplineListViewModel(disciplineQuery);
    }
}