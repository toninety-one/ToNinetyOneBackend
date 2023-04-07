namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkList;

public class LabWorkListViewModel
{
    public IList<LabWorkLookupDto> LabWorks { get; set; }

    public LabWorkListViewModel()
    {
    }

    public LabWorkListViewModel(IList<LabWorkLookupDto> labWorks)
    {
        LabWorks = labWorks;
    }
}