using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;

namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkList;

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
        var labWorkQuery = await _dbContext.LabWorks
            .Where(labWork => labWork.DisciplineId == request.DisciplineId)
            .ProjectTo<LabWorkLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

        return new LabWorkListViewModel(labWorkQuery);
    }
}