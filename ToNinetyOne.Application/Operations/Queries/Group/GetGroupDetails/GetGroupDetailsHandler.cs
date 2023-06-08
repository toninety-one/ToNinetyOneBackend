using System.Text.Json;
using System.Text.Json.Nodes;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupDetails;

public class GetGroupDetailsHandler : IRequestHandler<GetGroupDetailsQuery, GroupDetailsViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetGroupDetailsHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GroupDetailsViewModel> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Groups
            .Include(g => g.Users)
            .Include(g => g.Disciplines)
            .FirstOrDefaultAsync(discipline => discipline.Id == request.Id, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Domain.Group), request.Id);
        
        return _mapper.Map<GroupDetailsViewModel>(entity);
    }
}