namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;

public class GroupListViewModel
{
    public IList<GroupLookupDto> Groups { get; set; }

    public GroupListViewModel()
    {
        Groups = new List<GroupLookupDto>();
    }

    public GroupListViewModel(IList<GroupLookupDto> groups)
    {
        Groups = groups;
    }
}