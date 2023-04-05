using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineList;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;

public class GetGroupListQueryHandler : IRequestHandler<GetGroupListQuery, GroupListViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetGroupListQueryHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GroupListViewModel> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
    {
        var groupQuery = await _dbContext.Groups
            .Select(g => g)
            .ProjectTo<GroupLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GroupListViewModel(groupQuery);
    }
}