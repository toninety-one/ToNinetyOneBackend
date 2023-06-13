namespace ToNinetyOne.Application.Operations.Queries.User.GetUserList;

public class UsersListViewModel
{
    public UsersListViewModel()
    {
        Users = new List<UserLookupDto>();
    }

    public UsersListViewModel(IList<UserLookupDto> users)
    {
        Users = users;
    }

    public IList<UserLookupDto> Users { get; set; }
}