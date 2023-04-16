using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;

public class GetLabWorkListQuery : IRequest<LabWorkListViewModel>
{
    public GetLabWorkListQuery()
    {
    }

    public GetLabWorkListQuery(Guid userId, Guid? id, string userRole)
    {
        DisciplineId = id;
        UserId = userId;
        UserRole = userRole;
    }

    public Guid UserId { get; set; }
    public string UserRole { get; set; }
    public Guid? DisciplineId { get; set; }
}