using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;

public class GetLabWorkListQuery : IRequest<LabWorkListViewModel>
{
    public Guid? DisciplineId { get; set; }

    public GetLabWorkListQuery()
    {
    }

    public GetLabWorkListQuery(Guid? id)
    {
        DisciplineId = id;
    }
}