using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;

public class GetLabWorkDetailsQuery : IRequest<LabWorkDetailsViewModel>
{
    public GetLabWorkDetailsQuery()
    {
    }

    public GetLabWorkDetailsQuery(Guid userId, Guid id)
    {
        UserId = userId;
        Id = id;
    }

    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}