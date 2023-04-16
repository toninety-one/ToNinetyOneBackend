using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineDetails;

public class GetDisciplineDetailsQuery : IRequest<DisciplineDetailsViewModel>
{
    public GetDisciplineDetailsQuery(Guid userId, Guid id, string userRole)
    {
        UserId = userId;
        Id = id;
        UserRole = userRole;
    }

    public Guid UserId { get; set; }
    public string UserRole { get; set; }
    public Guid Id { get; set; }
}