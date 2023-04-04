using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineList;

public class GetDisciplineListQuery : IRequest<DisciplineListViewModel>
{
    public Guid UserId { get; set; }

    public GetDisciplineListQuery(Guid userId)
    {
        UserId = userId;
    }
}