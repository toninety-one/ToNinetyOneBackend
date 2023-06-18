using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineDetails;

public class GetDisciplineDetailsHandler : IRequestHandler<GetDisciplineDetailsQuery, DisciplineDetailsViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDisciplineDetailsHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<DisciplineDetailsViewModel> Handle(GetDisciplineDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity = _dbContext.Disciplines
            .Include(d => d.Groups)
            .Include(d => d.LabWorks)
            .ToList()
            .FirstOrDefault(
                discipline => discipline.Groups != null &&
                              discipline.Id == request.Id &&
                              (discipline.UserId == request.UserId || request.UserRole == Roles.Administrator ||
                               discipline.Groups.Any(g => g.Id == user.GroupId)));

        if (entity == null) throw new NotFoundException(nameof(Domain.Discipline), request.Id);

        return _mapper.Map<DisciplineDetailsViewModel>(entity);
    }
}