using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;

public class GetLabWorkListQuery : IRequest<LabWorkListViewModel>
{
    public Guid UserId { get; set; }
    public Guid? DisciplineId { get; set; }

    public GetLabWorkListQuery()
    {
    }

    public GetLabWorkListQuery(Guid userId, Guid? id)
    {
        DisciplineId = id;
        UserId = userId;
    }
}