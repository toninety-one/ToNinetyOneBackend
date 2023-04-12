namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;

public class LabWorkListViewModel
{
    public LabWorkListViewModel()
    {
        LabWorks = new List<LabWorkLookupDto>();
    }

    public LabWorkListViewModel(IList<LabWorkLookupDto> labWorks)
    {
        LabWorks = labWorks;
    }

    public IList<LabWorkLookupDto> LabWorks { get; set; }
}