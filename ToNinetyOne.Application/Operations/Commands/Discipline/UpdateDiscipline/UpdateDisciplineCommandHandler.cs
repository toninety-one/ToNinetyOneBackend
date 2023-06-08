using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.UpdateDiscipline;

public class UpdateDisciplineCommandHandler : IRequestHandler<UpdateDisciplineCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public UpdateDisciplineCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateDisciplineCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine(JsonSerializer.Serialize(request));
        var entity =
            await _dbContext.Disciplines
                .FirstOrDefaultAsync(
                    discipline => discipline.Id == request.Id &&
                                  (discipline.UserId == request.UserId || request.UserRole == Roles.Administrator),
                    cancellationToken);
        Console.WriteLine(JsonSerializer.Serialize(entity));
        if (entity == null)
            throw new NotFoundException(nameof(Domain.LabWork), request.Id);

        entity.Title = request.Title;
        entity.EditDate = DateTime.Now;
        entity.UserId = request.UserId;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}