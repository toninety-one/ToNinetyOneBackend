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
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var disciplineQuery = await _dbContext.Disciplines
            .Where(discipline => discipline.UserId == request.UserId || user.Role == Roles.Administrator ||
                                 discipline.Groups != null && discipline.Groups.Any(d =>
                                     user.UserGroup != null && d.Id == user.UserGroup.Id))
            .ProjectTo<DisciplineLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

        return new DisciplineListViewModel(disciplineQuery);
    }
}