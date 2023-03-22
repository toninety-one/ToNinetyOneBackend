using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Common.Exceptions;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkDetails;

public class GetLabWorkDetailsHandler : IRequestHandler<GetLabWorkDetailsQuery, LabWorkDetailsViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLabWorkDetailsHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<LabWorkDetailsViewModel> Handle(GetLabWorkDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.LabWorks
            .FirstOrDefaultAsync(labWork => labWork.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(LabWork), request.Id);
        }

        return _mapper.Map<LabWorkDetailsViewModel>(entity);
    }
}