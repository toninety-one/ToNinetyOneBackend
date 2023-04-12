using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineList;

public class GetDisciplineListQuery : IRequest<DisciplineListViewModel>
{
    public GetDisciplineListQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}