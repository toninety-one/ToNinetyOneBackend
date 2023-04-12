using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineDetails;

public class GetDisciplineDetailsQuery : IRequest<DisciplineDetailsViewModel>
{
    public GetDisciplineDetailsQuery(Guid userId, Guid id)
    {
        UserId = userId;
        Id = id;
    }

    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}