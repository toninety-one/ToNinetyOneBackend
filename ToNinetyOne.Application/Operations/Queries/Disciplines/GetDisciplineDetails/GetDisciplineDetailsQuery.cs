using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineDetails;

public class GetDisciplineDetailsQuery : IRequest<DisciplineDetailsViewModel>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }

    public GetDisciplineDetailsQuery(Guid userId, Guid id)
    {
        UserId = UserId;
        Id = id;
    }
}