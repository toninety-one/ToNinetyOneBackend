using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineList;

public class GetDisciplineListQuery : IRequest<DisciplineListViewModel>
{
    public Guid UserId { get; set; }

    public GetDisciplineListQuery(Guid userId)
    {
        UserId = userId;
    }
}