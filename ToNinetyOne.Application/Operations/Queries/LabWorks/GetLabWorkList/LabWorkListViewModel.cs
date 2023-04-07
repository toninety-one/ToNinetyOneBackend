namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkList;

public class LabWorkListViewModel
{
    public IList<LabWorkLookupDto> LabWorks { get; set; }

    public LabWorkListViewModel()
    {
        LabWorks = new List<LabWorkLookupDto>();
    }

    public LabWorkListViewModel(IList<LabWorkLookupDto> labWorks)
    {
        LabWorks = labWorks;
    }
}