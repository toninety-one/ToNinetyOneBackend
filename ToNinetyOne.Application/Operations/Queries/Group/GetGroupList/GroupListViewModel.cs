namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;

public class GroupListViewModel
{
    public IList<GroupLookupDto> Groups { get; set; }

    public GroupListViewModel()
    {
    }

    public GroupListViewModel(IList<GroupLookupDto> groups) : base()
    {
        Groups = groups;
    }
}