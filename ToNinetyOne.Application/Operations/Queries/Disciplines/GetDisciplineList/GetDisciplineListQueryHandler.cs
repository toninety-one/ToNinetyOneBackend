using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;

namespace ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineList;

public class GetDisciplineListQueryHandler : IRequestHandler<GetDisciplineListQuery, DisciplineListViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDisciplineListQueryHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<DisciplineListViewModel> Handle(GetDisciplineListQuery request, CancellationToken cancellationToken)
    {
        var disciplineQuery = await _dbContext.Disciplines
            .Where(discipline => discipline.UserId == request.UserId)
            .ProjectTo<DisciplineLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        
        return new DisciplineListViewModel(disciplineQuery);
    }
}