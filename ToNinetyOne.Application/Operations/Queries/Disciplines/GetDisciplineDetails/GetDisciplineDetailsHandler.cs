using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Common.Exceptions;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineDetails;

public class GetDisciplineDetailsHandler : IRequestHandler<GetDisciplineDetailsQuery, DisciplineDetailsViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDisciplineDetailsHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<DisciplineDetailsViewModel> Handle(GetDisciplineDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Disciplines
            .FirstOrDefaultAsync(discipline => discipline.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Discipline), request.Id);
        }

        return _mapper.Map<DisciplineDetailsViewModel>(entity);
    }
}