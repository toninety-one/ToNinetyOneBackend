using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;

public class GetLabWorkDetailsQuery : IRequest<LabWorkDetailsViewModel>
{ 
    public Guid Id { get; set; }

    public GetLabWorkDetailsQuery()
    {
        
    }

    public GetLabWorkDetailsQuery(Guid id)
    {
        Id = id;
    }
}