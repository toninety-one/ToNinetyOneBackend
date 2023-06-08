using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.SubmittedLab.GetSubmittedLabDetails;

public class GetSubmittedLabDetailsQuery : IRequest<SubmittedLabDetailsViewModel>
{
    public GetSubmittedLabDetailsQuery()
    {
    }

    public GetSubmittedLabDetailsQuery(Guid userId, Guid id, Guid submittedId, string userRole)
    {
        UserId = userId;
        Id = id;
        UserRole = userRole;
        SubmittedId = submittedId;
    }

    public Guid UserId { get; set; }
    public string UserRole { get; set; }
    public Guid Id { get; set; }
    public Guid SubmittedId { get; set; }
}