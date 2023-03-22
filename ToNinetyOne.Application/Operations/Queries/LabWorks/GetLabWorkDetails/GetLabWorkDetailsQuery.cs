using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkDetails;

public class GetLabWorkDetailsQuery : IRequest<LabWorkDetailsViewModel>
{
    public Guid DisciplineId { get; set; }
    public Guid Id { get; set; }
}