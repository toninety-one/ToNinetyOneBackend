using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;

public class GetLabWorkDetailsQuery : IRequest<LabWorkDetailsViewModel>
{
    public GetLabWorkDetailsQuery()
    {
    }

    public GetLabWorkDetailsQuery(Guid userId, Guid id, string userRole)
    {
        UserId = userId;
        Id = id;
        UserRole = userRole;
    }

    public Guid UserId { get; set; }
    public string UserRole { get; set; }
    public Guid Id { get; set; }
}