using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkList;

public class GetLabWorkListQuery : IRequest<LabWorkListViewModel>
{
    public Guid DisciplineId { get; set; }
}