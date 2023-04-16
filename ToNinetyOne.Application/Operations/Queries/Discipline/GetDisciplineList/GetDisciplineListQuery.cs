using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineList;

public class GetDisciplineListQuery : IRequest<DisciplineListViewModel>
{
    public GetDisciplineListQuery(Guid userId, string userRole)
    {
        UserId = userId;
        UserRole = userRole;
    }

    public Guid UserId { get; set; }
    public string UserRole { get; set; }
}