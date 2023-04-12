using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;

public class GetLabWorkDetailsHandler : IRequestHandler<GetLabWorkDetailsQuery, LabWorkDetailsViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLabWorkDetailsHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LabWorkDetailsViewModel> Handle(GetLabWorkDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.LabWorks
            .FirstOrDefaultAsync(labWork => labWork.Id == request.Id, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Domain.LabWork), request.Id);

        var submitted = await _dbContext.SubmittedLabs
            .Include(s => s.SelfLabWork)
            .Include(s => s.SelfUser)
            .FirstOrDefaultAsync(s => s.SelfLabWork.Id == request.Id && s.SelfUser.Id == request.UserId,
                cancellationToken);

        return _mapper.Map<LabWorkDetailsViewModel>(entity);
    }
}